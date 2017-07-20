using SQLite.Net;

namespace FootyScorer.Data
{
    public class DataManager
    {
        private SQLiteConnection _database;

        public DataManager(SQLiteConnection connection)
        {
            _database = connection;
        }
    }
}
