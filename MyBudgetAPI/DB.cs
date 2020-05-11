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
        public static SQLiteConnection DBContext() => new SQLiteConnection(GetConnectionString());
        public static string GetConnectionString(string path = @"C:\Users\sebkr\OneDrive\bgt.db")
        {
            var connString = new SQLiteConnectionStringBuilder();
            connString.DataSource = path;
            return connString.ToString();
        }
    }
}
