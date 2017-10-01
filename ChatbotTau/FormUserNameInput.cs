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
    public partial class FormUserNameInput : Form
    {
        string userName;

        public string UserNameResult
        {
            get { return userName; }
        }

        public FormUserNameInput()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            userName = textBoxInput.Text;
            this.DialogResult = (userName.Length != 0) ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        
    }
}
