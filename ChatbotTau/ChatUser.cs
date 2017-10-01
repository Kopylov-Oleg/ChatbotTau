using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotTau
{
    class ChatUser
    {
        string username;

        public string Name
        {
            get { return username; }
        }

        public ChatUser(string name)
        {
            this.username = name;
        }
    }
}
