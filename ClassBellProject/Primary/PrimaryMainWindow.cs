using ClassBellProject.Common;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Media;

namespace ClassBellProject.Primary
{
    public partial class PrimaryMainWindow : Form
    {
        public PrimaryMainWindow()
        {
            InitializeComponent();

            foreach (string format in formats)
            {
                comboBoxStartFormatInterval1.Items.Add(format);
                comboBoxStartFormatInterval2.Items.Add(format);
                comboBoxStartFormatInterval3.Items.Add(format);
                comboBoxStartFormatInterval4.Items.Add(format);
                comboBoxStartFormatInterval5.Items.Add(format);
                comboBoxStartFormatInterval6.Items.Add(format);
                comboBoxStartFormatInterval7.Items.Add(format);
                comboBoxStartFormatInterval8.Items.Add(format);
                comboBoxStartFormatInterval9.Items.Add(format);
                comboBoxStartFormatInterval10.Items.Add(format);
            }
            foreach (string format in formats)
            {
                comboBoxStopFormatInterval1.Items.Add(format);
                comboBoxStopFormatInterval2.Items.Add(format);
                comboBoxStopFormatInterval3.Items.Add(format);
                comboBoxStopFormatInterval4.Items.Add(format);
                comboBoxStopFormatInterval5.Items.Add(format);
                comboBoxStopFormatInterval6.Items.Add(format);
                comboBoxStopFormatInterval7.Items.Add(format);
                comboBoxStopFormatInterval8.Items.Add(format);
                comboBoxStopFormatInterval9.Items.Add(format);
                comboBoxStopFormatInterval10.Items.Add(format);
            }
            foreach (string hour in hours)
            {
                comboBoxStartHourInterval1.Items.Add(hour);
                comboBoxStartHourInterval2.Items.Add(hour);
                comboBoxStartHourInterval3.Items.Add(hour);
                comboBoxStartHourInterval4.Items.Add(hour);
                comboBoxStartHourInterval5.Items.Add(hour);
                comboBoxStartHourInterval6.Items.Add(hour);
                comboBoxStartHourInterval7.Items.Add(hour);
                comboBoxStartHourInterval8.Items.Add(hour);
                comboBoxStartHourInterval9.Items.Add(hour);
                comboBoxStartHourInterval10.Items.Add(hour);
            }
            foreach (string hour in hours)
            {
                comboBoxStopHourInterval1.Items.Add(hour);
                comboBoxStopHourInterval2.Items.Add(hour);
                comboBoxStopHourInterval3.Items.Add(hour);
                comboBoxStopHourInterval4.Items.Add(hour);
                comboBoxStopHourInterval5.Items.Add(hour);
                comboBoxStopHourInterval6.Items.Add(hour);
                comboBoxStopHourInterval7.Items.Add(hour);
                comboBoxStopHourInterval8.Items.Add(hour);
                comboBoxStopHourInterval9.Items.Add(hour);
                comboBoxStopHourInterval10.Items.Add(hour);
            }
            foreach (string minute in minutes)
            {
                comboBoxStartMinuteInterval1.Items.Add(minute);
                comboBoxStartMinuteInterval2.Items.Add(minute);
                comboBoxStartMinuteInterval3.Items.Add(minute);
                comboBoxStartMinuteInterval4.Items.Add(minute);
                comboBoxStartMinuteInterval5.Items.Add(minute);
                comboBoxStartMinuteInterval6.Items.Add(minute);
                comboBoxStartMinuteInterval7.Items.Add(minute);
                comboBoxStartMinuteInterval8.Items.Add(minute);
                comboBoxStartMinuteInterval9.Items.Add(minute);
                comboBoxStartMinuteInterval10.Items.Add(minute);
            }
            foreach (string minute in minutes)
            {
                comboBoxStopMinuteInterval1.Items.Add(minute);
                comboBoxStopMinuteInterval2.Items.Add(minute);
                comboBoxStopMinuteInterval3.Items.Add(minute);
                comboBoxStopMinuteInterval4.Items.Add(minute);
                comboBoxStopMinuteInterval5.Items.Add(minute);
                comboBoxStopMinuteInterval6.Items.Add(minute);
                comboBoxStopMinuteInterval7.Items.Add(minute);
                comboBoxStopMinuteInterval8.Items.Add(minute);
                comboBoxStopMinuteInterval9.Items.Add(minute);
                comboBoxStopMinuteInterval10.Items.Add(minute);
            }
        }

        private SoundPlayer soundPlayerForASongPrimary = new SoundPlayer();
        private SoundPlayer soundPlayerForATonePrimary = new SoundPlayer();

        private List<string> formats = new List<string>()
        {
            "AM",
            "PM"
        };

        private List<string> hours = new List<string>()
        {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"
        };

        private List<string> minutes = new List<string>()
        {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"
        };

        public List<string> GetDaysSelectedForPrimary()
        {
            // Dicționar pentru conversie rapidă
            var daysConversion = new Dictionary<string, string>
            {
                { "Luni", "Monday" },
                { "Marti", "Tuesday" },
                { "Miercuri", "Wednesday" },
                { "Joi", "Thursday" },
                { "Vineri", "Friday" },
                { "Sambata", "Saturday" },
                { "Duminica", "Sunday" }
            };

            // Luăm doar itemele care sunt bifate (CheckedItems)
            return checkedListBoxDaysPrimary.CheckedItems.Cast<string>()
                          .Where(day => daysConversion.ContainsKey(day))
                          .Select(day => daysConversion[day])
                          .ToList();
        }

        public string[] GetAllSongsPrimary() => GetFilesFromFolder("Songs Primary");

        public string[] GetAllTonesPrimary() => GetFilesFromFolder("Tones Primary");

        // Această variabilă trebuie să fie declarată în afara metodei, 
        // ca membru al clasei, pentru a-și păstra valoarea între apeluri.
        private DateTime _lastRunDatePrimary = DateTime.MinValue;

        public async Task StartSongsAndTonesPrimaryAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                DateTime now = DateTime.Now;
                string today = now.DayOfWeek.ToString();
                List<string> daysSelected = GetDaysSelectedForPrimary();

                if (daysSelected.Contains(today) && _lastRunDatePrimary.Date != now.Date)
                {
                    var intervals = GetIntervalsAndChecksFromDatabase(0, (int)now.DayOfWeek);

                    var lastInterval = intervals.Where(x => x.Start != "" && x.Stop != "").LastOrDefault();
                    DateTime lastTodayHour = lastInterval != null ? DateTime.Parse(lastInterval.Stop) : DateTime.MinValue;

                    if (now > lastTodayHour && intervals.Any())
                    {
                        _lastRunDatePrimary = now.Date;
                        await Task.Delay(TimeSpan.FromMinutes(30), token);
                        continue;
                    }

                    // --- AICI ESTE LOCUL CORECT PENTRU ÎNCĂRCAREA COLECȚIILOR ---
                    // Le încărcăm o singură dată pe zi, chiar înainte de a începe intervalele
                    string[] songs = GetAllSongsPrimary();
                    string[] tones = GetAllTonesPrimary();
                    int[] shuffleSongs = ShuffleAllSongsPrimary();
                    int songCursor = 0;
                    // ----------------------------------------------------------

                    foreach (var interval in intervals)
                    {
                        if (token.IsCancellationRequested) break;
                        if (string.IsNullOrEmpty(interval.Start) || string.IsNullOrEmpty(interval.Stop)) continue;

                        DateTime start = DateTime.Parse(interval.Start);
                        DateTime stop = DateTime.Parse(interval.Stop);

                        if (DateTime.Now > stop) continue; // Folosim DateTime.Now actualizat aici

                        // 1. AȘTEPTARE PÂNĂ LA START
                        while (DateTime.Now < start && !token.IsCancellationRequested)
                        {
                            await Task.Delay(500, token);
                        }

                        // 2. SONERIE IEȘIRE - Trimitem lista de tonuri deja încărcată
                        if (interval.ExitTone && !token.IsCancellationRequested)
                        {
                            await StartAToneByPositionPrimaryAsync(1, tones);
                        }

                        // 3. LOGICĂ MUZICĂ SAU CURS
                        if (interval.HoldCourse)
                        {
                            while (DateTime.Now < stop && !token.IsCancellationRequested)
                            {
                                await Task.Delay(1000, token);
                            }
                        }
                        else if (interval.HoldMusic)
                        {
                            while (DateTime.Now < stop && !token.IsCancellationRequested)
                            {
                                // Trimitem lista de melodii "songs" ca să nu le mai citească din nou de pe disc
                                await StartASongByPositionAndTimePrimaryAsync(shuffleSongs[songCursor], stop, songs);

                                songCursor = (songCursor + 1) % shuffleSongs.Length;
                            }
                        }

                        // 4. SONERIE INTRARE - Trimitem lista de tonuri
                        if (interval.EntranceTone && !token.IsCancellationRequested)
                        {
                            await StartAToneByPositionPrimaryAsync(0, tones);
                        }
                    }

                    _lastRunDatePrimary = DateTime.Today;
                }
                else
                {
                    await Task.Delay(TimeSpan.FromMinutes(30), token);
                }

                await Task.Delay(1000, token);
            }
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

        public decimal GetNumberOfSecondsOfASongPrimary(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            // 44100 Hz * 2 bytes (16-bit) * 2 channels = 176.400 bytes pe secundă
            const int bytesPerSecond = 44100 * 2 * 2;

            // Calculăm durata exactă
            decimal duration = (decimal)fileInfo.Length / bytesPerSecond;

            // Rotunjim în sus la cea mai apropiată secundă pentru siguranță
            return Math.Ceiling(duration);
        }

        public decimal GetNumberOfSecondsOfATonePrimary(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            // Parametrii standard pentru WAV (CD Quality)
            const int sampleRate = 44100;
            const int bytesPerSample = 2; // 16 bit / 8
            const int channels = 2;

            // Bytes per second = 44100 * 2 * 2 = 176,400 bytes/sec
            int bytesPerSecond = sampleRate * bytesPerSample * channels;

            decimal duration = (decimal)fileInfo.Length / bytesPerSecond;

            // Rotunjim în sus (Math.Ceiling) pentru a ne asigura că nu tăiem din finalul sunetului
            return Math.Ceiling(duration);
        }

        public async Task StartASongByPositionAndTimePrimaryAsync(int position, DateTime stopTime, string[] cachedSongs)
        {
            if (position >= cachedSongs.Length) return;

            string songPath = cachedSongs[position];
            soundPlayerForASongPrimary.SoundLocation = songPath;

            // Obținem durata și calculăm cât timp mai avem până la ora de Stop
            int durationMs = (int)(GetNumberOfSecondsOfASongPrimary(songPath) * 1000);
            int remainingTimeMs = (int)(stopTime - DateTime.Now).TotalMilliseconds;

            // Cântăm fie toată melodia, fie cât a mai rămas până la Stop (care e mai mică)
            int waitTime = Math.Min(durationMs, remainingTimeMs);

            if (waitTime > 0)
            {
                soundPlayerForASongPrimary.Play();
                await Task.Delay(waitTime);
                soundPlayerForASongPrimary.Stop(); // Oprirea explicită e mai sigură
            }
        }

        public async Task StartAToneByPositionPrimaryAsync(int position, string[] cachedTones)
        {
            if (position >= cachedTones.Length) return;

            string tonePath = cachedTones[position];
            soundPlayerForATonePrimary.SoundLocation = tonePath;

            int durationMs = (int)(GetNumberOfSecondsOfATonePrimary(tonePath) * 1000);

            soundPlayerForATonePrimary.Play();
            await Task.Delay(durationMs);
        }

        private Random rng = new Random();

        public int[] ShuffleAllSongsPrimary()
        {
            string[] songsPrimary = GetFilesFromFolder("Songs Primary");
            int[] songsPositions = Enumerable.Range(0, songsPrimary.Length).ToArray();
            int length = songsPrimary.Length;

            while (length > 1)
            {
                length--;

                int songPosition = rng.Next(length + 1);

                int value = songsPositions[songPosition];
                songsPositions[songPosition] = songsPositions[length];
                songsPositions[length] = value;
            }

            return songsPositions;
        }

        public void UpdateIntervalsAndChecksPrimaryForACertainDayInDatabase()
        {
            string dayChecked = string.Empty;

            using (var sqliteConnection = new SqliteConnection($"Data Source={GetDatabasePath()}"))
            {
                sqliteConnection.Open();
                SqliteCommand sqliteCommand;
                List<TimeInterval> timeInterval = new List<TimeInterval>();

                dayChecked = listBoxSelectDayPrimary.SelectedItem.ToString();
                switch (dayChecked)
                {
                    case "Luni":
                        if ((comboBoxStartHourInterval1.Text != "" && comboBoxStartMinuteInterval1.Text != "" && comboBoxStartFormatInterval1.Text != "") &&
                        (comboBoxStopHourInterval1.Text != "" && comboBoxStopMinuteInterval1.Text != "" && comboBoxStopFormatInterval1.Text != "") &&
                        (checkBoxExitTone1.Checked == false || checkBoxExitTone1.Checked == true) &&
                        (checkBoxEntranceTone1.Checked == false || checkBoxEntranceTone1.Checked == true) &&
                        (checkBoxHoldMusic1.Checked == false || checkBoxHoldMusic1.Checked == true) &&
                        (checkBoxHoldOn1.Checked == false || checkBoxHoldOn1.Checked == true) &&
                        (checkBoxHoldCourse1.Checked == false || checkBoxHoldCourse1.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 1,
                                Start = comboBoxStartHourInterval1.Text + ":" + comboBoxStartMinuteInterval1.Text + ":" + "00" + " " + comboBoxStartFormatInterval1.Text,
                                Stop = comboBoxStopHourInterval1.Text + ":" + comboBoxStopMinuteInterval1.Text + ":" + "00" + " " + comboBoxStopFormatInterval1.Text,
                                EntranceTone = checkBoxEntranceTone1.Checked,
                                ExitTone = checkBoxExitTone1.Checked,
                                HoldMusic = checkBoxHoldMusic1.Checked,
                                HoldOn = checkBoxHoldOn1.Checked,
                                HoldCourse = checkBoxHoldCourse1.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval2.Text != "" && comboBoxStartMinuteInterval2.Text != "" && comboBoxStartFormatInterval2.Text != "") &&
                            (comboBoxStopHourInterval2.Text != "" && comboBoxStopMinuteInterval2.Text != "" && comboBoxStopFormatInterval2.Text != "") &&
                            (checkBoxEntranceTone2.Checked == false || checkBoxEntranceTone2.Checked == true) &&
                            (checkBoxExitTone2.Checked == false || checkBoxExitTone2.Checked == true) &&
                            (checkBoxHoldMusic2.Checked == false || checkBoxHoldMusic2.Checked == true) &&
                            (checkBoxHoldOn2.Checked == false || checkBoxHoldOn2.Checked == true) &&
                            (checkBoxHoldCourse2.Checked == false || checkBoxHoldCourse2.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 2,
                                Start = comboBoxStartHourInterval2.Text + ":" + comboBoxStartMinuteInterval2.Text + ":" + "00" + " " + comboBoxStartFormatInterval2.Text,
                                Stop = comboBoxStopHourInterval2.Text + ":" + comboBoxStopMinuteInterval2.Text + ":" + "00" + " " + comboBoxStopFormatInterval2.Text,
                                EntranceTone = checkBoxEntranceTone2.Checked,
                                ExitTone = checkBoxExitTone2.Checked,
                                HoldMusic = checkBoxHoldMusic2.Checked,
                                HoldOn = checkBoxHoldOn2.Checked,
                                HoldCourse = checkBoxHoldCourse2.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval3.Text != "" && comboBoxStartMinuteInterval3.Text != "" && comboBoxStartFormatInterval3.Text != "") &&
                            (comboBoxStopHourInterval3.Text != "" && comboBoxStopMinuteInterval3.Text != "" && comboBoxStopFormatInterval3.Text != "") &&
                            (checkBoxEntranceTone3.Checked == false || checkBoxEntranceTone3.Checked == true) &&
                            (checkBoxExitTone3.Checked == false || checkBoxExitTone3.Checked == true) &&
                            (checkBoxHoldMusic3.Checked == false || checkBoxHoldMusic3.Checked == true) &&
                            (checkBoxHoldOn3.Checked == false || checkBoxHoldOn3.Checked == true) &&
                            (checkBoxHoldCourse3.Checked == false || checkBoxHoldCourse3.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 3,
                                Start = comboBoxStartHourInterval3.Text + ":" + comboBoxStartMinuteInterval3.Text + ":" + "00" + " " + comboBoxStartFormatInterval3.Text,
                                Stop = comboBoxStopHourInterval3.Text + ":" + comboBoxStopMinuteInterval3.Text + ":" + "00" + " " + comboBoxStopFormatInterval3.Text,
                                EntranceTone = checkBoxEntranceTone3.Checked,
                                ExitTone = checkBoxExitTone3.Checked,
                                HoldMusic = checkBoxHoldMusic3.Checked,
                                HoldOn = checkBoxHoldOn3.Checked,
                                HoldCourse = checkBoxHoldCourse3.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval4.Text != "" && comboBoxStartMinuteInterval4.Text != "" && comboBoxStartFormatInterval4.Text != "") &&
                            (comboBoxStopHourInterval4.Text != "" && comboBoxStopMinuteInterval4.Text != "" && comboBoxStopFormatInterval4.Text != "") &&
                            (checkBoxEntranceTone4.Checked == false || checkBoxEntranceTone4.Checked == true) &&
                            (checkBoxExitTone4.Checked == false || checkBoxExitTone4.Checked == true) &&
                            (checkBoxHoldMusic4.Checked == false || checkBoxHoldMusic4.Checked == true) &&
                            (checkBoxHoldOn4.Checked == false || checkBoxHoldOn4.Checked == true) &&
                            (checkBoxHoldCourse4.Checked == false || checkBoxHoldCourse4.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 4,
                                Start = comboBoxStartHourInterval4.Text + ":" + comboBoxStartMinuteInterval4.Text + ":" + "00" + " " + comboBoxStartFormatInterval4.Text,
                                Stop = comboBoxStopHourInterval4.Text + ":" + comboBoxStopMinuteInterval4.Text + ":" + "00" + " " + comboBoxStopFormatInterval4.Text,
                                EntranceTone = checkBoxEntranceTone4.Checked,
                                ExitTone = checkBoxExitTone4.Checked,
                                HoldMusic = checkBoxHoldMusic4.Checked,
                                HoldOn = checkBoxHoldOn4.Checked,
                                HoldCourse = checkBoxHoldCourse4.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval5.Text != "" && comboBoxStartMinuteInterval5.Text != "" && comboBoxStartFormatInterval5.Text != "") &&
                            (comboBoxStopHourInterval5.Text != "" && comboBoxStopMinuteInterval5.Text != "" && comboBoxStopFormatInterval5.Text != "") &&
                            (checkBoxEntranceTone5.Checked == false || checkBoxEntranceTone5.Checked == true) &&
                            (checkBoxExitTone5.Checked == false || checkBoxExitTone5.Checked == true) &&
                            (checkBoxHoldMusic5.Checked == false || checkBoxHoldMusic5.Checked == true) &&
                            (checkBoxHoldOn5.Checked == false || checkBoxHoldOn5.Checked == true) &&
                            (checkBoxHoldCourse5.Checked == false || checkBoxHoldCourse5.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 5,
                                Start = comboBoxStartHourInterval5.Text + ":" + comboBoxStartMinuteInterval5.Text + ":" + "00" + " " + comboBoxStartFormatInterval5.Text,
                                Stop = comboBoxStopHourInterval5.Text + ":" + comboBoxStopMinuteInterval5.Text + ":" + "00" + " " + comboBoxStopFormatInterval5.Text,
                                EntranceTone = checkBoxEntranceTone5.Checked,
                                ExitTone = checkBoxExitTone5.Checked,
                                HoldMusic = checkBoxHoldMusic5.Checked,
                                HoldOn = checkBoxHoldOn5.Checked,
                                HoldCourse = checkBoxHoldCourse5.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval6.Text != "" && comboBoxStartMinuteInterval6.Text != "" && comboBoxStartFormatInterval6.Text != "") &&
                            (comboBoxStopHourInterval6.Text != "" && comboBoxStopMinuteInterval6.Text != "" && comboBoxStopFormatInterval6.Text != "") &&
                            (checkBoxEntranceTone6.Checked == false || checkBoxEntranceTone6.Checked == true) &&
                            (checkBoxExitTone6.Checked == false || checkBoxExitTone6.Checked == true) &&
                            (checkBoxHoldMusic6.Checked == false || checkBoxHoldMusic6.Checked == true) &&
                            (checkBoxHoldOn6.Checked == false || checkBoxHoldOn6.Checked == true) &&
                            (checkBoxHoldCourse6.Checked == false || checkBoxHoldCourse6.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 6,
                                Start = comboBoxStartHourInterval6.Text + ":" + comboBoxStartMinuteInterval6.Text + ":" + "00" + " " + comboBoxStartFormatInterval6.Text,
                                Stop = comboBoxStopHourInterval6.Text + ":" + comboBoxStopMinuteInterval6.Text + ":" + "00" + " " + comboBoxStopFormatInterval6.Text,
                                EntranceTone = checkBoxEntranceTone6.Checked,
                                ExitTone = checkBoxExitTone6.Checked,
                                HoldMusic = checkBoxHoldMusic6.Checked,
                                HoldOn = checkBoxHoldOn6.Checked,
                                HoldCourse = checkBoxHoldCourse6.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval7.Text != "" && comboBoxStartMinuteInterval7.Text != "" && comboBoxStartFormatInterval7.Text != "") &&
                            (comboBoxStopHourInterval7.Text != "" && comboBoxStopMinuteInterval7.Text != "" && comboBoxStopFormatInterval7.Text != "") &&
                            (checkBoxEntranceTone7.Checked == false || checkBoxEntranceTone7.Checked == true) &&
                            (checkBoxExitTone7.Checked == false || checkBoxExitTone7.Checked == true) &&
                            (checkBoxHoldMusic7.Checked == false || checkBoxHoldMusic7.Checked == true) &&
                            (checkBoxHoldOn7.Checked == false || checkBoxHoldOn7.Checked == true) &&
                            (checkBoxHoldCourse7.Checked == false || checkBoxHoldCourse7.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 7,
                                Start = comboBoxStartHourInterval7.Text + ":" + comboBoxStartMinuteInterval7.Text + ":" + "00" + " " + comboBoxStartFormatInterval7.Text,
                                Stop = comboBoxStopHourInterval7.Text + ":" + comboBoxStopMinuteInterval7.Text + ":" + "00" + " " + comboBoxStopFormatInterval7.Text,
                                EntranceTone = checkBoxEntranceTone7.Checked,
                                ExitTone = checkBoxExitTone7.Checked,
                                HoldMusic = checkBoxHoldMusic7.Checked,
                                HoldOn = checkBoxHoldOn7.Checked,
                                HoldCourse = checkBoxHoldCourse7.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval8.Text != "" && comboBoxStartMinuteInterval8.Text != "" && comboBoxStartFormatInterval8.Text != "") &&
                            (comboBoxStopHourInterval8.Text != "" && comboBoxStopMinuteInterval8.Text != "" && comboBoxStopFormatInterval8.Text != "") &&
                            (checkBoxEntranceTone8.Checked == false || checkBoxEntranceTone8.Checked == true) &&
                            (checkBoxExitTone8.Checked == false || checkBoxExitTone8.Checked == true) &&
                            (checkBoxHoldMusic8.Checked == false || checkBoxHoldMusic8.Checked == true) &&
                            (checkBoxHoldOn8.Checked == false || checkBoxHoldOn8.Checked == true) &&
                            (checkBoxHoldCourse8.Checked == false || checkBoxHoldCourse8.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 8,
                                Start = comboBoxStartHourInterval8.Text + ":" + comboBoxStartMinuteInterval8.Text + ":" + "00" + " " + comboBoxStartFormatInterval8.Text,
                                Stop = comboBoxStopHourInterval8.Text + ":" + comboBoxStopMinuteInterval8.Text + ":" + "00" + " " + comboBoxStopFormatInterval8.Text,
                                EntranceTone = checkBoxEntranceTone8.Checked,
                                ExitTone = checkBoxExitTone8.Checked,
                                HoldMusic = checkBoxHoldMusic8.Checked,
                                HoldOn = checkBoxHoldOn8.Checked,
                                HoldCourse = checkBoxHoldCourse8.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval9.Text != "" && comboBoxStartMinuteInterval9.Text != "" && comboBoxStartFormatInterval9.Text != "") &&
                            (comboBoxStopHourInterval9.Text != "" && comboBoxStopMinuteInterval9.Text != "" && comboBoxStopFormatInterval9.Text != "") &&
                            (checkBoxEntranceTone9.Checked == false || checkBoxEntranceTone9.Checked == true) &&
                            (checkBoxExitTone9.Checked == false || checkBoxExitTone9.Checked == true) &&
                            (checkBoxHoldMusic9.Checked == false || checkBoxHoldMusic9.Checked == true) &&
                            (checkBoxHoldOn9.Checked == false || checkBoxHoldOn9.Checked == true) &&
                            (checkBoxHoldCourse9.Checked == false || checkBoxHoldCourse9.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 9,
                                Start = comboBoxStartHourInterval9.Text + ":" + comboBoxStartMinuteInterval9.Text + ":" + "00" + " " + comboBoxStartFormatInterval9.Text,
                                Stop = comboBoxStopHourInterval9.Text + ":" + comboBoxStopMinuteInterval9.Text + ":" + "00" + " " + comboBoxStopFormatInterval9.Text,
                                EntranceTone = checkBoxEntranceTone9.Checked,
                                ExitTone = checkBoxExitTone9.Checked,
                                HoldMusic = checkBoxHoldMusic9.Checked,
                                HoldOn = checkBoxHoldOn9.Checked,
                                HoldCourse = checkBoxHoldCourse9.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval10.Text != "" && comboBoxStartMinuteInterval10.Text != "" && comboBoxStartFormatInterval10.Text != "") &&
                            (comboBoxStopHourInterval10.Text != "" && comboBoxStopMinuteInterval10.Text != "" && comboBoxStopFormatInterval10.Text != "") &&
                            (checkBoxEntranceTone10.Checked == false || checkBoxEntranceTone10.Checked == true) &&
                            (checkBoxExitTone10.Checked == false || checkBoxExitTone10.Checked == true) &&
                            (checkBoxHoldMusic10.Checked == false || checkBoxHoldMusic10.Checked == true) &&
                            (checkBoxHoldOn10.Checked == false || checkBoxHoldOn10.Checked == true) &&
                            (checkBoxHoldCourse10.Checked == false || checkBoxHoldCourse10.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 10,
                                Start = comboBoxStartHourInterval10.Text + ":" + comboBoxStartMinuteInterval10.Text + ":" + "00" + " " + comboBoxStartFormatInterval10.Text,
                                Stop = comboBoxStopHourInterval10.Text + ":" + comboBoxStopMinuteInterval10.Text + ":" + "00" + " " + comboBoxStopFormatInterval10.Text,
                                EntranceTone = checkBoxEntranceTone10.Checked,
                                ExitTone = checkBoxExitTone10.Checked,
                                HoldMusic = checkBoxHoldMusic10.Checked,
                                HoldOn = checkBoxHoldOn10.Checked,
                                HoldCourse = checkBoxHoldCourse10.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        break;

                    case "Marti":
                        if ((comboBoxStartHourInterval1.Text != "" && comboBoxStartMinuteInterval1.Text != "" && comboBoxStartFormatInterval1.Text != "") &&
                            (comboBoxStopHourInterval1.Text != "" && comboBoxStopMinuteInterval1.Text != "" && comboBoxStopFormatInterval1.Text != "") &&
                            (checkBoxExitTone1.Checked == false || checkBoxExitTone1.Checked == true) &&
                            (checkBoxEntranceTone1.Checked == false || checkBoxEntranceTone1.Checked == true) &&
                            (checkBoxHoldMusic1.Checked == false || checkBoxHoldMusic1.Checked == true) &&
                            (checkBoxHoldOn1.Checked == false || checkBoxHoldOn1.Checked == true) &&
                            (checkBoxHoldCourse1.Checked == false || checkBoxHoldCourse1.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 11,
                                Start = comboBoxStartHourInterval1.Text + ":" + comboBoxStartMinuteInterval1.Text + ":" + "00" + " " + comboBoxStartFormatInterval1.Text,
                                Stop = comboBoxStopHourInterval1.Text + ":" + comboBoxStopMinuteInterval1.Text + ":" + "00" + " " + comboBoxStopFormatInterval1.Text,
                                EntranceTone = checkBoxEntranceTone1.Checked,
                                ExitTone = checkBoxExitTone1.Checked,
                                HoldMusic = checkBoxHoldMusic1.Checked,
                                HoldOn = checkBoxHoldOn1.Checked,
                                HoldCourse = checkBoxHoldCourse1.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval2.Text != "" && comboBoxStartMinuteInterval2.Text != "" && comboBoxStartFormatInterval2.Text != "") &&
                            (comboBoxStopHourInterval2.Text != "" && comboBoxStopMinuteInterval2.Text != "" && comboBoxStopFormatInterval2.Text != "") &&
                            (checkBoxEntranceTone2.Checked == false || checkBoxEntranceTone2.Checked == true) &&
                            (checkBoxExitTone2.Checked == false || checkBoxExitTone2.Checked == true) &&
                            (checkBoxHoldMusic2.Checked == false || checkBoxHoldMusic2.Checked == true) &&
                            (checkBoxHoldOn2.Checked == false || checkBoxHoldOn2.Checked == true) &&
                            (checkBoxHoldCourse2.Checked == false || checkBoxHoldCourse2.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 12,
                                Start = comboBoxStartHourInterval2.Text + ":" + comboBoxStartMinuteInterval2.Text + ":" + "00" + " " + comboBoxStartFormatInterval2.Text,
                                Stop = comboBoxStopHourInterval2.Text + ":" + comboBoxStopMinuteInterval2.Text + ":" + "00" + " " + comboBoxStopFormatInterval2.Text,
                                EntranceTone = checkBoxEntranceTone2.Checked,
                                ExitTone = checkBoxExitTone2.Checked,
                                HoldMusic = checkBoxHoldMusic2.Checked,
                                HoldOn = checkBoxHoldOn2.Checked,
                                HoldCourse = checkBoxHoldCourse2.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval3.Text != "" && comboBoxStartMinuteInterval3.Text != "" && comboBoxStartFormatInterval3.Text != "") &&
                            (comboBoxStopHourInterval3.Text != "" && comboBoxStopMinuteInterval3.Text != "" && comboBoxStopFormatInterval3.Text != "") &&
                            (checkBoxEntranceTone3.Checked == false || checkBoxEntranceTone3.Checked == true) &&
                            (checkBoxExitTone3.Checked == false || checkBoxExitTone3.Checked == true) &&
                            (checkBoxHoldMusic3.Checked == false || checkBoxHoldMusic3.Checked == true) &&
                            (checkBoxHoldOn3.Checked == false || checkBoxHoldOn3.Checked == true) &&
                            (checkBoxHoldCourse3.Checked == false || checkBoxHoldCourse3.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 13,
                                Start = comboBoxStartHourInterval3.Text + ":" + comboBoxStartMinuteInterval3.Text + ":" + "00" + " " + comboBoxStartFormatInterval3.Text,
                                Stop = comboBoxStopHourInterval3.Text + ":" + comboBoxStopMinuteInterval3.Text + ":" + "00" + " " + comboBoxStopFormatInterval3.Text,
                                EntranceTone = checkBoxEntranceTone3.Checked,
                                ExitTone = checkBoxExitTone3.Checked,
                                HoldMusic = checkBoxHoldMusic3.Checked,
                                HoldOn = checkBoxHoldOn3.Checked,
                                HoldCourse = checkBoxHoldCourse3.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval4.Text != "" && comboBoxStartMinuteInterval4.Text != "" && comboBoxStartFormatInterval4.Text != "") &&
                            (comboBoxStopHourInterval4.Text != "" && comboBoxStopMinuteInterval4.Text != "" && comboBoxStopFormatInterval4.Text != "") &&
                            (checkBoxEntranceTone4.Checked == false || checkBoxEntranceTone4.Checked == true) &&
                            (checkBoxExitTone4.Checked == false || checkBoxExitTone4.Checked == true) &&
                            (checkBoxHoldMusic4.Checked == false || checkBoxHoldMusic4.Checked == true) &&
                            (checkBoxHoldOn4.Checked == false || checkBoxHoldOn4.Checked == true) &&
                            (checkBoxHoldCourse4.Checked == false || checkBoxHoldCourse4.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 14,
                                Start = comboBoxStartHourInterval4.Text + ":" + comboBoxStartMinuteInterval4.Text + ":" + "00" + " " + comboBoxStartFormatInterval4.Text,
                                Stop = comboBoxStopHourInterval4.Text + ":" + comboBoxStopMinuteInterval4.Text + ":" + "00" + " " + comboBoxStopFormatInterval4.Text,
                                EntranceTone = checkBoxEntranceTone4.Checked,
                                ExitTone = checkBoxExitTone4.Checked,
                                HoldMusic = checkBoxHoldMusic4.Checked,
                                HoldOn = checkBoxHoldOn4.Checked,
                                HoldCourse = checkBoxHoldCourse4.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval5.Text != "" && comboBoxStartMinuteInterval5.Text != "" && comboBoxStartFormatInterval5.Text != "") &&
                            (comboBoxStopHourInterval5.Text != "" && comboBoxStopMinuteInterval5.Text != "" && comboBoxStopFormatInterval5.Text != "") &&
                            (checkBoxEntranceTone5.Checked == false || checkBoxEntranceTone5.Checked == true) &&
                            (checkBoxExitTone5.Checked == false || checkBoxExitTone5.Checked == true) &&
                            (checkBoxHoldMusic5.Checked == false || checkBoxHoldMusic5.Checked == true) &&
                            (checkBoxHoldOn5.Checked == false || checkBoxHoldOn5.Checked == true) &&
                            (checkBoxHoldCourse5.Checked == false || checkBoxHoldCourse5.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 15,
                                Start = comboBoxStartHourInterval5.Text + ":" + comboBoxStartMinuteInterval5.Text + ":" + "00" + " " + comboBoxStartFormatInterval5.Text,
                                Stop = comboBoxStopHourInterval5.Text + ":" + comboBoxStopMinuteInterval5.Text + ":" + "00" + " " + comboBoxStopFormatInterval5.Text,
                                EntranceTone = checkBoxEntranceTone5.Checked,
                                ExitTone = checkBoxExitTone5.Checked,
                                HoldMusic = checkBoxHoldMusic5.Checked,
                                HoldOn = checkBoxHoldOn5.Checked,
                                HoldCourse = checkBoxHoldCourse5.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval6.Text != "" && comboBoxStartMinuteInterval6.Text != "" && comboBoxStartFormatInterval6.Text != "") &&
                            (comboBoxStopHourInterval6.Text != "" && comboBoxStopMinuteInterval6.Text != "" && comboBoxStopFormatInterval6.Text != "") &&
                            (checkBoxEntranceTone6.Checked == false || checkBoxEntranceTone6.Checked == true) &&
                            (checkBoxExitTone6.Checked == false || checkBoxExitTone6.Checked == true) &&
                            (checkBoxHoldMusic6.Checked == false || checkBoxHoldMusic6.Checked == true) &&
                            (checkBoxHoldOn6.Checked == false || checkBoxHoldOn6.Checked == true) &&
                            (checkBoxHoldCourse6.Checked == false || checkBoxHoldCourse6.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 16,
                                Start = comboBoxStartHourInterval6.Text + ":" + comboBoxStartMinuteInterval6.Text + ":" + "00" + " " + comboBoxStartFormatInterval6.Text,
                                Stop = comboBoxStopHourInterval6.Text + ":" + comboBoxStopMinuteInterval6.Text + ":" + "00" + " " + comboBoxStopFormatInterval6.Text,
                                EntranceTone = checkBoxEntranceTone6.Checked,
                                ExitTone = checkBoxExitTone6.Checked,
                                HoldMusic = checkBoxHoldMusic6.Checked,
                                HoldOn = checkBoxHoldOn6.Checked,
                                HoldCourse = checkBoxHoldCourse6.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval7.Text != "" && comboBoxStartMinuteInterval7.Text != "" && comboBoxStartFormatInterval7.Text != "") &&
                            (comboBoxStopHourInterval7.Text != "" && comboBoxStopMinuteInterval7.Text != "" && comboBoxStopFormatInterval7.Text != "") &&
                            (checkBoxEntranceTone7.Checked == false || checkBoxEntranceTone7.Checked == true) &&
                            (checkBoxExitTone7.Checked == false || checkBoxExitTone7.Checked == true) &&
                            (checkBoxHoldMusic7.Checked == false || checkBoxHoldMusic7.Checked == true) &&
                            (checkBoxHoldOn7.Checked == false || checkBoxHoldOn7.Checked == true) &&
                            (checkBoxHoldCourse7.Checked == false || checkBoxHoldCourse7.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 17,
                                Start = comboBoxStartHourInterval7.Text + ":" + comboBoxStartMinuteInterval7.Text + ":" + "00" + " " + comboBoxStartFormatInterval7.Text,
                                Stop = comboBoxStopHourInterval7.Text + ":" + comboBoxStopMinuteInterval7.Text + ":" + "00" + " " + comboBoxStopFormatInterval7.Text,
                                EntranceTone = checkBoxEntranceTone7.Checked,
                                ExitTone = checkBoxExitTone7.Checked,
                                HoldMusic = checkBoxHoldMusic7.Checked,
                                HoldOn = checkBoxHoldOn7.Checked,
                                HoldCourse = checkBoxHoldCourse7.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval8.Text != "" && comboBoxStartMinuteInterval8.Text != "" && comboBoxStartFormatInterval8.Text != "") &&
                            (comboBoxStopHourInterval8.Text != "" && comboBoxStopMinuteInterval8.Text != "" && comboBoxStopFormatInterval8.Text != "") &&
                            (checkBoxEntranceTone8.Checked == false || checkBoxEntranceTone8.Checked == true) &&
                            (checkBoxExitTone8.Checked == false || checkBoxExitTone8.Checked == true) &&
                            (checkBoxHoldMusic8.Checked == false || checkBoxHoldMusic8.Checked == true) &&
                            (checkBoxHoldOn8.Checked == false || checkBoxHoldOn8.Checked == true) &&
                            (checkBoxHoldCourse8.Checked == false || checkBoxHoldCourse8.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 18,
                                Start = comboBoxStartHourInterval8.Text + ":" + comboBoxStartMinuteInterval8.Text + ":" + "00" + " " + comboBoxStartFormatInterval8.Text,
                                Stop = comboBoxStopHourInterval8.Text + ":" + comboBoxStopMinuteInterval8.Text + ":" + "00" + " " + comboBoxStopFormatInterval8.Text,
                                EntranceTone = checkBoxEntranceTone8.Checked,
                                ExitTone = checkBoxExitTone8.Checked,
                                HoldMusic = checkBoxHoldMusic8.Checked,
                                HoldOn = checkBoxHoldOn8.Checked,
                                HoldCourse = checkBoxHoldCourse8.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval9.Text != "" && comboBoxStartMinuteInterval9.Text != "" && comboBoxStartFormatInterval9.Text != "") &&
                            (comboBoxStopHourInterval9.Text != "" && comboBoxStopMinuteInterval9.Text != "" && comboBoxStopFormatInterval9.Text != "") &&
                            (checkBoxEntranceTone9.Checked == false || checkBoxEntranceTone9.Checked == true) &&
                            (checkBoxExitTone9.Checked == false || checkBoxExitTone9.Checked == true) &&
                            (checkBoxHoldMusic9.Checked == false || checkBoxHoldMusic9.Checked == true) &&
                            (checkBoxHoldOn9.Checked == false || checkBoxHoldOn9.Checked == true) &&
                            (checkBoxHoldCourse9.Checked == false || checkBoxHoldCourse9.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 19,
                                Start = comboBoxStartHourInterval9.Text + ":" + comboBoxStartMinuteInterval9.Text + ":" + "00" + " " + comboBoxStartFormatInterval9.Text,
                                Stop = comboBoxStopHourInterval9.Text + ":" + comboBoxStopMinuteInterval9.Text + ":" + "00" + " " + comboBoxStopFormatInterval9.Text,
                                EntranceTone = checkBoxEntranceTone9.Checked,
                                ExitTone = checkBoxExitTone9.Checked,
                                HoldMusic = checkBoxHoldMusic9.Checked,
                                HoldOn = checkBoxHoldOn9.Checked,
                                HoldCourse = checkBoxHoldCourse9.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval10.Text != "" && comboBoxStartMinuteInterval10.Text != "" && comboBoxStartFormatInterval10.Text != "") &&
                            (comboBoxStopHourInterval10.Text != "" && comboBoxStopMinuteInterval10.Text != "" && comboBoxStopFormatInterval10.Text != "") &&
                            (checkBoxEntranceTone10.Checked == false || checkBoxEntranceTone10.Checked == true) &&
                            (checkBoxExitTone10.Checked == false || checkBoxExitTone10.Checked == true) &&
                            (checkBoxHoldMusic10.Checked == false || checkBoxHoldMusic10.Checked == true) &&
                            (checkBoxHoldOn10.Checked == false || checkBoxHoldOn10.Checked == true) &&
                            (checkBoxHoldCourse10.Checked == false || checkBoxHoldCourse10.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 20,
                                Start = comboBoxStartHourInterval10.Text + ":" + comboBoxStartMinuteInterval10.Text + ":" + "00" + " " + comboBoxStartFormatInterval10.Text,
                                Stop = comboBoxStopHourInterval10.Text + ":" + comboBoxStopMinuteInterval10.Text + ":" + "00" + " " + comboBoxStopFormatInterval10.Text,
                                EntranceTone = checkBoxEntranceTone10.Checked,
                                ExitTone = checkBoxExitTone10.Checked,
                                HoldMusic = checkBoxHoldMusic10.Checked,
                                HoldOn = checkBoxHoldOn10.Checked,
                                HoldCourse = checkBoxHoldCourse10.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        break;

                    case "Miercuri":
                        if ((comboBoxStartHourInterval1.Text != "" && comboBoxStartMinuteInterval1.Text != "" && comboBoxStartFormatInterval1.Text != "") &&
                        (comboBoxStopHourInterval1.Text != "" && comboBoxStopMinuteInterval1.Text != "" && comboBoxStopFormatInterval1.Text != "") &&
                        (checkBoxExitTone1.Checked == false || checkBoxExitTone1.Checked == true) &&
                        (checkBoxEntranceTone1.Checked == false || checkBoxEntranceTone1.Checked == true) &&
                        (checkBoxHoldMusic1.Checked == false || checkBoxHoldMusic1.Checked == true) &&
                        (checkBoxHoldOn1.Checked == false || checkBoxHoldOn1.Checked == true) &&
                        (checkBoxHoldCourse1.Checked == false || checkBoxHoldCourse1.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 21,
                                Start = comboBoxStartHourInterval1.Text + ":" + comboBoxStartMinuteInterval1.Text + ":" + "00" + " " + comboBoxStartFormatInterval1.Text,
                                Stop = comboBoxStopHourInterval1.Text + ":" + comboBoxStopMinuteInterval1.Text + ":" + "00" + " " + comboBoxStopFormatInterval1.Text,
                                EntranceTone = checkBoxEntranceTone1.Checked,
                                ExitTone = checkBoxExitTone1.Checked,
                                HoldMusic = checkBoxHoldMusic1.Checked,
                                HoldOn = checkBoxHoldOn1.Checked,
                                HoldCourse = checkBoxHoldCourse1.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval2.Text != "" && comboBoxStartMinuteInterval2.Text != "" && comboBoxStartFormatInterval2.Text != "") &&
                            (comboBoxStopHourInterval2.Text != "" && comboBoxStopMinuteInterval2.Text != "" && comboBoxStopFormatInterval2.Text != "") &&
                            (checkBoxEntranceTone2.Checked == false || checkBoxEntranceTone2.Checked == true) &&
                            (checkBoxExitTone2.Checked == false || checkBoxExitTone2.Checked == true) &&
                            (checkBoxHoldMusic2.Checked == false || checkBoxHoldMusic2.Checked == true) &&
                            (checkBoxHoldOn2.Checked == false || checkBoxHoldOn2.Checked == true) &&
                            (checkBoxHoldCourse2.Checked == false || checkBoxHoldCourse2.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 22,
                                Start = comboBoxStartHourInterval2.Text + ":" + comboBoxStartMinuteInterval2.Text + ":" + "00" + " " + comboBoxStartFormatInterval2.Text,
                                Stop = comboBoxStopHourInterval2.Text + ":" + comboBoxStopMinuteInterval2.Text + ":" + "00" + " " + comboBoxStopFormatInterval2.Text,
                                EntranceTone = checkBoxEntranceTone2.Checked,
                                ExitTone = checkBoxExitTone2.Checked,
                                HoldMusic = checkBoxHoldMusic2.Checked,
                                HoldOn = checkBoxHoldOn2.Checked,
                                HoldCourse = checkBoxHoldCourse2.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval3.Text != "" && comboBoxStartMinuteInterval3.Text != "" && comboBoxStartFormatInterval3.Text != "") &&
                            (comboBoxStopHourInterval3.Text != "" && comboBoxStopMinuteInterval3.Text != "" && comboBoxStopFormatInterval3.Text != "") &&
                            (checkBoxEntranceTone3.Checked == false || checkBoxEntranceTone3.Checked == true) &&
                            (checkBoxExitTone3.Checked == false || checkBoxExitTone3.Checked == true) &&
                            (checkBoxHoldMusic3.Checked == false || checkBoxHoldMusic3.Checked == true) &&
                            (checkBoxHoldOn3.Checked == false || checkBoxHoldOn3.Checked == true) &&
                            (checkBoxHoldCourse3.Checked == false || checkBoxHoldCourse3.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 23,
                                Start = comboBoxStartHourInterval3.Text + ":" + comboBoxStartMinuteInterval3.Text + ":" + "00" + " " + comboBoxStartFormatInterval3.Text,
                                Stop = comboBoxStopHourInterval3.Text + ":" + comboBoxStopMinuteInterval3.Text + ":" + "00" + " " + comboBoxStopFormatInterval3.Text,
                                EntranceTone = checkBoxEntranceTone3.Checked,
                                ExitTone = checkBoxExitTone3.Checked,
                                HoldMusic = checkBoxHoldMusic3.Checked,
                                HoldOn = checkBoxHoldOn3.Checked,
                                HoldCourse = checkBoxHoldCourse3.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval4.Text != "" && comboBoxStartMinuteInterval4.Text != "" && comboBoxStartFormatInterval4.Text != "") &&
                            (comboBoxStopHourInterval4.Text != "" && comboBoxStopMinuteInterval4.Text != "" && comboBoxStopFormatInterval4.Text != "") &&
                            (checkBoxEntranceTone4.Checked == false || checkBoxEntranceTone4.Checked == true) &&
                            (checkBoxExitTone4.Checked == false || checkBoxExitTone4.Checked == true) &&
                            (checkBoxHoldMusic4.Checked == false || checkBoxHoldMusic4.Checked == true) &&
                            (checkBoxHoldOn4.Checked == false || checkBoxHoldOn4.Checked == true) &&
                            (checkBoxHoldCourse4.Checked == false || checkBoxHoldCourse4.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 24,
                                Start = comboBoxStartHourInterval4.Text + ":" + comboBoxStartMinuteInterval4.Text + ":" + "00" + " " + comboBoxStartFormatInterval4.Text,
                                Stop = comboBoxStopHourInterval4.Text + ":" + comboBoxStopMinuteInterval4.Text + ":" + "00" + " " + comboBoxStopFormatInterval4.Text,
                                EntranceTone = checkBoxEntranceTone4.Checked,
                                ExitTone = checkBoxExitTone4.Checked,
                                HoldMusic = checkBoxHoldMusic4.Checked,
                                HoldOn = checkBoxHoldOn4.Checked,
                                HoldCourse = checkBoxHoldCourse4.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval5.Text != "" && comboBoxStartMinuteInterval5.Text != "" && comboBoxStartFormatInterval5.Text != "") &&
                            (comboBoxStopHourInterval5.Text != "" && comboBoxStopMinuteInterval5.Text != "" && comboBoxStopFormatInterval5.Text != "") &&
                            (checkBoxEntranceTone5.Checked == false || checkBoxEntranceTone5.Checked == true) &&
                            (checkBoxExitTone5.Checked == false || checkBoxExitTone5.Checked == true) &&
                            (checkBoxHoldMusic5.Checked == false || checkBoxHoldMusic5.Checked == true) &&
                            (checkBoxHoldOn5.Checked == false || checkBoxHoldOn5.Checked == true) &&
                            (checkBoxHoldCourse5.Checked == false || checkBoxHoldCourse5.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 25,
                                Start = comboBoxStartHourInterval5.Text + ":" + comboBoxStartMinuteInterval5.Text + ":" + "00" + " " + comboBoxStartFormatInterval5.Text,
                                Stop = comboBoxStopHourInterval5.Text + ":" + comboBoxStopMinuteInterval5.Text + ":" + "00" + " " + comboBoxStopFormatInterval5.Text,
                                EntranceTone = checkBoxEntranceTone5.Checked,
                                ExitTone = checkBoxExitTone5.Checked,
                                HoldMusic = checkBoxHoldMusic5.Checked,
                                HoldOn = checkBoxHoldOn5.Checked,
                                HoldCourse = checkBoxHoldCourse5.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval6.Text != "" && comboBoxStartMinuteInterval6.Text != "" && comboBoxStartFormatInterval6.Text != "") &&
                            (comboBoxStopHourInterval6.Text != "" && comboBoxStopMinuteInterval6.Text != "" && comboBoxStopFormatInterval6.Text != "") &&
                            (checkBoxEntranceTone6.Checked == false || checkBoxEntranceTone6.Checked == true) &&
                            (checkBoxExitTone6.Checked == false || checkBoxExitTone6.Checked == true) &&
                            (checkBoxHoldMusic6.Checked == false || checkBoxHoldMusic6.Checked == true) &&
                            (checkBoxHoldOn6.Checked == false || checkBoxHoldOn6.Checked == true) &&
                            (checkBoxHoldCourse6.Checked == false || checkBoxHoldCourse6.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 26,
                                Start = comboBoxStartHourInterval6.Text + ":" + comboBoxStartMinuteInterval6.Text + ":" + "00" + " " + comboBoxStartFormatInterval6.Text,
                                Stop = comboBoxStopHourInterval6.Text + ":" + comboBoxStopMinuteInterval6.Text + ":" + "00" + " " + comboBoxStopFormatInterval6.Text,
                                EntranceTone = checkBoxEntranceTone6.Checked,
                                ExitTone = checkBoxExitTone6.Checked,
                                HoldMusic = checkBoxHoldMusic6.Checked,
                                HoldOn = checkBoxHoldOn6.Checked,
                                HoldCourse = checkBoxHoldCourse6.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval7.Text != "" && comboBoxStartMinuteInterval7.Text != "" && comboBoxStartFormatInterval7.Text != "") &&
                            (comboBoxStopHourInterval7.Text != "" && comboBoxStopMinuteInterval7.Text != "" && comboBoxStopFormatInterval7.Text != "") &&
                            (checkBoxEntranceTone7.Checked == false || checkBoxEntranceTone7.Checked == true) &&
                            (checkBoxExitTone7.Checked == false || checkBoxExitTone7.Checked == true) &&
                            (checkBoxHoldMusic7.Checked == false || checkBoxHoldMusic7.Checked == true) &&
                            (checkBoxHoldOn7.Checked == false || checkBoxHoldOn7.Checked == true) &&
                            (checkBoxHoldCourse7.Checked == false || checkBoxHoldCourse7.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 27,
                                Start = comboBoxStartHourInterval7.Text + ":" + comboBoxStartMinuteInterval7.Text + ":" + "00" + " " + comboBoxStartFormatInterval7.Text,
                                Stop = comboBoxStopHourInterval7.Text + ":" + comboBoxStopMinuteInterval7.Text + ":" + "00" + " " + comboBoxStopFormatInterval7.Text,
                                EntranceTone = checkBoxEntranceTone7.Checked,
                                ExitTone = checkBoxExitTone7.Checked,
                                HoldMusic = checkBoxHoldMusic7.Checked,
                                HoldOn = checkBoxHoldOn7.Checked,
                                HoldCourse = checkBoxHoldCourse7.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval8.Text != "" && comboBoxStartMinuteInterval8.Text != "" && comboBoxStartFormatInterval8.Text != "") &&
                            (comboBoxStopHourInterval8.Text != "" && comboBoxStopMinuteInterval8.Text != "" && comboBoxStopFormatInterval8.Text != "") &&
                            (checkBoxEntranceTone8.Checked == false || checkBoxEntranceTone8.Checked == true) &&
                            (checkBoxExitTone8.Checked == false || checkBoxExitTone8.Checked == true) &&
                            (checkBoxHoldMusic8.Checked == false || checkBoxHoldMusic8.Checked == true) &&
                            (checkBoxHoldOn8.Checked == false || checkBoxHoldOn8.Checked == true) &&
                            (checkBoxHoldCourse8.Checked == false || checkBoxHoldCourse8.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 28,
                                Start = comboBoxStartHourInterval8.Text + ":" + comboBoxStartMinuteInterval8.Text + ":" + "00" + " " + comboBoxStartFormatInterval8.Text,
                                Stop = comboBoxStopHourInterval8.Text + ":" + comboBoxStopMinuteInterval8.Text + ":" + "00" + " " + comboBoxStopFormatInterval8.Text,
                                EntranceTone = checkBoxEntranceTone8.Checked,
                                ExitTone = checkBoxExitTone8.Checked,
                                HoldMusic = checkBoxHoldMusic8.Checked,
                                HoldOn = checkBoxHoldOn8.Checked,
                                HoldCourse = checkBoxHoldCourse8.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval9.Text != "" && comboBoxStartMinuteInterval9.Text != "" && comboBoxStartFormatInterval9.Text != "") &&
                            (comboBoxStopHourInterval9.Text != "" && comboBoxStopMinuteInterval9.Text != "" && comboBoxStopFormatInterval9.Text != "") &&
                            (checkBoxEntranceTone9.Checked == false || checkBoxEntranceTone9.Checked == true) &&
                            (checkBoxExitTone9.Checked == false || checkBoxExitTone9.Checked == true) &&
                            (checkBoxHoldMusic9.Checked == false || checkBoxHoldMusic9.Checked == true) &&
                            (checkBoxHoldOn9.Checked == false || checkBoxHoldOn9.Checked == true) &&
                            (checkBoxHoldCourse9.Checked == false || checkBoxHoldCourse9.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 29,
                                Start = comboBoxStartHourInterval9.Text + ":" + comboBoxStartMinuteInterval9.Text + ":" + "00" + " " + comboBoxStartFormatInterval9.Text,
                                Stop = comboBoxStopHourInterval9.Text + ":" + comboBoxStopMinuteInterval9.Text + ":" + "00" + " " + comboBoxStopFormatInterval9.Text,
                                EntranceTone = checkBoxEntranceTone9.Checked,
                                ExitTone = checkBoxExitTone9.Checked,
                                HoldMusic = checkBoxHoldMusic9.Checked,
                                HoldOn = checkBoxHoldOn9.Checked,
                                HoldCourse = checkBoxHoldCourse9.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval10.Text != "" && comboBoxStartMinuteInterval10.Text != "" && comboBoxStartFormatInterval10.Text != "") &&
                            (comboBoxStopHourInterval10.Text != "" && comboBoxStopMinuteInterval10.Text != "" && comboBoxStopFormatInterval10.Text != "") &&
                            (checkBoxEntranceTone10.Checked == false || checkBoxEntranceTone10.Checked == true) &&
                            (checkBoxExitTone10.Checked == false || checkBoxExitTone10.Checked == true) &&
                            (checkBoxHoldMusic10.Checked == false || checkBoxHoldMusic10.Checked == true) &&
                            (checkBoxHoldOn10.Checked == false || checkBoxHoldOn10.Checked == true) &&
                            (checkBoxHoldCourse10.Checked == false || checkBoxHoldCourse10.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 30,
                                Start = comboBoxStartHourInterval10.Text + ":" + comboBoxStartMinuteInterval10.Text + ":" + "00" + " " + comboBoxStartFormatInterval10.Text,
                                Stop = comboBoxStopHourInterval10.Text + ":" + comboBoxStopMinuteInterval10.Text + ":" + "00" + " " + comboBoxStopFormatInterval10.Text,
                                EntranceTone = checkBoxEntranceTone10.Checked,
                                ExitTone = checkBoxExitTone10.Checked,
                                HoldMusic = checkBoxHoldMusic10.Checked,
                                HoldOn = checkBoxHoldOn10.Checked,
                                HoldCourse = checkBoxHoldCourse10.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        break;

                    case "Joi":
                        if ((comboBoxStartHourInterval1.Text != "" && comboBoxStartMinuteInterval1.Text != "" && comboBoxStartFormatInterval1.Text != "") &&
                        (comboBoxStopHourInterval1.Text != "" && comboBoxStopMinuteInterval1.Text != "" && comboBoxStopFormatInterval1.Text != "") &&
                        (checkBoxExitTone1.Checked == false || checkBoxExitTone1.Checked == true) &&
                        (checkBoxEntranceTone1.Checked == false || checkBoxEntranceTone1.Checked == true) &&
                        (checkBoxHoldMusic1.Checked == false || checkBoxHoldMusic1.Checked == true) &&
                        (checkBoxHoldOn1.Checked == false || checkBoxHoldOn1.Checked == true) &&
                        (checkBoxHoldCourse1.Checked == false || checkBoxHoldCourse1.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 31,
                                Start = comboBoxStartHourInterval1.Text + ":" + comboBoxStartMinuteInterval1.Text + ":" + "00" + " " + comboBoxStartFormatInterval1.Text,
                                Stop = comboBoxStopHourInterval1.Text + ":" + comboBoxStopMinuteInterval1.Text + ":" + "00" + " " + comboBoxStopFormatInterval1.Text,
                                EntranceTone = checkBoxEntranceTone1.Checked,
                                ExitTone = checkBoxExitTone1.Checked,
                                HoldMusic = checkBoxHoldMusic1.Checked,
                                HoldOn = checkBoxHoldOn1.Checked,
                                HoldCourse = checkBoxHoldCourse1.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval2.Text != "" && comboBoxStartMinuteInterval2.Text != "" && comboBoxStartFormatInterval2.Text != "") &&
                            (comboBoxStopHourInterval2.Text != "" && comboBoxStopMinuteInterval2.Text != "" && comboBoxStopFormatInterval2.Text != "") &&
                            (checkBoxEntranceTone2.Checked == false || checkBoxEntranceTone2.Checked == true) &&
                            (checkBoxExitTone2.Checked == false || checkBoxExitTone2.Checked == true) &&
                            (checkBoxHoldMusic2.Checked == false || checkBoxHoldMusic2.Checked == true) &&
                            (checkBoxHoldOn2.Checked == false || checkBoxHoldOn2.Checked == true) &&
                            (checkBoxHoldCourse2.Checked == false || checkBoxHoldCourse2.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 32,
                                Start = comboBoxStartHourInterval2.Text + ":" + comboBoxStartMinuteInterval2.Text + ":" + "00" + " " + comboBoxStartFormatInterval2.Text,
                                Stop = comboBoxStopHourInterval2.Text + ":" + comboBoxStopMinuteInterval2.Text + ":" + "00" + " " + comboBoxStopFormatInterval2.Text,
                                EntranceTone = checkBoxEntranceTone2.Checked,
                                ExitTone = checkBoxExitTone2.Checked,
                                HoldMusic = checkBoxHoldMusic2.Checked,
                                HoldOn = checkBoxHoldOn2.Checked,
                                HoldCourse = checkBoxHoldCourse2.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval3.Text != "" && comboBoxStartMinuteInterval3.Text != "" && comboBoxStartFormatInterval3.Text != "") &&
                            (comboBoxStopHourInterval3.Text != "" && comboBoxStopMinuteInterval3.Text != "" && comboBoxStopFormatInterval3.Text != "") &&
                            (checkBoxEntranceTone3.Checked == false || checkBoxEntranceTone3.Checked == true) &&
                            (checkBoxExitTone3.Checked == false || checkBoxExitTone3.Checked == true) &&
                            (checkBoxHoldMusic3.Checked == false || checkBoxHoldMusic3.Checked == true) &&
                            (checkBoxHoldOn3.Checked == false || checkBoxHoldOn3.Checked == true) &&
                            (checkBoxHoldCourse3.Checked == false || checkBoxHoldCourse3.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 33,
                                Start = comboBoxStartHourInterval3.Text + ":" + comboBoxStartMinuteInterval3.Text + ":" + "00" + " " + comboBoxStartFormatInterval3.Text,
                                Stop = comboBoxStopHourInterval3.Text + ":" + comboBoxStopMinuteInterval3.Text + ":" + "00" + " " + comboBoxStopFormatInterval3.Text,
                                EntranceTone = checkBoxEntranceTone3.Checked,
                                ExitTone = checkBoxExitTone3.Checked,
                                HoldMusic = checkBoxHoldMusic3.Checked,
                                HoldOn = checkBoxHoldOn3.Checked,
                                HoldCourse = checkBoxHoldCourse3.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval4.Text != "" && comboBoxStartMinuteInterval4.Text != "" && comboBoxStartFormatInterval4.Text != "") &&
                            (comboBoxStopHourInterval4.Text != "" && comboBoxStopMinuteInterval4.Text != "" && comboBoxStopFormatInterval4.Text != "") &&
                            (checkBoxEntranceTone4.Checked == false || checkBoxEntranceTone4.Checked == true) &&
                            (checkBoxExitTone4.Checked == false || checkBoxExitTone4.Checked == true) &&
                            (checkBoxHoldMusic4.Checked == false || checkBoxHoldMusic4.Checked == true) &&
                            (checkBoxHoldOn4.Checked == false || checkBoxHoldOn4.Checked == true) &&
                            (checkBoxHoldCourse4.Checked == false || checkBoxHoldCourse4.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 34,
                                Start = comboBoxStartHourInterval4.Text + ":" + comboBoxStartMinuteInterval4.Text + ":" + "00" + " " + comboBoxStartFormatInterval4.Text,
                                Stop = comboBoxStopHourInterval4.Text + ":" + comboBoxStopMinuteInterval4.Text + ":" + "00" + " " + comboBoxStopFormatInterval4.Text,
                                EntranceTone = checkBoxEntranceTone4.Checked,
                                ExitTone = checkBoxExitTone4.Checked,
                                HoldMusic = checkBoxHoldMusic4.Checked,
                                HoldOn = checkBoxHoldOn4.Checked,
                                HoldCourse = checkBoxHoldCourse4.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval5.Text != "" && comboBoxStartMinuteInterval5.Text != "" && comboBoxStartFormatInterval5.Text != "") &&
                            (comboBoxStopHourInterval5.Text != "" && comboBoxStopMinuteInterval5.Text != "" && comboBoxStopFormatInterval5.Text != "") &&
                            (checkBoxEntranceTone5.Checked == false || checkBoxEntranceTone5.Checked == true) &&
                            (checkBoxExitTone5.Checked == false || checkBoxExitTone5.Checked == true) &&
                            (checkBoxHoldMusic5.Checked == false || checkBoxHoldMusic5.Checked == true) &&
                            (checkBoxHoldOn5.Checked == false || checkBoxHoldOn5.Checked == true) &&
                            (checkBoxHoldCourse5.Checked == false || checkBoxHoldCourse5.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 35,
                                Start = comboBoxStartHourInterval5.Text + ":" + comboBoxStartMinuteInterval5.Text + ":" + "00" + " " + comboBoxStartFormatInterval5.Text,
                                Stop = comboBoxStopHourInterval5.Text + ":" + comboBoxStopMinuteInterval5.Text + ":" + "00" + " " + comboBoxStopFormatInterval5.Text,
                                EntranceTone = checkBoxEntranceTone5.Checked,
                                ExitTone = checkBoxExitTone5.Checked,
                                HoldMusic = checkBoxHoldMusic5.Checked,
                                HoldOn = checkBoxHoldOn5.Checked,
                                HoldCourse = checkBoxHoldCourse5.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval6.Text != "" && comboBoxStartMinuteInterval6.Text != "" && comboBoxStartFormatInterval6.Text != "") &&
                            (comboBoxStopHourInterval6.Text != "" && comboBoxStopMinuteInterval6.Text != "" && comboBoxStopFormatInterval6.Text != "") &&
                            (checkBoxEntranceTone6.Checked == false || checkBoxEntranceTone6.Checked == true) &&
                            (checkBoxExitTone6.Checked == false || checkBoxExitTone6.Checked == true) &&
                            (checkBoxHoldMusic6.Checked == false || checkBoxHoldMusic6.Checked == true) &&
                            (checkBoxHoldOn6.Checked == false || checkBoxHoldOn6.Checked == true) &&
                            (checkBoxHoldCourse6.Checked == false || checkBoxHoldCourse6.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 36,
                                Start = comboBoxStartHourInterval6.Text + ":" + comboBoxStartMinuteInterval6.Text + ":" + "00" + " " + comboBoxStartFormatInterval6.Text,
                                Stop = comboBoxStopHourInterval6.Text + ":" + comboBoxStopMinuteInterval6.Text + ":" + "00" + " " + comboBoxStopFormatInterval6.Text,
                                EntranceTone = checkBoxEntranceTone6.Checked,
                                ExitTone = checkBoxExitTone6.Checked,
                                HoldMusic = checkBoxHoldMusic6.Checked,
                                HoldOn = checkBoxHoldOn6.Checked,
                                HoldCourse = checkBoxHoldCourse6.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval7.Text != "" && comboBoxStartMinuteInterval7.Text != "" && comboBoxStartFormatInterval7.Text != "") &&
                            (comboBoxStopHourInterval7.Text != "" && comboBoxStopMinuteInterval7.Text != "" && comboBoxStopFormatInterval7.Text != "") &&
                            (checkBoxEntranceTone7.Checked == false || checkBoxEntranceTone7.Checked == true) &&
                            (checkBoxExitTone7.Checked == false || checkBoxExitTone7.Checked == true) &&
                            (checkBoxHoldMusic7.Checked == false || checkBoxHoldMusic7.Checked == true) &&
                            (checkBoxHoldOn7.Checked == false || checkBoxHoldOn7.Checked == true) &&
                            (checkBoxHoldCourse7.Checked == false || checkBoxHoldCourse7.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 37,
                                Start = comboBoxStartHourInterval7.Text + ":" + comboBoxStartMinuteInterval7.Text + ":" + "00" + " " + comboBoxStartFormatInterval7.Text,
                                Stop = comboBoxStopHourInterval7.Text + ":" + comboBoxStopMinuteInterval7.Text + ":" + "00" + " " + comboBoxStopFormatInterval7.Text,
                                EntranceTone = checkBoxEntranceTone7.Checked,
                                ExitTone = checkBoxExitTone7.Checked,
                                HoldMusic = checkBoxHoldMusic7.Checked,
                                HoldOn = checkBoxHoldOn7.Checked,
                                HoldCourse = checkBoxHoldCourse7.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval8.Text != "" && comboBoxStartMinuteInterval8.Text != "" && comboBoxStartFormatInterval8.Text != "") &&
                            (comboBoxStopHourInterval8.Text != "" && comboBoxStopMinuteInterval8.Text != "" && comboBoxStopFormatInterval8.Text != "") &&
                            (checkBoxEntranceTone8.Checked == false || checkBoxEntranceTone8.Checked == true) &&
                            (checkBoxExitTone8.Checked == false || checkBoxExitTone8.Checked == true) &&
                            (checkBoxHoldMusic8.Checked == false || checkBoxHoldMusic8.Checked == true) &&
                            (checkBoxHoldOn8.Checked == false || checkBoxHoldOn8.Checked == true) &&
                            (checkBoxHoldCourse8.Checked == false || checkBoxHoldCourse8.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 38,
                                Start = comboBoxStartHourInterval8.Text + ":" + comboBoxStartMinuteInterval8.Text + ":" + "00" + " " + comboBoxStartFormatInterval8.Text,
                                Stop = comboBoxStopHourInterval8.Text + ":" + comboBoxStopMinuteInterval8.Text + ":" + "00" + " " + comboBoxStopFormatInterval8.Text,
                                EntranceTone = checkBoxEntranceTone8.Checked,
                                ExitTone = checkBoxExitTone8.Checked,
                                HoldMusic = checkBoxHoldMusic8.Checked,
                                HoldOn = checkBoxHoldOn8.Checked,
                                HoldCourse = checkBoxHoldCourse8.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval9.Text != "" && comboBoxStartMinuteInterval9.Text != "" && comboBoxStartFormatInterval9.Text != "") &&
                            (comboBoxStopHourInterval9.Text != "" && comboBoxStopMinuteInterval9.Text != "" && comboBoxStopFormatInterval9.Text != "") &&
                            (checkBoxEntranceTone9.Checked == false || checkBoxEntranceTone9.Checked == true) &&
                            (checkBoxExitTone9.Checked == false || checkBoxExitTone9.Checked == true) &&
                            (checkBoxHoldMusic9.Checked == false || checkBoxHoldMusic9.Checked == true) &&
                            (checkBoxHoldOn9.Checked == false || checkBoxHoldOn9.Checked == true) &&
                            (checkBoxHoldCourse9.Checked == false || checkBoxHoldCourse9.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 39,
                                Start = comboBoxStartHourInterval9.Text + ":" + comboBoxStartMinuteInterval9.Text + ":" + "00" + " " + comboBoxStartFormatInterval9.Text,
                                Stop = comboBoxStopHourInterval9.Text + ":" + comboBoxStopMinuteInterval9.Text + ":" + "00" + " " + comboBoxStopFormatInterval9.Text,
                                EntranceTone = checkBoxEntranceTone9.Checked,
                                ExitTone = checkBoxExitTone9.Checked,
                                HoldMusic = checkBoxHoldMusic9.Checked,
                                HoldOn = checkBoxHoldOn9.Checked,
                                HoldCourse = checkBoxHoldCourse9.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval10.Text != "" && comboBoxStartMinuteInterval10.Text != "" && comboBoxStartFormatInterval10.Text != "") &&
                            (comboBoxStopHourInterval10.Text != "" && comboBoxStopMinuteInterval10.Text != "" && comboBoxStopFormatInterval10.Text != "") &&
                            (checkBoxEntranceTone10.Checked == false || checkBoxEntranceTone10.Checked == true) &&
                            (checkBoxExitTone10.Checked == false || checkBoxExitTone10.Checked == true) &&
                            (checkBoxHoldMusic10.Checked == false || checkBoxHoldMusic10.Checked == true) &&
                            (checkBoxHoldOn10.Checked == false || checkBoxHoldOn10.Checked == true) &&
                            (checkBoxHoldCourse10.Checked == false || checkBoxHoldCourse10.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 40,
                                Start = comboBoxStartHourInterval10.Text + ":" + comboBoxStartMinuteInterval10.Text + ":" + "00" + " " + comboBoxStartFormatInterval10.Text,
                                Stop = comboBoxStopHourInterval10.Text + ":" + comboBoxStopMinuteInterval10.Text + ":" + "00" + " " + comboBoxStopFormatInterval10.Text,
                                EntranceTone = checkBoxEntranceTone10.Checked,
                                ExitTone = checkBoxExitTone10.Checked,
                                HoldMusic = checkBoxHoldMusic10.Checked,
                                HoldOn = checkBoxHoldOn10.Checked,
                                HoldCourse = checkBoxHoldCourse10.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        break;

                    case "Vineri":
                        if ((comboBoxStartHourInterval1.Text != "" && comboBoxStartMinuteInterval1.Text != "" && comboBoxStartFormatInterval1.Text != "") &&
                        (comboBoxStopHourInterval1.Text != "" && comboBoxStopMinuteInterval1.Text != "" && comboBoxStopFormatInterval1.Text != "") &&
                        (checkBoxExitTone1.Checked == false || checkBoxExitTone1.Checked == true) &&
                        (checkBoxEntranceTone1.Checked == false || checkBoxEntranceTone1.Checked == true) &&
                        (checkBoxHoldMusic1.Checked == false || checkBoxHoldMusic1.Checked == true) &&
                        (checkBoxHoldOn1.Checked == false || checkBoxHoldOn1.Checked == true) &&
                        (checkBoxHoldCourse1.Checked == false || checkBoxHoldCourse1.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 41,
                                Start = comboBoxStartHourInterval1.Text + ":" + comboBoxStartMinuteInterval1.Text + ":" + "00" + " " + comboBoxStartFormatInterval1.Text,
                                Stop = comboBoxStopHourInterval1.Text + ":" + comboBoxStopMinuteInterval1.Text + ":" + "00" + " " + comboBoxStopFormatInterval1.Text,
                                EntranceTone = checkBoxEntranceTone1.Checked,
                                ExitTone = checkBoxExitTone1.Checked,
                                HoldMusic = checkBoxHoldMusic1.Checked,
                                HoldOn = checkBoxHoldOn1.Checked,
                                HoldCourse = checkBoxHoldCourse1.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval2.Text != "" && comboBoxStartMinuteInterval2.Text != "" && comboBoxStartFormatInterval2.Text != "") &&
                            (comboBoxStopHourInterval2.Text != "" && comboBoxStopMinuteInterval2.Text != "" && comboBoxStopFormatInterval2.Text != "") &&
                            (checkBoxEntranceTone2.Checked == false || checkBoxEntranceTone2.Checked == true) &&
                            (checkBoxExitTone2.Checked == false || checkBoxExitTone2.Checked == true) &&
                            (checkBoxHoldMusic2.Checked == false || checkBoxHoldMusic2.Checked == true) &&
                            (checkBoxHoldOn2.Checked == false || checkBoxHoldOn2.Checked == true) &&
                            (checkBoxHoldCourse2.Checked == false || checkBoxHoldCourse2.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 42,
                                Start = comboBoxStartHourInterval2.Text + ":" + comboBoxStartMinuteInterval2.Text + ":" + "00" + " " + comboBoxStartFormatInterval2.Text,
                                Stop = comboBoxStopHourInterval2.Text + ":" + comboBoxStopMinuteInterval2.Text + ":" + "00" + " " + comboBoxStopFormatInterval2.Text,
                                EntranceTone = checkBoxEntranceTone2.Checked,
                                ExitTone = checkBoxExitTone2.Checked,
                                HoldMusic = checkBoxHoldMusic2.Checked,
                                HoldOn = checkBoxHoldOn2.Checked,
                                HoldCourse = checkBoxHoldCourse2.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval3.Text != "" && comboBoxStartMinuteInterval3.Text != "" && comboBoxStartFormatInterval3.Text != "") &&
                            (comboBoxStopHourInterval3.Text != "" && comboBoxStopMinuteInterval3.Text != "" && comboBoxStopFormatInterval3.Text != "") &&
                            (checkBoxEntranceTone3.Checked == false || checkBoxEntranceTone3.Checked == true) &&
                            (checkBoxExitTone3.Checked == false || checkBoxExitTone3.Checked == true) &&
                            (checkBoxHoldMusic3.Checked == false || checkBoxHoldMusic3.Checked == true) &&
                            (checkBoxHoldOn3.Checked == false || checkBoxHoldOn3.Checked == true) &&
                            (checkBoxHoldCourse3.Checked == false || checkBoxHoldCourse3.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 43,
                                Start = comboBoxStartHourInterval3.Text + ":" + comboBoxStartMinuteInterval3.Text + ":" + "00" + " " + comboBoxStartFormatInterval3.Text,
                                Stop = comboBoxStopHourInterval3.Text + ":" + comboBoxStopMinuteInterval3.Text + ":" + "00" + " " + comboBoxStopFormatInterval3.Text,
                                EntranceTone = checkBoxEntranceTone3.Checked,
                                ExitTone = checkBoxExitTone3.Checked,
                                HoldMusic = checkBoxHoldMusic3.Checked,
                                HoldOn = checkBoxHoldOn3.Checked,
                                HoldCourse = checkBoxHoldCourse3.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval4.Text != "" && comboBoxStartMinuteInterval4.Text != "" && comboBoxStartFormatInterval4.Text != "") &&
                            (comboBoxStopHourInterval4.Text != "" && comboBoxStopMinuteInterval4.Text != "" && comboBoxStopFormatInterval4.Text != "") &&
                            (checkBoxEntranceTone4.Checked == false || checkBoxEntranceTone4.Checked == true) &&
                            (checkBoxExitTone4.Checked == false || checkBoxExitTone4.Checked == true) &&
                            (checkBoxHoldMusic4.Checked == false || checkBoxHoldMusic4.Checked == true) &&
                            (checkBoxHoldOn4.Checked == false || checkBoxHoldOn4.Checked == true) &&
                            (checkBoxHoldCourse4.Checked == false || checkBoxHoldCourse4.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 44,
                                Start = comboBoxStartHourInterval4.Text + ":" + comboBoxStartMinuteInterval4.Text + ":" + "00" + " " + comboBoxStartFormatInterval4.Text,
                                Stop = comboBoxStopHourInterval4.Text + ":" + comboBoxStopMinuteInterval4.Text + ":" + "00" + " " + comboBoxStopFormatInterval4.Text,
                                EntranceTone = checkBoxEntranceTone4.Checked,
                                ExitTone = checkBoxExitTone4.Checked,
                                HoldMusic = checkBoxHoldMusic4.Checked,
                                HoldOn = checkBoxHoldOn4.Checked,
                                HoldCourse = checkBoxHoldCourse4.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval5.Text != "" && comboBoxStartMinuteInterval5.Text != "" && comboBoxStartFormatInterval5.Text != "") &&
                            (comboBoxStopHourInterval5.Text != "" && comboBoxStopMinuteInterval5.Text != "" && comboBoxStopFormatInterval5.Text != "") &&
                            (checkBoxEntranceTone5.Checked == false || checkBoxEntranceTone5.Checked == true) &&
                            (checkBoxExitTone5.Checked == false || checkBoxExitTone5.Checked == true) &&
                            (checkBoxHoldMusic5.Checked == false || checkBoxHoldMusic5.Checked == true) &&
                            (checkBoxHoldOn5.Checked == false || checkBoxHoldOn5.Checked == true) &&
                            (checkBoxHoldCourse5.Checked == false || checkBoxHoldCourse5.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 45,
                                Start = comboBoxStartHourInterval5.Text + ":" + comboBoxStartMinuteInterval5.Text + ":" + "00" + " " + comboBoxStartFormatInterval5.Text,
                                Stop = comboBoxStopHourInterval5.Text + ":" + comboBoxStopMinuteInterval5.Text + ":" + "00" + " " + comboBoxStopFormatInterval5.Text,
                                EntranceTone = checkBoxEntranceTone5.Checked,
                                ExitTone = checkBoxExitTone5.Checked,
                                HoldMusic = checkBoxHoldMusic5.Checked,
                                HoldOn = checkBoxHoldOn5.Checked,
                                HoldCourse = checkBoxHoldCourse5.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval6.Text != "" && comboBoxStartMinuteInterval6.Text != "" && comboBoxStartFormatInterval6.Text != "") &&
                            (comboBoxStopHourInterval6.Text != "" && comboBoxStopMinuteInterval6.Text != "" && comboBoxStopFormatInterval6.Text != "") &&
                            (checkBoxEntranceTone6.Checked == false || checkBoxEntranceTone6.Checked == true) &&
                            (checkBoxExitTone6.Checked == false || checkBoxExitTone6.Checked == true) &&
                            (checkBoxHoldMusic6.Checked == false || checkBoxHoldMusic6.Checked == true) &&
                            (checkBoxHoldOn6.Checked == false || checkBoxHoldOn6.Checked == true) &&
                            (checkBoxHoldCourse6.Checked == false || checkBoxHoldCourse6.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 46,
                                Start = comboBoxStartHourInterval6.Text + ":" + comboBoxStartMinuteInterval6.Text + ":" + "00" + " " + comboBoxStartFormatInterval6.Text,
                                Stop = comboBoxStopHourInterval6.Text + ":" + comboBoxStopMinuteInterval6.Text + ":" + "00" + " " + comboBoxStopFormatInterval6.Text,
                                EntranceTone = checkBoxEntranceTone6.Checked,
                                ExitTone = checkBoxExitTone6.Checked,
                                HoldMusic = checkBoxHoldMusic6.Checked,
                                HoldOn = checkBoxHoldOn6.Checked,
                                HoldCourse = checkBoxHoldCourse6.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval7.Text != "" && comboBoxStartMinuteInterval7.Text != "" && comboBoxStartFormatInterval7.Text != "") &&
                            (comboBoxStopHourInterval7.Text != "" && comboBoxStopMinuteInterval7.Text != "" && comboBoxStopFormatInterval7.Text != "") &&
                            (checkBoxEntranceTone7.Checked == false || checkBoxEntranceTone7.Checked == true) &&
                            (checkBoxExitTone7.Checked == false || checkBoxExitTone7.Checked == true) &&
                            (checkBoxHoldMusic7.Checked == false || checkBoxHoldMusic7.Checked == true) &&
                            (checkBoxHoldOn7.Checked == false || checkBoxHoldOn7.Checked == true) &&
                            (checkBoxHoldCourse7.Checked == false || checkBoxHoldCourse7.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 47,
                                Start = comboBoxStartHourInterval7.Text + ":" + comboBoxStartMinuteInterval7.Text + ":" + "00" + " " + comboBoxStartFormatInterval7.Text,
                                Stop = comboBoxStopHourInterval7.Text + ":" + comboBoxStopMinuteInterval7.Text + ":" + "00" + " " + comboBoxStopFormatInterval7.Text,
                                EntranceTone = checkBoxEntranceTone7.Checked,
                                ExitTone = checkBoxExitTone7.Checked,
                                HoldMusic = checkBoxHoldMusic7.Checked,
                                HoldOn = checkBoxHoldOn7.Checked,
                                HoldCourse = checkBoxHoldCourse7.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval8.Text != "" && comboBoxStartMinuteInterval8.Text != "" && comboBoxStartFormatInterval8.Text != "") &&
                            (comboBoxStopHourInterval8.Text != "" && comboBoxStopMinuteInterval8.Text != "" && comboBoxStopFormatInterval8.Text != "") &&
                            (checkBoxEntranceTone8.Checked == false || checkBoxEntranceTone8.Checked == true) &&
                            (checkBoxExitTone8.Checked == false || checkBoxExitTone8.Checked == true) &&
                            (checkBoxHoldMusic8.Checked == false || checkBoxHoldMusic8.Checked == true) &&
                            (checkBoxHoldOn8.Checked == false || checkBoxHoldOn8.Checked == true) &&
                            (checkBoxHoldCourse8.Checked == false || checkBoxHoldCourse8.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 48,
                                Start = comboBoxStartHourInterval8.Text + ":" + comboBoxStartMinuteInterval8.Text + ":" + "00" + " " + comboBoxStartFormatInterval8.Text,
                                Stop = comboBoxStopHourInterval8.Text + ":" + comboBoxStopMinuteInterval8.Text + ":" + "00" + " " + comboBoxStopFormatInterval8.Text,
                                EntranceTone = checkBoxEntranceTone8.Checked,
                                ExitTone = checkBoxExitTone8.Checked,
                                HoldMusic = checkBoxHoldMusic8.Checked,
                                HoldOn = checkBoxHoldOn8.Checked,
                                HoldCourse = checkBoxHoldCourse8.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval9.Text != "" && comboBoxStartMinuteInterval9.Text != "" && comboBoxStartFormatInterval9.Text != "") &&
                            (comboBoxStopHourInterval9.Text != "" && comboBoxStopMinuteInterval9.Text != "" && comboBoxStopFormatInterval9.Text != "") &&
                            (checkBoxEntranceTone9.Checked == false || checkBoxEntranceTone9.Checked == true) &&
                            (checkBoxExitTone9.Checked == false || checkBoxExitTone9.Checked == true) &&
                            (checkBoxHoldMusic9.Checked == false || checkBoxHoldMusic9.Checked == true) &&
                            (checkBoxHoldOn9.Checked == false || checkBoxHoldOn9.Checked == true) &&
                            (checkBoxHoldCourse9.Checked == false || checkBoxHoldCourse9.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 49,
                                Start = comboBoxStartHourInterval9.Text + ":" + comboBoxStartMinuteInterval9.Text + ":" + "00" + " " + comboBoxStartFormatInterval9.Text,
                                Stop = comboBoxStopHourInterval9.Text + ":" + comboBoxStopMinuteInterval9.Text + ":" + "00" + " " + comboBoxStopFormatInterval9.Text,
                                EntranceTone = checkBoxEntranceTone9.Checked,
                                ExitTone = checkBoxExitTone9.Checked,
                                HoldMusic = checkBoxHoldMusic9.Checked,
                                HoldOn = checkBoxHoldOn9.Checked,
                                HoldCourse = checkBoxHoldCourse9.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval10.Text != "" && comboBoxStartMinuteInterval10.Text != "" && comboBoxStartFormatInterval10.Text != "") &&
                            (comboBoxStopHourInterval10.Text != "" && comboBoxStopMinuteInterval10.Text != "" && comboBoxStopFormatInterval10.Text != "") &&
                            (checkBoxEntranceTone10.Checked == false || checkBoxEntranceTone10.Checked == true) &&
                            (checkBoxExitTone10.Checked == false || checkBoxExitTone10.Checked == true) &&
                            (checkBoxHoldMusic10.Checked == false || checkBoxHoldMusic10.Checked == true) &&
                            (checkBoxHoldOn10.Checked == false || checkBoxHoldOn10.Checked == true) &&
                            (checkBoxHoldCourse10.Checked == false || checkBoxHoldCourse10.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 50,
                                Start = comboBoxStartHourInterval10.Text + ":" + comboBoxStartMinuteInterval10.Text + ":" + "00" + " " + comboBoxStartFormatInterval10.Text,
                                Stop = comboBoxStopHourInterval10.Text + ":" + comboBoxStopMinuteInterval10.Text + ":" + "00" + " " + comboBoxStopFormatInterval10.Text,
                                EntranceTone = checkBoxEntranceTone10.Checked,
                                ExitTone = checkBoxExitTone10.Checked,
                                HoldMusic = checkBoxHoldMusic10.Checked,
                                HoldOn = checkBoxHoldOn10.Checked,
                                HoldCourse = checkBoxHoldCourse10.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        break;

                    case "Sambata":
                        if ((comboBoxStartHourInterval1.Text != "" && comboBoxStartMinuteInterval1.Text != "" && comboBoxStartFormatInterval1.Text != "") &&
                        (comboBoxStopHourInterval1.Text != "" && comboBoxStopMinuteInterval1.Text != "" && comboBoxStopFormatInterval1.Text != "") &&
                        (checkBoxExitTone1.Checked == false || checkBoxExitTone1.Checked == true) &&
                        (checkBoxEntranceTone1.Checked == false || checkBoxEntranceTone1.Checked == true) &&
                        (checkBoxHoldMusic1.Checked == false || checkBoxHoldMusic1.Checked == true) &&
                        (checkBoxHoldOn1.Checked == false || checkBoxHoldOn1.Checked == true) &&
                        (checkBoxHoldCourse1.Checked == false || checkBoxHoldCourse1.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 51,
                                Start = comboBoxStartHourInterval1.Text + ":" + comboBoxStartMinuteInterval1.Text + ":" + "00" + " " + comboBoxStartFormatInterval1.Text,
                                Stop = comboBoxStopHourInterval1.Text + ":" + comboBoxStopMinuteInterval1.Text + ":" + "00" + " " + comboBoxStopFormatInterval1.Text,
                                EntranceTone = checkBoxEntranceTone1.Checked,
                                ExitTone = checkBoxExitTone1.Checked,
                                HoldMusic = checkBoxHoldMusic1.Checked,
                                HoldOn = checkBoxHoldOn1.Checked,
                                HoldCourse = checkBoxHoldCourse1.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval2.Text != "" && comboBoxStartMinuteInterval2.Text != "" && comboBoxStartFormatInterval2.Text != "") &&
                            (comboBoxStopHourInterval2.Text != "" && comboBoxStopMinuteInterval2.Text != "" && comboBoxStopFormatInterval2.Text != "") &&
                            (checkBoxEntranceTone2.Checked == false || checkBoxEntranceTone2.Checked == true) &&
                            (checkBoxExitTone2.Checked == false || checkBoxExitTone2.Checked == true) &&
                            (checkBoxHoldMusic2.Checked == false || checkBoxHoldMusic2.Checked == true) &&
                            (checkBoxHoldOn2.Checked == false || checkBoxHoldOn2.Checked == true) &&
                            (checkBoxHoldCourse2.Checked == false || checkBoxHoldCourse2.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 52,
                                Start = comboBoxStartHourInterval2.Text + ":" + comboBoxStartMinuteInterval2.Text + ":" + "00" + " " + comboBoxStartFormatInterval2.Text,
                                Stop = comboBoxStopHourInterval2.Text + ":" + comboBoxStopMinuteInterval2.Text + ":" + "00" + " " + comboBoxStopFormatInterval2.Text,
                                EntranceTone = checkBoxEntranceTone2.Checked,
                                ExitTone = checkBoxExitTone2.Checked,
                                HoldMusic = checkBoxHoldMusic2.Checked,
                                HoldOn = checkBoxHoldOn2.Checked,
                                HoldCourse = checkBoxHoldCourse2.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval3.Text != "" && comboBoxStartMinuteInterval3.Text != "" && comboBoxStartFormatInterval3.Text != "") &&
                            (comboBoxStopHourInterval3.Text != "" && comboBoxStopMinuteInterval3.Text != "" && comboBoxStopFormatInterval3.Text != "") &&
                            (checkBoxEntranceTone3.Checked == false || checkBoxEntranceTone3.Checked == true) &&
                            (checkBoxExitTone3.Checked == false || checkBoxExitTone3.Checked == true) &&
                            (checkBoxHoldMusic3.Checked == false || checkBoxHoldMusic3.Checked == true) &&
                            (checkBoxHoldOn3.Checked == false || checkBoxHoldOn3.Checked == true) &&
                            (checkBoxHoldCourse3.Checked == false || checkBoxHoldCourse3.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 53,
                                Start = comboBoxStartHourInterval3.Text + ":" + comboBoxStartMinuteInterval3.Text + ":" + "00" + " " + comboBoxStartFormatInterval3.Text,
                                Stop = comboBoxStopHourInterval3.Text + ":" + comboBoxStopMinuteInterval3.Text + ":" + "00" + " " + comboBoxStopFormatInterval3.Text,
                                EntranceTone = checkBoxEntranceTone3.Checked,
                                ExitTone = checkBoxExitTone3.Checked,
                                HoldMusic = checkBoxHoldMusic3.Checked,
                                HoldOn = checkBoxHoldOn3.Checked,
                                HoldCourse = checkBoxHoldCourse3.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval4.Text != "" && comboBoxStartMinuteInterval4.Text != "" && comboBoxStartFormatInterval4.Text != "") &&
                            (comboBoxStopHourInterval4.Text != "" && comboBoxStopMinuteInterval4.Text != "" && comboBoxStopFormatInterval4.Text != "") &&
                            (checkBoxEntranceTone4.Checked == false || checkBoxEntranceTone4.Checked == true) &&
                            (checkBoxExitTone4.Checked == false || checkBoxExitTone4.Checked == true) &&
                            (checkBoxHoldMusic4.Checked == false || checkBoxHoldMusic4.Checked == true) &&
                            (checkBoxHoldOn4.Checked == false || checkBoxHoldOn4.Checked == true) &&
                            (checkBoxHoldCourse4.Checked == false || checkBoxHoldCourse4.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 54,
                                Start = comboBoxStartHourInterval4.Text + ":" + comboBoxStartMinuteInterval4.Text + ":" + "00" + " " + comboBoxStartFormatInterval4.Text,
                                Stop = comboBoxStopHourInterval4.Text + ":" + comboBoxStopMinuteInterval4.Text + ":" + "00" + " " + comboBoxStopFormatInterval4.Text,
                                EntranceTone = checkBoxEntranceTone4.Checked,
                                ExitTone = checkBoxExitTone4.Checked,
                                HoldMusic = checkBoxHoldMusic4.Checked,
                                HoldOn = checkBoxHoldOn4.Checked,
                                HoldCourse = checkBoxHoldCourse4.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval5.Text != "" && comboBoxStartMinuteInterval5.Text != "" && comboBoxStartFormatInterval5.Text != "") &&
                            (comboBoxStopHourInterval5.Text != "" && comboBoxStopMinuteInterval5.Text != "" && comboBoxStopFormatInterval5.Text != "") &&
                            (checkBoxEntranceTone5.Checked == false || checkBoxEntranceTone5.Checked == true) &&
                            (checkBoxExitTone5.Checked == false || checkBoxExitTone5.Checked == true) &&
                            (checkBoxHoldMusic5.Checked == false || checkBoxHoldMusic5.Checked == true) &&
                            (checkBoxHoldOn5.Checked == false || checkBoxHoldOn5.Checked == true) &&
                            (checkBoxHoldCourse5.Checked == false || checkBoxHoldCourse5.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 55,
                                Start = comboBoxStartHourInterval5.Text + ":" + comboBoxStartMinuteInterval5.Text + ":" + "00" + " " + comboBoxStartFormatInterval5.Text,
                                Stop = comboBoxStopHourInterval5.Text + ":" + comboBoxStopMinuteInterval5.Text + ":" + "00" + " " + comboBoxStopFormatInterval5.Text,
                                EntranceTone = checkBoxEntranceTone5.Checked,
                                ExitTone = checkBoxExitTone5.Checked,
                                HoldMusic = checkBoxHoldMusic5.Checked,
                                HoldOn = checkBoxHoldOn5.Checked,
                                HoldCourse = checkBoxHoldCourse5.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval6.Text != "" && comboBoxStartMinuteInterval6.Text != "" && comboBoxStartFormatInterval6.Text != "") &&
                            (comboBoxStopHourInterval6.Text != "" && comboBoxStopMinuteInterval6.Text != "" && comboBoxStopFormatInterval6.Text != "") &&
                            (checkBoxEntranceTone6.Checked == false || checkBoxEntranceTone6.Checked == true) &&
                            (checkBoxExitTone6.Checked == false || checkBoxExitTone6.Checked == true) &&
                            (checkBoxHoldMusic6.Checked == false || checkBoxHoldMusic6.Checked == true) &&
                            (checkBoxHoldOn6.Checked == false || checkBoxHoldOn6.Checked == true) &&
                            (checkBoxHoldCourse6.Checked == false || checkBoxHoldCourse6.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 56,
                                Start = comboBoxStartHourInterval6.Text + ":" + comboBoxStartMinuteInterval6.Text + ":" + "00" + " " + comboBoxStartFormatInterval6.Text,
                                Stop = comboBoxStopHourInterval6.Text + ":" + comboBoxStopMinuteInterval6.Text + ":" + "00" + " " + comboBoxStopFormatInterval6.Text,
                                EntranceTone = checkBoxEntranceTone6.Checked,
                                ExitTone = checkBoxExitTone6.Checked,
                                HoldMusic = checkBoxHoldMusic6.Checked,
                                HoldOn = checkBoxHoldOn6.Checked,
                                HoldCourse = checkBoxHoldCourse6.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval7.Text != "" && comboBoxStartMinuteInterval7.Text != "" && comboBoxStartFormatInterval7.Text != "") &&
                            (comboBoxStopHourInterval7.Text != "" && comboBoxStopMinuteInterval7.Text != "" && comboBoxStopFormatInterval7.Text != "") &&
                            (checkBoxEntranceTone7.Checked == false || checkBoxEntranceTone7.Checked == true) &&
                            (checkBoxExitTone7.Checked == false || checkBoxExitTone7.Checked == true) &&
                            (checkBoxHoldMusic7.Checked == false || checkBoxHoldMusic7.Checked == true) &&
                            (checkBoxHoldOn7.Checked == false || checkBoxHoldOn7.Checked == true) &&
                            (checkBoxHoldCourse7.Checked == false || checkBoxHoldCourse7.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 57,
                                Start = comboBoxStartHourInterval7.Text + ":" + comboBoxStartMinuteInterval7.Text + ":" + "00" + " " + comboBoxStartFormatInterval7.Text,
                                Stop = comboBoxStopHourInterval7.Text + ":" + comboBoxStopMinuteInterval7.Text + ":" + "00" + " " + comboBoxStopFormatInterval7.Text,
                                EntranceTone = checkBoxEntranceTone7.Checked,
                                ExitTone = checkBoxExitTone7.Checked,
                                HoldMusic = checkBoxHoldMusic7.Checked,
                                HoldOn = checkBoxHoldOn7.Checked,
                                HoldCourse = checkBoxHoldCourse7.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval8.Text != "" && comboBoxStartMinuteInterval8.Text != "" && comboBoxStartFormatInterval8.Text != "") &&
                            (comboBoxStopHourInterval8.Text != "" && comboBoxStopMinuteInterval8.Text != "" && comboBoxStopFormatInterval8.Text != "") &&
                            (checkBoxEntranceTone8.Checked == false || checkBoxEntranceTone8.Checked == true) &&
                            (checkBoxExitTone8.Checked == false || checkBoxExitTone8.Checked == true) &&
                            (checkBoxHoldMusic8.Checked == false || checkBoxHoldMusic8.Checked == true) &&
                            (checkBoxHoldOn8.Checked == false || checkBoxHoldOn8.Checked == true) &&
                            (checkBoxHoldCourse8.Checked == false || checkBoxHoldCourse8.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 58,
                                Start = comboBoxStartHourInterval8.Text + ":" + comboBoxStartMinuteInterval8.Text + ":" + "00" + " " + comboBoxStartFormatInterval8.Text,
                                Stop = comboBoxStopHourInterval8.Text + ":" + comboBoxStopMinuteInterval8.Text + ":" + "00" + " " + comboBoxStopFormatInterval8.Text,
                                EntranceTone = checkBoxEntranceTone8.Checked,
                                ExitTone = checkBoxExitTone8.Checked,
                                HoldMusic = checkBoxHoldMusic8.Checked,
                                HoldOn = checkBoxHoldOn8.Checked,
                                HoldCourse = checkBoxHoldCourse8.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval9.Text != "" && comboBoxStartMinuteInterval9.Text != "" && comboBoxStartFormatInterval9.Text != "") &&
                            (comboBoxStopHourInterval9.Text != "" && comboBoxStopMinuteInterval9.Text != "" && comboBoxStopFormatInterval9.Text != "") &&
                            (checkBoxEntranceTone9.Checked == false || checkBoxEntranceTone9.Checked == true) &&
                            (checkBoxExitTone9.Checked == false || checkBoxExitTone9.Checked == true) &&
                            (checkBoxHoldMusic9.Checked == false || checkBoxHoldMusic9.Checked == true) &&
                            (checkBoxHoldOn9.Checked == false || checkBoxHoldOn9.Checked == true) &&
                            (checkBoxHoldCourse9.Checked == false || checkBoxHoldCourse9.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 59,
                                Start = comboBoxStartHourInterval9.Text + ":" + comboBoxStartMinuteInterval9.Text + ":" + "00" + " " + comboBoxStartFormatInterval9.Text,
                                Stop = comboBoxStopHourInterval9.Text + ":" + comboBoxStopMinuteInterval9.Text + ":" + "00" + " " + comboBoxStopFormatInterval9.Text,
                                EntranceTone = checkBoxEntranceTone9.Checked,
                                ExitTone = checkBoxExitTone9.Checked,
                                HoldMusic = checkBoxHoldMusic9.Checked,
                                HoldOn = checkBoxHoldOn9.Checked,
                                HoldCourse = checkBoxHoldCourse9.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval10.Text != "" && comboBoxStartMinuteInterval10.Text != "" && comboBoxStartFormatInterval10.Text != "") &&
                            (comboBoxStopHourInterval10.Text != "" && comboBoxStopMinuteInterval10.Text != "" && comboBoxStopFormatInterval10.Text != "") &&
                            (checkBoxEntranceTone10.Checked == false || checkBoxEntranceTone10.Checked == true) &&
                            (checkBoxExitTone10.Checked == false || checkBoxExitTone10.Checked == true) &&
                            (checkBoxHoldMusic10.Checked == false || checkBoxHoldMusic10.Checked == true) &&
                            (checkBoxHoldOn10.Checked == false || checkBoxHoldOn10.Checked == true) &&
                            (checkBoxHoldCourse10.Checked == false || checkBoxHoldCourse10.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 60,
                                Start = comboBoxStartHourInterval10.Text + ":" + comboBoxStartMinuteInterval10.Text + ":" + "00" + " " + comboBoxStartFormatInterval10.Text,
                                Stop = comboBoxStopHourInterval10.Text + ":" + comboBoxStopMinuteInterval10.Text + ":" + "00" + " " + comboBoxStopFormatInterval10.Text,
                                EntranceTone = checkBoxEntranceTone10.Checked,
                                ExitTone = checkBoxExitTone10.Checked,
                                HoldMusic = checkBoxHoldMusic10.Checked,
                                HoldOn = checkBoxHoldOn10.Checked,
                                HoldCourse = checkBoxHoldCourse10.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        break;

                    case "Duminica":
                        if ((comboBoxStartHourInterval1.Text != "" && comboBoxStartMinuteInterval1.Text != "" && comboBoxStartFormatInterval1.Text != "") &&
                        (comboBoxStopHourInterval1.Text != "" && comboBoxStopMinuteInterval1.Text != "" && comboBoxStopFormatInterval1.Text != "") &&
                        (checkBoxExitTone1.Checked == false || checkBoxExitTone1.Checked == true) &&
                        (checkBoxEntranceTone1.Checked == false || checkBoxEntranceTone1.Checked == true) &&
                        (checkBoxHoldMusic1.Checked == false || checkBoxHoldMusic1.Checked == true) &&
                        (checkBoxHoldOn1.Checked == false || checkBoxHoldOn1.Checked == true) &&
                        (checkBoxHoldCourse1.Checked == false || checkBoxHoldCourse1.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 61,
                                Start = comboBoxStartHourInterval1.Text + ":" + comboBoxStartMinuteInterval1.Text + ":" + "00" + " " + comboBoxStartFormatInterval1.Text,
                                Stop = comboBoxStopHourInterval1.Text + ":" + comboBoxStopMinuteInterval1.Text + ":" + "00" + " " + comboBoxStopFormatInterval1.Text,
                                EntranceTone = checkBoxEntranceTone1.Checked,
                                ExitTone = checkBoxExitTone1.Checked,
                                HoldMusic = checkBoxHoldMusic1.Checked,
                                HoldOn = checkBoxHoldOn1.Checked,
                                HoldCourse = checkBoxHoldCourse1.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval2.Text != "" && comboBoxStartMinuteInterval2.Text != "" && comboBoxStartFormatInterval2.Text != "") &&
                            (comboBoxStopHourInterval2.Text != "" && comboBoxStopMinuteInterval2.Text != "" && comboBoxStopFormatInterval2.Text != "") &&
                            (checkBoxEntranceTone2.Checked == false || checkBoxEntranceTone2.Checked == true) &&
                            (checkBoxExitTone2.Checked == false || checkBoxExitTone2.Checked == true) &&
                            (checkBoxHoldMusic2.Checked == false || checkBoxHoldMusic2.Checked == true) &&
                            (checkBoxHoldOn2.Checked == false || checkBoxHoldOn2.Checked == true) &&
                            (checkBoxHoldCourse2.Checked == false || checkBoxHoldCourse2.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 62,
                                Start = comboBoxStartHourInterval2.Text + ":" + comboBoxStartMinuteInterval2.Text + ":" + "00" + " " + comboBoxStartFormatInterval2.Text,
                                Stop = comboBoxStopHourInterval2.Text + ":" + comboBoxStopMinuteInterval2.Text + ":" + "00" + " " + comboBoxStopFormatInterval2.Text,
                                EntranceTone = checkBoxEntranceTone2.Checked,
                                ExitTone = checkBoxExitTone2.Checked,
                                HoldMusic = checkBoxHoldMusic2.Checked,
                                HoldOn = checkBoxHoldOn2.Checked,
                                HoldCourse = checkBoxHoldCourse2.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval3.Text != "" && comboBoxStartMinuteInterval3.Text != "" && comboBoxStartFormatInterval3.Text != "") &&
                            (comboBoxStopHourInterval3.Text != "" && comboBoxStopMinuteInterval3.Text != "" && comboBoxStopFormatInterval3.Text != "") &&
                            (checkBoxEntranceTone3.Checked == false || checkBoxEntranceTone3.Checked == true) &&
                            (checkBoxExitTone3.Checked == false || checkBoxExitTone3.Checked == true) &&
                            (checkBoxHoldMusic3.Checked == false || checkBoxHoldMusic3.Checked == true) &&
                            (checkBoxHoldOn3.Checked == false || checkBoxHoldOn3.Checked == true) &&
                            (checkBoxHoldCourse3.Checked == false || checkBoxHoldCourse3.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 63,
                                Start = comboBoxStartHourInterval3.Text + ":" + comboBoxStartMinuteInterval3.Text + ":" + "00" + " " + comboBoxStartFormatInterval3.Text,
                                Stop = comboBoxStopHourInterval3.Text + ":" + comboBoxStopMinuteInterval3.Text + ":" + "00" + " " + comboBoxStopFormatInterval3.Text,
                                EntranceTone = checkBoxEntranceTone3.Checked,
                                ExitTone = checkBoxExitTone3.Checked,
                                HoldMusic = checkBoxHoldMusic3.Checked,
                                HoldOn = checkBoxHoldOn3.Checked,
                                HoldCourse = checkBoxHoldCourse3.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval4.Text != "" && comboBoxStartMinuteInterval4.Text != "" && comboBoxStartFormatInterval4.Text != "") &&
                            (comboBoxStopHourInterval4.Text != "" && comboBoxStopMinuteInterval4.Text != "" && comboBoxStopFormatInterval4.Text != "") &&
                            (checkBoxEntranceTone4.Checked == false || checkBoxEntranceTone4.Checked == true) &&
                            (checkBoxExitTone4.Checked == false || checkBoxExitTone4.Checked == true) &&
                            (checkBoxHoldMusic4.Checked == false || checkBoxHoldMusic4.Checked == true) &&
                            (checkBoxHoldOn4.Checked == false || checkBoxHoldOn4.Checked == true) &&
                            (checkBoxHoldCourse4.Checked == false || checkBoxHoldCourse4.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 64,
                                Start = comboBoxStartHourInterval4.Text + ":" + comboBoxStartMinuteInterval4.Text + ":" + "00" + " " + comboBoxStartFormatInterval4.Text,
                                Stop = comboBoxStopHourInterval4.Text + ":" + comboBoxStopMinuteInterval4.Text + ":" + "00" + " " + comboBoxStopFormatInterval4.Text,
                                EntranceTone = checkBoxEntranceTone4.Checked,
                                ExitTone = checkBoxExitTone4.Checked,
                                HoldMusic = checkBoxHoldMusic4.Checked,
                                HoldOn = checkBoxHoldOn4.Checked,
                                HoldCourse = checkBoxHoldCourse4.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval5.Text != "" && comboBoxStartMinuteInterval5.Text != "" && comboBoxStartFormatInterval5.Text != "") &&
                            (comboBoxStopHourInterval5.Text != "" && comboBoxStopMinuteInterval5.Text != "" && comboBoxStopFormatInterval5.Text != "") &&
                            (checkBoxEntranceTone5.Checked == false || checkBoxEntranceTone5.Checked == true) &&
                            (checkBoxExitTone5.Checked == false || checkBoxExitTone5.Checked == true) &&
                            (checkBoxHoldMusic5.Checked == false || checkBoxHoldMusic5.Checked == true) &&
                            (checkBoxHoldOn5.Checked == false || checkBoxHoldOn5.Checked == true) &&
                            (checkBoxHoldCourse5.Checked == false || checkBoxHoldCourse5.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 65,
                                Start = comboBoxStartHourInterval5.Text + ":" + comboBoxStartMinuteInterval5.Text + ":" + "00" + " " + comboBoxStartFormatInterval5.Text,
                                Stop = comboBoxStopHourInterval5.Text + ":" + comboBoxStopMinuteInterval5.Text + ":" + "00" + " " + comboBoxStopFormatInterval5.Text,
                                EntranceTone = checkBoxEntranceTone5.Checked,
                                ExitTone = checkBoxExitTone5.Checked,
                                HoldMusic = checkBoxHoldMusic5.Checked,
                                HoldOn = checkBoxHoldOn5.Checked,
                                HoldCourse = checkBoxHoldCourse5.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval6.Text != "" && comboBoxStartMinuteInterval6.Text != "" && comboBoxStartFormatInterval6.Text != "") &&
                            (comboBoxStopHourInterval6.Text != "" && comboBoxStopMinuteInterval6.Text != "" && comboBoxStopFormatInterval6.Text != "") &&
                            (checkBoxEntranceTone6.Checked == false || checkBoxEntranceTone6.Checked == true) &&
                            (checkBoxExitTone6.Checked == false || checkBoxExitTone6.Checked == true) &&
                            (checkBoxHoldMusic6.Checked == false || checkBoxHoldMusic6.Checked == true) &&
                            (checkBoxHoldOn6.Checked == false || checkBoxHoldOn6.Checked == true) &&
                            (checkBoxHoldCourse6.Checked == false || checkBoxHoldCourse6.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 66,
                                Start = comboBoxStartHourInterval6.Text + ":" + comboBoxStartMinuteInterval6.Text + ":" + "00" + " " + comboBoxStartFormatInterval6.Text,
                                Stop = comboBoxStopHourInterval6.Text + ":" + comboBoxStopMinuteInterval6.Text + ":" + "00" + " " + comboBoxStopFormatInterval6.Text,
                                EntranceTone = checkBoxEntranceTone6.Checked,
                                ExitTone = checkBoxExitTone6.Checked,
                                HoldMusic = checkBoxHoldMusic6.Checked,
                                HoldOn = checkBoxHoldOn6.Checked,
                                HoldCourse = checkBoxHoldCourse6.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval7.Text != "" && comboBoxStartMinuteInterval7.Text != "" && comboBoxStartFormatInterval7.Text != "") &&
                            (comboBoxStopHourInterval7.Text != "" && comboBoxStopMinuteInterval7.Text != "" && comboBoxStopFormatInterval7.Text != "") &&
                            (checkBoxEntranceTone7.Checked == false || checkBoxEntranceTone7.Checked == true) &&
                            (checkBoxExitTone7.Checked == false || checkBoxExitTone7.Checked == true) &&
                            (checkBoxHoldMusic7.Checked == false || checkBoxHoldMusic7.Checked == true) &&
                            (checkBoxHoldOn7.Checked == false || checkBoxHoldOn7.Checked == true) &&
                            (checkBoxHoldCourse7.Checked == false || checkBoxHoldCourse7.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 67,
                                Start = comboBoxStartHourInterval7.Text + ":" + comboBoxStartMinuteInterval7.Text + ":" + "00" + " " + comboBoxStartFormatInterval7.Text,
                                Stop = comboBoxStopHourInterval7.Text + ":" + comboBoxStopMinuteInterval7.Text + ":" + "00" + " " + comboBoxStopFormatInterval7.Text,
                                EntranceTone = checkBoxEntranceTone7.Checked,
                                ExitTone = checkBoxExitTone7.Checked,
                                HoldMusic = checkBoxHoldMusic7.Checked,
                                HoldOn = checkBoxHoldOn7.Checked,
                                HoldCourse = checkBoxHoldCourse7.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval8.Text != "" && comboBoxStartMinuteInterval8.Text != "" && comboBoxStartFormatInterval8.Text != "") &&
                            (comboBoxStopHourInterval8.Text != "" && comboBoxStopMinuteInterval8.Text != "" && comboBoxStopFormatInterval8.Text != "") &&
                            (checkBoxEntranceTone8.Checked == false || checkBoxEntranceTone8.Checked == true) &&
                            (checkBoxExitTone8.Checked == false || checkBoxExitTone8.Checked == true) &&
                            (checkBoxHoldMusic8.Checked == false || checkBoxHoldMusic8.Checked == true) &&
                            (checkBoxHoldOn8.Checked == false || checkBoxHoldOn8.Checked == true) &&
                            (checkBoxHoldCourse8.Checked == false || checkBoxHoldCourse8.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 68,
                                Start = comboBoxStartHourInterval8.Text + ":" + comboBoxStartMinuteInterval8.Text + ":" + "00" + " " + comboBoxStartFormatInterval8.Text,
                                Stop = comboBoxStopHourInterval8.Text + ":" + comboBoxStopMinuteInterval8.Text + ":" + "00" + " " + comboBoxStopFormatInterval8.Text,
                                EntranceTone = checkBoxEntranceTone8.Checked,
                                ExitTone = checkBoxExitTone8.Checked,
                                HoldMusic = checkBoxHoldMusic8.Checked,
                                HoldOn = checkBoxHoldOn8.Checked,
                                HoldCourse = checkBoxHoldCourse8.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval9.Text != "" && comboBoxStartMinuteInterval9.Text != "" && comboBoxStartFormatInterval9.Text != "") &&
                            (comboBoxStopHourInterval9.Text != "" && comboBoxStopMinuteInterval9.Text != "" && comboBoxStopFormatInterval9.Text != "") &&
                            (checkBoxEntranceTone9.Checked == false || checkBoxEntranceTone9.Checked == true) &&
                            (checkBoxExitTone9.Checked == false || checkBoxExitTone9.Checked == true) &&
                            (checkBoxHoldMusic9.Checked == false || checkBoxHoldMusic9.Checked == true) &&
                            (checkBoxHoldOn9.Checked == false || checkBoxHoldOn9.Checked == true) &&
                            (checkBoxHoldCourse9.Checked == false || checkBoxHoldCourse9.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 69,
                                Start = comboBoxStartHourInterval9.Text + ":" + comboBoxStartMinuteInterval9.Text + ":" + "00" + " " + comboBoxStartFormatInterval9.Text,
                                Stop = comboBoxStopHourInterval9.Text + ":" + comboBoxStopMinuteInterval9.Text + ":" + "00" + " " + comboBoxStopFormatInterval9.Text,
                                EntranceTone = checkBoxEntranceTone9.Checked,
                                ExitTone = checkBoxExitTone9.Checked,
                                HoldMusic = checkBoxHoldMusic9.Checked,
                                HoldOn = checkBoxHoldOn9.Checked,
                                HoldCourse = checkBoxHoldCourse9.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        if ((comboBoxStartHourInterval10.Text != "" && comboBoxStartMinuteInterval10.Text != "" && comboBoxStartFormatInterval10.Text != "") &&
                            (comboBoxStopHourInterval10.Text != "" && comboBoxStopMinuteInterval10.Text != "" && comboBoxStopFormatInterval10.Text != "") &&
                            (checkBoxEntranceTone10.Checked == false || checkBoxEntranceTone10.Checked == true) &&
                            (checkBoxExitTone10.Checked == false || checkBoxExitTone10.Checked == true) &&
                            (checkBoxHoldMusic10.Checked == false || checkBoxHoldMusic10.Checked == true) &&
                            (checkBoxHoldOn10.Checked == false || checkBoxHoldOn10.Checked == true) &&
                            (checkBoxHoldCourse10.Checked == false || checkBoxHoldCourse10.Checked == true))
                        {
                            TimeInterval timeIntervalObject = new TimeInterval()
                            {
                                Id = 70,
                                Start = comboBoxStartHourInterval10.Text + ":" + comboBoxStartMinuteInterval10.Text + ":" + "00" + " " + comboBoxStartFormatInterval10.Text,
                                Stop = comboBoxStopHourInterval10.Text + ":" + comboBoxStopMinuteInterval10.Text + ":" + "00" + " " + comboBoxStopFormatInterval10.Text,
                                EntranceTone = checkBoxEntranceTone10.Checked,
                                ExitTone = checkBoxExitTone10.Checked,
                                HoldMusic = checkBoxHoldMusic10.Checked,
                                HoldOn = checkBoxHoldOn10.Checked,
                                HoldCourse = checkBoxHoldCourse10.Checked
                            };
                            timeInterval.Add(timeIntervalObject);
                            sqliteCommand = new SqliteCommand(
                                "update TimeInterval" +
                                " set " + "Start" + " = " + "@Start" + ", " +
                                          "Stop" + " = " + "@Stop" + ", " +
                                          "ExitTone" + " = " + "@ExitTone" + ", " +
                                          "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                          "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                          "HoldOn" + " = " + "@HoldOn" + ", " +
                                          "HoldCourse" + " = " + "@HoldCourse " +
                                          "where Id = " + "@Id" + ";", sqliteConnection);

                            sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                            sqliteCommand.Parameters["@Id"].Value = timeIntervalObject.Id;
                            sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                            sqliteCommand.Parameters["@Start"].Value = timeIntervalObject.Start;
                            sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                            sqliteCommand.Parameters["@Stop"].Value = timeIntervalObject.Stop;
                            sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@ExitTone"].Value = timeIntervalObject.ExitTone;
                            sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                            sqliteCommand.Parameters["@EntranceTone"].Value = timeIntervalObject.EntranceTone;
                            sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldMusic"].Value = timeIntervalObject.HoldMusic;
                            sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldOn"].Value = timeIntervalObject.HoldOn;
                            sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                            sqliteCommand.Parameters["@HoldCourse"].Value = timeIntervalObject.HoldCourse;

                            sqliteCommand.ExecuteNonQuery();
                        }
                        break;
                }
            }

            PopulateIntervalsAndChecksSelectingDay();
        }

        private string GetDatabasePath()
        {
            // Obține folderul unde rulează aplicația (ex: C:\Proiect\Bin\Debug\)
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combină folderul cu numele fișierului bazei de date într-un mod sigur
            // Path.Combine se ocupă singur de backslash-uri (\)
            return Path.Combine(baseDirectory, "ClassBellProjectDatabase.db");
        }

        // 1. Definim connection string-ul într-un singur loc (ex: variabilă globală sau setare)
        private string GetConnectionString()
        {
            // Dacă baza de date este în folderul binar al aplicației:
            return $"Data Source={GetDatabasePath()}";
        }

        // 2. Metoda unificată care înlocuiește vechea dependență
        public List<TimeInterval> GetIntervalsAndChecksFromDatabase(int? cycleId = null, int? dayId = null)
        {
            var timeIntervals = new List<TimeInterval>();

            using (var connection = new SqliteConnection(GetConnectionString()))
            {
                connection.Open();

                // Construim SQL-ul dinamic în funcție de filtre
                string sql = "SELECT * FROM TimeInterval WHERE 1 = 1";
                if (cycleId.HasValue) sql += " AND CycleId = @cycleId";
                if (dayId.HasValue) sql += " AND DayId = @dayId";

                using (var command = new SqliteCommand(sql, connection))
                {
                    if (cycleId.HasValue) command.Parameters.AddWithValue("@cycleId", cycleId.Value);
                    if (dayId.HasValue) command.Parameters.AddWithValue("@dayId", dayId.Value);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            timeIntervals.Add(new TimeInterval
                            {
                                Id = reader.GetInt32(0),
                                CycleId = reader.GetInt32(1),
                                DayId = reader.GetInt32(2),
                                Start = reader.GetString(3),
                                Stop = reader.GetString(4),
                                ExitTone = reader.GetBoolean(5), // SqliteDataReader știe să facă singur conversia 0/1 -> bool
                                EntranceTone = reader.GetBoolean(6),
                                HoldMusic = reader.GetBoolean(7),
                                HoldOn = reader.GetBoolean(8),
                                HoldCourse = reader.GetBoolean(9)
                            });
                        }
                    }
                }
            }

            return timeIntervals;
        }

        public void PopulateIntervalsAndChecksSelectingDay()
        {
            string dayChecked = string.Empty;

            List<TimeInterval> IntervalsAndChecksPrimary = GetIntervalsAndChecksFromDatabase();

            string[] startIntervalComponents;
            string[] timeStartIntervalComponents;
            string[] stopIntervalComponents;
            string[] timeStopIntervalComponents;

            dayChecked = listBoxSelectDayPrimary.SelectedItem.ToString();
            switch (dayChecked)
            {
                case "Luni":
                    if (IntervalsAndChecksPrimary[0].Start != "" && IntervalsAndChecksPrimary[0].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[0].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[0].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksPrimary[0].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksPrimary[0].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksPrimary[0].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksPrimary[0].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksPrimary[0].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[1].Start != "" && IntervalsAndChecksPrimary[1].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[1].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[1].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksPrimary[1].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksPrimary[1].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksPrimary[1].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksPrimary[1].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksPrimary[1].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[2].Start != "" && IntervalsAndChecksPrimary[2].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[2].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[2].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksPrimary[2].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksPrimary[2].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksPrimary[2].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksPrimary[2].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksPrimary[2].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[3].Start != "" && IntervalsAndChecksPrimary[3].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[3].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[3].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksPrimary[3].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksPrimary[3].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksPrimary[3].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksPrimary[3].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksPrimary[3].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[4].Start != "" && IntervalsAndChecksPrimary[4].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[4].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[4].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksPrimary[4].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksPrimary[4].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksPrimary[4].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksPrimary[4].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksPrimary[4].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[5].Start != "" && IntervalsAndChecksPrimary[5].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[5].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[5].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksPrimary[5].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksPrimary[5].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksPrimary[5].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksPrimary[5].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksPrimary[5].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[6].Start != "" && IntervalsAndChecksPrimary[6].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[6].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[6].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksPrimary[6].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksPrimary[6].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksPrimary[6].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksPrimary[6].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksPrimary[6].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[7].Start != "" && IntervalsAndChecksPrimary[7].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[7].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[7].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksPrimary[7].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksPrimary[7].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksPrimary[7].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksPrimary[7].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksPrimary[7].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[8].Start != "" && IntervalsAndChecksPrimary[8].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[8].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[8].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksPrimary[8].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksPrimary[8].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksPrimary[8].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksPrimary[8].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksPrimary[8].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[9].Start != "" && IntervalsAndChecksPrimary[9].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[9].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[9].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksPrimary[9].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksPrimary[9].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksPrimary[9].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksPrimary[9].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksPrimary[9].HoldCourse;
                    }

                    break;

                case "Marti":
                    if (IntervalsAndChecksPrimary[10].Start != "" && IntervalsAndChecksPrimary[10].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[10].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[10].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksPrimary[10].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksPrimary[10].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksPrimary[10].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksPrimary[10].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksPrimary[10].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[11].Start != "" && IntervalsAndChecksPrimary[11].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[11].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[11].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksPrimary[11].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksPrimary[11].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksPrimary[11].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksPrimary[11].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksPrimary[11].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[12].Start != "" && IntervalsAndChecksPrimary[12].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[12].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[12].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksPrimary[12].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksPrimary[2].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksPrimary[12].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksPrimary[12].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksPrimary[12].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[13].Start != "" && IntervalsAndChecksPrimary[13].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[13].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[13].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksPrimary[13].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksPrimary[13].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksPrimary[13].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksPrimary[13].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksPrimary[13].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[14].Start != "" && IntervalsAndChecksPrimary[14].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[14].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[14].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksPrimary[14].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksPrimary[14].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksPrimary[14].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksPrimary[14].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksPrimary[14].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[15].Start != "" && IntervalsAndChecksPrimary[15].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[15].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[15].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksPrimary[15].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksPrimary[15].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksPrimary[15].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksPrimary[15].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksPrimary[15].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[16].Start != "" && IntervalsAndChecksPrimary[16].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[16].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[16].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksPrimary[16].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksPrimary[16].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksPrimary[16].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksPrimary[16].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksPrimary[16].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[17].Start != "" && IntervalsAndChecksPrimary[17].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[17].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[17].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksPrimary[17].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksPrimary[17].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksPrimary[17].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksPrimary[17].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksPrimary[17].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[18].Start != "" && IntervalsAndChecksPrimary[18].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[18].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[18].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksPrimary[18].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksPrimary[18].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksPrimary[18].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksPrimary[18].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksPrimary[18].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[19].Start != "" && IntervalsAndChecksPrimary[19].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[19].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[19].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksPrimary[19].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksPrimary[19].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksPrimary[19].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksPrimary[19].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksPrimary[19].HoldCourse;
                    }

                    break;

                case "Miercuri":
                    if (IntervalsAndChecksPrimary[20].Start != "" && IntervalsAndChecksPrimary[20].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[20].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[20].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksPrimary[20].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksPrimary[20].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksPrimary[20].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksPrimary[20].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksPrimary[20].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[21].Start != "" && IntervalsAndChecksPrimary[21].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[21].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[21].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksPrimary[21].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksPrimary[21].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksPrimary[21].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksPrimary[21].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksPrimary[21].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[22].Start != "" && IntervalsAndChecksPrimary[22].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[22].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[22].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksPrimary[22].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksPrimary[22].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksPrimary[22].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksPrimary[22].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksPrimary[22].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[23].Start != "" && IntervalsAndChecksPrimary[23].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[23].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[23].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksPrimary[23].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksPrimary[23].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksPrimary[23].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksPrimary[23].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksPrimary[23].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[24].Start != "" && IntervalsAndChecksPrimary[24].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[24].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[24].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksPrimary[24].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksPrimary[24].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksPrimary[24].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksPrimary[24].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksPrimary[24].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[25].Start != "" && IntervalsAndChecksPrimary[25].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[25].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[25].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksPrimary[25].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksPrimary[25].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksPrimary[25].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksPrimary[25].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksPrimary[25].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[26].Start != "" && IntervalsAndChecksPrimary[26].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[26].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[26].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksPrimary[26].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksPrimary[26].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksPrimary[26].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksPrimary[26].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksPrimary[26].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[27].Start != "" && IntervalsAndChecksPrimary[27].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[27].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[27].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksPrimary[27].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksPrimary[27].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksPrimary[27].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksPrimary[27].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksPrimary[27].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[28].Start != "" && IntervalsAndChecksPrimary[28].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[28].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[28].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksPrimary[28].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksPrimary[28].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksPrimary[28].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksPrimary[28].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksPrimary[28].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[29].Start != "" && IntervalsAndChecksPrimary[29].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[29].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[29].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksPrimary[29].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksPrimary[29].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksPrimary[29].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksPrimary[29].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksPrimary[29].HoldCourse;
                    }

                    break;

                case "Joi":
                    if (IntervalsAndChecksPrimary[30].Start != "" && IntervalsAndChecksPrimary[30].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[30].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[30].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksPrimary[30].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksPrimary[30].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksPrimary[30].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksPrimary[30].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksPrimary[30].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[31].Start != "" && IntervalsAndChecksPrimary[31].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[31].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[31].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksPrimary[31].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksPrimary[31].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksPrimary[31].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksPrimary[31].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksPrimary[31].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[32].Start != "" && IntervalsAndChecksPrimary[32].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[32].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[32].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksPrimary[32].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksPrimary[32].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksPrimary[32].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksPrimary[32].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksPrimary[32].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[33].Start != "" && IntervalsAndChecksPrimary[33].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[33].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[33].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksPrimary[33].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksPrimary[33].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksPrimary[33].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksPrimary[33].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksPrimary[33].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[34].Start != "" && IntervalsAndChecksPrimary[34].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[34].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[34].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksPrimary[34].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksPrimary[34].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksPrimary[34].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksPrimary[34].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksPrimary[34].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[35].Start != "" && IntervalsAndChecksPrimary[35].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[35].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[35].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksPrimary[35].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksPrimary[35].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksPrimary[35].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksPrimary[35].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksPrimary[35].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[36].Start != "" && IntervalsAndChecksPrimary[36].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[36].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[36].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksPrimary[36].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksPrimary[36].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksPrimary[36].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksPrimary[36].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksPrimary[36].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[37].Start != "" && IntervalsAndChecksPrimary[37].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[37].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[37].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksPrimary[37].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksPrimary[37].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksPrimary[37].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksPrimary[37].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksPrimary[37].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[38].Start != "" && IntervalsAndChecksPrimary[38].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[38].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[38].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksPrimary[38].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksPrimary[38].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksPrimary[38].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksPrimary[38].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksPrimary[38].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[39].Start != "" && IntervalsAndChecksPrimary[39].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[39].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[39].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksPrimary[39].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksPrimary[39].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksPrimary[39].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksPrimary[39].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksPrimary[39].HoldCourse;
                    }

                    break;

                case "Vineri":
                    if (IntervalsAndChecksPrimary[40].Start != "" && IntervalsAndChecksPrimary[40].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[40].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[40].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksPrimary[40].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksPrimary[40].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksPrimary[40].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksPrimary[40].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksPrimary[40].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[41].Start != "" && IntervalsAndChecksPrimary[41].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[41].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[41].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksPrimary[41].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksPrimary[41].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksPrimary[41].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksPrimary[41].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksPrimary[41].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[42].Start != "" && IntervalsAndChecksPrimary[42].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[42].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[42].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksPrimary[42].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksPrimary[42].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksPrimary[42].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksPrimary[42].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksPrimary[42].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[43].Start != "" && IntervalsAndChecksPrimary[43].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[43].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[43].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksPrimary[43].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksPrimary[43].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksPrimary[43].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksPrimary[43].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksPrimary[43].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[44].Start != "" && IntervalsAndChecksPrimary[44].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[44].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[44].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksPrimary[44].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksPrimary[44].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksPrimary[44].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksPrimary[44].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksPrimary[44].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[45].Start != "" && IntervalsAndChecksPrimary[45].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[45].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[45].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksPrimary[45].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksPrimary[45].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksPrimary[45].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksPrimary[45].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksPrimary[45].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[46].Start != "" && IntervalsAndChecksPrimary[46].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[46].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[46].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksPrimary[46].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksPrimary[46].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksPrimary[46].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksPrimary[46].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksPrimary[46].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[47].Start != "" && IntervalsAndChecksPrimary[47].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[47].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[47].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksPrimary[47].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksPrimary[47].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksPrimary[47].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksPrimary[47].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksPrimary[47].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[48].Start != "" && IntervalsAndChecksPrimary[48].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[48].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[48].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksPrimary[48].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksPrimary[48].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksPrimary[48].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksPrimary[48].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksPrimary[48].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[49].Start != "" && IntervalsAndChecksPrimary[49].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[49].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[49].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksPrimary[49].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksPrimary[49].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksPrimary[49].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksPrimary[49].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksPrimary[49].HoldCourse;
                    }

                    break;

                case "Sambata":
                    if (IntervalsAndChecksPrimary[50].Start != "" && IntervalsAndChecksPrimary[50].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[50].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[50].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksPrimary[50].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksPrimary[50].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksPrimary[50].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksPrimary[50].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksPrimary[50].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[51].Start != "" && IntervalsAndChecksPrimary[51].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[51].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[51].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksPrimary[51].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksPrimary[51].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksPrimary[51].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksPrimary[51].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksPrimary[51].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[52].Start != "" && IntervalsAndChecksPrimary[52].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[52].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[52].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksPrimary[52].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksPrimary[52].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksPrimary[52].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksPrimary[52].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksPrimary[52].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[53].Start != "" && IntervalsAndChecksPrimary[53].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[53].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[53].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksPrimary[53].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksPrimary[53].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksPrimary[53].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksPrimary[53].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksPrimary[53].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[54].Start != "" && IntervalsAndChecksPrimary[54].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[54].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[54].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksPrimary[54].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksPrimary[54].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksPrimary[54].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksPrimary[54].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksPrimary[54].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[55].Start != "" && IntervalsAndChecksPrimary[55].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[55].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[55].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksPrimary[55].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksPrimary[55].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksPrimary[55].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksPrimary[55].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksPrimary[55].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[56].Start != "" && IntervalsAndChecksPrimary[56].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[56].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[56].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksPrimary[56].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksPrimary[56].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksPrimary[56].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksPrimary[56].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksPrimary[56].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[57].Start != "" && IntervalsAndChecksPrimary[57].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[57].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[57].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksPrimary[57].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksPrimary[57].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksPrimary[57].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksPrimary[57].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksPrimary[57].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[58].Start != "" && IntervalsAndChecksPrimary[58].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[58].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[58].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksPrimary[58].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksPrimary[58].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksPrimary[58].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksPrimary[58].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksPrimary[58].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[59].Start != "" && IntervalsAndChecksPrimary[59].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[59].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[59].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksPrimary[59].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksPrimary[59].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksPrimary[59].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksPrimary[59].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksPrimary[59].HoldCourse;
                    }

                    break;

                case "Duminica":
                    if (IntervalsAndChecksPrimary[60].Start != "" && IntervalsAndChecksPrimary[60].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[60].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[60].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksPrimary[60].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksPrimary[60].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksPrimary[60].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksPrimary[60].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksPrimary[60].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[61].Start != "" && IntervalsAndChecksPrimary[61].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[61].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[61].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksPrimary[61].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksPrimary[61].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksPrimary[61].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksPrimary[61].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksPrimary[61].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[62].Start != "" && IntervalsAndChecksPrimary[62].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[62].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[62].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksPrimary[62].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksPrimary[62].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksPrimary[62].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksPrimary[62].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksPrimary[62].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[63].Start != "" && IntervalsAndChecksPrimary[63].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[63].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[63].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksPrimary[63].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksPrimary[63].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksPrimary[63].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksPrimary[63].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksPrimary[63].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[64].Start != "" && IntervalsAndChecksPrimary[64].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[64].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[64].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksPrimary[64].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksPrimary[64].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksPrimary[64].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksPrimary[64].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksPrimary[64].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[65].Start != "" && IntervalsAndChecksPrimary[65].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[65].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[65].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksPrimary[65].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksPrimary[65].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksPrimary[65].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksPrimary[65].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksPrimary[65].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[66].Start != "" && IntervalsAndChecksPrimary[66].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[66].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[66].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksPrimary[66].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksPrimary[66].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksPrimary[66].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksPrimary[66].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksPrimary[66].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[67].Start != "" && IntervalsAndChecksPrimary[67].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[67].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[67].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksPrimary[67].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksPrimary[67].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksPrimary[67].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksPrimary[67].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksPrimary[67].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[68].Start != "" && IntervalsAndChecksPrimary[68].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[68].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[68].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksPrimary[68].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksPrimary[68].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksPrimary[68].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksPrimary[68].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksPrimary[68].HoldCourse;
                    }

                    if (IntervalsAndChecksPrimary[69].Start != "" && IntervalsAndChecksPrimary[69].Stop != "")
                    {
                        startIntervalComponents = IntervalsAndChecksPrimary[69].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksPrimary[69].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksPrimary[69].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksPrimary[69].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksPrimary[69].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksPrimary[69].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksPrimary[69].HoldCourse;
                    }

                    break;
            }
        }

        // Definirea la nivel de clasă
        private CancellationTokenSource ctsPrimary;

        private async void buttonStartIntervalsAndDaysPrimary_ClickAsync(object sender, EventArgs e)
        {
            if (ctsPrimary != null) return; // Deja rulează

            // Luăm zilele folosind metoda universală pe care am discutat-o anterior
            List<string> daysSelected = GetDaysSelectedForPrimary();

            if (daysSelected.Count == 0)
            {
                MessageBox.Show("Selectează zilele pentru ciclul primar!");
                return;
            }

            buttonStartIntervalsAndDaysPrimary.Enabled = false;
            ctsPrimary = new CancellationTokenSource();

            try
            {
                // Pornim procesul
                await StartSongsAndTonesPrimaryAsync(ctsPrimary.Token);
            }
            catch (OperationCanceledException)
            {
                // Este normal să ajungem aici când apăsăm STOP, nu facem nimic special
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
            finally
            {
                // Curățăm CTS-ul când task-ul se termină (prin eroare sau stop)
                ctsPrimary = null;
                buttonStartIntervalsAndDaysPrimary.Enabled = true;
            }
        }

        private void buttonStopIntervalsAndDaysPrimary_Click(object sender, EventArgs e)
        {
            if (ctsPrimary != null)
            {
                ctsPrimary.Cancel();
                ctsPrimary.Dispose(); // Foarte important să eliberezi resursele
                ctsPrimary = null;
            }

            soundPlayerForASongPrimary.Stop();
            soundPlayerForATonePrimary.Stop();

            buttonStartIntervalsAndDaysPrimary.Enabled = true;
        }

        private void listBoxSelectDayPrimary_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateIntervalsAndChecksSelectingDay();
        }

        private void buttonUpdateIntervalsAndChecksForACertainDay_Click(object sender, EventArgs e)
        {
            UpdateIntervalsAndChecksPrimaryForACertainDayInDatabase();
        }
    }
}