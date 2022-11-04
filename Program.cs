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
            Login.FileCreate();
            Login.Enter();

            SQLiteConnection sqlite_conn; //Создание соединения
            sqlite_conn = CreateConnection.Cr_Connect(); //Соединение создано

            Console.WriteLine("Добро пожаловать в менеджер паролей v0.1");
            Console.WriteLine("");
            Console.WriteLine("Выберите пункт меню.");
            Console.WriteLine("1.Создание базы данных с паролями");
            Console.WriteLine("2.Ввести данные для базы данных");
            Console.WriteLine("3.Посмотреть пароли");

            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 1: 
                    CreateTable.CrTable(sqlite_conn); //Создание DataBase\
                    break;

                case 2:
                    Console.WriteLine("Введите значение: ");
                    string id = Console.ReadLine();
                    string login = Console.ReadLine();
                    string pass = Console.ReadLine();
                    InsertData.InsData(sqlite_conn, pass, id, login); //Ввод данных в Data Base
                    break;

                case 3:
                    ReadData.RdData(sqlite_conn); //Вывод данных из Data Base
                    break;
            }

            
        }
    }
}