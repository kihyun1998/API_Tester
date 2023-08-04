using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Tester
{
    class Communication
    {
        public string cookie = "sessionID=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwZXJzb24iOnsiSUQiOiJhcGFkbWluIiwiTmFtZSI6IiIsIlR5cGUiOiJBUElUb2tlbiJ9LCJDb25zb2xlVHlwZSI6ImFwaXRva2VuIiwiSVAiOiIxOTIuMTY4LjEzNy4xIiwianRpIjoiY2QyZTkzMDViZjg5NDc0NWIyNWFkM2I2MjA0ODFlZWEifQ.ZOYB1XjH502-JrZiFgz71smlJLBj0w_dM3LBMhkiZkg";
        

        public string[] Request(string url, string method, string cookie, out string err)
        {
            string[] lines;

            try 
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = method;
                req.Headers.Add("Cookie", cookie);

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (Stream dataStream = res.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string readRes = reader.ReadToEnd();

                    lines = readRes.Split(new[] { "," }, StringSplitOptions.None);
                    err = "";
                    return lines;
                }

                res.Close();
                return lines;
            }
            catch(Exception e)
            {
                err = e.Message;
                lines = new string[]{ "" };
                return lines;
            }   
        }

        public string[] Request(string url, string method, string cookie, string postData, out string err)
        {
            string[] lines;

            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = method;

                string postMsg = string.Format("msg={0}", postData);
                byte[] data = Encoding.ASCII.GetBytes(postMsg);

                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = data.Length;
                req.Headers.Add("Cookie", cookie);

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                using (Stream dataStream = res.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string readRes = reader.ReadToEnd();

                    lines = readRes.Split(new[] { "," }, StringSplitOptions.None);

                }
                res.Close();
                err = "";
                return lines;
            }
            catch(Exception e)
            {
                err = e.Message;
                lines = new string[] { "" };
                return lines;
            }


           
        }
    }
}
