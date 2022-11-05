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

            Login.FileCreate();
            Login.Enter();

            SQLiteConnection sqlite_conn; //Создание соединения
            sqlite_conn = CreateConnection.Cr_Connect(); //Соединение создано

            Console.WriteLine("Добро пожаловать в менеджер паролей v0.1");
            Console.WriteLine("");
        menu:
            Console.WriteLine("Выберите пункт меню.");
            //Console.WriteLine("0.Инициализация базы данных");
            Console.WriteLine("1.Создание базы данных с паролями => !!!Запускать только при первом запуске!!!");
            Console.WriteLine("2.Ввести данные для базы данных");
            Console.WriteLine("3.Посмотреть пароли");
            Console.WriteLine("4.Удалить значение из базы данных");

            string number = Console.ReadLine();
            int menu;
            bool Check = int.TryParse(number, out menu);

            switch (menu)
            {
                case 1:
                    Console.Clear();
                    /*string dat = "database.db";
                    if (File.Exists(dat))
                    {
                        Console.WriteLine("База данных уже существует.");
                        Console.WriteLine("Возвращаемся в меню, нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        goto menu;
                    }*/
                    Console.WriteLine("Ожидайте, создаётся база данных");
                    Thread.Sleep(1000);
                    CreateTable.CrTable(sqlite_conn); //Создание DataBase
                    Console.WriteLine("База данных успешно создана.");
                    Console.WriteLine("Возвращаем Вас в главное меню");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto menu;

                case 2:
                    Console.Clear();
                    Console.Write("Введите ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Введите логин: ");
                    string login = Console.ReadLine();
                    Console.Write("Введите пароль: ");
                    string pass = Console.ReadLine();
                    InsertData.InsData(sqlite_conn, pass, id, login); //Ввод данных в Data Base
                    sqlite_conn = CreateConnection.Cr_Connect(); //Восстанавливаем соединение с базой данных
                    Console.WriteLine("Данные сохранены.");
                    Console.WriteLine("Для выхода в меню нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                    goto menu;

                case 3:
                    Console.Clear();
                    ReadData.RdData(sqlite_conn); //Вывод данных из Data Base
                    sqlite_conn = CreateConnection.Cr_Connect(); //Восстанавливаем соединение с базой данных
                    Console.WriteLine("Для выхода в меню нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                    goto menu;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Это действие удалит строку данных, Вы уверенны?");
                    Console.WriteLine("1.Да");
                    Console.WriteLine("0.Нет");
                    int choose = Convert.ToInt32(Console.ReadLine());
                    if (choose == 0)
                    {
                        Console.Clear();
                        goto menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Введите Id, который необходимо удалить: ");
                    string Id = Console.ReadLine();
                    DeleteData.DelData(sqlite_conn, Id);
                    sqlite_conn = CreateConnection.Cr_Connect(); //Восстанавливаем соединение с базой данных
                    Console.WriteLine("Для выхода в меню нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                    goto menu;

                default:
                    Console.Clear();
                    goto menu;
            }
        }
    }
}