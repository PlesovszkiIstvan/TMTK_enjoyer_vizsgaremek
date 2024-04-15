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
using MySqlX.XDevAPI;
using System.Net.Http;

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


        public static JArray getUserData(string uri)
        {

            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                
                webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Login.getToken());
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string jsonResponse = reader.ReadToEnd();
                JObject responseObject = JObject.Parse(jsonResponse);
                JArray data = (JArray)responseObject["data"];
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static JArray getFilteredData(string uri, string termeknev)
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
                    var filtered = termekekFiltered.Where(termek => termek.termek_nev == termeknev);
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

        public static bool checkPrivilege(string token)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/api/getonefelhasznalo");
                webRequest.ContentType = "application/json";
                webRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    string json = "{\"token\":\"" + token + "\"}";
                    streamWriter.Write(json);
                }
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string jsonResponse = reader.ReadToEnd();
                JObject responseObject = JObject.Parse(jsonResponse);
                JArray data = (JArray)responseObject["data"];
                var adat = data[0];
                if (adat["jogosultsag"].Value<int>() > 1)
                {
                    return true;
                }
                else {
                    MessageBox.Show("Hiba!","Az alkalmazás használatához nincs jogosultságot");
                    return false; 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool loginToProg( string email, string password, string url) {
            try
            {
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
                    string token = DbOperations.getKey(result);
                    Login.setToken(token);
                    if (checkPrivilege(token))
                    {
                        return true;
                    }
                    else
                    {
                        logOut(token, "http://127.0.0.1:8000/api/logout");
                        return false;
                    }
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Hibás bejelentkezési paraméterek!");
                return false;
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
            }
        }

        public static JArray getOrderData(string token, string uri) 
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                
                webRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Login.getToken());
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string jsonResponse = reader.ReadToEnd();
                JObject responseObject = JObject.Parse(jsonResponse);
                JArray data = (JArray)responseObject["data"];
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static JArray getOrderData( string uri)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                JObject responseObject = JObject.Parse(s);
                JArray data = (JArray)responseObject["data"];
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


    }
}

