using System;

namespace LabWork11._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Second.ToString();
            Form1 form1 = new Form1();
            Random random = new Random();
            label1.Location = new Point(random.Next(100, form1.Size.Width - 100), random.Next(100, form1.Size.Width - 100));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.WindowState = FormWindowState.Maximized;
            label1.Location = new Point(form1.Size.Width / 2, form1.Size.Height / 2);
        }
    }
}
