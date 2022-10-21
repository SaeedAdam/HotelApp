namespace HotelAppLibrary.Databases;

public interface ISqliteDataAccess
{
    List<T> LoadData<T, TU>(string sqlStatement, TU parameters, string connectionStringName);
    void SaveData<T>(string sqlStatement, T parameters, string connectionStringName);
}