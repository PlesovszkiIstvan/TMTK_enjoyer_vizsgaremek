using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isabike
{
    internal class DbConnect
    {
        public static JArray getData(string uri)
        {

            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (s.Length > 0))
                {
                    return JsonConvert.DeserializeObject<JArray>(s);
                }
                else
                {
                    MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}
