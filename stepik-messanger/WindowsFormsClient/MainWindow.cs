using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient
{

    public partial class MainWindow : Form
    {
        private static int MessageID = 0;
        private static string UserName = "NoName";
        private static MessengerClientAPI API = new MessengerClientAPI();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            string enterMessage = messageTextBox.Text;
            if((enterMessage.Length > 0))
            {
                Message message = new Message(UserName,enterMessage,DateTime.Now);
                API.SendMessage(message);
            }
        }

        private void nameTextBox_TextChanged(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                UserName = nameTextBox.Text;
            }

        }

        private void UpdateMessagesTimer_Tick(object sender, EventArgs e)
        {
            var getMessage = new Func<Task>(async () =>
            {
                Message message = await API.GetMessageHTTPAsync(MessageID);
                while (message != null)
                {
                    MessagesListBox.Items.Add(message);
                    MessageID++;
                    message = await API.GetMessageHTTPAsync(MessageID);
                }
                
            });
            getMessage.Invoke();
        }
    }

}
