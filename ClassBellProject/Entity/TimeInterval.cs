namespace ClassBellProject.Entity
{
    public class TimeInterval
    {
        public int Id { get; set; }
        public int CycleId { get; set; } // Foarte important!
        public int DayId { get; set; }
        public string Start { get; set; }
        public string Stop { get; set; }
        public bool ExitTone { get; set; }
        public bool EntranceTone { get; set; }
        public bool HoldMusic { get; set; }
        public bool HoldOn { get; set; }
        public bool HoldCourse { get; set; }
    }
}
