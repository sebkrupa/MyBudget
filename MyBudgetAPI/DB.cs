using System.Data.SQLite;

namespace MyBudgetAPI
{
    public static class DB
    {
        public static string DBPath = null;
        public static SQLiteConnection DBContext() => new SQLiteConnection(GetConnectionString());
        public static string GetConnectionString()
        {
            var connString = new SQLiteConnectionStringBuilder();
            connString.DataSource = DBPath;
            return connString.ToString();
        }
    }
}
