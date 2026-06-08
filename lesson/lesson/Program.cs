internal class Program
{
    private static void Main(string[] args)
    {
        string login = "admin", password = "admin123";

        if (args.Length == 2)//значит указаны логин и пароль
        {
            if (args[0] == login && args[1] == password)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Добро пожаловать!");
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Не верно введены данные... Пока!");
            }
        }
        else if (args.Length == 0)//не указаны параметры, выводим справку по использов
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка в синтаксисе команды");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("lesson.exe <логин> <пароль>");
        }
        else if (args[0] == "/?")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("lesson.exe <логин> <пароль>");
        }
        else //пользователь ошибся, выведем справку
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка в синтаксисе команды");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("lesson.exe <логин> <пароль>");
        }
        Console.ResetColor();
    }
}