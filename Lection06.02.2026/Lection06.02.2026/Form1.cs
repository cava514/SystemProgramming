namespace Lection06._02._2026
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        private void Draw()
        {
            g = CreateGraphics();
            g.Clear(Color.White);

            Pen blackPen = new Pen(Color.Black);
            //Голова
            g.FillEllipse(new SolidBrush(Color.FromArgb(128, 128, 128)), 100, 100, 100, 100);

            //Правое ухо
            Point[] points = [new Point(10, 10), new Point(40, 10), new Point(10, 40)];
            g.FillPolygon(new SolidBrush(Color.FromArgb(128, 128, 128)), points);

            //Левое ухо
            Point[] points1 = { new Point(100, 10), new Point(400, 10), new Point(100, 40) };
            g.FillPolygon(new SolidBrush(Color.FromArgb(128, 128, 128)), points1);

            //Глаз
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), 20, 20, 20, 20);
            g.FillEllipse(new SolidBrush(Color.FromArgb(0, 0, 0)), 20, 20, 20, 20);

            //Глаз
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0)), 20, 20, 20, 20);
            g.FillEllipse(new SolidBrush(Color.FromArgb(0, 0, 0)), 20, 20, 20, 20);

            //Нос
            Point[] points2 = { new Point(100, 10), new Point(400, 10), new Point(100, 40) };
            g.FillPolygon(new SolidBrush(Color.FromArgb(255, 192, 203)), points1);

            //Усы
            g.DrawLine(blackPen, new Point(1, 2), new Point(1, 2));
            g.DrawLine(blackPen, new Point(1, 2), new Point(1, 2));
            g.DrawLine(blackPen, new Point(1, 2), new Point(1, 2));
            g.DrawLine(blackPen, new Point(1, 2), new Point(1, 2));

            g.Dispose(); //Освобождение памяти
        }
        //событие рисования Paint
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw(); //вызов метода рисования
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
