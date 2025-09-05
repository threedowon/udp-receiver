using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPReceiver
{
    public partial class ReceiverForm : Form
    {
        private UdpClient? udpServer;
        private bool isListening = false;
        private CancellationTokenSource? cancellationTokenSource;
        private int receivedCount = 0;
        private long totalBytes = 0;

        public ReceiverForm()
        {
            InitializeComponent();
            this.Load += ReceiverForm_Load;
        }

        private void ReceiverForm_Load(object? sender, EventArgs e)
        {
            // 기본 포트 설정
            txtPort.Text = "7777";
            LogMessage("UDP 수신기가 준비되었습니다.");
            
            // 폼 아이콘 설정 (선택사항)
            try
            {
                this.Icon = new Icon("udp_receiver.ico");
            }
            catch
            {
                // 아이콘 파일이 없으면 기본 아이콘 사용
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                StopListening();
            }
            else
            {
                StartListening();
            }
        }

        private void StartListening()
        {
            try
            {
                if (string.IsNullOrEmpty(txtPort.Text))
                {
                    MessageBox.Show("포트 번호를 입력해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
                {
                    MessageBox.Show("올바른 포트 번호를 입력해주세요 (1-65535).", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // UDP 서버 시작
                udpServer = new UdpClient(port);
                cancellationTokenSource = new CancellationTokenSource();

                isListening = true;
                btnStartStop.Text = "수신 중지";
                btnStartStop.BackColor = Color.LightCoral;
                txtPort.Enabled = false;

                LogMessage($"포트 {port}에서 UDP 수신을 시작했습니다.");
                LogMessage($"로컬 IP: {GetLocalIPAddress()}");

                // 비동기 수신 시작
                _ = StartReceivingAsync(cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                LogMessage($"UDP 서버 시작 실패: {ex.Message}");
                MessageBox.Show($"UDP 서버 시작에 실패했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopListening()
        {
            try
            {
                cancellationTokenSource?.Cancel();
                udpServer?.Close();
                udpServer = null;

                isListening = false;
                btnStartStop.Text = "수신 시작";
                btnStartStop.BackColor = SystemColors.Control;
                txtPort.Enabled = true;

                LogMessage("UDP 수신이 중지되었습니다.");
            }
            catch (Exception ex)
            {
                LogMessage($"UDP 서버 중지 실패: {ex.Message}");
            }
        }

        private async Task StartReceivingAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested && udpServer != null)
                {
                    var result = await udpServer.ReceiveAsync(cancellationToken);
                    var message = Encoding.UTF8.GetString(result.Buffer);
                    var remoteEndPoint = result.RemoteEndPoint;
                    var dataSize = result.Buffer.Length;

                    receivedCount++;
                    totalBytes += dataSize;

                    // UI 업데이트
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        Invoke(() =>
                        {
                            if (!this.IsDisposed)
                            {
                                UpdateStatistics();
                                LogMessage($"수신 #{receivedCount}: {remoteEndPoint} -> {dataSize} bytes");
                                LogMessage($"  데이터: {message}");
                                
                                // JSON 데이터인 경우 파싱 시도
                                TryParseAndDisplayJson(message);
                            }
                        });
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // 정상적인 취소
            }
            catch (Exception ex)
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    Invoke(() =>
                    {
                        if (!this.IsDisposed)
                        {
                            LogMessage($"수신 오류: {ex.Message}");
                        }
                    });
                }
            }
        }

        private void TryParseAndDisplayJson(string message)
        {
            try
            {
                if (message.Trim().StartsWith("{") && message.Trim().EndsWith("}"))
                {
                    var jsonData = System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(message);
                    var formattedJson = System.Text.Json.JsonSerializer.Serialize(jsonData, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                    
                    LogMessage($"  JSON 파싱 성공:");
                    foreach (var line in formattedJson.Split('\n'))
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            LogMessage($"    {line.Trim()}");
                        }
                    }
                }
            }
            catch
            {
                // JSON 파싱 실패 시 무시
            }
        }

        private void UpdateStatistics()
        {
            lblReceivedCount.Text = $"수신 패킷: {receivedCount:N0}";
            lblTotalBytes.Text = $"총 바이트: {totalBytes:N0}";
            lblAverageSize.Text = $"평균 크기: {(receivedCount > 0 ? totalBytes / receivedCount : 0):N0} bytes";
        }

        private string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch
            {
                // 무시
            }
            return "127.0.0.1";
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void btnClearStats_Click(object sender, EventArgs e)
        {
            receivedCount = 0;
            totalBytes = 0;
            UpdateStatistics();
            LogMessage("통계가 초기화되었습니다.");
        }

        private void LogMessage(string message)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
            txtLog.AppendText($"[{timestamp}] {message}{Environment.NewLine}");
            txtLog.ScrollToCaret();
        }

        private void btnCopyIP_Click(object sender, EventArgs e)
        {
            var localIP = GetLocalIPAddress();
            Clipboard.SetText(localIP);
            LogMessage($"로컬 IP 주소가 클립보드에 복사되었습니다: {localIP}");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopListening();
            base.OnFormClosing(e);
        }
    }
}
