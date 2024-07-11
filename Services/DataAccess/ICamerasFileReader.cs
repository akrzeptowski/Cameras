namespace Services.DataAccess;

public interface ICamerasFileReader
{
    Task<IList<CameraFileRecord>> GetRecords(string path);
}