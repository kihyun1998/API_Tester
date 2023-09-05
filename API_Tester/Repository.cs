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

namespace API_Tester
{
    public partial class Repository : Form
    { 

        string _rootPath = Path.GetFullPath(@"..\Repository");
        Form1 _f1 = null;

        CustomInputForm _customInputForm = null;

        int _lx = 0;
        int _ly = 0;

        public Repository(Form1 form)
        {
            InitializeComponent();
            ListDirectory(treeView1, _rootPath);
            this._f1 = form;
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            DirectoryInfo isExists = new DirectoryInfo(_rootPath);
            if (!isExists.Exists)
            {
                isExists.Create();
            }
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }
            //파일도 tree view에 등록
            foreach (var file in directoryInfo.GetFiles())
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
            _customInputForm._action = TypeEnum.Action.Add.ToString();
            _customInputForm.Show();
        }

        ////////////
        /// 폴더 추가 동작 함수
        public void AddFolder(object sender, EventArgs e)
        {
            _customInputForm.Close();
            var sNode = treeView1.SelectedNode;

            string folderName = _customInputForm._name;

            if (folderName != "")
            {
                if (sNode != null)
                {
                    string savePath = string.Format("..\\{0}\\{1}", sNode.FullPath, folderName);


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
                }
            }
            else
            {
                CustomMessageBox.ShowMessage("이름은 한 글자 이상 입력해주세요!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBoxName.Text = string.Empty;
            }
        }

        //////////
        // 폴더 삭제 창 띄우기
        public void btnDelete_Click(object sender, EventArgs e)
        {
            _lx = _f1.Location.X;
            _ly = _f1.Location.Y;
            _customInputForm = new CustomInputForm(this);
            _customInputForm.StartPosition = FormStartPosition.Manual;
            _customInputForm.Location = new Point(_lx + _customInputForm.Width, _ly + _customInputForm.Height);
            _customInputForm._type = TypeEnum.Type.Folder.ToString();
            _customInputForm._action = TypeEnum.Action.Remove.ToString();
            _customInputForm.Show();
        }

        ///////////
        // 폴더 삭제 동작 함수
        public void RemoveFolder(object sender, EventArgs e)
        {
            _customInputForm.Close();
            var sNode = treeView1.SelectedNode;

            if (sNode != null && sNode.Parent != null)
            {
                if (CustomMessageBox.ShowMessage("폴더를 삭제하시겠습니까?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deletePath = string.Format("..\\{0}", sNode.FullPath);
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
            _customInputForm._action = TypeEnum.Action.Add.ToString();
            _customInputForm.Show();
        }


        //////////
        /// 파일 추가 동작 함수
        public void AddFile(object sender, EventArgs e)
        {
            _customInputForm.Close();
            var sNode = treeView1.SelectedNode;

            string fileName = _customInputForm._name;

            if (fileName != "")
            {
                if (sNode != null)
                {
                    string savePath = string.Format("..\\{0}\\{1}", sNode.FullPath, string.Format(fileName + ".xml"));

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
                        CustomMessageBox.ShowMessage("중복된 폴더명입니다!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                CustomMessageBox.ShowMessage("이름은 한 글자 이상 입력해주세요!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tBoxName.Text = string.Empty;
            }
        }





        /////////
        /// 파일 삭제 창 띄우기
        private void btnDelFile_Click(object sender, EventArgs e)
        {
            _lx = _f1.Location.X;
            _ly = _f1.Location.Y;
            _customInputForm = new CustomInputForm(this);
            _customInputForm.StartPosition = FormStartPosition.Manual;
            _customInputForm.Location = new Point(_lx + _customInputForm.Width, _ly + _customInputForm.Height);
            _customInputForm._type = TypeEnum.Type.File.ToString();
            _customInputForm._action = TypeEnum.Action.Remove.ToString();
            _customInputForm.Show();
        }
        
        /////////
        /// 파일 삭제 동작 함수
        public void RemoveFile(object sender, EventArgs e)
        {
            _customInputForm.Close();
            var sNode = treeView1.SelectedNode;

            if (sNode != null && sNode.Parent != null)
            {
                if (CustomMessageBox.ShowMessage("파일를 삭제하시겠습니까?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deletePath = string.Format("..\\{0}", string.Format(sNode.FullPath + ".xml"));

                    File.Delete(deletePath);
                    treeView1.Nodes.Remove(sNode);

                    CustomMessageBox.ShowMessage(string.Format("{0}이(가) 삭제됐습니다 !", sNode.Text), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tBoxName.Text = string.Empty;
                }

            }
        }





        //////////
        ////선택한 노드가 있나 없나 체크
        ///그리고 버튼 보여줄지 말지
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var sNode = treeView1.SelectedNode;
            _f1._selectedNode = sNode;

            int nLevel = sNode.Level;
           
            if (sNode != null)
            {

                switch (nLevel)
                {
                    case 0:
                        tBoxName.Enabled = true;    // 입력 가능
                        tBoxName.Visible = true;    // 이름 인풋 보임 ( 폴더 생성을 위해 )
                        btnAdd.Visible = true;      // 폴더 추가 가능
                        btnDelete.Visible = false;  // 폴더 삭제 불가능
                        btnAddFile.Visible = false; // 파일 추가 불가능
                        btnDelFile.Visible = false; // 파일 삭제 불가능
                        break;
                    case 1:
                        tBoxName.Enabled = true;    // 입력 가능
                        tBoxName.Visible = true;    // 이름 인풋 보임( 파일 생성을 위해 )
                        btnAdd.Visible = false;     // 폴더 추가 불가능
                        btnDelete.Visible = true;   // 폴더 삭제 가능
                        btnAddFile.Visible = true;  // 파일 추가 가능
                        btnDelFile.Visible = false; // 파일 삭제 불가능
                        break;
                    case 2:
                        tBoxName.Enabled = false;    // 입력 불가능
                        tBoxName.Visible = false;   // 이름 인풋 안보임
                        btnAdd.Visible = false;     // 폴더 추가 불가능
                        btnDelete.Visible = false;  // 폴더 삭제 불가능
                        btnAddFile.Visible = false; // 파일 추가 불가능
                        btnDelFile.Visible = true;  // 파일 삭제 가능
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _f1._selectedNode = null;
                tBoxName.Enabled = false;
                _f1.btnSave.Visible = false;
                _f1.lblTitle.Visible = false;
                //_isSelected = false;
            }
        }

        /////////////
        ///더블 클릭 시 이벤트 (값 불러오기)
        /// 추후에 notUse()로 막혀있는 화면은 다른 화면으로 대체할 예정
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            var sNode = treeView1.SelectedNode;
            _f1._selectedNode = sNode;

            int nLevel = sNode.Level;

            // 일단 저장 버튼 숨기기
            _f1.btnSave.Visible = false;
            
            if (sNode != null)
            {
                switch (nLevel)
                {
                    case 0:
                        _f1.lblTitle.Visible = false;
                        _f1.cBoxMethod.Text = _f1._methods[0];
                        _f1.tBoxURL.Text = string.Empty;
                        _f1.tBoxCookie.Text = string.Empty;
                        _f1.tBoxMsg.Text = string.Empty;
                        _f1.tBoxRst.Text = string.Empty;
                        _f1.notUse();
                        break;
                    case 1:
                        _f1.lblTitle.Visible = false;
                        _f1.cBoxMethod.Text = _f1._methods[0];
                        _f1.tBoxURL.Text = string.Empty;
                        _f1.tBoxCookie.Text = string.Empty;
                        _f1.tBoxMsg.Text = string.Empty;
                        _f1.tBoxRst.Text = string.Empty;
                        _f1.notUse();
                        break;
                    case 2:
                        string savePath = string.Format("..\\{0}", string.Format(sNode.FullPath + ".xml"));
                        FileInfo saveFile = new FileInfo(savePath);
                        if (saveFile.Exists)
                        {
                            string[] saveData = _f1.Load_XML(savePath);
                            _f1.isUse();
                            _f1.lblTitle.Visible = true;
                            _f1.lblTitle.Text = sNode.Text;
                            _f1.cBoxMethod.Text = saveData[0];
                            _f1.tBoxURL.Text = saveData[1];
                            _f1.tBoxCookie.Text = saveData[2];
                            _f1.tBoxMsg.Text = saveData[3];
                        }
                        break;
                    default:
                        break;
                }
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
                _f1._selectedNode = sNode;

                int nLevel = sNode.Level;

                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode ClickNode = treeView1.GetNodeAt(ClickPoint);
                if (ClickNode == null) return;

                Point ScreenPoint = treeView1.PointToScreen(ClickPoint);
                Point FormPoint = this.PointToClient(ScreenPoint);

                ContextMenuStrip cMenu = new ContextMenuStrip();

                if (sNode != null)
                {
                    // Form 하나 추가해서 입력 받는 칸 만들어야 할 듯
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


    }
}
