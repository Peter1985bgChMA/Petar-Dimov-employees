namespace TeamLongestPeriod.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string FullName { get { return string.IsNullOrWhiteSpace(Name) ? Id.ToString() : $"{Id}: {Name}"; } }
        public int ProjectId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime LastWorkingDate { get { return DateTo ?? DateTime.Now; } }
    }
}
