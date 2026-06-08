namespace LabWork11._3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Image> files = new List<Image>
            {
                new Bitmap(@"C:\Users\221\Students\ISPP-45\SystemProgramming\LabWork11\LabWork11.3\images\1.jpg"),
                new Bitmap(@"C:\Users\221\Students\ISPP-45\SystemProgramming\LabWork11\LabWork11.3\images\2.jpg"),
                new Bitmap(@"C:\Users\221\Students\ISPP-45\SystemProgramming\LabWork11\LabWork11.3\images\3.jpg")
            };
            Form1 form1 = new Form1();
            while (true)
                foreach (var item in files)
                {
                    form1.BackgroundImage = item;
                }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //    Close();
        }
    }
}
