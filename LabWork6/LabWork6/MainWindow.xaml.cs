using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
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

namespace LabWork6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.IO.FileStream file;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult)
                return;
            file = File.OpenRead(ofd.RootDirectory);
        }
        
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            HashMD5Label.Content = GetHashSumMD5(file);
            HashSHALabel.Content = GetHashSumSHA(file);
        }

        string GetHashSumMD5(FileStream file)
        {
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.ASCII.GetBytes(file.GetHashCode().ToString()));
            }
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        string GetHashSumSHA(FileStream file)
        {
            byte[] hash;
            using (SHA256 sha = SHA256.Create())
            {
                hash = sha.ComputeHash(Encoding.UTF8.GetBytes(file.GetHashCode().ToString()));
            }
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}