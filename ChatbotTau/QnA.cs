using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotTau
{
    class QnA // класс "Вопрос и ответы", содержащий вопрос, ответы, и список ключевых слов для каждого ответа
    {
        string question; // вопрос
        List<Answer> answersList; // список ответов, и список ключевых слов для каждого ответа

        public string QuestionWording
        {
            get { return question; }
        }

        public string GetAnswer(string userWord) //получение ответа на вопрос по слову фразы пользователя, null, если ответ не найден
        {
            for(int i = 0; i < answersList.Count; i++)
            {
                if(answersList[i].IsRightKeyword(userWord))
                {
                    return answersList[i].Wording;
                }
            }
            return null;
        }

        public void AddAnswer(string wording)
        {
            answersList.Add(new Answer(wording));
        }

        public void AddKeywordToLastAnswer(string keyword)
        {
            answersList.Last().AddKeyword(keyword);
        }

        public QnA(string questionWording)
        {
            question = questionWording;
            answersList = new List<Answer>();
        }
    }
}
