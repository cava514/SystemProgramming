using System.Diagnostics;

namespace ProcessLibrary
{
    /// <summary>
    /// Класс для вывода инофрмации о процессах
    /// </summary>
    public class Tasklist
    {
        /// <summary>
        /// Метод для вывода всех запущенных процессов
        /// </summary>
        public void GetThreadAliveAll()
        {
            Console.WriteLine("Id Name StartTime");
            foreach (var item in Process.GetProcesses())
            {
                Console.WriteLine($"{item.Id}" + $"{item.ProcessName}");
            }
        }
        /// <summary>
        /// Метод для поиска процесса по максимальному индетификатору
        /// </summary>
        public void GetThreadByMaxId()
        {
            int maxId = 0;
            foreach (var item in Process.GetProcesses())
            {
                maxId = item.Id > maxId ? item.Id : maxId;
            }
            Console.WriteLine($"{Process.GetProcessById(maxId)}");
        }
        /// <summary>
        /// Метод для вывода информации о процессе по его имени
        /// </summary>
        /// <param name="name">Имя процесса</param>
        public void GetThreadByName(string name)
        {
            foreach (var item in Process.GetProcesses())
            {
                if(item.ProcessName == name)
                    Console.WriteLine($"{item.Id}" + $"{item.ProcessName}" + $"{item.StartTime}");
            }
        }
        /// <summary>
        /// Метод для запуска нового процесса
        /// </summary>
        /// <param name="name">Имя нового процесса</param>
        public void StartingANewProcess(string name)
        {
            Process.Start(name);
        }
    }
}
