using Services.Dto;

namespace Services.Abstractions;

public interface ICameraService
{
    IList<Camera> GetCameras();
}