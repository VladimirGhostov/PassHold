using System.Collections.Generic;
using System.Data.SQLite;
using System;

namespace PassHoldApp
{
    internal class ReadData
    {
        static public void RdData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Passwords";

            using (SQLiteDataReader reader = sqlite_cmd.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())   // построчно считываем данные
                    {
                        var Id = reader.GetValue(0);
                        var Login = reader.GetValue(1);
                        var Password = reader.GetValue(2);

                        Console.WriteLine($"{Id} \t {Login} \t {Password}");
                    }
                }
            }
            conn.Close();
        }
    }
}