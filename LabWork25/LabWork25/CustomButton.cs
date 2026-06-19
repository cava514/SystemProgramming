using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LabWork25
{
    public class CustomButton : FrameworkElement
    {
        // 5.1.3 Добавить в класс поля и свойства необходимые для отрисовки
        private VisualCollection _children;
        private DrawingVisual _visual;
        protected override int VisualChildrenCount => _children.Count;
        protected override Visual GetVisualChild(int index) => _children[index];

        // 5.4.1 Добавить в класс поля для хранения состояний наведения и нажатия на кнопку, а также для скейлинга кнопки
        private bool _isHovered;
        private bool _isPressed;
        private double _scale = 1.0;
        private double _targetScale = 1.0;

        // 5.5.1 Добавить в класс кнопки RoutedEvent для обработки нажатия на кнопку
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
            "Click",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(CustomButton));

        public string? Content { get; set; }
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Цвет текста")]
        public Color Color { get; set; }
        public Point Point { get; set; }
        public Rect Rect { get; set; }

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        public CustomButton() {
            // 5.1.4 Инициализировать свойства в конструкторе класса
            _children = new VisualCollection(this);
            _visual = new DrawingVisual();
            _children.Add(_visual);

            // 5.1.5 В конструкторе добавить подписку на событие и создайте новый пустой обработчик OnRenderFrame
            CompositionTarget.Rendering += OnRenderFrame;

            // 5.4.2 В конструкторе класса добавить обработчики для событий MouseEnter, MouseLeave, MouseDown, MouseUp
            MouseEnter += CustomButtonMouseEnter;
            MouseLeave += CustomButtonMouseLeave;
            MouseDown += CustomButtonMouseDown;
            MouseUp += CustomButtonMouseUp;
        }

        private void CustomButtonMouseUp(object sender, MouseButtonEventArgs e)
        {
            _targetScale = 1.1;
            _isHovered = true;
            _isPressed = false;
            RaiseEvent(new RoutedEventArgs(ClickEvent, this));
        }

        private void CustomButtonMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void CustomButtonMouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void CustomButtonMouseEnter(object sender, MouseEventArgs e)
        {
            _targetScale = 0.95;
            _isPressed = true;
            _isHovered = false;
        }

        private void OnRenderFrame(object? sender, EventArgs e)
        {
            // 5.4.5 В обработчик OnRenderFrame добавить код для плавной смены размера перед вызовом метода Draw
            _scale += (_targetScale - _scale) * 0.15; // плавная интерполяция
            Draw();
        }

        private void Draw()
        {
            using (DrawingContext dc = _visual.RenderOpen())
            {
                // 5.4.4 Для изменения размера кнопки при нажатии добавить в метод Draw код, добавляющий трансформацию графики
                Point center = new Point(50, 50);
                dc.PushTransform(new ScaleTransform(_scale, _scale, center.X, center.Y));
                // вся предыдущая логика отрисовки графики

                // отрисовка
                dc.DrawRoundedRectangle( // тень
                    new SolidColorBrush(Colors.Black), // первым параметром в метод передается объект SolidColorBrush для цвета фона
                    null, // вторым параметром передается объект Pen для цвета и толщины обводки
                    new Rect(1, -1, Width, Height), // третьим – объект Rect, определяющий размеры и позицию отрисовываемого элемента
                    10, // четвертый – радиус скругления прямоугольника по горизонтали
                    10); // пятый – радиус скругления прямоугольника по вертикали

                //5.2.3 Для отрисовки базы кнопки используем метод dc.DrawRoundedRectangle
                dc.DrawRoundedRectangle( // вид кнопки
                    new SolidColorBrush(Colors.Gray), // первым параметром в метод передается объект SolidColorBrush для цвета фона
                    null, // вторым параметром передается объект Pen для цвета и толщины обводки
                    new Rect(0, 0, Width, Height), // третьим – объект Rect, определяющий размеры и позицию отрисовываемого элемента
                    10, // четвертый – радиус скругления прямоугольника по горизонтали
                    10); // пятый – радиус скругления прямоугольника по вертикали

                // 5.3.1 Для подготовки текста перед отрисовкой необходимо обработать его через FormattedText, например
                FormattedText text = new FormattedText(
                    "Button", // текст
                    System.Globalization.CultureInfo.CurrentCulture, //информация о культуре
                    FlowDirection.LeftToRight, //направление текста
                    new Typeface("Segoe UI"), //шрифт
                    20, //размер шрифта
                    Brushes.Black, // цвет текста
                    1.25); //значение, зависящее от DPI

                // 5.3.2 Далее необходимо отрисовать текст при помощи DrawText, позицию текста вычислять относительно ширины и высоты кнопки и форматированного текста
                dc.DrawText(text, // FormattedText
                    new Point(Width / 2, Height / 2)); // позиция текста, объект Point

                dc.Pop();
            }
        }
    }
}
