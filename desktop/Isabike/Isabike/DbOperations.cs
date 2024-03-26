using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isabike
{
    internal class DbOperations
    {
        public static string getKey(string res) {
            var charsToRemove = new string[] { "\"","{","}"};

            foreach (var c in charsToRemove)
            {
                res = res.Replace(c, string.Empty);
            }

            string[] splitedRes = res.Split(',');

            string[] keyLocation = splitedRes[1].Split(':');

            MessageBox.Show(keyLocation[1]);

            return keyLocation[1];
        }   
    }
}
