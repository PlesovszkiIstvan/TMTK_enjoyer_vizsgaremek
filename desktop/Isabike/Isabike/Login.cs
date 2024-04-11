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
using System.Runtime.CompilerServices;
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

        private static string token { get;set; }

        public static void setToken(string userToken)
        {
           token = userToken;
        }

        public static string getToken() { return token; }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (DbConnect.loginToProg(EmailTextfield.Text, PasswordTextfield.Text, "http://127.0.0.1:8000/api/login"))
            {
                MessageBox.Show("Sikeres bejelentkezés!");
                MainForm main = new MainForm();
                this.Visible = false;
                main.ShowDialog();
            
            }
            
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
