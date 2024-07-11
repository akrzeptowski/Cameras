using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Services.DataAccess
{
    public class CamerasFileReader() : ICamerasFileReader
    {
        public async Task<IList<CameraFileRecord>> GetRecords(string path)
        {
            using var stream = new StreamReader(path);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                MissingFieldFound = null,
            };

            using var csvReader = new CsvReader(stream, config);
            var records = csvReader.GetRecordsAsync<CameraFileRecord>();
            var result = new List<CameraFileRecord>();
            await foreach (var record in records)
            {
                result.Add(record);
            }

            return result;
        }
    }
}
