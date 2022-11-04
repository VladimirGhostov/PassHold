using System.Collections.Generic;
using System.Data.SQLite;

namespace PassHoldApp
{
    internal class InsertData
    {
        public static void InsData(SQLiteConnection conn, string pass, string id, string login)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            string str = "INSERT INTO Passwords (Id, Login, Password) VALUES ('ID: " + id +" ', 'Login: " + login + " ', 'Password: " + pass + "');";
            sqlite_cmd.CommandText = str;
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
