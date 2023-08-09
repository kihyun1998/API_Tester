using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace API_Tester
{
    public partial class Request : Form
    {
        public delegate void delReturn(object sender, string[] rst);
        public event delReturn returnMsg;

        string _url = string.Empty;
        string _method = string.Empty;
        string _cookie = string.Empty;
        string _postData = string.Empty;

        Thread _thread = null;

        public Request()
        {
            InitializeComponent();
        }
        
        public Request(string url, string method, string cookie)
        {
            InitializeComponent();
            _url = url;
            _method = method;
            _cookie = cookie;
        }
        public Request(string url, string method, string cookie, string postData)
        {
            InitializeComponent();
            _url = url;
            _method = method;
            _cookie = cookie;
            _postData = postData;
        }

        public void RequestThreadStart()
        {
            _thread = new Thread(new ThreadStart(Run));
            _thread.Start();
        }

        private void Run()
        {
            Communication call = new Communication();

            if (_method == "GET")
            {
                string[] rst = call.Request(_url, _method, _cookie);
                returnMsg(this, rst);
            }
            else if (_method == "POST" || _method == "PUT" || _method == "DELETE")
            {
                
                string[] rst = call.Request(_url, _method, _cookie, _postData);
                returnMsg(this, rst);
            }
        }
    }
}
