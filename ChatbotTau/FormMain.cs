using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatbotTau
{
    public partial class FormMain : Form
    {
        //Пользователи
        ChatUser User;
        ChatUser BotTau;

        public FormMain()
        {
            InitializeComponent();
            MinimumSize = Size;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            GetUserName(); //открытие формы ввода ника пользователя
            BotTau = new ChatUser("Бот"); // добавление пользователя "бот"
            FileInterface.ReadQnAFromFile();            
            Send(BotTau, ChatbotAI.StartConversation(), Color.DarkRed); // печать сообщения бота
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message = textBoxInput.Text;
            if(message.Length != 0)
            {
                Chatting(message); //функция реализации общения
            }            
        }

        #region Функции

        void GetUserName() //открытие формы ввода ника пользователя
        {
            FormUserNameInput fUserNameInput = new FormUserNameInput();
            var inputResult = fUserNameInput.ShowDialog();
            if (inputResult == DialogResult.OK)
            {
                User = new ChatUser(fUserNameInput.UserNameResult);
            }
            else
            {
                this.Close();
            }
        }

        void Chatting(string userMessage) //функция реализации общения
        {
            Send(User, userMessage, Color.DarkBlue); // печать сообщения пользователя
            Send(BotTau, ChatbotAI.React(userMessage), Color.DarkRed); // печать сообщения бота
        }

        void Send(ChatUser sender, string message, Color userColor) // печать сообщения в richTextBoxChat
        {
            ChatboxIOInterface.SendMessage(richTextBoxChat, sender, message, userColor);
        }

        #endregion
    }
}
