using FluentValidation;
using Services.Abstractions;
using Services.DataAccess;
using Services.Dto;

namespace Services
{
    public class CamerasService(
        ICamerasFileReader camerasFileReader,
        IValidator<CameraFileRecord> validator,
        ICameraFactory cameraFactory) : ICameraService
    {
        public IList<Camera> GetCameras()
        {
            var records = camerasFileReader.GetRecords();
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
