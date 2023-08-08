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

        private async void btnRequest_Click(object sender, EventArgs e)
        {
            tBoxRst.Text = "";
            btnRequest.Enabled = false;
            cBoxMethod.Enabled = false;

            Communication call = new Communication();

            string sUrl = tBoxURL.Text.ToString();
            string sMethod = cBoxMethod.SelectedItem.ToString();
            call.cookie = tBoxCookie.Text.ToString();

            if(sMethod == "GET")
            {
                string[] rst = await call.Request(sUrl, sMethod, call.cookie);
                string resText = rst[0];

                tBoxRst.Text = resText;

                string err = rst[1];
                if (err.Length != 0)
                {
                    ErrMsg(err);
                }
            }else if (sMethod == "POST" || sMethod == "PUT" || sMethod == "DELETE")
            {
                String sPostData = tBoxMsg.Text.ToString();
                string[] rst = await call.Request(sUrl, sMethod, call.cookie, sPostData);
                string resText = rst[0];
                tBoxRst.Text = resText;

                string err = rst[1];
                if (err.Length != 0)
                {
                    ErrMsg(err);
                }
            }

            btnRequest.Enabled = true;
            cBoxMethod.Enabled = true;
        }

        private void ErrMsg(string err)
        {
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
                tBoxRst.Text = "";
            }
        }

        private void cBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxMethod.Text == "POST" || cBoxMethod.Text == "PUT" || cBoxMethod.Text == "DELETE")
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



        ///////////////////
        ///패널 이동

        bool mouseDown;
        int sizeX;
        int sizeY;

        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            sizeX = e.X+20;
            sizeY = e.Y;
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                this.SetDesktopLocation(MousePosition.X - sizeX, MousePosition.Y - sizeY);
            }
        }

        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
