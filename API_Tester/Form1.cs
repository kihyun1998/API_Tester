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
            

            Communication call = new Communication();
            string sMethod = cBoxMethod.SelectedItem.ToString();
            string sUrl = tBoxURL.Text.ToString();
            call.cookie = tBoxCookie.Text.ToString();

            if (sMethod == "GET")
            {
                string[] resLines = call.Request(sUrl, sMethod, call.cookie, out string err);
                foreach (string line in resLines)
                {
                    lBoxRst.Items.Add(string.Format("{0},",line as string));
                }
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
            else if(sMethod == "POST" || sMethod == "PUT" || sMethod == "DELETE")
            {
                String sPostData = tBoxMsg.Text.ToString();
                string[] resLines = call.Request(sUrl, sMethod, call.cookie, sPostData, out string err);
                foreach (string line in resLines)
                {
                    lBoxRst.Items.Add(string.Format("{0},", line as string));
                }
                if( err.Length != 0)
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
    }
}
