using FluentValidation;
using Microsoft.Extensions.Options;
using Services.Abstractions;
using Services.Configuration;
using Services.DataAccess;
using Services.Dto;

namespace Services
{
    public class CamerasService(
        ICamerasFileReader camerasFileReader,
        IValidator<CameraFileRecord> validator,
        ICameraFactory cameraFactory,
        IOptions<CamerasFileConfiguration> configuration) : ICameraService
    {
        public async Task<IList<Camera>> GetCameras()
        {
            var records = await camerasFileReader.GetRecords(configuration.Value.Path);
            var validRecords = new List<Camera>();
            foreach (var record in records)
            {
                var validationResult = validator.Validate(record);
                if (validationResult.IsValid)
                {
                    var camera = cameraFactory.Create(record);
                    validRecords.Add(camera);
                }
                else
                {
                    // TODO: Log validation result, indicate row no
                }
            }

            return validRecords;
        }
    }
}
