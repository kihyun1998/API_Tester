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
using System.Runtime.InteropServices;

namespace API_Tester
{
    public partial class Form1 : Form
    {
        [DllImport("request.dll")]
        public static extern IntPtr RequestGet(byte[] url, byte[] cookie);

        [DllImport("request.dll")]
        public static extern IntPtr RequestPPD(byte[] method, byte[] url, byte[] cookie, byte[] msg);

        [DllImport("request.dll")]
        public static extern void Free();


        string _url = string.Empty;
        string _method = string.Empty;
        string _cookie = string.Empty;
        string _postData = string.Empty;
        string _err = string.Empty;
        public TreeNode _selectedNode = null;
        public string[] _methods = { "GET", "POST", "PUT", "DELETE" };

        Thread _threadRequest = null;
        Repository _rt = null;

        int _lx = 0;
        int _ly = 0;


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            _lx = this.Location.X;
            _ly = this.Location.Y;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cBoxMethod.Items.AddRange(_methods);
            cBoxMethod.SelectedIndex = 0;
            btnNom.Visible = false;
        }

        ///////
        /// 사이드 창 같이 움직이기
        private void Form1_Move(object sender, EventArgs e)
        {

            if (_rt != null)
            {
                _lx = this.Location.X;
                _ly = this.Location.Y;
                _rt.Location = new Point(_lx - _rt.Width, _ly);
            }
        }


        ///////
        ///트리 뷰 조작

        private void btnLeft_Click(object sender, EventArgs e)
        {
            btnRight.Visible = true;
            btnLeft.Visible = false;

            _lx = this.Location.X;
            _ly = this.Location.Y;

            _rt = new Repository(this);
            _rt.StartPosition = FormStartPosition.Manual;
            _rt.Location = new Point(_lx - _rt.Width, _ly);
            _rt.Show();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            

            btnRight.Visible = false;
            btnLeft.Visible = true;

            if (_selectedNode != null)
            {
                string savePath = getSavePath();
                FileInfo saved = new FileInfo(savePath);
                if (saved.Exists)
                {
                    string[] saveData = System.IO.File.ReadAllLines(savePath);
                    if (IsChanged(saveData))
                    {
                        questionSave(savePath);
                    }
                }
                else
                {
                    string[] data = new string[] { _methods[0], "", "", "" };
                    if (IsChanged(data))
                    {
                        questionSave(savePath);
                    }
                }
            }
            
            _rt.Close();
            _rt = null;
            _selectedNode = null;
            lblTitle.Visible = false;
            btnSave.Visible = false;
            cBoxMethod.Text = _methods[0];
            tBoxURL.Text = string.Empty;
            tBoxCookie.Text = string.Empty;
            tBoxMsg.Text = string.Empty;
            isUse();
        }

        /////////////////
        /// 잡다한 함수
        private void questionSave(string savePath)
        {
            if (MessageBox.Show("변경내용이 있습니다.\n저장 하시겠습니까?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<string> writeList = new List<string>();
                writeList.Add(cBoxMethod.Text);
                writeList.Add(tBoxURL.Text);
                writeList.Add(tBoxCookie.Text);
                writeList.Add(tBoxMsg.Text);

                string[] writeArr = writeList.ToArray();

                System.IO.File.WriteAllLines(savePath, writeArr);
                MessageBox.Show("저장되었습니다.");
            }
            else
            {
                cBoxMethod.Text = _methods[0];
                tBoxURL.Text = string.Empty;
                tBoxCookie.Text = string.Empty;
                tBoxMsg.Text = string.Empty;
            }
        }


        private string getSavePath()
        {
            try
            {
                string savePath = string.Format("..\\{0}\\{1}", _selectedNode.FullPath, "save_file");
                return savePath;
            }
            catch
            {
                MessageBox.Show("노드 선택 여부 검사 안함");
                return "";
            }   
        }

        private bool IsChanged(string[] read)
        {
            if (cBoxMethod.Text == read[0] && tBoxURL.Text == read[1] && tBoxCookie.Text == read[2] && tBoxMsg.Text == read[3])
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void notUse()
        {
            tBoxURL.BackColor = Color.Gray;
            tBoxCookie.BackColor = Color.Gray;
            tBoxMsg.BackColor = Color.Gray;
            cBoxMethod.Enabled = false;
            tBoxURL.Enabled = false;
            tBoxCookie.Enabled = false;
            tBoxMsg.Enabled = false;
        }

        public void isUse()
        {
            tBoxURL.BackColor = Color.WhiteSmoke;
            tBoxCookie.BackColor = Color.WhiteSmoke;
            tBoxMsg.BackColor = Color.WhiteSmoke;
            cBoxMethod.Enabled = true;
            tBoxURL.Enabled = true;
            tBoxCookie.Enabled = true;
            tBoxMsg.Enabled = true;
        }

        /////////////////////////////


        ////////////////
        ///HTTP Request
        private void btnRequest_Click(object sender, EventArgs e)
        {
            tBoxRst.Text = string.Empty;
            btnRequest.Enabled = false;
            cBoxMethod.Enabled = false;

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
            IntPtr pRst;

            if (_method == "GET")
            {
                pRst = RequestGet(
                    Encoding.UTF8.GetBytes(_url),
                    Encoding.UTF8.GetBytes(_cookie));
                
            }
            else // (_method == "POST" || _method == "PUT" || _method == "DELETE")
            {
                pRst = RequestPPD(
                    Encoding.UTF8.GetBytes(_method),
                    Encoding.UTF8.GetBytes(_url),
                    Encoding.UTF8.GetBytes(_cookie),
                    Encoding.UTF8.GetBytes(_postData));
            }
            Free();

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(delegate ()
                {
                    string resText = MarshalUtf8ToUnicode(pRst);
                    

                    if (resText.StartsWith("[Error]"))
                    {
                        ErrMsg(resText);
                    }
                    else
                    {
                        tBoxRst.Text = resText;
                    }
                }));
            }
        }

        static unsafe string MarshalUtf8ToUnicode(IntPtr pStringUtf82)
        {
            var pStringUtf8 = (byte*)pStringUtf82;
            var len = 0;
            while (pStringUtf8[len] != 0)
                len++;
            return Encoding.UTF8.GetString(pStringUtf8, len);
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
        //////////////////////////////////////


        ////////////////
        /// 파일 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (_rt != null)
            {
                var sNode = _rt.treeView1.SelectedNode;
                string selectPath = string.Format("..\\{0}\\{1}", sNode.FullPath, "save_file");
                

                List<string> writeList = new List<string>();
                writeList.Add(cBoxMethod.Text);
                writeList.Add(tBoxURL.Text);
                writeList.Add(tBoxCookie.Text);
                writeList.Add(tBoxMsg.Text);

                string[] writeArr = writeList.ToArray();

                System.IO.File.WriteAllLines(selectPath, writeArr);
                MessageBox.Show("저장이 완료됐습니다!");
            }
            else
            {
                MessageBox.Show("파일 저장 버그!");
            }
        }


        //////////////////
        ///텍스트 변경 시
        public void TextBox_TextChanged(Object sender, EventArgs e) {


            if (_rt != null)
            {
                string savePath = getSavePath();
                FileInfo save = new FileInfo(savePath);
                if (save.Exists)
                {
                    string[] saveData = System.IO.File.ReadAllLines(savePath);
                    if (IsChanged(saveData))
                    {
                        btnSave.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = false;
                    }
                }
                else
                {
                    string[] data = new string[] { _methods[0], "", "", "" };
                    if (IsChanged(data))
                    {
                        btnSave.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = false;
                    }
                }
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
        Rectangle Left { get { return new Rectangle(0, 0, ten, this.ClientSize.Height); } }


        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - ten, this.ClientSize.Width, ten); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - ten, 0, ten, this.ClientSize.Height); } }

        //Rectangle TopLeft { get { return new Rectangle(0, 0, ten, ten); } }
        //Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - ten, 0, ten, ten); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - ten, ten, ten); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - ten, this.ClientSize.Height - ten, ten, ten); } }

        // 창 변환 구간 함수
        protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
        {
            //e.Graphics.FillRectangle(Brushes.White, Top);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, Left);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, Right);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, Bottom);
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
                if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                //else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
        /////////////////////////////
    }
}
