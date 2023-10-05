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
                //// 무결성 검사 폴더는 숨기기
                //if (directory.Name == "etc")
                //{
                //    break;
                //}
                
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


        ////////////
        /// 폴더 추가 창 띄우기
        public void btnAdd_Click(object sender, EventArgs e)
        {
            _lx = _f1.Location.X;
            _ly = _f1.Location.Y;
            _customInputForm = new CustomInputForm(this);
            _customInputForm.StartPosition = FormStartPosition.Manual;
            _customInputForm.Location = new Point(_lx + _customInputForm.Width, _ly + _customInputForm.Height);
            _customInputForm._type = TypeEnum.Type.Folder.ToString();
            _customInputForm.Show();
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


        ////////////
        /// 폴더 추가 동작 함수
        public void AddFolder(object sender, EventArgs e)
        {
            // 파일 생성 창 닫기
            _customInputForm.Close();

            // 초기 폴더 생성 및 검사 (etc,sec)
            CreateEtcFolder();

            var sNode = treeView1.SelectedNode;

            string folderName = _customInputForm._name;
            

            if (folderName != "")
            {
                if (sNode != null)
                {
                    //string savePath = string.Format("..\\{0}\\{1}", sNode.FullPath, folderName);
                    string savePath = string.Format("{0}\\{1}\\{2}", _rootPath, _repoFolderName,folderName);

                    DirectoryInfo createdDir = new DirectoryInfo(savePath);
                    if (!createdDir.Exists)
                    {
                        createdDir.Create();
                        sNode.Nodes.Add(new TreeNode(folderName));
                        CustomMessageBox.ShowMessage(string.Format("{0}이(가) 추가됐습니다 !", folderName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tBoxName.Text = string.Empty;
                    }
                    else
                    {
                        CustomMessageBox.ShowMessage("중복된 폴더명입니다!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    CreateRepoFolder(folderName);
                }
            }
            else
            {
                CustomMessageBox.ShowMessage("이름은 한 글자 이상 입력해주세요!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBoxName.Text = string.Empty;
            }
        }

        ///////////
        // 폴더 삭제 동작 함수
        public void btnDelete_Click(object sender, EventArgs e)
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
                    tBoxName.Text = string.Empty;
                }

            }
        }

        

        //////////
        /// 파일 추가 창 띄우기
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            _lx = _f1.Location.X;
            _ly = _f1.Location.Y;
            _customInputForm = new CustomInputForm(this);
            _customInputForm.StartPosition = FormStartPosition.Manual;
            _customInputForm.Location = new Point(_lx + _customInputForm.Width, _ly + _customInputForm.Height);
            _customInputForm._type = TypeEnum.Type.File.ToString();
            _customInputForm.Show();
        }


        //////////
        /// 파일 추가 동작 함수
        public void AddFile(object sender, EventArgs e)
        {
            // 파일 생성 창 닫기
            _customInputForm.Close();

            // 초기 폴더 생성 및 검사 (etc,sec)
            CreateEtcFolder();
            
            var sNode = treeView1.SelectedNode;

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
                        tBoxName.Text = string.Empty;
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
                tBoxName.Text = string.Empty;
            }
        }
        
        /////////
        /// 파일 삭제 동작 함수
        public void btnDelFile_Click(object sender, EventArgs e)
        {
            CreateEtcFolder();

            var sNode = treeView1.SelectedNode;

            if (sNode != null && sNode.Parent != null)
            {
                if (CustomMessageBox.ShowMessage("파일를 삭제하시겠습니까?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deletePath = GetSavePathForFile(sNode);

                    File.Delete(deletePath);
                    treeView1.Nodes.Remove(sNode);

                    CustomMessageBox.ShowMessage(string.Format("{0}이(가) 삭제됐습니다 !", sNode.Text), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tBoxName.Text = string.Empty;
                }
            }
        }


        /////////
        /// 수정할 때 사용
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
        /// 파일 생성 시 사용
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
                        tBoxName.Enabled = true;    // 입력 가능
                        tBoxName.Visible = true;    // 이름 인풋 보임 ( 폴더 생성을 위해 )

                        btnAdd.Visible = true;      // 폴더 추가 가능
                        btnDelete.Visible = false;  // 폴더 삭제 불가능
                        btnAddFile.Visible = false; // 파일 추가 불가능
                        btnDelFile.Visible = false; // 파일 삭제 불가능

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
                        tBoxName.Enabled = true;    // 입력 가능
                        tBoxName.Visible = true;    // 이름 인풋 보임( 파일 생성을 위해 )

                        btnAdd.Visible = false;     // 폴더 추가 불가능
                        btnDelete.Visible = true;   // 폴더 삭제 가능
                        btnAddFile.Visible = true;  // 파일 추가 가능
                        btnDelFile.Visible = false; // 파일 삭제 불가능

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
                        tBoxName.Enabled = false;    // 입력 불가능
                        tBoxName.Visible = false;   // 이름 인풋 안보임

                        btnAdd.Visible = false;     // 폴더 추가 불가능
                        btnDelete.Visible = false;  // 폴더 삭제 불가능
                        btnAddFile.Visible = false; // 파일 추가 불가능
                        btnDelFile.Visible = true;  // 파일 삭제 가능

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
                tBoxName.Enabled = false;
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
                var sNode = treeView1.SelectedNode;

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

                            itemAddService.Click += btnAdd_Click;
                            
                            cMenu.Items.Add(itemAddService);
                            break;
                        case 1:
                            ToolStripMenuItem itemAddRequest = new ToolStripMenuItem("➕ Add a Request");
                            ToolStripMenuItem itemRemoveFolder = new ToolStripMenuItem("🗑 Remove");

                            itemAddRequest.Click += btnAddFile_Click;
                            itemRemoveFolder.Click += btnDelete_Click;

                            cMenu.Items.Add(itemAddRequest);
                            cMenu.Items.Add(itemRemoveFolder);
                            break;
                        case 2:
                            ToolStripMenuItem itemRemoveFile = new ToolStripMenuItem("🗑 Remove");

                            itemRemoveFile.Click += btnDelFile_Click;
                    
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
    }
}
