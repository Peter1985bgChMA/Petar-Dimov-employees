using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace TeamLongestPeriod.Utils
{
    public class MultiFormatDateConverter : DefaultTypeConverter
    {
        private static readonly string[] SupportedFormats =
        {
            "yyyy-MM-dd",
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-ddTHH:mm:ss",
            "yyyy-MM-ddTHH:mm:ssZ",

            "yyyy/MM/dd",
            "dd/MM/yyyy",
            "MM/dd/yyyy",

            "dd.MM.yyyy",
            "dd.MM.yyyy HH:mm",
            "dd.MM.yyyy HH:mm:ss",

            "yyyyMMdd",

            "dd-MMM-yyyy",
            "MMM dd yyyy"
        };

        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text) ||
                text.Equals("NULL", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            if (DateTime.TryParseExact(
                    text.Trim(),
                    SupportedFormats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime result))
            {
                return result;
            }

            if (DateTime.TryParse(text, out result))
            {
                return result;
            }

            throw new TypeConverterException(
                this, memberMapData, text, row.Context,
                $"Unsupported date format: '{text}'");
        }
    }
}
