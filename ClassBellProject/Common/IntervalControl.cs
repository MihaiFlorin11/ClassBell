namespace ClassBellProject.Common
{
    public class IntervalControl
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public ComboBox StartHour { get; set; }
        public ComboBox StartMinute { get; set; }
        public ComboBox StartFormat { get; set; }
        public ComboBox StopHour { get; set; }
        public ComboBox StopMinute { get; set; }
        public ComboBox StopFormat { get; set; }
        public CheckBox EntranceTone { get; set; }
        public CheckBox ExitTone { get; set; }
        public CheckBox HoldMusic { get; set; }
        public CheckBox HoldOn { get; set; }
        public CheckBox HoldCourse { get; set; }
    }
}
