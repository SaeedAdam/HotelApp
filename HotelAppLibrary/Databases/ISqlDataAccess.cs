namespace HotelAppLibrary.Databases
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, TU>(string sqlStatement,
            TU parameters,
            string connectionStringName,
            bool isStoredProcedure = false);

        void SaveData<T>(string sqlStatement,
            T parameters,
            string connectionStringName,
            bool isStoredProcedure = false);

    }
}
