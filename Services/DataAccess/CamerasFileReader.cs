using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Services.DataAccess
{
    public class CamerasFileReader() : ICamerasFileReader
    {
        public IList<CameraFileRecord> GetRecords()
        {
            using var stream = new StreamReader("./cameras-defb.csv");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                MissingFieldFound = null,
            };

            using var csvReader = new CsvReader(stream, config);
            var records = csvReader.GetRecords<CameraFileRecord>();

            return records.ToList();
        }
    }
}
