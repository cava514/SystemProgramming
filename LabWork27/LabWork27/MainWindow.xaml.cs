using Microsoft.AspNetCore.SignalR.Client;
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

namespace LabWork27
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            GetChatHubListBox.Items.Clear();
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:4075/chat")
                .Build();
            connection.On<string>("ReceiveMessage", (message) =>
            {
                GetChatHubListBox.Items.Add(message);
            });
            connection.StartAsync();
        }

        private void InputNameUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameUserTextBox.Text.IsNormalized())
            {
                ChatHubStackPanel.IsEnabled = true;
            }
            else
            {
                ChatHubStackPanel.IsEnabled = false;
            }
        }

        private async void InputMessageButton_Click(object sender, RoutedEventArgs e)
        {
            await connection.InvokeAsync("SendMessage", MessageTextBox.Text);
            SendChatHubListBox.Items.Add(MessageTextBox.Text);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await connection.StartAsync();
        }
    }
}