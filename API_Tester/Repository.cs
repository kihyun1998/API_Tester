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
using System.IO;
using System.Xml;

namespace API_Tester
{
    public partial class Repository : Form
    {
        // _etcFolderName과 관련된거 지워야 함
        //string _etcFolderName = ".apitest";
        string _repoFolderName = "My Drive";

        //string _rootPath = Path.GetFullPath(@"..\Repository");
        string _rootPath = string.Format("{0}\\..\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ".apitest");
        Form1 _f1 = null;

        CustomInputForm _customInputForm = null;

        int _lx = 0;
        int _ly = 0;

        public Repository(Form1 form)
        {
            InitializeComponent();
            string repoPath =  string.Format("{0}\\{1}", _rootPath, _repoFolderName);
            ListDirectory(treeView1, repoPath);
            this._f1 = form;
            // 버튼 visible
            btnFolderAdd.Visible = false;
            btnFolderDel.Visible = false;
            btnFileAdd.Visible = false;
            btnFileDel.Visible = false;
            btnFolderRename.Visible = false;
            btnFileRename.Visible = false;  
        }

        private void ListDirectory(TreeView treeView, string repoPath)
        {
            // root 경로 확인
            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(_rootPath);
            if (!rootDirectoryInfo.Exists)
            {
                rootDirectoryInfo.Create();
            }
            
            // repo 경로 확인
            DirectoryInfo repoDirectoryInfo = new DirectoryInfo(repoPath);
            if (!repoDirectoryInfo.Exists)
            {
                repoDirectoryInfo.Create();
            }

            treeView.Nodes.Clear();
            treeView.Nodes.Add(CreateDirectoryNode(repoDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo repoDirectoryInfo)
        {
            TreeNode directoryNode = new TreeNode(repoDirectoryInfo.Name);
            
            // 폴더 등록
            foreach (var directory in repoDirectoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }

            //파일 등록 (여기서 잘못된 파일 검증해야함) *******
            foreach (var file in repoDirectoryInfo.GetFiles())
            {
                string fileName = file.Name.Substring(0, file.Name.LastIndexOf('.'));
                directoryNode.Nodes.Add(new TreeNode(fileName));
            }

            return directoryNode;
        }
        public void CreateEtcFolder()
        {
            //// C:\Users\유저\.apitest 폴더 생성
            //string etcFolder = string.Format("{0}\\..\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), _etcFolderName);
            DirectoryInfo etcDir = new DirectoryInfo(_rootPath);
            if (!etcDir.Exists)
            {
                etcDir.Create();
            }

            // My Drive 폴더 생성
            string repoFolder = string.Format("{0}\\{1}", _rootPath, _repoFolderName);
            DirectoryInfo repoDir = new DirectoryInfo(repoFolder);
            if (!repoDir.Exists)
            {
                repoDir.Create();
            }
        }

        // 폴더 생성 시 필수
        public void CreateRepoFolder(string folderName)
        {
            string repoPath = string.Format("{0}\\{1}\\{2}", _rootPath, _repoFolderName, folderName);
            // C:\Users\유저\.apitest\sec 밑에 전용 해쉬 폴더 생성
            // 왜냐하면 폴더 마다 중복되는 파일 명 있으면 안되니까
            DirectoryInfo repoDir = new DirectoryInfo(repoPath);
            if (!repoDir.Exists)
            {
                repoDir.Create();
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 버튼 누르면 나오는 창
        private void showWindow(string type)
        {
            _lx = _f1.Location.X;
            _ly = _f1.Location.Y;
            TreeNode sNode = treeView1.SelectedNode;
            if (sNode != null)
            {
                _customInputForm = new CustomInputForm(this);
                _customInputForm.Title = sNode.Text;
                _customInputForm.StartPosition = FormStartPosition.Manual;
                _customInputForm.Location = new Point(_lx + _customInputForm.Width, _ly + _customInputForm.Height);
                _customInputForm._type = type;
                if (type == TypeEnum.Type.CreateFolder.ToString() || type == TypeEnum.Type.CreateFile.ToString())
                {
                    _customInputForm.ButtonText = "➕ Create";
                }
                else if (type == TypeEnum.Type.RenameFolder.ToString() || type == TypeEnum.Type.RenameFile.ToString())
                {
                    _customInputForm.ButtonText = "📄 Rename";
                }
                _customInputForm.Show();
            }
        }


        //////////////////////
        /// 폴더 추가 버튼 클릭 시 - 창만 띄운다.
        private void btnFolderAdd_Click(object sender, EventArgs e)
        {
            string type = TypeEnum.Type.CreateFolder.ToString();
            showWindow(type);
        }

        //////////////////////
        /// 폴더 삭제 버튼 클릭 시 (동작 포함)
        private void btnFolderDel_Click(object sender, EventArgs e)
        {
            var sNode = treeView1.SelectedNode;

            if (sNode != null && sNode.Parent != null)
            {
                if (CustomMessageBox.ShowMessage("폴더를 삭제하시겠습니까?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deletePath = string.Format("{0}\\{1}\\{2}", _rootPath, _repoFolderName, sNode.Text);

                    Directory.Delete(deletePath, recursive: true);
                    treeView1.Nodes.Remove(sNode);

                    CustomMessageBox.ShowMessage(string.Format("{0}이(가) 삭제됐습니다 !", sNode.Text), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // 파일 추가 버튼 클릭 시 - 창만 띄움
        private void btnFileAdd_Click(object sender, EventArgs e)
        {
            string type = TypeEnum.Type.CreateFile.ToString();
            showWindow(type);
        }

        // 파일 삭제 버튼 클릭 시 (동작 포함)
        private void btnFileDel_Click(object sender, EventArgs e)
        {
            CreateEtcFolder();

            TreeNode sNode = treeView1.SelectedNode;

            if (sNode != null && sNode.Parent != null)
            {
                if (CustomMessageBox.ShowMessage("파일를 삭제하시겠습니까?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deletePath = GetSavePathForFile(sNode);

                    File.Delete(deletePath);
                    treeView1.Nodes.Remove(sNode);

                    CustomMessageBox.ShowMessage(string.Format("{0}이(가) 삭제됐습니다 !", sNode.Text), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        // 폴더 수정 버튼 클릭 시 
        private void btnFolderRename_Click(object sender, EventArgs e)
        {
            string type = TypeEnum.Type.RenameFolder.ToString();
            showWindow(type);   
        }

        // 파일 수정 버튼 클릭 시 
        private void btnFileRename_Click(object sender, EventArgs e)
        {
            string type = TypeEnum.Type.RenameFile.ToString();
            showWindow(type); 
        }



        ///////////////////////
        /// 폴더 추가 동작 함수
        public void AddFolder(object sender, EventArgs e)
        {
            // 파일 생성 창 닫기
            _customInputForm.Close();

            // 초기 폴더 생성 및 검사
            CreateEtcFolder();

            TreeNode sNode = treeView1.SelectedNode;

            string folderName = _customInputForm._name;
            

            if (folderName != "")
            {
                if (sNode != null)
                {
                    string savePath = string.Format("{0}\\{1}\\{2}", _rootPath, _repoFolderName,folderName);

                    DirectoryInfo createdDir = new DirectoryInfo(savePath);
                    if (!createdDir.Exists)
                    {
                        createdDir.Create();
                        sNode.Nodes.Add(new TreeNode(folderName));
                        CustomMessageBox.ShowMessage(string.Format("{0}이(가) 추가됐습니다 !", folderName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CustomMessageBox.ShowMessage("중복된 폴더명입니다!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                CustomMessageBox.ShowMessage("이름은 한 글자 이상 입력해주세요!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        //////////
        /// 파일 추가 동작 함수
        public void AddFile(object sender, EventArgs e)
        {
            // 인풋창 닫기
            _customInputForm.Close();

            // 초기 폴더 생성 및 검사
            CreateEtcFolder();
            
            TreeNode sNode = treeView1.SelectedNode;

            string fileName = _customInputForm._name;


            if (fileName != "")
            {
                if (sNode != null)
                {
                    string savePath = GetSavePathForFolder(sNode, fileName);

                    RequestXML requestXML = new RequestXML();

                    requestXML._METHOD = _f1._methods[0];
                    requestXML._URL = "";
                    requestXML._COOKIE = "";
                    requestXML._MSG = "";

                    FileInfo createdFile = new FileInfo(savePath);
                    if (!createdFile.Exists)
                    {
                        _f1.Save_XML(requestXML, savePath);
                        sNode.Nodes.Add(new TreeNode(fileName));
                        CustomMessageBox.ShowMessage(string.Format("{0}이(가) 추가됐습니다 !", fileName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CustomMessageBox.ShowMessage("중복된 파일명입니다!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                CustomMessageBox.ShowMessage("파일 이름은 한 글자 이상 입력해주세요!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void RenameFolder(object sender, EventArgs e)
        {
            // 인풋창 닫기
            _customInputForm.Close();

            // 초기 폴더 생성 및 검사
            CreateEtcFolder();

            TreeNode sNode = treeView1.SelectedNode;
            string newFolderName = _customInputForm._name;

            if (newFolderName != "")
            {
                if (sNode != null)
                {
                    string oldPath = string.Format("{0}\\{1}\\{2}", _rootPath, _repoFolderName, sNode.Text);
                    string newPath = string.Format("{0}\\{1}\\{2}", _rootPath, _repoFolderName, newFolderName);
                    DirectoryInfo updateDir = new DirectoryInfo(newPath);
                    if (!updateDir.Exists)
                    {
                        Directory.Move(oldPath, newPath);
                        sNode.Text = newFolderName;
                        CustomMessageBox.ShowMessage(string.Format("{0}(으)로 변경됐습니다 !", newFolderName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CustomMessageBox.ShowMessage("중복된 폴더명입니다!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                CustomMessageBox.ShowMessage("이름은 한 글자 이상 입력해주세요!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void RenameFile()
        {
            // 인풋창 닫기
            _customInputForm.Close();

            // 초기 폴더 생성 및 검사
            CreateEtcFolder();

            TreeNode sNode = treeView1.SelectedNode;
            string newFileName = _customInputForm._name;

            if (newFileName != "")
            {
                if (sNode != null)
                {
                    string oldPath = GetSavePathForFile(sNode);
                    string newPath = GetSavePathForFolder(sNode.Parent, newFileName);

                    FileInfo updateFile = new FileInfo(newPath);
                    if (!updateFile.Exists)
                    {
                        File.Move(oldPath, newPath);
                        sNode.Text = newFileName;
                        CustomMessageBox.ShowMessage(string.Format("{0}(으)로 변경됐습니다 !", newFileName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CustomMessageBox.ShowMessage("중복된 폴더명입니다!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                CustomMessageBox.ShowMessage("이름은 한 글자 이상 입력해주세요!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /////////
        /// 이미 생성된 파일을 수정할 때의 경로를 반환해준다.
        public string GetSavePathForFile(TreeNode sNode)
        {
            if (sNode != null)
            {
                // sNode가 파일인 경우에만
                if(sNode.Level == 2)
                {
                    // 여기서 sNode는 파일이다.
                    string savePath = string.Format("{0}\\{1}\\{2}\\{3}.txt", _rootPath, _repoFolderName, sNode.Parent.Text, sNode.Text);
                    return savePath;
                }
            }
            return "";
        }

        ///////////
        /// 파일 처음 생성 시 사용하는 경로를 반환해준다.
        public string GetSavePathForFolder(TreeNode sNode, string fileName)
        {
            if(sNode != null)
            {
                // sNode가 root 폴더가 아닌 폴더만
                if (sNode.Level == 1)
                {
                    // 여기서 sNode는 폴더이다.
                    string savePath = string.Format("{0}\\{1}\\{2}\\{3}.txt", _rootPath, _repoFolderName, sNode.Text, fileName);
                    return savePath;
                }
            }
            return "";
                
        }



        //////////
        ////선택한 노드가 있나 없나 체크
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            whenClick();
        }

        /////////////
        ///더블 클릭 시 이벤트 (값 불러오기)
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            whenClick();
        }

        /// 추후에 isNotUse()로 막혀있는 화면은 다른 화면으로 대체할 예정
        private void whenClick()
        {
            // 초기 폴더 생성 및 검사 (etc,sec)
            CreateEtcFolder();

            // 저장 버튼 안보이게하기
            _f1.btnSave.Visible = false;

            var sNode = treeView1.SelectedNode;
            if (sNode != null)
            {
                int nLevel = sNode.Level;

                switch (nLevel)
                {
                    case 0:
                        btnFolderAdd.Visible = true;     // 폴더 추가 가능
                        btnFolderDel.Visible = false;    // 폴더 삭제 불가능
                        btnFolderRename.Visible = false; // 폴더 이름 수정 불가능
                        btnFileAdd.Visible = false;      // 파일 추가 불가능
                        btnFileDel.Visible = false;      // 파일 삭제 불가능
                        btnFileRename.Visible = false;   // 파일 이름 수정 불가능

                        // 한번 클릭 시에도 창 전환되도록 변경
                        _f1.lblTitle.Visible = false;
                        _f1.cBoxMethod.Text = _f1._methods[0];
                        _f1.tBoxURL.Text = string.Empty;
                        _f1.tBoxCookie.Text = string.Empty;
                        _f1.tBoxMsg.Text = string.Empty;
                        _f1.tBoxRst.Text = string.Empty;
                        _f1.isNotUse();
                        break;
                    case 1:
                        btnFolderAdd.Visible = false;   // 폴더 추가 불가능
                        btnFolderDel.Visible = true;    // 폴더 삭제 가능
                        btnFolderRename.Visible = true; // 폴더 이름 수정 가능
                        btnFileAdd.Visible = true;      // 파일 추가 가능
                        btnFileDel.Visible = false;     // 파일 삭제 불가능
                        btnFileRename.Visible = false;  // 파일 이름 수정 불가능

                        // 한번 클릭 시에도 창 전환되도록 변경
                        _f1.lblTitle.Visible = false;
                        _f1.cBoxMethod.Text = _f1._methods[0];
                        _f1.tBoxURL.Text = string.Empty;
                        _f1.tBoxCookie.Text = string.Empty;
                        _f1.tBoxMsg.Text = string.Empty;
                        _f1.tBoxRst.Text = string.Empty;
                        _f1.isNotUse();

                        // 만약 해시 폴더 없다면 생성
                        CreateRepoFolder(sNode.Text);
                        break;

                        // 해시 파일 없는 경우 처리 해야함
                    case 2:
                        btnFolderAdd.Visible = false;    // 폴더 추가 불가능
                        btnFolderDel.Visible = false;    // 폴더 삭제 불가능
                        btnFolderRename.Visible = false; // 폴더 이름 수정 불가능
                        btnFileAdd.Visible = false;      // 파일 추가 불가능
                        btnFileDel.Visible = true;       // 파일 삭제 가능
                        btnFileRename.Visible = true;   // 파일 이름 수정 가능

                        _f1._canCheck = false;      // 노드 변경 시 text_changed 이벤트가 발생하는 현상이 있어서 검사

                        string savePath = GetSavePathForFile(sNode);
                        FileInfo saveFile = new FileInfo(savePath);
                        if (saveFile.Exists)
                        {
                                
                            XmlDocument xdoc = _f1.Load_XML(sNode);
                            string[] saveData = _f1.XMLtoStringArr(xdoc);

                            // 무결성 깨지면 saveData.Length == 0 임.
                            // 무결성 깨지면 초기화가 이루어진다.
                            if (saveData.Length == 0)
                            {
                                _f1.cBoxMethod.Text = _f1._methods[0];
                                _f1.tBoxURL.Text = "";
                                _f1.tBoxCookie.Text = "";
                                _f1.tBoxMsg.Text = "";
                                _f1.isUse();
                                _f1.lblTitle.Visible = true;
                                _f1.lblTitle.Text = sNode.Text;

                                RequestXML requestXML = new RequestXML();

                                requestXML._METHOD = _f1._methods[0];
                                requestXML._URL = "";
                                requestXML._COOKIE = "";
                                requestXML._MSG = "";

                                _f1.Save_XML(requestXML, savePath);
                            }
                            else
                            {
                                _f1.cBoxMethod.Text = saveData[0];
                                _f1.tBoxURL.Text = saveData[1];
                                _f1.tBoxCookie.Text = saveData[2];
                                _f1.tBoxMsg.Text = saveData[3];
                                _f1.isUse();
                                _f1.lblTitle.Visible = true;
                                _f1.lblTitle.Text = sNode.Text;
                            }
                            _f1._canCheck = true;     // 값을 잘 불러왔다면 텍스트 변화 감지 true
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                btnFolderAdd.Visible = false;
                btnFolderDel.Visible = false;
                btnFileAdd.Visible = false;
                btnFileDel.Visible = false;
                btnFolderRename.Visible = false;
                btnFileRename.Visible = false;

                _f1.btnSave.Visible = false;
                _f1.lblTitle.Visible = false;
            }
         }


        //////////////
        /// 우클릭 시 Context Menu에 대한 정의
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 우클릭 해도 노드 선택되도록
                treeView1.SelectedNode = e.Node;
                TreeNode sNode = treeView1.SelectedNode;
                if(sNode != null)
                {
                    int nLevel = sNode.Level;

                    Point ClickPoint = new Point(e.X, e.Y);
                    TreeNode ClickNode = treeView1.GetNodeAt(ClickPoint);
                    if (ClickNode == null) return;

                    Point ScreenPoint = treeView1.PointToScreen(ClickPoint);
                    Point FormPoint = this.PointToClient(ScreenPoint);

                    ContextMenuStrip cMenu = new ContextMenuStrip();

                    if (sNode != null)
                    {
                        switch (nLevel)
                        {
                            case 0:
                                ToolStripMenuItem itemAddService = new ToolStripMenuItem("➕ Add a Service");

                                itemAddService.Click += btnFolderAdd_Click;

                                
                                cMenu.Items.Add(itemAddService);
                                break;
                            case 1:
                                ToolStripMenuItem itemAddRequest = new ToolStripMenuItem("➕ Add a Request");
                                ToolStripMenuItem itemRenameFolder = new ToolStripMenuItem("📄 Rename");
                                ToolStripMenuItem itemRemoveFolder = new ToolStripMenuItem("🗑 Remove");

                                itemAddRequest.Click += btnFileAdd_Click;
                                itemRenameFolder.Click += btnFolderRename_Click;
                                itemRemoveFolder.Click += btnFolderDel_Click;

                                cMenu.Items.Add(itemAddRequest);
                                cMenu.Items.Add(itemRenameFolder);
                                cMenu.Items.Add(itemRemoveFolder);
                                break;
                            case 2:
                                ToolStripMenuItem itemRenameFile = new ToolStripMenuItem("📄 Rename");
                                ToolStripMenuItem itemRemoveFile = new ToolStripMenuItem("🗑 Remove");

                                itemRenameFile.Click += btnFileRename_Click;
                                itemRemoveFile.Click += btnFileDel_Click;


                                cMenu.Items.Add(itemRenameFile);
                                cMenu.Items.Add(itemRemoveFile);
                                break;
                            default:
                                break;

                                // Form 추가해서 rename 기능 추가하기 로직은 밑에 처럼 or Text 해봐야 알듯
                                // myTreeView.SelectedNode.Name = "NewNodeName";
                        }
                    }
                    cMenu.Show(this, FormPoint);
                }
            }
        }


        // TreeView 확장 시에도 Hash 폴더 만들도록
        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                // 만약 repo 폴더 없다면 생성
                CreateRepoFolder(e.Node.Text);
            }
            
        }

        // TreeView 축소 시에도 Hash 폴더 만들도록
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                // 만약 repo 폴더 없다면 생성
                CreateRepoFolder(e.Node.Text);
            }
        }


        //////// 상단바 이동 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Boolean mouseDown = false;
        public Point startPos;
        public Point endPos;

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
                Point pLoc = new Point((this.Location.X + (endPos.X - startPos.X)), (this.Location.Y + (endPos.Y - startPos.Y)));
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



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
