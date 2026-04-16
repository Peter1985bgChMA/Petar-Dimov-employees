using CsvHelper.Configuration;
using TeamLongestPeriod.Utils;

namespace TeamLongestPeriod.Entities
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.ProjectId).Index(2);
            Map(m => m.DateFrom)
                .Index(3)
                .TypeConverter<MultiFormatDateConverter>();
            Map(m => m.DateTo)
                .Index(4)
                .TypeConverter<MultiFormatDateConverter>();
        }
    }
}
