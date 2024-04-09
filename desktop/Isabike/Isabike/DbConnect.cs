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
using System.Security.Policy;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using K4os.Compression.LZ4.Streams.Abstractions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Isabike
{
    internal class DbConnect
    {

        public static List<Termekek> termekek = new List<Termekek>();

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

                    termekek = JsonConvert.DeserializeObject<List<Termekek>>(s);
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

        public static JArray getFilteredData(string uri, string termeknev, double suly, string gyarto)
        {

            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (s.Length > 0))
                {
                    List<Termekek> termekekFiltered = JsonConvert.DeserializeObject<List<Termekek>>(s);
                    var filtered = termekekFiltered.Where(termek => termek.gyarto_neve == gyarto)
                        .Where(termek => termek.termek_nev == termeknev)
                        .Where(termek => termek.tomeg_erteke == suly);
                    return JArray.FromObject(filtered);
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

        public static void loginToProg( string email, string password, string url) {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using(var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
{
                string json = "{\"password\":\"" + password +"\"," +
                              "\"email\":\""+ email +"\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result);
                string token = DbOperations.getKey(result);
                Login.setToken(token);
            }
        }


        public static void logOut(string token, string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"token\":\"" + token + "\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result);
            }
        }
    }
}

