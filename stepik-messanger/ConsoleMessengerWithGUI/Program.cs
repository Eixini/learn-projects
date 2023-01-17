using ConsoleMessengerWithGUI;
using Terminal.Gui;

List<Message> messages = new List<Message>();
MessengerClientAPI API = new MessengerClientAPI();

MenuBar menuBar = null;
Window mainWindow = null;
Window messagesWindow = null;
Label messageLabel = null;
Label userLabel = null;
TextField messageField = null;
TextField userField = null;
Button sendButton = null;


Application.Init();
var top = Application.Top;

//menuBar = new MenuBar(new MenuBarItem[]
//{
//            new MenuBarItem("_App", new MenuBar[]
//            {
//                //new MenuItem("_Quit",
//                //             "Close the app",
//                //             Application.RequestStop),
//            }),
//});
top.Add(menuBar);

mainWindow = new Window()
{
    Title = "TerminalGUI Messenger",
    X = 0,
    Y = 1,
    Width = Dim.Fill(),
    Height = Dim.Fill()
};
top.Add(mainWindow);

messagesWindow = new Window()
{
    X = 0,
    Y = 0,
    Width = mainWindow.Width,
    Height = mainWindow.Height - 2
};
mainWindow.Add(messagesWindow);

userLabel = new Label()
{
    X = 0,
    Y = Pos.Bottom(mainWindow) - 5,
    Width = 15,
    Height = 1,
    Text = "Username:"
};
mainWindow.Add(userLabel);

userField = new TextField()
{
    X = 15,
    Y = Pos.Bottom(mainWindow) - 5,
    Width = mainWindow.Width - 14,
    Height = 1
};
mainWindow.Add(userField);

messageLabel = new Label()
{
    X = 0,
    Y = Pos.Bottom(mainWindow) - 4,
    Width = 15,
    Height = 1,
    Text = "Message:"
};
mainWindow.Add(messageLabel);

messageField = new TextField()
{
    X = 15,
    Y = Pos.Bottom(mainWindow) - 4,
    Width = mainWindow.Width - 14,
    Height = 1
};
mainWindow.Add(messageField);

sendButton = new Button()
{
    X = Pos.Right(mainWindow) - 10 - 5,
    Y = Pos.Bottom(mainWindow) - 4,
    Width = 10,
    Height = 1,
    Text = "  Send  "
};
mainWindow.Add(sendButton);

sendButton.Clicked += sendButtonClick;

var updateLoop = new System.Timers.Timer();
updateLoop.Interval = 1000;
int MessageID = 0;
updateLoop.Elapsed += (sender, eventArgs) =>
{
    Message message = API.GetMessage(MessageID);
    while (message != null)
    {
        messages.Add(message);
        UpdateMessages();
        MessageID++;
        message = API.GetMessage(MessageID);
    }
};
updateLoop.Start();

Application.Run();
Console.Clear();

void sendButtonClick()
{
    if (messageField.Text.ToString() != "" && userField.Text.ToString() != "")
    {
        var message = new Message(userField.Text.ToString(),
                                  messageField.Text.ToString(),
                                  DateTime.Now);
        API.SendMessage(message);

        messageField.Text = "";
    }
}

void UpdateMessages()
{
    messagesWindow.RemoveAll();
    int offset = 0;
    for (var i = messages.Count - 1; i >= 0; i--)
    {
        var message = messages[i];
        messagesWindow.Add(new View()
        {
            X = 0,
            Y = offset,
            Width = messagesWindow.Width,
            Height = 1,
            Text = message.ToString()
        });
        offset++;
    }
    Application.Refresh();
}
