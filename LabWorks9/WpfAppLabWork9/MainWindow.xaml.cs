using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppLabWork9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DirectoryInfo[] directory = new DirectoryInfo("C:\\").GetDirectories();
            FileInfo[] directory1 = new DirectoryInfo("C:\\").GetFiles();
            ListViewItem listViewItem = new ListViewItem();
            if (Directory.Exists("C:\\"))
            {
                listViewItem.DataContext = directory;
                CatalogsTreeView.ItemsSource = listViewItem.Resources;
            }
            FileInfo[] files = directory1;
            for (int i = 0; i < files.Length; i++)
            {
                CatalogListView.Items.Add(files[i].Name);
            }
        }
    }
}