using System.Net.Sockets;
using System.Text;

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
                    byte[] buffer = Encoding.ASCII.GetBytes(messageToSend);
                    stream.Write(buffer, 0, buffer.Length);

                    messageToSend = Console.ReadLine();
                }
            }
        }

        public static void Main( string[] args)
        {
            ChatClient Client  =new ChatClient();
            Console.WriteLine("Inserisci l'IP del server:");
            string serverIP = Console.ReadLine();
            Client.StartServer(serverIP, 3000);
        }
    }