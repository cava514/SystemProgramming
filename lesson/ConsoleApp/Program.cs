internal class Program
{
    private static void Main(string[] args)
    {
        System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcesses();
        if (args.Length == 0)
        {
            foreach (System.Diagnostics.Process item in process)
            {
                Console.WriteLine(item.Id + "\t" +item.ProcessName);
            }
        }
        else if (args[0] == "-sort")
        {
            process.OrderBy(p => p.Id);
            foreach (System.Diagnostics.Process item in process)
            {
                Console.WriteLine(item.Id + "\t" + item.ProcessName);
            }
        }
        else if (args[0] == "/?")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("lesson.exe <логин> <пароль>");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка в синтаксисе команды");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("lesson.exe <логин> <пароль>");
        }
        Console.ResetColor();
    }
}