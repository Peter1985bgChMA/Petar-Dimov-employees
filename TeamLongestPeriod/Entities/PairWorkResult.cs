namespace TeamLongestPeriod.Entities
{
    public class PairWorkResult
    {
        public string FirstEmployee { get; set; } = string.Empty;
        public string SecondEmployee { get; set; } = string.Empty;
        public int TotalDays { get; set; }
        public List<ProjectOverlap> Projects { get; set; } = [];
    }

    public class ProjectOverlap
    {
        public int ProjectId { get; set; }
        public int DaysWorked { get; set; }
    }
}
