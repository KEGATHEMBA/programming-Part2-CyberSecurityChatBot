using CyberSecurityBot;
using System.Windows;
using System.Windows.Documents;

namespace CyberSecuritybot
{
    public partial class MainWindow : Window

    {
        ChatBot bot = new ChatBot();

        MemoryStore memory = new MemoryStore();

        public MainWindow()
        {
            InitializeComponent();

            AddBotMessage("Welcome to the Cybersecurity Chatbot!");
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = txtMessage.Text;

            if (userMessage.ToLower().Contains("my name is"))

            {
                string name = userMessage.Replace("my name is", "").Trim();

                memory.SaveMemory("username", name);

                AddBotMessage("Nice to meet you" + name);

                txtMessage.Clear();

                return;
            }

            AddUserMessage(userMessage);

            string savedName = memory.GetMemory("username");

            if (savedName != "")

            {
                AddBotMessage("Welcome back " + savedName);
            }

            string response = bot.GetReply(userMessage);

            AddBotMessage(response);

            txtMessage.Clear();
        }

        private void AddBotMessage(string message)
        {
            rtbChat.Document.Blocks.Add(
                new Paragraph(new Run("Bot: " + message)));
        }

        private void AddUserMessage(string message)
        {
            rtbChat.Document.Blocks.Add(
                new Paragraph(new Run("You: " + message)));
        }
    }
}