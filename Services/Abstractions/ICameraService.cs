using Services.Dto;

namespace Services.Abstractions;

public interface ICameraService
{
    Task<IList<Camera>> GetCameras();
}