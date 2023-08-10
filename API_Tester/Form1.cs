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
        string _url = string.Empty;
        string _method = string.Empty;
        string _cookie = string.Empty;
        string _postData = string.Empty;
        string _err = string.Empty;

        Thread _threadRequest = null;


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
            btnNom.Visible = false;
        }

        private async void btnRequest_Click(object sender, EventArgs e)
        {
            string[] rst;
            tBoxRst.Text = string.Empty;
            btnRequest.Enabled = false;
            cBoxMethod.Enabled = false;

            Communication call = new Communication();

            _url = tBoxURL.Text.ToString();
            _method = cBoxMethod.SelectedItem.ToString();
            _cookie = tBoxCookie.Text.ToString();
            _postData = tBoxMsg.Text.ToString();

            _threadRequest = new Thread(new ThreadStart(Request));
            _threadRequest.Start();

            btnRequest.Enabled = true;
            cBoxMethod.Enabled = true;
        }

        private void Request()
        {
            Communication call = new Communication();
            Communication.Result rst;

            if (_method == "GET")
            {
                rst = call.Request(_url, _method, _cookie);
            }
            else // (_method == "POST" || _method == "PUT" || _method == "DELETE")
            { 
                rst = call.Request(_url, _method, _cookie, _postData);
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(delegate ()
                {
                    string resText = rst.ResultText;
                    tBoxRst.Text = resText;

                    string err = rst.Err;
                    if (err.Length != 0)
                    {
                        ErrMsg(err);
                    }
                }));
            }
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
                tBoxRst.Text = string.Empty;
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
            if (_threadRequest.IsAlive)
            {
                _threadRequest.Join(100);
                _threadRequest.Interrupt();
            }
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
