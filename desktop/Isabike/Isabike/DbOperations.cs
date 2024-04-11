using MySqlX.XDevAPI;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isabike
{
    internal class DbOperations
    {
        public static string getKey(string res)
        {
            var charsToRemove = new string[] { "\"", "{", "}" };

            foreach (var c in charsToRemove)
            {
                res = res.Replace(c, string.Empty);
            }

            string[] splitedRes = res.Split(',');

            string[] keyLocation = splitedRes[1].Split(':');

            MessageBox.Show(keyLocation[1]);

            return keyLocation[1];
        }

        public static void addProduct(string jsondata, string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsondata);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result);
            }

        }

        public async void deleteProduct(string jsondata, string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Login.getToken());

                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Content = new StringContent(jsondata, Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(url)
                    };
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Item deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show($"Failed to delete item. Status code: {response.StatusCode}");
                        // Optionally, you can read the response content for more details
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Response body: {responseBody}");
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }

        }

        public async void updateProduct(string jsondata, string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Login.getToken());

                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Content = new StringContent(jsondata, Encoding.UTF8, "application/json"),
                        Method = new HttpMethod("PATCH"),
                        RequestUri = new Uri(url)
                    };
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Item updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show($"Failed to updated item. Status code: {response.StatusCode}");
                        // Optionally, you can read the response content for more details
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Response body: {responseBody}");
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }

        }

        public async void updateUser(string jsonData, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Content = new StringContent(jsonData, Encoding.UTF8, "application/json"),
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(url)
                };
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("User updated successfully.");
                }
                else
                {
                    MessageBox.Show($"Failed to updated user. Status code: {response.StatusCode}");
                    // Optionally, you can read the response content for more details
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Response body: {responseBody}");
                }
            }
        }
    }
}
