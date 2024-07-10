using System.Text.RegularExpressions;
using Services.DataAccess;
using Services.Abstractions;
using Services.Dto;

namespace Services
{
    public class CameraFactory : ICameraFactory
    {
        public Camera Create(CameraFileRecord record)
        {
            return new Camera
            {
                Number = GetNumber(record.Camera),
                Name = record.Camera,
                Latitude = GetDecimalValue(record.Latitude),
                Longitude = GetDecimalValue(record.Longitude)
            };
        }

        private static int GetNumber(string cameraName)
        {
            var match = Regex.Match(cameraName, @"^UTR-CM-(\d{3})\s");
            int.TryParse(match.Groups[1].Value, out var value);
            return value;
        }

        private static decimal GetDecimalValue(string decimalString)
        {
            decimal.TryParse(decimalString, out var value);
            return value;
        }
    }
}
