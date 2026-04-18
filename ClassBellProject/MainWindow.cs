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

        SoundPlayer soundPlayerForATonePrimary = new SoundPlayer();
        SoundPlayer soundPlayerForAToneGymnasium = new SoundPlayer();

        public string[] GetAllTonesPrimary()
        {
            string[] names = Directory.GetCurrentDirectory().Split("\\");
            string namesComposed = string.Empty;
            foreach (string name in names)
            {
                if (!name.Contains("ClassBell"))
                {
                    namesComposed += name + "\\";
                }
                else
                {
                    namesComposed += name + "\\" + "Tones Primary";
                    break;
                }
            }
            string[] files = Directory.GetFiles(namesComposed);

            return files;
        }

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

        //public double GetNumberOfSecondsOfATone(string toneLength)
        //{
        //    FileInfo fileInfo = new FileInfo(toneLength);
        //    int audioSampleRate = 44100;
        //    int audioSampleSize = 16;
        //    int channels = 2;
        //    long file_size = fileInfo.Length;
        //    double duration = file_size / (audioSampleRate * (audioSampleSize / 8.0) * channels);

        //    return duration;
        //}

        public async Task StartAToneByPositionPrimaryAsync(int position)
        {
            string[] tonesPrimary = GetFilesFromFolder("Tones Primary");
            soundPlayerForATonePrimary.SoundLocation = tonesPrimary[position];
            soundPlayerForATonePrimary.Play();
        }

        public async Task StartAToneByPositionGymnasiumAsync(int position)
        {
            string[] tonesGymnasium = GetFilesFromFolder("Tones Gymnasium");
            soundPlayerForAToneGymnasium.SoundLocation = tonesGymnasium[position];
            soundPlayerForAToneGymnasium.Play();
        }

        private void buttonPrimary_Click(object sender, EventArgs e)
        {
            PrimaryMainWindow primaryMainWindow = new PrimaryMainWindow();
            if (!primaryMainWindow.Visible)
            {
                primaryMainWindow.Show();
                buttonPrimary.Enabled = false;
            }
            primaryMainWindow.FormClosed += delegate
            {
                buttonPrimary.Enabled = true;
            };
        }

        private void buttonGymnasium_Click(object sender, EventArgs e)
        {
            GymnasiumMainWindow gymnasiumMainWindow = new GymnasiumMainWindow();
            if (!gymnasiumMainWindow.Visible)
            {
                gymnasiumMainWindow.Show();
                buttonGymnasium.Enabled = false;
            }
            gymnasiumMainWindow.FormClosed += delegate
            {
                buttonGymnasium.Enabled = true;
            };
        }

        private async void buttonStartEntranceTonePrimary_Click(object sender, EventArgs e)
        {
            await StartAToneByPositionPrimaryAsync(0);
        }

        private async void buttonStartExitTonePrimary_Click(object sender, EventArgs e)
        {
            await StartAToneByPositionPrimaryAsync(1);
        }

        private async void buttonStartEntranceToneGymnasium_Click(object sender, EventArgs e)
        {
            await StartAToneByPositionGymnasiumAsync(0);
        }

        private async void buttonStartExitToneGymnasium_Click(object sender, EventArgs e)
        {
            await StartAToneByPositionGymnasiumAsync(1);
        }
    }
}
