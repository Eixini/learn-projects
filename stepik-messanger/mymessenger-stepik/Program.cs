using Newtonsoft.Json;

namespace mymessenger_stepik;

internal class Program
{
    private static int MessageID;
    private static string UserName;
    private static MessengerClientAPI API = new MessengerClientAPI();

    private static void GetNewMessages()
    {
        Message message = API.GetMessage(MessageID);
        while(message != null)
        {
            Console.WriteLine(message);
            MessageID++;
            message = API.GetMessage(MessageID);
        }
    }

    static void Main(string[] args)
    {
        MessageID = 1;
        Console.WriteLine("Введите ваше имя: ");
        UserName = Console.ReadLine();
        string MessageText = "";

        Thread myThread = new Thread(new ThreadStart(GetNewMessages));
        myThread.Start();

        while(MessageText != "exit")
        {
            GetNewMessages();
            Console.WriteLine("Введите текст сообщения:");
            MessageText = Console.ReadLine();
            if(MessageText.Length > 1)
            {
                Message sendMessage = new Message(UserName, MessageText, DateTime.Now);
                API.SendMessage(sendMessage);
            }
        }
    }
}