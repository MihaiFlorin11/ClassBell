using ClassBellProject.Gymnasium;
using ClassBellProject.Primary;
using NAudio.Wave;

namespace ClassBellProject
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // La nivel de clasă
        private WaveOutEvent _manualOutputDevice;
        private AudioFileReader _manualAudioFile;

        private string[] _cachedTonesPrimary;
        private string[] _cachedTonesGymnasium;

        // Alias-uri care folosesc metoda ta GetFilesFromFolder deja existentă
        public string[] GetAllTonesPrimary() => GetFilesFromFolder("Tones Primary");
        public string[] GetAllTonesGymnasium() => GetFilesFromFolder("Tones Gymnasium");

        private string[] GetFilesFromFolder(string folderName)
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            string finalPath = Path.Combine(currentPath, folderName);

            // Logică de siguranță pentru Debug (Visual Studio)
            if (!Directory.Exists(finalPath))
            {
                DirectoryInfo parent = Directory.GetParent(currentPath);
                while (parent != null)
                {
                    string checkPath = Path.Combine(parent.FullName, folderName);
                    if (Directory.Exists(checkPath)) { finalPath = checkPath; break; }
                    parent = parent.Parent;
                }
            }

            if (!Directory.Exists(finalPath)) return Array.Empty<string>();

            // Luăm doar WAV și MP3
            string[] extensions = { ".wav", ".mp3" };
            return Directory.GetFiles(finalPath)
                            .Where(file => extensions.Contains(Path.GetExtension(file).ToLower()))
                            .ToArray();
        }

        public async Task PlayToneAsync(string filePath)
        {
            if (!File.Exists(filePath)) return;

            try
            {
                // Oprim ce cânta anterior pe acest player manual
                _manualOutputDevice?.Stop();
                _manualAudioFile?.Dispose();
                _manualOutputDevice?.Dispose();

                _manualOutputDevice = new WaveOutEvent();
                _manualAudioFile = new AudioFileReader(filePath);

                _manualOutputDevice.Init(_manualAudioFile);
                _manualOutputDevice.Play();

                // Așteptăm să se termine tonul
                int durationMs = (int)_manualAudioFile.TotalTime.TotalMilliseconds;
                await Task.Delay(durationMs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare redare: {ex.Message}");
            }
            finally
            {
                // Curățăm resursele după ce s-a terminat Task.Delay
                _manualAudioFile?.Dispose();
                _manualOutputDevice?.Dispose();
                _manualAudioFile = null;
                _manualOutputDevice = null;
            }
        }

        public async Task StartAToneByPositionPrimaryAsync(int position)
        {
            if (_cachedTonesPrimary == null) _cachedTonesPrimary = GetFilesFromFolder("Tones Primary");

            if (position >= 0 && position < _cachedTonesPrimary.Length)
            {
                await PlayToneAsync(_cachedTonesPrimary[position]);
            }
        }

        public async Task StartAToneByPositionGymnasiumAsync(int position)
        {
            if (_cachedTonesGymnasium == null) _cachedTonesGymnasium = GetFilesFromFolder("Tones Gymnasium");

            if (position >= 0 && position < _cachedTonesGymnasium.Length)
            {
                await PlayToneAsync(_cachedTonesGymnasium[position]);
            }
        }

        private void buttonPrimary_Click(object sender, EventArgs e)
        {
            PrimaryMainWindow primaryMainWindow = new PrimaryMainWindow();
            buttonPrimary.Enabled = false;

            primaryMainWindow.FormClosed += (s, args) => buttonPrimary.Enabled = true;
            primaryMainWindow.Show();
        }

        private void buttonGymnasium_Click(object sender, EventArgs e)
        {
            GymnasiumMainWindow gymnasiumMainWindow = new GymnasiumMainWindow();
            buttonGymnasium.Enabled = false;

            gymnasiumMainWindow.FormClosed += (s, args) => buttonGymnasium.Enabled = true;
            gymnasiumMainWindow.Show();
        }

        private async void buttonStartEntranceTonePrimary_Click(object sender, EventArgs e)
            => await StartAToneByPositionPrimaryAsync(0);

        private async void buttonStartExitTonePrimary_Click(object sender, EventArgs e)
            => await StartAToneByPositionPrimaryAsync(1);

        private async void buttonStartEntranceToneGymnasium_Click(object sender, EventArgs e)
            => await StartAToneByPositionGymnasiumAsync(0);

        private async void buttonStartExitToneGymnasium_Click(object sender, EventArgs e)
            => await StartAToneByPositionGymnasiumAsync(1);
    }
}
