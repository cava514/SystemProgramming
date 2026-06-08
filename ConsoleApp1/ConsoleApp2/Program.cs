using Terminal.Gui;

// Инициализация приложения
Application.Init();

// Создание главного окна
var win = new Window("Мое TUI Приложение")
{
    X = 0,
    Y = 1, // Оставляем место для верхнего меню, если оно будет
    Width = Dim.Fill(),
    Height = Dim.Fill()
};

// Добавление текстовой метки
var label = new Label("Введите ваше имя:")
{
    X = 3,
    Y = 2
};

var label1 = new Label("Введите:")
{
    X = 3,
    Y = 2
};

//// Поле для ввода текста
//var textField = new TextField("")
//{
//    X = Pos.Right(label) + 1,
//    Y = Pos.Top(label),
//    Width = 20
//};

var textField1 = new TextField("")
{
    X = Pos.Right(label1) + 1,
    Y = Pos.Top(label),
    Width = 20
};

var radioGroup = new RadioGroup(new NStack.ustring[] { "C' ~ F`", "км ~ м" }, 2)
{
    X = Pos.Right(label1),
    Y = Pos.Top(label) + 1,
    Width = 20
};

// Кнопка
var btn = new Button("Поприветствовать")
{
    X = Pos.Left(label),
    Y = Pos.Bottom(label) + 2
};

var btn1 = new Button("Конвертировать")
{
    X = Pos.Left(label),
    Y = Pos.Bottom(label) + 2
};

//// Обработка нажатия на кнопку
//btn.Clicked += () => {
//    MessageBox.Query("Приветствие", $"Привет, {textField?.Text}!", "Ок");
//};
btn1.Clicked += () =>
{
    if (radioGroup.SelectedItem == 0)
    {
        MessageBox.Query("Конвертация", $"Грдусы в F`: {(Convert.ToDouble(textField1.Text) * 1.8) + 32}!", "Ок");
    }
    else
    {
        MessageBox.Query("Конвертация", $"Метров: {Convert.ToDouble(textField1.Text) * 1000}!", "Ок");
    }
};


// Добавляем элементы в окно
//win.Add(label, textField, btn);

win.Add(label1, textField1, btn1, radioGroup);

// Запуск главного цикла приложения
Application.Top.Add(win);
Application.Run();

// Корректное завершение работы терминала
Application.Shutdown();