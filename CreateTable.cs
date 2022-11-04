using System.Collections.Generic;
using System.Data.SQLite;

namespace PassHoldApp
{
    internal static class CreateTable
    {
        static public void CrTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE Passwords (Id VARCHAR(40), Login VARCHAR(40), Password VARCHAR(40))";
         sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
