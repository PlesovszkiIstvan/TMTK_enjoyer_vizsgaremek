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

        public void Serialize(Stream output, object input)
        {
            var ser = new DataContractSerializer(input.GetType());
            ser.WriteObject(output, input);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            this.Visible = false;
            main.ShowDialog();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginshite()
        {
            if (UsernameTextfield.Text != null && PasswordTextfield.Text != null)
            {
                var request = WebRequest.Create("http://172.16.16.157:8000/api/login");
                request.Method = "POST";
                request.ContentType = "application/json";

                if (PasswordTextfield.Text != "" && UsernameTextfield.Text != "")
                {
                    var payload = new
                    {
                        password = PasswordTextfield.Text,
                        email = UsernameTextfield.Text,
                    };

                    var setting = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        Formatting = Formatting.Indented,
                    };

                    string json = JsonConvert.SerializeObject(payload, setting);

                    MessageBox.Show(payload.ToString());
                    Stream dataStream = request.GetRequestStream();
                    Serialize(dataStream, json);
                    dataStream.Close();
                }

                try
                {
                    HttpWebRequest req = WebRequest.Create("http://172.16.16.157:8000/api/login") as HttpWebRequest;

                    WebResponse wr = req.GetResponse();
                    MessageBox.Show(wr.ToString());
                }
                    catch (WebException wex)
                    {
                        var pageContent = new StreamReader(wex.Response.GetResponseStream())
                                              .ReadToEnd();
                        MessageBox.Show(pageContent);
                    }
                }
            }
    }
}
