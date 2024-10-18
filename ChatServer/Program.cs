using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks.Dataflow;

public class ChatServer
{
    private TcpListener? listener;
    public void StartServer (int port)
    {
        listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"Server avviato su porta{port}");

        while(true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient!));
            clientThread.Start(client);
        }
    }
    private void HandleClient (object obj)
    {
        TcpClient client = (TcpClient) obj;
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int byteCount;

        while ((byteCount = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, byteCount);
            Console.WriteLine("Ricevuto: " + message);
            Broadcast(message);
        }
        client.Close();
    }

    private void Broadcast(string message)
    {
        
    }

    public static void Main(string[] args)
    {
        ChatServer server = new ChatServer();
        server.StartServer(3000);
    }
}