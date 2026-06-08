using System.Management;

GetPK();
GetDisk();
GetProgramm();

void GetPK()
{
    ManagementObjectSearcher processor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
    foreach (ManagementObject obj in processor.Get())
    {
        Console.WriteLine("Процессор: " + obj["Name"]);
        Console.WriteLine("Количество ядер: " + obj["NumberOfCores"]);
    }

    ManagementObjectSearcher memory = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
    foreach (ManagementObject obj in memory.Get())
    {
        Console.WriteLine("Память: " + obj["Name"]);
        Console.WriteLine("Объем оперативной памяти: " + obj["Capacity"]);
    }

    ManagementObjectSearcher baseBoard = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
    foreach (ManagementObject obj in baseBoard.Get())
    {
        Console.WriteLine("Имя платы: " + obj["Name"]);
        Console.WriteLine("Модель: " + obj["Model"]);
    }

    ManagementObjectSearcher BIOS = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
    foreach (ManagementObject obj in BIOS.Get())
    {
        Console.WriteLine("Версия BIOS: " + obj["BIOSVersion"]);
    }
}

void GetDisk()
{
    ManagementObjectSearcher logicalDisk = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
    foreach (ManagementObject obj in logicalDisk.Get())
    {
        Console.WriteLine("Имя диска: " + obj["DeviceID"]);
        Console.WriteLine("Файловая система: " + obj["FileSystem"]);
        Console.WriteLine("Свободно места: " + (Convert.ToDouble(Convert.ToInt64(obj["FreeSpace"]) * 100 / Convert.ToInt64(obj["Size"]))) + "%");
    }
}

void GetProgramm()
{
    ManagementObjectSearcher startProgramm = new ManagementObjectSearcher("SELECT * FROM Win32_StartupCommand");
    foreach (ManagementObject obj in startProgramm.Get())
    {
        Console.WriteLine(obj["Caption"]);
        Console.WriteLine(obj["Description"]);
        Console.WriteLine(obj["SettingID"]);
        Console.WriteLine(obj["Command"]);
        Console.WriteLine(obj["Location"]);
        Console.WriteLine(obj["Name"]);
        Console.WriteLine(obj["User"]);
        Console.WriteLine(obj["UserSID"]);
    }
}
