using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Terminal.Gui;

Process[] process = Process.GetProcesses();

// Инициализация приложения
Application.Init();

// Создание главного окна
var win = new Window("Мое TUI Приложение")
{
    X = 0,
    Y = 1,
    Width = Dim.Fill(),
    Height = Dim.Fill(),
};

var buttonRunProcessSelected = new Button("Запустить процесс")
{
    X = 0,
    Y = 1
};

var textField = new TextField()
{
    X = Pos.Right(buttonRunProcessSelected) + 1,
    Y = Pos.Top(buttonRunProcessSelected),
    Width = 20
};

var buttonnStopProcessSelected = new Button("Остановить процесс")
{
    X = Pos.Right(textField) + 1,
    Y = 1
};

DataTable dataTable = new DataTable();
dataTable.Columns.AddRange(new[]{
    new DataColumn(){ ColumnName = "Id", DataType = typeof(string) },
    new DataColumn(){ ColumnName = "ProcessName", DataType = typeof(string) },
    new DataColumn(){ ColumnName = "WorkingSet64", DataType = typeof(string) },
});
foreach (var item in process)
{
    dataTable.Rows.Add(item.Id, item.ProcessName, item.WorkingSet64);
}

var tableView = new TableView()
{
    X = 1,
    Y = Pos.Top(buttonRunProcessSelected) + 1,
    Width = 50,
    Height = 50,
    Table = dataTable
};

buttonRunProcessSelected.Clicked += () =>
{
    if (textField.Text != "")
    {
        Process.Start(textField.Text.ToString());
    }
    else
    {
        MessageBox.Query("", "Введите имя файла", "Ok");
    }
};

buttonnStopProcessSelected.Clicked += () =>
{
    if (tableView.IsSelected(tableView.SelectedColumn, tableView.SelectedRow))
    {
        foreach (Process proc in process)
        {
            if (proc.ProcessName == tableView.IsSelected(tableView.ColumnOffset, tableView.SelectedRow).ToString())
                proc.Kill();
        }
    }
    else
    {
        MessageBox.Query("", "Выберите процесс", "Ок");
    }
};

//// Поле для ввода текста
//var textField = new TextField("")
//{
//    X = Pos.Right(tableView) + 1,
//    Y = Pos.Top(tableView),
//    Width = 20
//};

// Добавляем элементы в окно
win.Add(buttonRunProcessSelected, textField, buttonnStopProcessSelected, tableView);

// Запуск главного цикла приложения
Application.Top.Add(win);
Application.Run();

// Корректное завершение работы терминала
Application.Shutdown();