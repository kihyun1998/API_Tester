﻿using System;
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
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            string[] method = { "GET", "POST", "PUT", "DELETE" };
            cBoxMethod.Items.AddRange(method);
            cBoxMethod.SelectedIndex = 0;
            tBoxRst.Enabled = false;
            btnNom.Visible = false;
        }

        private async void btnRequest_Click(object sender, EventArgs e)
        {
            string[] rst;
            tBoxRst.Text = "";
            btnRequest.Enabled = false;
            cBoxMethod.Enabled = false;

            Communication call = new Communication();

            string sUrl = tBoxURL.Text.ToString();
            string sMethod = cBoxMethod.SelectedItem.ToString();
            string sCookie = tBoxCookie.Text.ToString();

            if (sMethod == "GET")
            {
                rst = await call.Request(sUrl, sMethod, sCookie);
            }
            else // (sMethod == "POST" || sMethod == "PUT" || sMethod == "DELETE")
            {
                string sPostData = tBoxMsg.Text.ToString();
                rst = await call.Request(sUrl, sMethod, sCookie, sPostData);
            }
            string resText = rst[0];

            tBoxRst.Text = resText;

            string err = rst[1];
            if (err.Length != 0)
            {
                ErrMsg(err);
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



        ///////////////////////
        ///패널 이동 + 상단바
        bool mouseDown;
        int sizeX;
        int sizeY;



        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            sizeX = e.X + 20;
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

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            btnNom.Visible = true;
            btnMax.Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnNom_Click(object sender, EventArgs e)
        {
            btnNom.Visible = false;
            btnMax.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        ////////////////////////////////////////////////////////////


        ////////////////////
        ///화면 사이즈 변경
        
        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int ten = 10;

        //Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, ten); } }
        //Rectangle Left { get { return new Rectangle(0, 0, ten, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - ten, this.ClientSize.Width, ten); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - ten, 0, ten, this.ClientSize.Height); } }

        //Rectangle TopLeft { get { return new Rectangle(0, 0, ten, ten); } }
        //Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - ten, 0, ten, ten); } }
        //Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - ten, ten, ten); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - ten, this.ClientSize.Height - ten, ten, ten); } }

        // 창 변환 구간 함수
        protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
        {
            //e.Graphics.FillRectangle(Brushes.White, Top);
            //e.Graphics.FillRectangle(Brushes.White, Left);
            e.Graphics.FillRectangle(Brushes.White, Right);
            e.Graphics.FillRectangle(Brushes.White, Bottom);
        }

        // 커서 변경 함수
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                //if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                //else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                //if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                //else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                //else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
    }
}
