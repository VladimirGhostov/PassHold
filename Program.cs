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
            Console.ForegroundColor = ConsoleColor.Green;

            bool del_file = false;

            Login.FileCreate();
            Login.Enter();

            SQLiteConnection sqlite_conn; //Создание соединения
            sqlite_conn = CreateConnection.Cr_Connect(); //Соединение создано

            Console.WriteLine("Добро пожаловать в менеджер паролей v0.1");
            Console.WriteLine("");
        menu:
            Console.WriteLine("Выберите пункт меню.");
            //Console.WriteLine("0.Инициализация базы данных");
            Console.WriteLine("1.Создание базы данных с паролями");
            Console.WriteLine("2.Ввести данные для базы данных");
            Console.WriteLine("3.Посмотреть пароли");
            Console.WriteLine("4.Удалить значение из базы данных");

            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Ожидайте, создаётся база данных");
                    Thread.Sleep(1000);
                    CreateTable.CrTable(sqlite_conn); //Создание DataBase
                    Console.WriteLine("База данных успешно создана.");
                    Console.WriteLine("Возвращаем Вас в главное меню");
                    goto menu;
                    break;

                case 2:
                    Console.WriteLine("Введите значение: ");
                    string id = Console.ReadLine();
                    string login = Console.ReadLine();
                    string pass = Console.ReadLine();
                    InsertData.InsData(sqlite_conn, pass, id, login); //Ввод данных в Data Base
                    goto menu;

                case 3:
                    Console.Clear();
                    ReadData.RdData(sqlite_conn); //Вывод данных из Data Base
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Это действие удалит ВСЕ ДАННЫЕ, Вы уверенны?");
                    Console.WriteLine("1.Да");
                    Console.WriteLine("0.Нет");
                    Console.Clear();
                    Console.WriteLine("Введите Id, который необходимо удалить: ");
                    string Id = Console.ReadLine();
                    DeleteData.DelData(sqlite_conn, Id);
                    goto menu;
            }

            
        }
    }
}