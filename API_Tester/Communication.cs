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
        //public string cookie = "sessionID=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwZXJzb24iOnsiSUQiOiJhcGFkbWluIiwiTmFtZSI6IiIsIlR5cGUiOiJBUElUb2tlbiJ9LCJDb25zb2xlVHlwZSI6ImFwaXRva2VuIiwiSVAiOiIxOTIuMTY4LjEzNy4xIiwianRpIjoiY2QyZTkzMDViZjg5NDc0NWIyNWFkM2I2MjA0ODFlZWEifQ.ZOYB1XjH502-JrZiFgz71smlJLBj0w_dM3LBMhkiZkg";
        public struct Result
        {
            public string ResultText;
            public string Err;
        };

        public Result Request(string url, string method, string cookie)
        {
            string resText;
            string err;
            Result rst;

            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = method;
                req.Headers.Add("Cookie", cookie);

                using (WebResponse res = req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                    {
                        resText = reader.ReadToEnd();
                        rst.ResultText = resText;

                        err = "";
                        rst.Err = err;
                        return rst;
                    }
                }
            }
            catch (Exception e)
            {
                resText = "";
                rst.ResultText = resText;

                err = e.Message;
                rst.Err = err;
                return rst;
            }
        }

        public Result Request(string url, string method, string cookie, string postData)
        {
            string resText;
            string err;
            Result rst;

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

                using (WebResponse res = req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                    {
                        resText = reader.ReadToEnd();
                        rst.ResultText = resText;

                        err = "";
                        rst.Err = err;
                        return rst;
                    }
                }
            }
            catch (Exception e)
            {
                resText = "";
                rst.ResultText = resText;

                err = e.Message;
                rst.Err = err;
                return rst;
            }



        }
    }
}
