using System.Net;
using System.Net.Sockets;
using System.Text;

Socket clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);

clientSocket.Connect(serverEndPoint);

string message1 = Console.ReadLine();
byte[] sendBuffer1 = Encoding.UTF8.GetBytes(message1);
clientSocket.Send(sendBuffer1);

while (true)
{
    string message = Console.ReadLine();
    byte[] sendBuffer = Encoding.UTF8.GetBytes(message);
    clientSocket.Send(sendBuffer);

    byte[] receiveBuffer = new byte[1024];
    int bytesReceived = clientSocket.Receive(receiveBuffer);
    string response = Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived);
    Console.WriteLine($"Ответ от сервера: {response}");

}