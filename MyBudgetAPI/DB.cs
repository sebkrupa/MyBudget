using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
