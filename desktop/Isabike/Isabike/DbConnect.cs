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

        public static JArray getFilteredData(string uri,string filter)
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
                    var filtered = termekekFiltered.Where(termek => termek.gyarto_neve == filter);
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

    }
}
