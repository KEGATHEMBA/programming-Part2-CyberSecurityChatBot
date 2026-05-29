
using CyberSecuritybot;
using CyberSecurityBot;

namespace CyberSecurityBot
{
    public class ChatBot
    {
        private KeywordResponder responder =
            new KeywordResponder();

        private SentimentDetector sentiment =
            new SentimentDetector();

        public string GetReply(string userMessage)
        {
            string mood =
                sentiment.DetectMood(userMessage);

            string response =
                responder.GetResponse(userMessage);

            return mood + "\n" + response;
        }
    }
}