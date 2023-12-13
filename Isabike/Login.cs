using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isabike
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (Username.Text=="root" && Password.Text=="root") {
                MainForm main = new MainForm();
                this.Visible = false;
                main.ShowDialog();
                
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
