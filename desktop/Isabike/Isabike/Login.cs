using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        private void loginBtn_Click(object sender, EventArgs e)
        {
            DbConnect.loginToProg(EmailTextfield.Text, PasswordTextfield.Text, "http://172.16.16.157:8000/api/login");
            MainForm main = new MainForm();
            this.Visible = false;
            main.ShowDialog();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
