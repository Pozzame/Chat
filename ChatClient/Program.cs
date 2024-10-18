using System.Net.Sockets;

public class ChatClient
    {
        void StartClient(string serverIP, int port)
        {
            using (var client = new TcpClient(serverIP, port));
            using (var stream = client.GetStream())
            {
                Console.WriteLine("Connesso al server");
                string messageToSend = Console.ReadLine();
                while (!string.IsNullOrEmpty(messageToSend))
                {
                    ping google.it
                }
            }
        }
    }