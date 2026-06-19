namespace WorkerService
{
    public class FileWathcerService : BackgroundService
    {
        private readonly ILogger<FileWathcerService> _logger;

        //5.1.2 Добавить в конструктор сервиса параметр IConfiguration configuration для доступа к конфигурации приложения через внедрение зависимостей.
        private readonly IConfiguration _configuration;
        public FileWathcerService(ILogger<FileWathcerService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Все строковые параметры для сервиса (имена файлов, каталогов, пути, параметры cron) необходимо получать из конфигурации (appsettings.json) при помощи
            string? data = _configuration.GetSection("LogLevel")["Default"];
            // 5.2 В методе выполнения сервиса определить объект FileSystemWatcher для отслеживания изменений внутри определенного каталога
            using FileSystemWatcher watcher = new FileSystemWatcher("C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\");
            // 5.2.1 Добавить подписку на события Changed, Created, Deleted, Renamed, Error для watcher. В обработчиках данных событий записывать в файл логи формата «[дата и время]: [событие] – [полный путь к файлу / сообщение об ошибке]»
            watcher.Changed += WatcherChanged;
            watcher.Created += WatcherCreated;
            watcher.Deleted += WatcherDeleted;
            watcher.Renamed += WatcherRenamed;
            watcher.Error += WatcherError;
            // 5.2.2 Включить отслеживание изменений в подкаталогах и генерацию событий:
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            // 5.2.3 Добавить бесконечное ожидание в программе, пока пользователь не запросит завершение сервиса
            while (!stoppingToken.IsCancellationRequested)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }
                await Task.CompletedTask;
            }
        }

        private void WatcherError(object sender, ErrorEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt", true))
            {
                writer.WriteLine($"[{DateTime.Now}]: [Error] - [C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt / сообщение об ошибке]");
            }
        }

        private void WatcherRenamed(object sender, RenamedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt", true))
            {
                writer.WriteLine($"[{DateTime.Now}]: [Renamed] - [C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt / сообщение об ошибке]");
            }
        }

        private void WatcherDeleted(object sender, FileSystemEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt", true))
            {
                writer.WriteLine($"[{DateTime.Now}]: [Deleted] - [C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt / сообщение об ошибке]");
            }
        }

        private void WatcherCreated(object sender, FileSystemEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt", true))
            {
                writer.WriteLine($"[{DateTime.Now}]: [Created] - [C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt / сообщение об ошибке]");
            }
        }

        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt", true))
            {
                writer.WriteLine($"[{DateTime.Now}]: [Changed] - [C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\SystemProgramming\\WorkerService\\WorkerService\\Watcher.txt / сообщение об ошибке]");
            }
        }
    }
}
