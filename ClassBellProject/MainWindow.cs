using ClassBellProject.Gymnasium;
using ClassBellProject.Primary;
using System.Media;

namespace ClassBellProject
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Playerele la nivel de clasă
        private readonly SoundPlayer soundPlayerForATonePrimary = new SoundPlayer();
        private readonly SoundPlayer soundPlayerForAToneGymnasium = new SoundPlayer();

        // Cache pentru fișiere (se încarcă la pornirea aplicației sau la nevoie)
        private string[] _cachedTonesPrimary;
        private string[] _cachedTonesGymnasium;

        // Alias-uri care folosesc metoda ta GetFilesFromFolder deja existentă
        public string[] GetAllTonesPrimary() => GetFilesFromFolder("Tones Primary");
        public string[] GetAllTonesGymnasium() => GetFilesFromFolder("Tones Gymnasium");

        private string[] GetFilesFromFolder(string folderName)
        {
            // Aceasta este calea FIXĂ a folderului unde este instalată aplicația
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Curățăm calea pentru a găsi folderul rădăcină "ClassBell"
            // Dacă după publish folderul "Tones Primary" este direct lângă .exe, 
            // nu mai avem nevoie de logica cu IndexOf("ClassBell")

            string rootPath = basePath;
            if (basePath.Contains("ClassBell"))
            {
                rootPath = basePath.Substring(0, basePath.IndexOf("ClassBell") + "ClassBell".Length);
            }

            // Construim calea finală
            string finalPath = Path.Combine(rootPath, folderName);

            if (!Directory.Exists(finalPath))
            {
                // Debug: Te ajută să vezi în consolă unde caută de fapt aplicația
                Console.WriteLine($"Eroare: Folderul nu a fost găsit la calea: {finalPath}");
                return Array.Empty<string>();
            }

            return Directory.GetFiles(finalPath);
        }

        public double GetNumberOfSecondsOfATone(string filePath)
        {
            if (!File.Exists(filePath)) return 0;

            FileInfo fileInfo = new FileInfo(filePath);
            const int audioSampleRate = 44100;
            const int audioSampleSize = 16;
            const int channels = 2;

            // Calculăm durata exactă (folosind 8.0 pentru a forța calculul double)
            double duration = fileInfo.Length / (audioSampleRate * (audioSampleSize / 8.0) * channels);

            return duration;
        }

        // Versiuni asincrone care folosesc cache-ul pentru viteză
        public async Task StartAToneByPositionPrimaryAsync(int position)
        {
            // Încărcăm cache-ul dacă e gol
            if (_cachedTonesPrimary == null) _cachedTonesPrimary = GetAllTonesPrimary();

            if (position < _cachedTonesPrimary.Length)
            {
                soundPlayerForATonePrimary.SoundLocation = _cachedTonesPrimary[position];
                soundPlayerForATonePrimary.Play();
            }
        }

        public async Task StartAToneByPositionGymnasiumAsync(int position)
        {
            if (_cachedTonesGymnasium == null) _cachedTonesGymnasium = GetAllTonesGymnasium();

            if (position < _cachedTonesGymnasium.Length)
            {
                soundPlayerForAToneGymnasium.SoundLocation = _cachedTonesGymnasium[position];
                soundPlayerForAToneGymnasium.Play();
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
