using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPReceiver
{
    public partial class ReceiverForm : Form
    {
        private class PortListener
        {
            public int Port;
            public UdpClient? Client;
            public CancellationTokenSource? Cts;
            public bool IsListening;
            public int PacketCount;
            public DateTime? LastReceived;
        }

        private readonly List<PortListener> _listeners = new();
        private int _totalPackets = 0;
        private Font? _statusFont;

        public ReceiverForm()
        {
            InitializeComponent();
            this.Load += ReceiverForm_Load;
        }

        private void ReceiverForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridView();
            txtNewPort.Text = "7777";
            UpdateLocalIPLabel();
            UpdateStatusBar();
            LogMessage("UDP 수신기가 준비되었습니다. 포트를 추가하고 수신을 시작하세요.");

            txtNewPort.KeyDown += (s, ke) =>
            {
                if (ke.KeyCode == Keys.Enter)
                {
                    ke.SuppressKeyPress = true;
                    btnAddPort_Click(s!, ke);
                }
            };
        }

        private void SetupDataGridView()
        {
            _statusFont = new Font(dgvPorts.Font.FontFamily, 14f);

            dgvPorts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "상태", Width = 58, ReadOnly = true });
            dgvPorts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPort", HeaderText = "포트", Width = 64, ReadOnly = true });
            dgvPorts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPackets", HeaderText = "패킷수", Width = 65, ReadOnly = true });
            dgvPorts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLastRecv", HeaderText = "마지막 수신", Width = 112, ReadOnly = true });
            dgvPorts.Columns.Add(new DataGridViewButtonColumn { Name = "colToggle", HeaderText = "제어", Width = 60, UseColumnTextForButtonValue = false });

            dgvPorts.AllowUserToAddRows = false;
            dgvPorts.AllowUserToDeleteRows = false;
            dgvPorts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPorts.MultiSelect = false;
            dgvPorts.RowHeadersVisible = false;
            dgvPorts.BackgroundColor = SystemColors.Window;
            dgvPorts.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvPorts.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPorts.ColumnHeadersDefaultCellStyle.Font = new Font(dgvPorts.Font, FontStyle.Bold);
            dgvPorts.EnableHeadersVisualStyles = false;
            dgvPorts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 60);
            dgvPorts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvPorts.CellFormatting += DgvPorts_CellFormatting;
            dgvPorts.CellClick += DgvPorts_CellClick;
            dgvPorts.SelectionChanged += (s, e) =>
            {
                btnRemovePort.Enabled = dgvPorts.SelectedRows.Count > 0;
            };
        }

        private void DgvPorts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvPorts.Rows[e.RowIndex].Tag is not int port) return;
            var listener = _listeners.FirstOrDefault(l => l.Port == port);
            if (listener == null) return;

            if (e.ColumnIndex == dgvPorts.Columns["colToggle"]!.Index)
            {
                e.Value = listener.IsListening ? "중지" : "시작";
            }
        }

        private void ApplyStatusStyle(DataGridViewRow row, bool isListening)
        {
            var cell = row.Cells["colStatus"];
            cell.Style.Font = _statusFont;
            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cell.Style.ForeColor = isListening ? Color.LimeGreen : Color.Tomato;
            cell.Style.SelectionForeColor = isListening ? Color.LimeGreen : Color.Tomato;
        }

        private void DgvPorts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != dgvPorts.Columns["colToggle"]!.Index) return;
            if (dgvPorts.Rows[e.RowIndex].Tag is not int port) return;

            var listener = _listeners.FirstOrDefault(l => l.Port == port);
            if (listener == null) return;

            if (listener.IsListening)
                StopListener(listener);
            else
                StartListener(listener);
        }

        private void btnAddPort_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtNewPort.Text.Trim(), out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("올바른 포트 번호를 입력해주세요 (1-65535).", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_listeners.Any(l => l.Port == port))
            {
                MessageBox.Show($"포트 {port}는 이미 목록에 있습니다.", "중복", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var listener = new PortListener { Port = port };
            _listeners.Add(listener);

            var rowIndex = dgvPorts.Rows.Add("●", port, 0, "-", "시작");
            var newRow = dgvPorts.Rows[rowIndex];
            newRow.Tag = port;
            ApplyStatusStyle(newRow, isListening: false);

            UpdateStatusBar();
            LogMessage($"[포트 {port}] 목록에 추가됨 (수신 시작 버튼을 눌러주세요)");
        }

        private void btnRemovePort_Click(object sender, EventArgs e)
        {
            if (dgvPorts.SelectedRows.Count == 0) return;
            var row = dgvPorts.SelectedRows[0];
            if (row.Tag is not int port) return;

            var listener = _listeners.FirstOrDefault(l => l.Port == port);
            if (listener != null)
            {
                if (listener.IsListening) StopListener(listener);
                _listeners.Remove(listener);
            }

            dgvPorts.Rows.Remove(row);
            UpdateStatusBar();
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            foreach (var l in _listeners.Where(l => !l.IsListening).ToList())
                StartListener(l);
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            foreach (var l in _listeners.Where(l => l.IsListening).ToList())
                StopListener(l);
        }

        private void StartListener(PortListener listener)
        {
            try
            {
                listener.Client = new UdpClient(listener.Port);
                listener.Cts = new CancellationTokenSource();
                listener.IsListening = true;

                RefreshPortRow(listener);
                UpdateStatusBar();
                LogMessage($"[포트 {listener.Port}] 수신 시작됨");

                _ = ReceiveLoopAsync(listener);
            }
            catch (Exception ex)
            {
                listener.IsListening = false;
                listener.Client?.Close();
                listener.Client = null;
                RefreshPortRow(listener);
                LogMessage($"[포트 {listener.Port}] 시작 실패: {ex.Message}");
                MessageBox.Show($"포트 {listener.Port} 시작 실패:\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopListener(PortListener listener)
        {
            try
            {
                listener.Cts?.Cancel();
                listener.Client?.Close();
            }
            catch { }
            finally
            {
                listener.Client = null;
                listener.IsListening = false;
                RefreshPortRow(listener);
                UpdateStatusBar();
                LogMessage($"[포트 {listener.Port}] 수신 중지됨");
            }
        }

        private async Task ReceiveLoopAsync(PortListener listener)
        {
            try
            {
                while (listener.Cts != null && !listener.Cts.Token.IsCancellationRequested && listener.Client != null)
                {
                    var result = await listener.Client.ReceiveAsync(listener.Cts.Token);
                    var message = Encoding.UTF8.GetString(result.Buffer);
                    var dataSize = result.Buffer.Length;
                    var remoteEp = result.RemoteEndPoint;

                    if (!this.IsHandleCreated || this.IsDisposed) break;

                    Invoke(() =>
                    {
                        if (this.IsDisposed) return;

                        listener.PacketCount++;
                        listener.LastReceived = DateTime.Now;
                        _totalPackets++;

                        RefreshPortRow(listener);
                        FlashRow(listener.Port);
                        UpdateStatusBar();
                        LogMessage($"[:{listener.Port}] #{listener.PacketCount}  {remoteEp}  →  {dataSize}B");
                        LogMessage($"  {message}");
                    });
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!this.IsHandleCreated || this.IsDisposed) return;
                Invoke(() =>
                {
                    if (!this.IsDisposed)
                    {
                        listener.IsListening = false;
                        listener.Client = null;
                        RefreshPortRow(listener);
                        UpdateStatusBar();
                        LogMessage($"[포트 {listener.Port}] 오류로 중단됨: {ex.Message}");
                    }
                });
            }
        }

        private void RefreshPortRow(PortListener listener)
        {
            var idx = GetRowIndex(listener.Port);
            if (idx < 0) return;

            var row = dgvPorts.Rows[idx];
            row.Cells["colPackets"].Value = listener.PacketCount;
            row.Cells["colLastRecv"].Value = listener.LastReceived?.ToString("HH:mm:ss.fff") ?? "-";
            row.Cells["colToggle"].Value = listener.IsListening ? "중지" : "시작";
            ApplyStatusStyle(row, listener.IsListening);
        }

        private async void FlashRow(int port)
        {
            var idx = GetRowIndex(port);
            if (idx < 0) return;

            dgvPorts.Rows[idx].DefaultCellStyle.BackColor = Color.LightCyan;
            await Task.Delay(350);

            idx = GetRowIndex(port);
            if (idx >= 0 && idx < dgvPorts.Rows.Count)
            {
                dgvPorts.Rows[idx].DefaultCellStyle.BackColor = Color.Empty;
                dgvPorts.InvalidateRow(idx);
            }
        }

        private int GetRowIndex(int port)
        {
            for (int i = 0; i < dgvPorts.Rows.Count; i++)
                if (dgvPorts.Rows[i].Tag is int p && p == port) return i;
            return -1;
        }

        private void UpdateLocalIPLabel()
        {
            lblLocalIP.Text = $"로컬 IP: {GetLocalIPAddress()}";
        }

        private void UpdateStatusBar()
        {
            var active = _listeners.Count(l => l.IsListening);
            tsslPorts.Text = $"포트: {_listeners.Count}개";
            tsslActive.Text = $"활성: {active}개";
            tsslActive.ForeColor = active > 0 ? Color.LimeGreen : SystemColors.ControlText;
            tsslPackets.Text = $"전체 패킷: {_totalPackets:N0}";
        }

        private void btnClearLog_Click(object sender, EventArgs e) => txtLog.Clear();

        private void btnCopyIP_Click(object sender, EventArgs e)
        {
            var ip = GetLocalIPAddress();
            Clipboard.SetText(ip);
            LogMessage($"IP 복사됨: {ip}");
        }

        private void LogMessage(string message)
        {
            var ts = DateTime.Now.ToString("HH:mm:ss.fff");
            txtLog.AppendText($"[{ts}] {message}{Environment.NewLine}");
            txtLog.ScrollToCaret();
        }

        private string GetLocalIPAddress()
        {
            try
            {
                foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        return ip.ToString();
            }
            catch { }
            return "127.0.0.1";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (var l in _listeners.Where(l => l.IsListening).ToList())
                StopListener(l);
            _statusFont?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
