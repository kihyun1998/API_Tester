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
using System.Xml;


namespace API_Tester
{
    public partial class Form1 : Form
    {
        [DllImport("request.dll")]
        public static extern IntPtr RequestGet(byte[] url, byte[] cookie);

        [DllImport("request.dll")]
        public static extern IntPtr RequestPPD(byte[] method, byte[] url, byte[] cookie, byte[] msg);

        [DllImport("request.dll")]
        public static extern void RequestFree(IntPtr p);




        string _url = string.Empty;
        string _method = string.Empty;
        string _cookie = string.Empty;
        string _postData = string.Empty;
        string _err = string.Empty;
        public bool _canCheck = true;
  
        public string[] _methods = { "GET", "POST", "PUT", "DELETE" };

        Thread _threadRequest = null;
        Repository _repository = null;

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

            if (_repository != null)
            {
                _lx = this.Location.X;
                _ly = this.Location.Y;
                _repository.Location = new Point(_lx - _repository.Width, _ly);
            }
        }


        /////////////////
        ///트리 뷰 조작
        
        //////////
        /// 좌측 repository 창 열기
        private void btnLeft_Click(object sender, EventArgs e)
        {
            btnRight.Visible = true;
            btnLeft.Visible = false;

            _lx = this.Location.X;
            _ly = this.Location.Y;

            _repository = new Repository(this);
            _repository.StartPosition = FormStartPosition.Manual;
            _repository.Location = new Point(_lx - _repository.Width, _ly);
            _repository.Show();
        }

        ///////
        /// 좌측 repository 창 닫기
        private void btnRight_Click(object sender, EventArgs e)
        {
            btnRight.Visible = false;
            btnLeft.Visible = true;
            TreeNode sNode = _repository.treeView1.SelectedNode;

            if (sNode != null)
            {
                string xmlPath = _repository.GetXmlPath(sNode);
                string hashPath = _repository.GetHashPathForFile(sNode);
                FileInfo saved = new FileInfo(xmlPath);
                if (saved.Exists)
                {

                    // 싱글톤 객체를 통한 XML 검사
                    SingletonXML sXML = SingletonXML.Instance;
                    XmlDocument xdoc = sXML.GetXML();
                    string[] saveData = XMLtoStringArr(xdoc);

                    if (IsChanged(saveData))
                    {
                        QuestionToSave(xmlPath, hashPath);
                    }
                }
                else
                {
                    string[] data = new string[] { _methods[0], "", "", "" };
                    if (IsChanged(data))
                    {
                        QuestionToSave(xmlPath, hashPath);
                    }
                }
            }
            
            _repository.Close();
            _repository = null;
            sNode = null;
            lblTitle.Visible = false;
            btnSave.Visible = false;
            cBoxMethod.Text = _methods[0];
            tBoxURL.Text = string.Empty;
            tBoxCookie.Text = string.Empty;
            tBoxMsg.Text = string.Empty;
            tBoxRst.Text = string.Empty;
            isUse();
        }

        /////////////////
        /// 잡다한 함수
        /// 

        // 비밀번호 저장할거냐고 묻는 함수
        private void QuestionToSave(string xmlPath, string hashPath)
        {
            if(CustomMessageBox.ShowMessage("변경내용이 있습니다.\n저장 하시겠습니까?","Save",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RequestXML requestXML = new RequestXML();

                requestXML._METHOD = cBoxMethod.Text;
                requestXML._URL = tBoxURL.Text;
                requestXML._COOKIE = tBoxCookie.Text;
                requestXML._MSG = tBoxMsg.Text;

                Save_XML(requestXML, xmlPath, hashPath);
                CustomMessageBox.ShowMessage("저장되었습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cBoxMethod.Text = _methods[0];
                tBoxURL.Text = string.Empty;
                tBoxCookie.Text = string.Empty;
                tBoxMsg.Text = string.Empty;
                tBoxRst.Text = string.Empty;
            }
        }

        ////////////////
        /// 파일 저장
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_repository != null)
            {
                var sNode = _repository.treeView1.SelectedNode;
                string xmlPath = _repository.GetXmlPath(sNode);
                string hashPath = _repository.GetHashPathForFile(sNode);

                RequestXML requestXML = new RequestXML();

                requestXML._METHOD = cBoxMethod.Text;
                requestXML._URL = tBoxURL.Text;
                requestXML._COOKIE = tBoxCookie.Text;
                requestXML._MSG = tBoxMsg.Text;

                Save_XML(requestXML, xmlPath, hashPath);
                CustomMessageBox.ShowMessage("저장이 완료됐습니다!", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnSave.Visible = false;
            }
            else
            {
                CustomMessageBox.ShowMessage("파일 저장 버그!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // textbox에 있던 파일을 requestXML 객체로 받아서 로컬에 저장하기 직전 함수
        // 프로그램 종료 시에도 저장 하도록 하는 로직 추가해야한다. (아직 안함)
        public void Save_XML(RequestXML requestXML, string xmlPath, string hashPath)
        {
            XmlDocument xdoc = new XmlDocument();

            XmlNode root = xdoc.CreateElement("Request");
            xdoc.AppendChild(root);

            XmlNode xData = xdoc.CreateElement("Request-Data");

            XmlNode xMethod = xdoc.CreateElement("Method");
            xMethod.InnerText = requestXML._METHOD;
            xData.AppendChild(xMethod);

            XmlNode xUrl = xdoc.CreateElement("URL");
            xUrl.InnerText = requestXML._URL;
            xData.AppendChild(xUrl);

            XmlNode xCookie = xdoc.CreateElement("Cookie");
            xCookie.InnerText = requestXML._COOKIE;
            xData.AppendChild(xCookie);

            XmlNode xMsg = xdoc.CreateElement("Msg");
            xMsg.InnerText = requestXML._MSG;
            xData.AppendChild(xMsg);

            root.AppendChild(xData);

            //XML 대신 암호문을 Base64로 저장
            string cipherText = AES256.Encrypt(root.OuterXml);
            File.WriteAllText(xmlPath, cipherText, Encoding.Default);

            // 해시파일도 등록 (추후 원본 해시로 변경해야함)
            string hashText = SHA256.Hash(root.OuterXml);
            File.WriteAllText(hashPath, hashText, Encoding.Default);


            // 저장한 XML 싱글톤으로 등록
            List<string> returnList = new List<string> { };

            returnList.Add(requestXML._METHOD);
            returnList.Add(requestXML._URL);
            returnList.Add(requestXML._COOKIE);
            returnList.Add(requestXML._MSG);

            // 저장 시 싱글톤에 저장
            SingletonXML sXML = SingletonXML.Instance;
            sXML.SetXML(xdoc);
        }
        

        public XmlDocument Load_XML(TreeNode sNode, bool wantCheck)
        {
            string loadPath = _repository.GetXmlPath(sNode);

            string cryptXML = File.ReadAllText(loadPath);
            string decryptXML = AES256.Decrypt(cryptXML);

            // 무결성 검사 실패한다면 무결성 실패가 아닌 그냥 값 초기화 후 사용할 수 있도록 해야함
            if (wantCheck)
            {
                string hashPath = _repository.GetHashPathForFile(sNode);
                string hashText = File.ReadAllText(hashPath);

                bool checkValue = SHA256.CheckIntegrity(hashText, decryptXML);

                if (!checkValue)
                {
                    //CustomMessageBox.ShowMessage("[ERROR] 무결성 검사 실패", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(decryptXML);


            // 불러온 XML 싱글톤으로 등록
            SingletonXML sXML = SingletonXML.Instance;
            sXML.SetXML(xdoc);

            return xdoc;
        }

        public string[] XMLtoStringArr(XmlDocument xdoc)
        {
            List<string> returnList = new List<string> { };

            if (xdoc == null)
            {
                return returnList.ToArray();
            }

            XmlNodeList nodes = xdoc.SelectNodes("/Request/Request-Data");

            foreach (XmlNode data in nodes)
            {
                string sMethod = data.SelectSingleNode("Method").InnerText;
                string sURL = data.SelectSingleNode("URL").InnerText;
                string sCookie = data.SelectSingleNode("Cookie").InnerText;
                string sMsg = data.SelectSingleNode("Msg").InnerText;

                returnList.Add(sMethod);
                returnList.Add(sURL);
                returnList.Add(sCookie);
                returnList.Add(sMsg);
            }


            return returnList.ToArray();
        }


        //////////////////
        ///텍스트 변경 시 저장버튼 visible 
        public void TextBox_TextChanged(Object sender, EventArgs e)
        {
            if (_repository != null && _canCheck)
            {
                TreeNode sNode = _repository.treeView1.SelectedNode;
                string xmlPath = _repository.GetXmlPath(sNode);
                FileInfo save = new FileInfo(xmlPath);

                if (save.Exists)
                {
                    // 싱글톤 객체를 통한 XML 검사
                    SingletonXML sXML = SingletonXML.Instance;
                    XmlDocument xdoc = sXML.GetXML();
                    string[] saveData = XMLtoStringArr(xdoc);

                    if (IsChanged(saveData))
                    {
                        btnSave.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = false;
                    }
                }
                // 이제 사용 안함
                //else
                //{
                //    string[] data = new string[] { _methods[0], "", "", "" };
                //    if (IsChanged(data))
                //    {
                //        btnSave.Visible = true;
                //    }
                //    else
                //    {
                //        btnSave.Visible = false;
                //    }
                //}
            }
        }

        // 내용 변경 확인 함수
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

        //사용하지 않을 때 색 변경
        public void isNotUse()
        {
            tBoxURL.BackColor = Color.Gray;
            tBoxCookie.BackColor = Color.Gray;
            tBoxMsg.BackColor = Color.Gray;
            cBoxMethod.Enabled = false;
            tBoxURL.Enabled = false;
            tBoxCookie.Enabled = false;
            tBoxMsg.Enabled = false;
            btnRequest.Enabled = false;
        }

        //사용할 때 색 변경
        public void isUse()
        {
            tBoxURL.BackColor = Color.WhiteSmoke;
            tBoxCookie.BackColor = Color.WhiteSmoke;
            tBoxMsg.BackColor = Color.WhiteSmoke;
            cBoxMethod.Enabled = true;
            tBoxURL.Enabled = true;
            tBoxCookie.Enabled = true;
            tBoxMsg.Enabled = true;
            btnRequest.Enabled = true;
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
            RequestFree(pRst);

        }

        public static unsafe string MarshalUtf8ToUnicode(IntPtr pStringUtf82)
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
                CustomMessageBox.ShowMessage(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Method 변경 시 저장 버튼 추가하는 로직 추가
            if(_repository != null)
            {
                TreeNode sNode = _repository.treeView1.SelectedNode;
                string xmlPath = _repository.GetXmlPath(sNode);
                FileInfo save = new FileInfo(xmlPath);
                if (save.Exists)
                {
                    // 싱글톤 객체를 통한 XML 검사
                    SingletonXML sXML = SingletonXML.Instance;
                    XmlDocument xdoc = sXML.GetXML();
                    string[] saveData = XMLtoStringArr(xdoc);

                    if (IsChanged(saveData))
                    {
                        btnSave.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = false;
                    }
                }
                // 이제 사용 안함
                //else
                //{
                //    string[] data = new string[] { _methods[0], "", "", "" };
                //    if (IsChanged(data))
                //    {
                //        btnSave.Visible = true;
                //    }
                //    else
                //    {
                //        btnSave.Visible = false;
                //    }
                //}
            }
        }
        //////////////////////////////////////








        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///패널 이동 + 상단바
        private Boolean mouseDown = false;
        private Point startPos;
        private Point endPos;


        ///////////////////////상단바 이동 함수들////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        // 상단바 클릭 시
        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            startPos = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                endPos = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                Point pLoc = new Point( ( this.Location.X + (endPos.X - startPos.X) ), ( this.Location.Y + (endPos.Y - startPos.Y) ) );
                startPos = endPos;
                this.Location = pLoc;
            }
            else
            {
                return;
            }
        }

        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        // 상단 이름 클릭 시
        private void lblProgramName_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            startPos = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
        }

        private void lblProgramName_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                endPos = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                Point pLoc = new Point((this.Location.X + (endPos.X - startPos.X)), (this.Location.Y + (endPos.Y - startPos.Y)));
                startPos = endPos;
                this.Location = pLoc;
            }
            else
            {
                return;
            }
        }

        private void lblProgramName_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////// 상단 버튼 함수들 ////////////////////////
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
