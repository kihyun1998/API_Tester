using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace API_Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] method = { "GET", "POST", "PUT", "DELETE" };
            cBoxMethod.Items.AddRange(method);
            cBoxMethod.SelectedIndex = 0;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            lBoxRst.Items.Clear();
            btnRequest.Enabled = false;
            cBoxMethod.Enabled = false;

            Communication call = new Communication();


            string sMethod = cBoxMethod.SelectedItem.ToString();
            string sUrl = tBoxURL.Text.ToString();
            call.cookie = tBoxCookie.Text.ToString();

            string[] args = new string[] { sUrl, sMethod,  call.cookie };
            backgroundWorker1.RunWorkerAsync(args);
            
        }

        private void cBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBoxMethod.Text == "POST" || cBoxMethod.Text == "PUT" || cBoxMethod.Text == "DELETE")
            {
                tBoxMsg.Visible = true;
                lblMsg.Visible = true;
            }
            else
            {
                tBoxMsg.Visible = false;
                lblMsg.Visible = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Communication call = new Communication();
            BackgroundWorker worker = sender as BackgroundWorker;

            string[] args = e.Argument as string[];


            if (args[1] == "GET")
            {
                string[] resLines = call.Request(args[0], args[1], call.cookie, out string err);
                add_lines(resLines);
                if (err.Length != 0)
                {
                    MessageBox.Show(err);
                    if (err.Contains("404"))
                    {
                        tBoxURL.Text = "";
                        tBoxURL.Focus();
                    }
                    else if (err.Contains("401"))
                    {
                        tBoxCookie.Text = "";
                        tBoxCookie.Focus();
                    }
                    else if (err.Contains("URI"))
                    {
                        tBoxURL.Text = "";
                        tBoxURL.Focus();
                    }
                    lBoxRst.Items.Clear();
                }
            }
            else if (args[1] == "POST" || args[1] == "PUT" || args[1] == "DELETE")
            {
                String sPostData = tBoxMsg.Text.ToString();
                string[] resLines = call.Request(args[0], args[1], call.cookie, sPostData, out string err);
                
                add_lines(resLines);
                if (err.Length != 0)
                {
                    MessageBox.Show(err);
                    if (err.Contains("404"))
                    {
                        tBoxURL.Text = "";
                        tBoxMsg.Text = "";
                        tBoxURL.Focus();
                    }
                    else if (err.Contains("401"))
                    {
                        tBoxCookie.Text = "";
                        tBoxCookie.Focus();
                    }
                    else if (err.Contains("URI"))
                    {
                        tBoxURL.Text = "";
                        tBoxURL.Focus();
                    }
                    lBoxRst.Items.Clear();
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRequest.Enabled = true;
            cBoxMethod.Enabled = true;
        }



        private string get_URL()
        {
            string sUrl="";
            if (tBoxURL.InvokeRequired == true)
            {
                tBoxURL.Invoke((MethodInvoker)delegate
                {
                    sUrl = tBoxURL.Text.ToString();
                });
            }
            else
            {
                sUrl = tBoxURL.Text.ToString();
                return sUrl;
            }
            return sUrl;
        }

        private string get_Method()
        {
            string sMethod = "";
            if (cBoxMethod.InvokeRequired == true)
            {
                cBoxMethod.Invoke((MethodInvoker)delegate
                {
                    sMethod = cBoxMethod.SelectedItem.ToString();
                });
            }
            else
            {
                sMethod = cBoxMethod.SelectedItem.ToString();
            }
            return sMethod;
        }

        private void add_lines(string[] resLines)
        {
            if (lBoxRst.InvokeRequired == true)
            {
                lBoxRst.Invoke((MethodInvoker)delegate
                {
                    foreach (string line in resLines)
                    {
                        lBoxRst.Items.Add(string.Format("{0},", line as string));
                        Thread.Sleep(100);
                    }
                });
            }
            else
            {
                foreach (string line in resLines)
                {
                    lBoxRst.Items.Add(string.Format("{0},", line as string));
                    Thread.Sleep(100);
                }
            }
            
        }

        
    }
}
