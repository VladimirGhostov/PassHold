using PassHoldApp;
using Start;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassHold
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Login.FileCreate();
            //Login.Enter();

            Console.WriteLine("Введите значение: ");
            string id = Console.ReadLine();
            string login = Console.ReadLine();
            string pass = Console.ReadLine();

            SQLiteConnection sqlite_conn; //Создание соединения
            sqlite_conn = CreateConnection.Cr_Connect(); //Соединение создано
            CreateTable.CrTable(sqlite_conn); //Создание DataBase
            InsertData.InsData(sqlite_conn, pass, id, login); //Ввод данных в Data Base
            ReadData.RdData(sqlite_conn); //Вывод данных из Data Base

        }
    }
}