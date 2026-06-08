using static System.Net.Mime.MediaTypeNames;

namespace LabWork12
{
    public partial class Form1 : Form
    {
        private string text;
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            Bitmap result = new Bitmap(Width, Height);

            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);

            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };

            Graphics g = Graphics.FromImage((System.Drawing.Image)result);

            g.Clear(Color.LightBlue);

            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];


            g.DrawString(text,
                         new System.Drawing.Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));
            g.RotateTransform(5);

            for (int i = 0; i < text.Length; i++)
            {
                g.DrawLine(Pens.Black,
                       new Point(rnd.Next(Width) - 1, rnd.Next(Height) - 1),
                       new Point(rnd.Next(Width) - 1, rnd.Next(Height) - 1));
            }

            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.FromArgb(rnd.Next(255)));

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == text)
                MessageBox.Show("Верно!");
            else
                MessageBox.Show("Ошибка!");
        }
    }
}
