namespace Services.DataAccess;

public interface ICamerasFileReader
{
    IList<CameraFileRecord> GetRecords();
}