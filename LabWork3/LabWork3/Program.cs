// Task 1
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Thread thread = new Thread(Print);
//        thread.Start();
//        for (int i = 0; i < 10; i++)
//        {
//            Console.Write(i);
//            Thread.Sleep(2000);
//        }
//    }

//    public static string alphabetAJ = "ABCDEFGHIJ";
//    public static void Print()
//    {
//        for (int i = 0; i < alphabetAJ.Length; i++)
//        {
//            Console.WriteLine(alphabetAJ[i]);
//            Thread.Sleep(2000);
//        }
//    }
//}
//Task 2
//using Castle.Core.Internal;
//int x = 0;
//object lockObj = new();
//for (int i = 1; i < 6; i++)
//{
//    Thread thread = new(Print);
//    thread.Name = $"Поток {i}";
//    thread.Start();
//}
//void Print()
//{
//    lock (lockObj)
//    {
//        x = 1;
//        for (int i = 0; i < 5; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//}
//Task 3
//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        for (int i = 1; i < 6; i++)
//        {
//            Thread thread = new(Print);
//            thread.Name = $"Поток {i}";
//            thread.Start();
//        }
//    }
//    static int x = 0;
//    static Mutex mutexObj = new();
//    static void Print()
//    {
//        Console.WriteLine("Запуск кода");
//        mutexObj.WaitOne();
//        x = 0;
//        x = 1;
//        for (int i = 0; i < 5; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
//            x++;
//            Thread.Sleep(100);
//        }
//        mutexObj.ReleaseMutex();
//    }
//}
//Task 4
//using System.Threading;
//internal class Program
//{
//    public static string commonVar;
//    private static void Main(string[] args)
//    {
//        Thread thread = new Thread(MyThread);
//        thread.Start();
//        for (int i = 0; i < 10; i++)
//        {
//            commonVar = i.ToString();
//            if (i == 5)
//                commonVar = "x";
//            Console.WriteLine(commonVar);
//            Thread.Sleep(2000);
//        }
//    }
//    public static void MyThread()
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            if (commonVar == "x")
//                break;
//            Console.Write(i.ToString());
//            Thread.Sleep(2000);
//        }
//    }
//}
// Task 5
//using System.Threading;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        Thread thread = new Thread(MyThread);
//        thread.Start();
//        for (int i = 0; i < 10; i++)
//        {
//            Console.Write(i);
//            Thread.Sleep(2000);
//        }
//    }
//    public static string alphabetAJ = "ABCDEFGHIJ";
//    public static void MyThread()
//    {
//        for (int i = 0; i < alphabetAJ.Length; i++)
//        {
//            Console.WriteLine(alphabetAJ[i]);
//            Thread.Sleep(2000);
//        }
//    }
//}