﻿using System.Collections.Generic;
using System.Data.SQLite;

namespace PassHoldApp
{
    internal static class CreateConnection
    {
        public static SQLiteConnection Cr_Connect()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
         // Open the connection:
         try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
    }
}
