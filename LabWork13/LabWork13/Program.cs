using System.Net;
using System.Net.Sockets;
using System.Text;

Socket listener = new Socket(SocketType.Stream, ProtocolType.Tcp);

IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 5000);
listener.Bind(localEndPoint);

listener.Listen(10);
Console.WriteLine("Ожидание подключения...");

Socket handler = listener.Accept();

StreamReader fileInfo = new StreamReader("C:\\Users\\221\\Students\\ISPP-45\\SystemProgramming\\LabWork13\\LabWork13\\TextFile1.txt");
string text = fileInfo.ReadToEnd();

while (true)
{
    byte[] bufferClient = new byte[1024];
    int bytesReceivedClient = handler.Receive(bufferClient);
    string dataClient = Encoding.UTF8.GetString(bufferClient, 0, bytesReceivedClient);
    string login = dataClient[dataClient.IndexOf(" ")].
    if (!text.Contains(dataClient[dataClient.IndexOf(" ")])) Console.WriteLine("Доступ запрещен");
    else break;
}

while (true)
{
    byte[] buffer = new byte[1024];
    int bytesReceived = handler.Receive(buffer);
    string data = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
    Console.WriteLine($"[{DateTime.Now.ToShortDateString()}:{DateTime.Now.ToShortTimeString()}:{DateTime.Now.Second}][]:Получено сообщение: {data}");

    string response = "Сообщение получено!";
    byte[] responseBuffer = Encoding.UTF8.GetBytes(response);
    handler.Send(responseBuffer);

    
}
