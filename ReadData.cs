using System.Collections.Generic;
using System.Data.SQLite;
using System;

namespace PassHoldApp
{
    internal class ReadData
    {
        static public void RdData(SQLiteConnection conn)
        {
            
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Passwords";

            /*sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
                for (int i = 0; i < 3; i++)
                {
                    string line = sqlite_datareader.GetString(i);
                    Console.Write(line);
                }
            }*/
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