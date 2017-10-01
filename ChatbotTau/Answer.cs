using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotTau
{
    class Answer // класс "Ответ" - ключевые слова и текст ответа ответ
    {
        List<string> keywords; // ключевые слова
        string ansWording; // формулировка ответа

        public string Wording
        {
            get { return ansWording; }
        }

        public bool IsRightKeyword(string word) // проверка, является ли полученное слова ключевым для данного вопроса
        {
            for(int i = 0; i < keywords.Count; i++)
            {
                if(keywords[i] == word)
                {
                    return true;
                }
            }              
            return false;
        }

        public void AddKeyword(string keyword) // добавление ключевого слова
        {
            keywords.Add(keyword);
        }

        public Answer(string Wording)
        {
            keywords = new List<string>();
            ansWording = Wording;
        }
    }
}
