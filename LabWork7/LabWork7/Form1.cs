using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LabWork7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string path = @"C:\Users\221\Students\ISPP-45\SystemProgramming\LabWork7\LabWork7\passwords.txt";
            string fileText = File.ReadAllText(path);
            string[] words = fileText.Split(new char[] { ';' });

            List<string> list = new List<string>();
            list.AddRange(words);
            
            ListViewItem listViewItem1 = new ListViewItem();
            listViewItem1.SubItems.Add(list[0]);
            ManagerListView.Columns.Clear();
            ManagerListView.View = View.Details;
            ManagerListView.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader(){Text = "сайт/приложение"},
                new ColumnHeader(){Text = "логин"},
                new ColumnHeader(){Text = "пароль"}
            });
            ManagerListView.Items.Add(listViewItem1);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    ManagerListView.Items.Add(list[i]);
            //}
        }
    }
}
