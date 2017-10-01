using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotTau
{
    static class ChatboxIOInterface
    {
        public static void SendMessage(System.Windows.Forms.RichTextBox richTextBoxChat, ChatUser sender, string message, Color userColor)
        {
            if (message.Length != 0)
            {
                string textForPrinting;
                Color oldColor = richTextBoxChat.SelectionColor;

                textForPrinting = sender.Name + ": ";
                richTextBoxChat.SelectionColor = userColor;
                richTextBoxChat.AppendText(textForPrinting);

                textForPrinting = message + Environment.NewLine;
                richTextBoxChat.SelectionColor = oldColor;
                richTextBoxChat.AppendText(textForPrinting);
            }            
        }
    }
}
