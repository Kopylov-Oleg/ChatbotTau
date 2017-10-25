using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatbotTau
{
    static class ChatbotAI
    {
        static int activeQuestion;

        public static string React(string message)
        {
            return Answer(message) + Environment.NewLine + AskQuestion();
        }

        public static string StartConversation()
        {
            return QnAData.DefaultStart() + Environment.NewLine + AskQuestion();
        }

        static string AskQuestion()
        {
            activeQuestion = QnAData.rng.Next(QnAData.GetQuestionsCount());
            return QnAData.GetQuestion(activeQuestion);
        }

        static string Answer(string message)
        {
            string answer = null;
            char[] arr = message.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c)
                                              || char.IsWhiteSpace(c))));
            //                                || c == '-')));
            message = new string(arr);
            message = message.ToLower();
            var words = message.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                answer = QnAData.GetAnswer(activeQuestion, words[i]);
                if (answer != null)
                    return answer;
            }
            return QnAData.DefaultAnswer();
        }
    }
}
