using System.Collections.Generic;
using System.Data.SQLite;

namespace PassHoldApp
{
    internal class DeleteData
    {
        public static void DelData(SQLiteConnection conn, string Id)
        {
            string sqlExpression = "DELETE  FROM Passwords WHERE Id='ID: " + Id + " '";
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);

                command.ExecuteNonQuery();

                Console.WriteLine("Объект удалён");
            }
        }
    }
}
