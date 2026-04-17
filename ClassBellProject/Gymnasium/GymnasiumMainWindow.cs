using ClassBellProject.Gymnasium;
using ClassBellProject.Primary;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SqlClient;
using System.Media;

namespace ClassBellProject.Gymnasium
{
    public partial class GymnasiumMainWindow : Form
    {
        public GymnasiumMainWindow()
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

        SoundPlayer soundPlayerForASongGymnasium = new SoundPlayer();
        SoundPlayer soundPlayerForAToneGymnasium = new SoundPlayer();

        List<string> hours = new List<string>()
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
        List<string> minutes = new List<string>()
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
        List<string> formats = new List<string>()
        {
            "AM",
            "PM"
        };
        string dayChecked;
        List<string> days = new List<string>();

        public List<string> GetDaysSelected()
        {
            List<string> daysChecked = new List<string>();

            days = checkedListBoxDaysGymnasium.Items.Cast<string>().ToList();

            foreach (string day in days)
            {
                if (checkedListBoxDaysGymnasium.CheckedItems.Contains(day))
                {
                    switch (day)
                    {
                        case "Luni":
                            daysChecked.Add(DayOfWeek.Monday.ToString());
                            break;
                        case "Marti":
                            daysChecked.Add(DayOfWeek.Tuesday.ToString());
                            break;
                        case "Miercuri":
                            daysChecked.Add(DayOfWeek.Wednesday.ToString());
                            break;
                        case "Joi":
                            daysChecked.Add(DayOfWeek.Thursday.ToString());
                            break;
                        case "Vineri":
                            daysChecked.Add(DayOfWeek.Friday.ToString());
                            break;
                        case "Sambata":
                            daysChecked.Add(DayOfWeek.Saturday.ToString());
                            break;
                        case "Duminica":
                            daysChecked.Add(DayOfWeek.Sunday.ToString());
                            break;
                    }
                }
            }

            return daysChecked;
        }

        public async Task StartSongsAndTonesByIntervalsAndDaysGymnasiumAsync()
        {
            Dictionary<int, string> indexesAndDays = new Dictionary<int, string>()
            {
                {1,  "Monday"},
                {2,  "Tuesday"},
                {3,  "Wednesday"},
                {4,  "Thursday"},
                {5,  "Friday"},
                {6,  "Saturday"},
                {7,  "Sunday"}
            };

            List<IntervalsAndChecksGymnasium> IntervalsAndChecksGymnasium = new List<IntervalsAndChecksGymnasium>();
            List<string> daysSelected = GetDaysSelected();
            List<string> nextDaysForActualDay = new List<string>();
            int nextDayPosition = 0;
            for (int k = 0; k < daysSelected.Count - 1; k++)
            {
                nextDayPosition = indexesAndDays.FirstOrDefault(x => x.Value == daysSelected[k + 1]).Key;
                nextDaysForActualDay.Add(indexesAndDays[nextDayPosition]);
            }

            for (int i = 0; i < daysSelected.Count; i++)
            {
                if (daysSelected[i] == DateTime.Now.DayOfWeek.ToString())
                {
                    int[] shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                    int songCursor = 0;
                    int indexNumber = 0;
                    int actualDayKeyForIntervalsAndChecks = indexesAndDays.FirstOrDefault(x => x.Value == daysSelected[i]).Key;
                    List<IntervalsAndChecksGymnasium> actualIntervalsAndChecksByDayId = GetAllIntervalsAndChecksGymnasiumByDayId(actualDayKeyForIntervalsAndChecks);

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[0].Start != "" && actualIntervalsAndChecksByDayId[0].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[0].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[0].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[0].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[0].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[0].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[0].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[0].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[0].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[0].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[0].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[1].Start != "" && actualIntervalsAndChecksByDayId[1].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[1].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[1].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[1].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[1].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[1].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[1].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[1].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[1].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[1].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[1].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[2].Start != "" && actualIntervalsAndChecksByDayId[2].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[2].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[2].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[2].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[2].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[2].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[2].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[2].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[2].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[2].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[2].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[3].Start != "" && actualIntervalsAndChecksByDayId[3].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[3].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[3].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[3].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[3].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[3].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[3].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[3].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[3].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[3].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[3].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[4].Start != "" && actualIntervalsAndChecksByDayId[4].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[4].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[4].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[4].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[4].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[4].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[4].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[4].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[4].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[4].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[4].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[5].Start != "" && actualIntervalsAndChecksByDayId[5].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[5].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[5].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[5].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[5].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[5].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[5].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[5].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[5].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[5].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[5].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[6].Start != "" && actualIntervalsAndChecksByDayId[6].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[6].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[6].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[6].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[6].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[6].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[6].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[6].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[6].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[6].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[6].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[7].Start != "" && actualIntervalsAndChecksByDayId[7].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[7].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[7].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[7].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[7].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[7].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[7].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[7].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[7].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[7].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[7].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[8].Start != "" && actualIntervalsAndChecksByDayId[8].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[8].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[8].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[8].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[8].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[8].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[8].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[8].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[8].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[8].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[8].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    if (indexNumber < actualIntervalsAndChecksByDayId.Count)
                    {
                        if (actualIntervalsAndChecksByDayId[9].Start != "" && actualIntervalsAndChecksByDayId[9].Stop != "" &&
                            DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[9].Stop))
                        {
                            if (actualIntervalsAndChecksByDayId[9].HoldOn == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[9].Start)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[9].ExitTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(1);
                            }
                            if (actualIntervalsAndChecksByDayId[9].HoldCourse == true)
                            {
                                await Task.Delay((int)Math.Abs(DateTime.Now.Subtract(DateTime.Parse(actualIntervalsAndChecksByDayId[9].Stop)).TotalMilliseconds));
                            }
                            if (actualIntervalsAndChecksByDayId[9].HoldMusic == true)
                            {
                                while (DateTime.Parse(DateTime.Now.ToLongTimeString()) < DateTime.Parse(actualIntervalsAndChecksByDayId[9].Stop))
                                {
                                    await StartASongByPositionAndTimeGymnasiumAsync(shuffleSongsGymnasium[songCursor], DateTime.Parse(actualIntervalsAndChecksByDayId[9].Stop));
                                    songCursor++;
                                    if (songCursor == shuffleSongsGymnasium.Length)
                                    {
                                        songCursor = 0;
                                        shuffleSongsGymnasium = ShuffleAllSongsGymnasium();
                                    }
                                }
                            }
                            if (actualIntervalsAndChecksByDayId[9].EntranceTone == true)
                            {
                                await StartAToneByPositionGymnasiumAsync(0);
                            }
                        }
                    }
                    indexNumber++;

                    int actualDayKey = 0;
                    int nextDayKey = 0;
                    string startIntervalNextDayValue = string.Empty;
                    string stopIntervalActualDayValue = string.Empty;
                    if (daysSelected.Count > 1)
                    {
                        if (i < daysSelected.Count - 1)
                        {
                            nextDayKey = indexesAndDays.FirstOrDefault(x => x.Value == nextDaysForActualDay[i]).Key;
                            actualDayKey = indexesAndDays.FirstOrDefault(x => x.Value == daysSelected[i]).Key;
                            startIntervalNextDayValue = GetStartIntervalGymnasiumByDayId(nextDayKey);
                            stopIntervalActualDayValue = GetStopIntervalGymnasiumByDayId(actualDayKey);
                        }
                        else
                        {
                            break;
                        }
                        if (nextDayKey - actualDayKey - 1 == 0)
                        {
                            await Task.Delay((int)Math.Abs(86400000 - Math.Abs(DateTime.Parse(stopIntervalActualDayValue).
                                                                      Subtract(DateTime.Parse(startIntervalNextDayValue)).TotalMilliseconds)));
                        }
                        else
                        {
                            if (nextDayKey - actualDayKey - 1 > 0)
                            {
                                await Task.Delay((int)Math.Abs(86400000 - Math.Abs(DateTime.Parse(stopIntervalActualDayValue).
                                                               Subtract(DateTime.Parse(startIntervalNextDayValue)).TotalMilliseconds)) +
                                                              (nextDayKey - actualDayKey - 1) * 86400000);
                            }
                        }
                    }
                }
            }
        }

        public string GetStartIntervalGymnasiumByDayId(int dayId)
        {
            string startIntervalGymnasium = string.Empty;
            List<IntervalsAndChecksGymnasium> IntervalsAndChecksGymnasium = ReadIntervalsAndChecksGymnasiumFromDatabase();
            for (int iterator = 0; iterator < IntervalsAndChecksGymnasium.Count; iterator++)
            {
                if (IntervalsAndChecksGymnasium[iterator].DayGymnasiumId == dayId &&
                    IntervalsAndChecksGymnasium[iterator].Start != "" &&
                    IntervalsAndChecksGymnasium[iterator].Stop != "")
                {
                    startIntervalGymnasium = IntervalsAndChecksGymnasium[iterator].Start;
                    break;
                }
            }

            return startIntervalGymnasium;
        }

        public string GetStopIntervalGymnasiumByDayId(int dayId)
        {
            string stopIntervalGymnasium = string.Empty;
            List<IntervalsAndChecksGymnasium> IntervalsAndChecksGymnasium = ReadIntervalsAndChecksGymnasiumFromDatabase();
            for (int iterator = 0; iterator < IntervalsAndChecksGymnasium.Count; iterator++)
            {
                if (IntervalsAndChecksGymnasium[iterator].DayGymnasiumId == dayId &&
                    IntervalsAndChecksGymnasium[iterator].Start != "" &&
                    IntervalsAndChecksGymnasium[iterator].Stop != "")
                {
                    stopIntervalGymnasium = IntervalsAndChecksGymnasium[iterator].Stop;
                }
            }

            return stopIntervalGymnasium;
        }

        public List<IntervalsAndChecksGymnasium> GetAllIntervalsAndChecksGymnasiumByDayId(int dayId)
        {
            List<IntervalsAndChecksGymnasium> IntervalsAndChecksGymnasiumToReturn = new List<IntervalsAndChecksGymnasium>();
            List<IntervalsAndChecksGymnasium> IntervalsAndChecksGymnasium = ReadIntervalsAndChecksGymnasiumFromDatabase();
            for (int iterator = 0; iterator < IntervalsAndChecksGymnasium.Count; iterator++)
            {
                if (IntervalsAndChecksGymnasium[iterator].DayGymnasiumId == dayId &&
                    IntervalsAndChecksGymnasium[iterator].Start != "" &&
                    IntervalsAndChecksGymnasium[iterator].Stop != "")
                {
                    IntervalsAndChecksGymnasiumToReturn.Add(IntervalsAndChecksGymnasium[iterator]);
                }
            }

            return IntervalsAndChecksGymnasiumToReturn;
        }

        public string[] GetAllSongsGymnasium()
        {
            string[] names = Directory.GetCurrentDirectory().Split("\\");
            string namesComposed = string.Empty;
            int iterator = 0;
            foreach (string name in names)
            {
                namesComposed = namesComposed + name + "\\";
                iterator++;
                if (iterator == 5)
                {
                    break;
                }
            }
            namesComposed = namesComposed + "Songs Gymnasium";
            string[] files = Directory.GetFiles(namesComposed);

            return files;
        }

        public string[] GetAllTonesGymnasium()
        {
            string[] names = Directory.GetCurrentDirectory().Split("\\");
            string namesComposed = string.Empty;
            int iterator = 0;
            foreach (string name in names)
            {
                namesComposed = namesComposed + name + "\\";
                iterator++;
                if (iterator == 5)
                {
                    break;
                }
            }
            namesComposed = namesComposed + "Tones Gymnasium";
            string[] files = Directory.GetFiles(namesComposed);

            return files;
        }

        public decimal GetNumberOfSecondsOfASongGymnasium(string songLength)
        {
            FileInfo fileInfo = new FileInfo(songLength);
            int sample_rate = 44100;
            int Integer_depth = 16;
            int channels = 2;
            long file_size = fileInfo.Length;
            decimal duration = file_size / (sample_rate * (Integer_depth / 8) * channels);
            decimal result = Math.Round(duration);

            return result;
        }

        public decimal GetNumberOfSecondsOfAToneGymnasium(string toneLength)
        {
            FileInfo fileInfo = new FileInfo(toneLength);
            int sample_rate = 44100;
            int Integer_depth = 16;
            int channels = 2;
            long file_size = fileInfo.Length;
            decimal duration = file_size / (sample_rate * (Integer_depth / 8) * channels);
            decimal result = Math.Round(duration);

            return result;
        }

        public async Task StartASongByPositionAndTimeGymnasiumAsync(int position, DateTime dateTime)
        {
            string[] songsGymnasium = GetAllSongsGymnasium();
            soundPlayerForASongGymnasium.SoundLocation = songsGymnasium[position];
            decimal songDuration = GetNumberOfSecondsOfASongGymnasium(songsGymnasium[position]);
            int Interval = (int)(songDuration * 1000);
            if (dateTime.Subtract(DateTime.Now).TotalMilliseconds > Interval)
            {
                soundPlayerForASongGymnasium.Play();
                await Task.Delay(Interval);
            }
            else
            {
                soundPlayerForASongGymnasium.Play();
                await Task.Delay((int)Math.Abs(dateTime.Subtract(DateTime.Now).TotalMilliseconds));
            }
        }

        public async Task StartAToneByPositionGymnasiumAsync(int position)
        {
            string[] tonesGymnasium = GetAllTonesGymnasium();
            soundPlayerForAToneGymnasium.SoundLocation = tonesGymnasium[position];
            decimal songDuration = GetNumberOfSecondsOfAToneGymnasium(tonesGymnasium[position]);
            int Interval = (int)(songDuration * 1000);
            soundPlayerForAToneGymnasium.Play();
            await Task.Delay(Interval);
        }

        public int[] ShuffleAllSongsGymnasium()
        {
            string[] songsGymnasium = GetAllSongsGymnasium();
            int[] indexes = new int[songsGymnasium.Length];
            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = -1;
            }
            Random random = new Random();
            int iterator = 0;
            while (iterator < songsGymnasium.Length)
            {
                int number = random.Next(0, songsGymnasium.Length);
                if (!indexes.Contains(number))
                {
                    indexes[iterator] = number;
                    iterator++;
                }
            }

            return indexes;
        }

        public void UpdateTableIntervalsAndChecksGymnasiumForACertainDayInDatabase()
        {
            string connectionString = @"Data Source=C:\Users\ComputerName\Desktop\ClassBellProject\ClassBellProjectDatabase.db;";
            SqliteConnection sqliteConnection = new SqliteConnection(connectionString);
            sqliteConnection.Open();
            SqliteCommand sqliteCommand;
            List<IntervalsAndChecksGymnasium> IntervalsAndChecksGymnasium = new List<IntervalsAndChecksGymnasium>();

            dayChecked = listBoxSelectDayGymnasium.SelectedItem.ToString();
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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

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
                        IntervalsAndChecksGymnasium IntervalsAndChecksGymnasiumObject = new IntervalsAndChecksGymnasium()
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
                        IntervalsAndChecksGymnasium.Add(IntervalsAndChecksGymnasiumObject);
                        sqliteCommand = new SqliteCommand(
                            "update IntervalsAndChecksGymnasium" +
                            " set " + "Start" + " = " + "@Start" + ", " +
                                      "Stop" + " = " + "@Stop" + ", " +
                                      "ExitTone" + " = " + "@ExitTone" + ", " +
                                      "EntranceTone" + " = " + "@EntranceTone" + ", " +
                                      "HoldMusic" + " = " + "@HoldMusic" + ", " +
                                      "HoldOn" + " = " + "@HoldOn" + ", " +
                                      "HoldCourse" + " = " + "@HoldCourse " +
                                      "where Id = " + "@Id" + ";", sqliteConnection);

                        sqliteCommand.Parameters.Add("@Id", SqliteType.Integer);
                        sqliteCommand.Parameters["@Id"].Value = IntervalsAndChecksGymnasiumObject.Id;
                        sqliteCommand.Parameters.Add("@Start", SqliteType.Text);
                        sqliteCommand.Parameters["@Start"].Value = IntervalsAndChecksGymnasiumObject.Start;
                        sqliteCommand.Parameters.Add("@Stop", SqliteType.Text);
                        sqliteCommand.Parameters["@Stop"].Value = IntervalsAndChecksGymnasiumObject.Stop;
                        sqliteCommand.Parameters.Add("@ExitTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@ExitTone"].Value = IntervalsAndChecksGymnasiumObject.ExitTone;
                        sqliteCommand.Parameters.Add("@EntranceTone", SqliteType.Integer);
                        sqliteCommand.Parameters["@EntranceTone"].Value = IntervalsAndChecksGymnasiumObject.EntranceTone;
                        sqliteCommand.Parameters.Add("@HoldMusic", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldMusic"].Value = IntervalsAndChecksGymnasiumObject.HoldMusic;
                        sqliteCommand.Parameters.Add("@HoldOn", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldOn"].Value = IntervalsAndChecksGymnasiumObject.HoldOn;
                        sqliteCommand.Parameters.Add("@HoldCourse", SqliteType.Integer);
                        sqliteCommand.Parameters["@HoldCourse"].Value = IntervalsAndChecksGymnasiumObject.HoldCourse;

                        sqliteCommand.ExecuteNonQuery();
                    }
                    break;
            }
        }

        public List<IntervalsAndChecksGymnasium> ReadIntervalsAndChecksGymnasiumFromDatabase()
        {
            string connectionString = @"Data Source=C:\Users\ComputerName\Desktop\ClassBellProject\ClassBellProjectDatabase.db;";
            SqliteConnection sqliteConnection = new SqliteConnection(connectionString);
            sqliteConnection.Open();
            SqliteCommand sqliteCommand = new SqliteCommand("select * from IntervalsAndChecksGymnasium;", sqliteConnection);
            SqliteDataReader reader = sqliteCommand.ExecuteReader();
            List<IntervalsAndChecksGymnasium> IntervalsAndChecksGymnasium = new List<IntervalsAndChecksGymnasium>();
            while (reader.Read())
            {
                IntervalsAndChecksGymnasium.Add(new IntervalsAndChecksGymnasium()
                {
                    Id = (int)(long)reader.GetValue(0),
                    DayGymnasiumId = (int)(long)reader.GetValue(1),
                    Start = reader.GetValue(2).ToString(),
                    Stop = reader.GetValue(3).ToString(),
                    ExitTone = (int)(long)reader.GetValue(4) != 0,
                    EntranceTone = (int)(long)reader.GetValue(5) != 0,
                    HoldMusic = (int)(long)reader.GetValue(6) != 0,
                    HoldOn = (int)(long)reader.GetValue(7) != 0,
                    HoldCourse = (int)(long)reader.GetValue(8) != 0
                });
            }
            sqliteConnection.Close();

            return IntervalsAndChecksGymnasium;
        }

        public void PopulateIntervalsAndChecksSelectingDay()
        {
            List<IntervalsAndChecksGymnasium> IntervalsAndChecksGymnasium = ReadIntervalsAndChecksGymnasiumFromDatabase();

            string[] startIntervalComponents;
            string[] timeStartIntervalComponents;
            string[] stopIntervalComponents;
            string[] timeStopIntervalComponents;

            dayChecked = listBoxSelectDayGymnasium.SelectedItem.ToString();
            switch (dayChecked)
            {
                case "Luni":
                    if (IntervalsAndChecksGymnasium[0].Start != "" && IntervalsAndChecksGymnasium[0].Stop != "" &&
                        IntervalsAndChecksGymnasium[0].Id == 1)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[0].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[0].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksGymnasium[0].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksGymnasium[0].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksGymnasium[0].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksGymnasium[0].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksGymnasium[0].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[1].Start != "" && IntervalsAndChecksGymnasium[1].Stop != "" &&
                        IntervalsAndChecksGymnasium[1].Id == 2)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[1].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[1].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksGymnasium[1].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksGymnasium[1].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksGymnasium[1].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksGymnasium[1].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksGymnasium[1].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[2].Start != "" && IntervalsAndChecksGymnasium[2].Stop != "" &&
                        IntervalsAndChecksGymnasium[2].Id == 3)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[2].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[2].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksGymnasium[2].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksGymnasium[2].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksGymnasium[2].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksGymnasium[2].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksGymnasium[2].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[3].Start != "" && IntervalsAndChecksGymnasium[3].Stop != "" && 
                        IntervalsAndChecksGymnasium[3].Id == 4)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[3].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[3].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksGymnasium[3].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksGymnasium[3].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksGymnasium[3].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksGymnasium[3].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksGymnasium[3].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[4].Start != "" && IntervalsAndChecksGymnasium[4].Stop != "" &&
                        IntervalsAndChecksGymnasium[4].Id == 5)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[4].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[4].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksGymnasium[4].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksGymnasium[4].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksGymnasium[4].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksGymnasium[4].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksGymnasium[4].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[5].Start != "" && IntervalsAndChecksGymnasium[5].Stop != "" &&
                        IntervalsAndChecksGymnasium[5].Id == 6)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[5].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[5].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksGymnasium[5].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksGymnasium[5].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksGymnasium[5].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksGymnasium[5].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksGymnasium[5].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[6].Start != "" && IntervalsAndChecksGymnasium[6].Stop != "" &&
                        IntervalsAndChecksGymnasium[6].Id == 7)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[6].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[6].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksGymnasium[6].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksGymnasium[6].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksGymnasium[6].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksGymnasium[6].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksGymnasium[6].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[7].Start != "" && IntervalsAndChecksGymnasium[7].Stop != "" &&
                        IntervalsAndChecksGymnasium[7].Id == 8)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[7].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[7].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksGymnasium[7].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksGymnasium[7].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksGymnasium[7].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksGymnasium[7].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksGymnasium[7].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[8].Start != "" && IntervalsAndChecksGymnasium[8].Stop != "" &&
                        IntervalsAndChecksGymnasium[8].Id == 9)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[8].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[8].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksGymnasium[8].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksGymnasium[8].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksGymnasium[8].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksGymnasium[8].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksGymnasium[8].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[9].Start != "" && IntervalsAndChecksGymnasium[9].Stop != "" &&
                        IntervalsAndChecksGymnasium[9].Id == 10)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[9].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[9].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksGymnasium[9].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksGymnasium[9].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksGymnasium[9].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksGymnasium[9].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksGymnasium[9].HoldCourse;
                    }

                    break;

                case "Marti":
                    if (IntervalsAndChecksGymnasium[10].Start != "" && IntervalsAndChecksGymnasium[10].Stop != "" &&
                        IntervalsAndChecksGymnasium[10].Id == 11)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[10].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[10].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksGymnasium[10].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksGymnasium[10].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksGymnasium[10].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksGymnasium[10].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksGymnasium[10].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[11].Start != "" && IntervalsAndChecksGymnasium[11].Stop != "" &&
                        IntervalsAndChecksGymnasium[11].Id == 12)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[11].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[11].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksGymnasium[11].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksGymnasium[11].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksGymnasium[11].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksGymnasium[11].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksGymnasium[11].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[12].Start != "" && IntervalsAndChecksGymnasium[12].Stop != "" &&
                        IntervalsAndChecksGymnasium[12].Id == 13)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[12].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[12].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksGymnasium[12].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksGymnasium[2].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksGymnasium[12].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksGymnasium[12].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksGymnasium[12].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[13].Start != "" && IntervalsAndChecksGymnasium[13].Stop != "" &&
                        IntervalsAndChecksGymnasium[13].Id == 14)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[13].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[13].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksGymnasium[13].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksGymnasium[13].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksGymnasium[13].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksGymnasium[13].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksGymnasium[13].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[14].Start != "" && IntervalsAndChecksGymnasium[14].Stop != "" &&
                        IntervalsAndChecksGymnasium[14].Id == 15)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[14].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[14].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksGymnasium[14].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksGymnasium[14].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksGymnasium[14].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksGymnasium[14].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksGymnasium[14].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[15].Start != "" && IntervalsAndChecksGymnasium[15].Stop != "" &&
                        IntervalsAndChecksGymnasium[15].Id == 16)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[15].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[15].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksGymnasium[15].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksGymnasium[15].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksGymnasium[15].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksGymnasium[15].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksGymnasium[15].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[16].Start != "" && IntervalsAndChecksGymnasium[16].Stop != "" &&
                        IntervalsAndChecksGymnasium[16].Id == 17)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[16].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[16].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksGymnasium[16].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksGymnasium[16].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksGymnasium[16].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksGymnasium[16].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksGymnasium[16].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[17].Start != "" && IntervalsAndChecksGymnasium[17].Stop != "" &&
                        IntervalsAndChecksGymnasium[17].Id == 18)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[17].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[17].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksGymnasium[17].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksGymnasium[17].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksGymnasium[17].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksGymnasium[17].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksGymnasium[17].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[18].Start != "" && IntervalsAndChecksGymnasium[18].Stop != "" &&
                        IntervalsAndChecksGymnasium[18].Id == 19)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[18].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[18].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksGymnasium[18].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksGymnasium[18].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksGymnasium[18].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksGymnasium[18].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksGymnasium[18].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[19].Start != "" && IntervalsAndChecksGymnasium[19].Stop != "" &&
                        IntervalsAndChecksGymnasium[19].Id == 20)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[19].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[19].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksGymnasium[19].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksGymnasium[19].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksGymnasium[19].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksGymnasium[19].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksGymnasium[19].HoldCourse;
                    }

                    break;

                case "Miercuri":
                    if (IntervalsAndChecksGymnasium[20].Start != "" && IntervalsAndChecksGymnasium[20].Stop != "" &&
                        IntervalsAndChecksGymnasium[20].Id == 21)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[20].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[20].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksGymnasium[20].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksGymnasium[20].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksGymnasium[20].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksGymnasium[20].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksGymnasium[20].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[21].Start != "" && IntervalsAndChecksGymnasium[21].Stop != "" &&
                        IntervalsAndChecksGymnasium[21].Id == 22)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[21].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[21].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksGymnasium[21].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksGymnasium[21].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksGymnasium[21].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksGymnasium[21].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksGymnasium[21].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[22].Start != "" && IntervalsAndChecksGymnasium[22].Stop != "" &&
                        IntervalsAndChecksGymnasium[22].Id == 23)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[22].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[22].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksGymnasium[22].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksGymnasium[22].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksGymnasium[22].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksGymnasium[22].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksGymnasium[22].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[23].Start != "" && IntervalsAndChecksGymnasium[23].Stop != "" &&
                        IntervalsAndChecksGymnasium[23].Id == 24)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[23].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[23].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksGymnasium[23].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksGymnasium[23].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksGymnasium[23].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksGymnasium[23].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksGymnasium[23].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[24].Start != "" && IntervalsAndChecksGymnasium[24].Stop != "" &&
                        IntervalsAndChecksGymnasium[24].Id == 25)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[24].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[24].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksGymnasium[24].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksGymnasium[24].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksGymnasium[24].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksGymnasium[24].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksGymnasium[24].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[25].Start != "" && IntervalsAndChecksGymnasium[25].Stop != "" &&
                        IntervalsAndChecksGymnasium[25].Id == 26)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[25].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[25].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksGymnasium[25].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksGymnasium[25].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksGymnasium[25].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksGymnasium[25].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksGymnasium[25].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[26].Start != "" && IntervalsAndChecksGymnasium[26].Stop != "" &&
                        IntervalsAndChecksGymnasium[26].Id == 27)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[26].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[26].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksGymnasium[26].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksGymnasium[26].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksGymnasium[26].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksGymnasium[26].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksGymnasium[26].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[27].Start != "" && IntervalsAndChecksGymnasium[27].Stop != "" &&
                        IntervalsAndChecksGymnasium[27].Id == 28)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[27].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[27].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksGymnasium[27].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksGymnasium[27].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksGymnasium[27].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksGymnasium[27].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksGymnasium[27].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[28].Start != "" && IntervalsAndChecksGymnasium[28].Stop != "" &&
                        IntervalsAndChecksGymnasium[28].Id == 29)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[28].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[28].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksGymnasium[28].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksGymnasium[28].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksGymnasium[28].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksGymnasium[28].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksGymnasium[28].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[29].Start != "" && IntervalsAndChecksGymnasium[29].Stop != "" &&
                        IntervalsAndChecksGymnasium[29].Id == 30)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[29].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[29].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksGymnasium[29].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksGymnasium[29].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksGymnasium[29].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksGymnasium[29].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksGymnasium[29].HoldCourse;
                    }

                    break;

                case "Joi":
                    if (IntervalsAndChecksGymnasium[30].Start != "" && IntervalsAndChecksGymnasium[30].Stop != "" &&
                        IntervalsAndChecksGymnasium[30].Id == 31)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[30].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[30].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksGymnasium[30].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksGymnasium[30].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksGymnasium[30].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksGymnasium[30].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksGymnasium[30].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[31].Start != "" && IntervalsAndChecksGymnasium[31].Stop != "" &&
                        IntervalsAndChecksGymnasium[31].Id == 32)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[31].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[31].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksGymnasium[31].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksGymnasium[31].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksGymnasium[31].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksGymnasium[31].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksGymnasium[31].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[32].Start != "" && IntervalsAndChecksGymnasium[32].Stop != "" &&
                        IntervalsAndChecksGymnasium[32].Id == 33)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[32].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[32].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksGymnasium[32].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksGymnasium[32].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksGymnasium[32].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksGymnasium[32].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksGymnasium[32].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[33].Start != "" && IntervalsAndChecksGymnasium[33].Stop != "" &&
                        IntervalsAndChecksGymnasium[33].Id == 34)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[33].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[33].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksGymnasium[33].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksGymnasium[33].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksGymnasium[33].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksGymnasium[33].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksGymnasium[33].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[34].Start != "" && IntervalsAndChecksGymnasium[34].Stop != "" &&
                        IntervalsAndChecksGymnasium[34].Id == 35)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[34].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[34].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksGymnasium[34].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksGymnasium[34].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksGymnasium[34].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksGymnasium[34].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksGymnasium[34].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[35].Start != "" && IntervalsAndChecksGymnasium[35].Stop != "" &&
                        IntervalsAndChecksGymnasium[35].Id == 36)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[35].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[35].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksGymnasium[35].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksGymnasium[35].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksGymnasium[35].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksGymnasium[35].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksGymnasium[35].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[36].Start != "" && IntervalsAndChecksGymnasium[36].Stop != "" &&
                        IntervalsAndChecksGymnasium[36].Id == 37)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[36].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[36].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksGymnasium[36].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksGymnasium[36].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksGymnasium[36].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksGymnasium[36].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksGymnasium[36].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[37].Start != "" && IntervalsAndChecksGymnasium[37].Stop != "" &&
                        IntervalsAndChecksGymnasium[37].Id == 38)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[37].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[37].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksGymnasium[37].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksGymnasium[37].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksGymnasium[37].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksGymnasium[37].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksGymnasium[37].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[38].Start != "" && IntervalsAndChecksGymnasium[38].Stop != "" &&
                        IntervalsAndChecksGymnasium[38].Id == 39)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[38].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[38].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksGymnasium[38].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksGymnasium[38].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksGymnasium[38].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksGymnasium[38].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksGymnasium[38].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[39].Start != "" && IntervalsAndChecksGymnasium[39].Stop != "" &&
                        IntervalsAndChecksGymnasium[39].Id == 40)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[39].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[39].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksGymnasium[39].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksGymnasium[39].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksGymnasium[39].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksGymnasium[39].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksGymnasium[39].HoldCourse;
                    }

                    break;

                case "Vineri":
                    if (IntervalsAndChecksGymnasium[40].Start != "" && IntervalsAndChecksGymnasium[40].Stop != "" &&
                        IntervalsAndChecksGymnasium[40].Id == 41)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[40].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[40].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksGymnasium[40].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksGymnasium[40].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksGymnasium[40].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksGymnasium[40].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksGymnasium[40].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[41].Start != "" && IntervalsAndChecksGymnasium[41].Stop != "" &&
                        IntervalsAndChecksGymnasium[41].Id == 42)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[41].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[41].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksGymnasium[41].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksGymnasium[41].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksGymnasium[41].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksGymnasium[41].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksGymnasium[41].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[42].Start != "" && IntervalsAndChecksGymnasium[42].Stop != "" &&
                        IntervalsAndChecksGymnasium[42].Id == 43)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[42].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[42].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksGymnasium[42].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksGymnasium[42].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksGymnasium[42].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksGymnasium[42].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksGymnasium[42].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[43].Start != "" && IntervalsAndChecksGymnasium[43].Stop != "" &&
                        IntervalsAndChecksGymnasium[43].Id == 44)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[43].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[43].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksGymnasium[43].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksGymnasium[43].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksGymnasium[43].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksGymnasium[43].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksGymnasium[43].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[44].Start != "" && IntervalsAndChecksGymnasium[44].Stop != "" &&
                        IntervalsAndChecksGymnasium[44].Id == 45)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[44].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[44].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksGymnasium[44].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksGymnasium[44].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksGymnasium[44].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksGymnasium[44].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksGymnasium[44].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[45].Start != "" && IntervalsAndChecksGymnasium[45].Stop != "" &&
                        IntervalsAndChecksGymnasium[45].Id == 46)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[45].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[45].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksGymnasium[45].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksGymnasium[45].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksGymnasium[45].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksGymnasium[45].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksGymnasium[45].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[46].Start != "" && IntervalsAndChecksGymnasium[46].Stop != "" &&
                        IntervalsAndChecksGymnasium[46].Id == 47)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[46].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[46].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksGymnasium[46].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksGymnasium[46].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksGymnasium[46].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksGymnasium[46].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksGymnasium[46].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[47].Start != "" && IntervalsAndChecksGymnasium[47].Stop != "" &&
                        IntervalsAndChecksGymnasium[47].Id == 48)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[47].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[47].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksGymnasium[47].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksGymnasium[47].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksGymnasium[47].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksGymnasium[47].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksGymnasium[47].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[48].Start != "" && IntervalsAndChecksGymnasium[48].Stop != "" &&
                        IntervalsAndChecksGymnasium[48].Id == 49)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[48].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[48].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksGymnasium[48].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksGymnasium[48].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksGymnasium[48].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksGymnasium[48].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksGymnasium[48].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[49].Start != "" && IntervalsAndChecksGymnasium[49].Stop != "" &&
                        IntervalsAndChecksGymnasium[49].Id == 50)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[49].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[49].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksGymnasium[49].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksGymnasium[49].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksGymnasium[49].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksGymnasium[49].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksGymnasium[49].HoldCourse;
                    }

                    break;

                case "Sambata":
                    if (IntervalsAndChecksGymnasium[50].Start != "" && IntervalsAndChecksGymnasium[50].Stop != "" &&
                        IntervalsAndChecksGymnasium[50].Id == 51)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[50].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[50].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksGymnasium[50].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksGymnasium[50].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksGymnasium[50].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksGymnasium[50].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksGymnasium[50].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[51].Start != "" && IntervalsAndChecksGymnasium[51].Stop != "" &&
                        IntervalsAndChecksGymnasium[51].Id == 52)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[51].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[51].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksGymnasium[51].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksGymnasium[51].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksGymnasium[51].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksGymnasium[51].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksGymnasium[51].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[52].Start != "" && IntervalsAndChecksGymnasium[52].Stop != "" && 
                        IntervalsAndChecksGymnasium[52].Id == 53)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[52].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[52].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksGymnasium[52].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksGymnasium[52].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksGymnasium[52].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksGymnasium[52].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksGymnasium[52].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[53].Start != "" && IntervalsAndChecksGymnasium[53].Stop != "" &&
                        IntervalsAndChecksGymnasium[53].Id == 54)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[53].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[53].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksGymnasium[53].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksGymnasium[53].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksGymnasium[53].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksGymnasium[53].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksGymnasium[53].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[54].Start != "" && IntervalsAndChecksGymnasium[54].Stop != "" &&
                        IntervalsAndChecksGymnasium[54].Id == 55)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[54].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[54].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksGymnasium[54].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksGymnasium[54].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksGymnasium[54].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksGymnasium[54].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksGymnasium[54].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[55].Start != "" && IntervalsAndChecksGymnasium[55].Stop != "" &&
                        IntervalsAndChecksGymnasium[55].Id == 56)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[55].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[55].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksGymnasium[55].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksGymnasium[55].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksGymnasium[55].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksGymnasium[55].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksGymnasium[55].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[56].Start != "" && IntervalsAndChecksGymnasium[56].Stop != "" &&
                        IntervalsAndChecksGymnasium[56].Id == 57)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[56].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[56].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksGymnasium[56].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksGymnasium[56].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksGymnasium[56].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksGymnasium[56].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksGymnasium[56].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[57].Start != "" && IntervalsAndChecksGymnasium[57].Stop != "" &&
                        IntervalsAndChecksGymnasium[57].Id == 58)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[57].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[57].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksGymnasium[57].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksGymnasium[57].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksGymnasium[57].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksGymnasium[57].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksGymnasium[57].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[58].Start != "" && IntervalsAndChecksGymnasium[58].Stop != "" &&
                        IntervalsAndChecksGymnasium[58].Id == 59)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[58].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[58].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksGymnasium[58].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksGymnasium[58].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksGymnasium[58].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksGymnasium[58].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksGymnasium[58].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[59].Start != "" && IntervalsAndChecksGymnasium[59].Stop != "" &&
                        IntervalsAndChecksGymnasium[59].Id == 60)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[59].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[59].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksGymnasium[59].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksGymnasium[59].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksGymnasium[59].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksGymnasium[59].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksGymnasium[59].HoldCourse;
                    }

                    break;

                case "Duminica":
                    if (IntervalsAndChecksGymnasium[60].Start != "" && IntervalsAndChecksGymnasium[60].Stop != "" &&
                        IntervalsAndChecksGymnasium[60].Id == 61)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[60].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval1.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval1.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval1.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[60].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval1.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval1.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval1.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone1.Checked = IntervalsAndChecksGymnasium[60].ExitTone;
                        checkBoxEntranceTone1.Checked = IntervalsAndChecksGymnasium[60].EntranceTone;
                        checkBoxHoldMusic1.Checked = IntervalsAndChecksGymnasium[60].HoldMusic;
                        checkBoxHoldOn1.Checked = IntervalsAndChecksGymnasium[60].HoldOn;
                        checkBoxHoldCourse1.Checked = IntervalsAndChecksGymnasium[60].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[61].Start != "" && IntervalsAndChecksGymnasium[61].Stop != "" &&
                        IntervalsAndChecksGymnasium[61].Id == 62)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[61].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval2.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval2.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval2.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[61].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval2.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval2.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval2.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone2.Checked = IntervalsAndChecksGymnasium[61].ExitTone;
                        checkBoxEntranceTone2.Checked = IntervalsAndChecksGymnasium[61].EntranceTone;
                        checkBoxHoldMusic2.Checked = IntervalsAndChecksGymnasium[61].HoldMusic;
                        checkBoxHoldOn2.Checked = IntervalsAndChecksGymnasium[61].HoldOn;
                        checkBoxHoldCourse2.Checked = IntervalsAndChecksGymnasium[61].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[62].Start != "" && IntervalsAndChecksGymnasium[62].Stop != "" &&
                        IntervalsAndChecksGymnasium[62].Id == 63)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[62].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval3.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval3.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval3.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[62].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval3.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval3.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval3.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone3.Checked = IntervalsAndChecksGymnasium[62].ExitTone;
                        checkBoxEntranceTone3.Checked = IntervalsAndChecksGymnasium[62].EntranceTone;
                        checkBoxHoldMusic3.Checked = IntervalsAndChecksGymnasium[62].HoldMusic;
                        checkBoxHoldOn3.Checked = IntervalsAndChecksGymnasium[62].HoldOn;
                        checkBoxHoldCourse3.Checked = IntervalsAndChecksGymnasium[62].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[63].Start != "" && IntervalsAndChecksGymnasium[63].Stop != "" &&
                        IntervalsAndChecksGymnasium[63].Id == 64)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[63].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval4.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval4.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval4.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[63].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval4.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval4.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval4.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone4.Checked = IntervalsAndChecksGymnasium[63].ExitTone;
                        checkBoxEntranceTone4.Checked = IntervalsAndChecksGymnasium[63].EntranceTone;
                        checkBoxHoldMusic4.Checked = IntervalsAndChecksGymnasium[63].HoldMusic;
                        checkBoxHoldOn4.Checked = IntervalsAndChecksGymnasium[63].HoldOn;
                        checkBoxHoldCourse4.Checked = IntervalsAndChecksGymnasium[63].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[64].Start != "" && IntervalsAndChecksGymnasium[64].Stop != "" &&
                        IntervalsAndChecksGymnasium[64].Id == 65)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[64].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval5.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval5.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval5.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[64].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval5.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval5.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval5.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone5.Checked = IntervalsAndChecksGymnasium[64].ExitTone;
                        checkBoxEntranceTone5.Checked = IntervalsAndChecksGymnasium[64].EntranceTone;
                        checkBoxHoldMusic5.Checked = IntervalsAndChecksGymnasium[64].HoldMusic;
                        checkBoxHoldOn5.Checked = IntervalsAndChecksGymnasium[64].HoldOn;
                        checkBoxHoldCourse5.Checked = IntervalsAndChecksGymnasium[64].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[65].Start != "" && IntervalsAndChecksGymnasium[65].Stop != "" &&
                        IntervalsAndChecksGymnasium[65].Id == 66)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[65].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval6.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval6.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval6.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[65].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval6.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval6.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval6.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone6.Checked = IntervalsAndChecksGymnasium[65].ExitTone;
                        checkBoxEntranceTone6.Checked = IntervalsAndChecksGymnasium[65].EntranceTone;
                        checkBoxHoldMusic6.Checked = IntervalsAndChecksGymnasium[65].HoldMusic;
                        checkBoxHoldOn6.Checked = IntervalsAndChecksGymnasium[65].HoldOn;
                        checkBoxHoldCourse6.Checked = IntervalsAndChecksGymnasium[65].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[66].Start != "" && IntervalsAndChecksGymnasium[66].Stop != "" &&
                        IntervalsAndChecksGymnasium[66].Id == 67)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[66].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval7.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval7.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval7.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[66].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval7.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval7.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval7.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone7.Checked = IntervalsAndChecksGymnasium[66].ExitTone;
                        checkBoxEntranceTone7.Checked = IntervalsAndChecksGymnasium[66].EntranceTone;
                        checkBoxHoldMusic7.Checked = IntervalsAndChecksGymnasium[66].HoldMusic;
                        checkBoxHoldOn7.Checked = IntervalsAndChecksGymnasium[66].HoldOn;
                        checkBoxHoldCourse7.Checked = IntervalsAndChecksGymnasium[66].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[67].Start != "" && IntervalsAndChecksGymnasium[67].Stop != "" &&
                        IntervalsAndChecksGymnasium[67].Id == 68)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[67].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval8.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval8.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval8.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[67].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval8.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval8.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval8.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone8.Checked = IntervalsAndChecksGymnasium[67].ExitTone;
                        checkBoxEntranceTone8.Checked = IntervalsAndChecksGymnasium[67].EntranceTone;
                        checkBoxHoldMusic8.Checked = IntervalsAndChecksGymnasium[67].HoldMusic;
                        checkBoxHoldOn8.Checked = IntervalsAndChecksGymnasium[67].HoldOn;
                        checkBoxHoldCourse8.Checked = IntervalsAndChecksGymnasium[67].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[68].Start != "" && IntervalsAndChecksGymnasium[68].Stop != "" &&
                        IntervalsAndChecksGymnasium[68].Id == 69)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[68].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval9.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval9.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval9.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[68].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval9.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval9.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval9.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone9.Checked = IntervalsAndChecksGymnasium[68].ExitTone;
                        checkBoxEntranceTone9.Checked = IntervalsAndChecksGymnasium[68].EntranceTone;
                        checkBoxHoldMusic9.Checked = IntervalsAndChecksGymnasium[68].HoldMusic;
                        checkBoxHoldOn9.Checked = IntervalsAndChecksGymnasium[68].HoldOn;
                        checkBoxHoldCourse9.Checked = IntervalsAndChecksGymnasium[68].HoldCourse;
                    }

                    if (IntervalsAndChecksGymnasium[69].Start != "" && IntervalsAndChecksGymnasium[69].Stop != "" &&
                        IntervalsAndChecksGymnasium[69].Id == 70)
                    {
                        startIntervalComponents = IntervalsAndChecksGymnasium[69].Start.Split(' ');
                        timeStartIntervalComponents = startIntervalComponents[0].Split(':');
                        comboBoxStartHourInterval10.SelectedItem = timeStartIntervalComponents[0];
                        comboBoxStartMinuteInterval10.SelectedItem = timeStartIntervalComponents[1];
                        comboBoxStartFormatInterval10.SelectedItem = startIntervalComponents[1];
                        stopIntervalComponents = IntervalsAndChecksGymnasium[69].Stop.Split(' ');
                        timeStopIntervalComponents = stopIntervalComponents[0].Split(':');
                        comboBoxStopHourInterval10.SelectedItem = timeStopIntervalComponents[0];
                        comboBoxStopMinuteInterval10.SelectedItem = timeStopIntervalComponents[1];
                        comboBoxStopFormatInterval10.SelectedItem = stopIntervalComponents[1];
                        checkBoxExitTone10.Checked = IntervalsAndChecksGymnasium[69].ExitTone;
                        checkBoxEntranceTone10.Checked = IntervalsAndChecksGymnasium[69].EntranceTone;
                        checkBoxHoldMusic10.Checked = IntervalsAndChecksGymnasium[69].HoldMusic;
                        checkBoxHoldOn10.Checked = IntervalsAndChecksGymnasium[69].HoldOn;
                        checkBoxHoldCourse10.Checked = IntervalsAndChecksGymnasium[69].HoldCourse;
                    }

                    break;
            }
        }

        private async void buttonStartIntervalsAndDaysGymnasium_Click(object sender, EventArgs e)
        {
            List<string> daysSelected = GetDaysSelected();
            if (daysSelected.Count > 0)
            {               
                buttonStartIntervalsAndDaysGymnasium.Enabled = false;
                await StartSongsAndTonesByIntervalsAndDaysGymnasiumAsync();
            }
            else
            {
                return;
            }
        }

        private void buttonStopIntervalsAndDaysGymnasium_Click(object sender, EventArgs e)
        {
            buttonStartIntervalsAndDaysGymnasium.Enabled = true;
            soundPlayerForASongGymnasium.Stop();
            soundPlayerForAToneGymnasium.Stop();
        }

        private void listBoxSelectDayGymnasium_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateIntervalsAndChecksSelectingDay();
        }

        private void buttonUpdateIntervalsAndChecksForACertainDay_Click(object sender, EventArgs e)
        {
            UpdateTableIntervalsAndChecksGymnasiumForACertainDayInDatabase();
        }
    }
}
