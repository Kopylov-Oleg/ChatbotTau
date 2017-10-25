using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotTau
{
    static class QnAData
    {
        static List<QnA> QnAList;
        static string defanswer = "Понятно.";
        static string defstart = "Привет. Я не бот. Давай общаться.";

        public static Random rng = new Random();

        public static string DefaultStart()
        {
            return defstart;
        }

        public static string DefaultAnswer()
        {
            return defanswer;
        }

        public static void CreateQnAList()
        {
            QnAList = new List<QnA>();
        }

        public static void AddQuestion(string wording)
        {
            QnAList.Add(new QnA(wording));
        }

        public static void AddAnswerToLastQuestion(string wording)
        {
            QnAList.Last().AddAnswer(wording);
        }

        public static void AddKeywordsToLastQuestion(string keywords)
        {
            if (keywords.Length == 0)
            {
                return;
            }
            var keyswordsArray = keywords.Split(' ');
            for(int i = 0; i < keyswordsArray.Length; i++)
            {
                QnAList.Last().AddKeywordToLastAnswer(keyswordsArray[i]);
            }
        }

        public static string GetQuestion(int number)
        {
            return QnAList[number].QuestionWording;
        }

        public static int GetQuestionsCount()
        {
            return QnAList.Count();
        }

        public static string GetAnswer(int questionNumber, string userWord)
        {
            return QnAList[questionNumber].GetAnswer(userWord);
        }
    }
}
