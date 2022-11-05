using System;

namespace Start;

static class Login
{
    public static void FileCreate() //Метод для создания файла с логином и паролем в корне программы
    {
        string data = "Data"; //Название и путь к файлу

        bool file_exist = false; //Переменная для проверки
        string log = "";
        string pas = "";

        if (File.Exists(data))
        {
            file_exist = true;
        }
        if (file_exist == false) //Если файл НЕ существует
        {
            using StreamWriter writer = new StreamWriter(data, false); //Запись файла по пути DATA. False - перезапись файла, true - дописать в файлaaaaaaaaaa
            Console.Clear();
            Console.WriteLine("Введите данные для входа в приложение");
            Console.WriteLine();
            Console.Write("Логин: ");
                log = Console.ReadLine();
            Console.Write("Пароль: ");
                pas = Console.ReadLine();

            writer.WriteLine(log); //Пишет в первую строку файла логин
            writer.WriteLine(pas); //Пишет во вторую строку файла пароль
            writer.Close();
        }
        /*else //Если файл существует
        {
            writer.Close(); //Шоб память не съебалась, прекращаем запись
        }*/
    }
    public static void Enter()
    {
        //Объявление переменных в функции
        string path = "Data";
        string? log = "";
        string? pas = "";
        string? password = "";
        string? login = "";
        //Объявление переменных для сравнения хэшей
        int hash_log = 0;
        int hash_pas = 0;
        int hash_ent_log = 0;
        int hash_ent_pas = 0;

        using (StreamReader reader = new StreamReader(path)) //Считываем строки из Data и получаем их хэш
        {
                log = reader.ReadLine();
                hash_log = String.GetHashCode(log);
                pas = reader.ReadLine();
                hash_pas = String.GetHashCode(pas);
            reader.Close(); //Закрываем
        }

        //Console.Beep();
        Console.Clear();
        Console.WriteLine("Загрузка приложения, подождите...");
        Thread.Sleep(1500);

    first:   //Метка для запуска заново 
        Console.Write("Введите логин: "); //Запрашиваем логин
            login = Console.ReadLine(); //Считываем логин
            hash_ent_log = String.GetHashCode(login); //Получаем хэш
        Console.Write("Введите пароль: "); //Запрашиваем пароль
            password = Console.ReadLine(); //Считываем пароль
            hash_ent_pas = String.GetHashCode(password); //Получаем хэш

        Console.Clear();

        if ((hash_log == hash_ent_log) & (hash_pas == hash_ent_pas)) //Сравниваем хэши
        {
            Console.WriteLine("Вход успешный!");
            Thread.Sleep(1000);
            Console.Clear();
        }
        else //Если неудача, то запрашиваем всё заново
        {
            Console.WriteLine("Неверный логин или пароль, повторите ввод");
            Console.WriteLine("Нажмите для продолжения...");
            Console.ReadKey();
            Console.Clear();
            goto first; //Переходим к метке
        }

    }

}