using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotTau
{
    static class FileInterface
    {
        public static void ReadQnAFromFile()
        {
            QnAData.CreateQnAList();
            string[] lines = System.IO.File.ReadAllLines(@"./QnAData/QnA.txt", Encoding.Default);
            foreach (string line in lines)
            {
                if (line[line.Length - 1] == '?')
                {
                    QnAData.AddQuestion(line);
                }
                else
                {
                    if (line[line.Length - 1] == '.')
                    {
                        QnAData.AddAnswerToLastQuestion(line);
                    }
                    else
                    {
                        QnAData.AddKeywordsToLastQuestion(line);
                    }
                }
            }
        }
    }
}