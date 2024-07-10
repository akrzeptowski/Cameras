using Services.DataAccess;
using Services.Dto;

namespace Services.Abstractions;

public interface ICameraFactory
{
    Camera Create(CameraFileRecord record);
}