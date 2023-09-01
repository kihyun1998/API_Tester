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
        //bool _isSelected = false;

        //Thread _thread = null;
        Form1 _f1 = null;

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
        /// 폴더 추가
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var sNode = treeView1.SelectedNode;
            string folderName = tBoxName.Text;
       
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
                        MessageBox.Show(string.Format("{0}이(가) 추가됐습니다 !", folderName));
                        tBoxName.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("중복된 폴더명입니다!");
                    }
                }
            }
            else
            {
                MessageBox.Show("이름은 한 글자 이상 입력해주세요!");
                tBoxName.Text = string.Empty;
            }
        }


        ///////////
        // 폴더 삭제
        private void btnDelete_Click(object sender, EventArgs e)  
        {
            var sNode = treeView1.SelectedNode;

            if (sNode != null && sNode.Parent != null)
            {
                if (MessageBox.Show("폴더를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string deletePath = string.Format("..\\{0}", sNode.FullPath);
                    Directory.Delete(deletePath, recursive: true);
                    treeView1.Nodes.Remove(sNode);

                    MessageBox.Show(string.Format("{0}이(가) 삭제됐습니다 !", sNode.Text));
                    tBoxName.Text = string.Empty;
                }
                
            }
        }

        //////////
        /// 파일 추가
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            var sNode = treeView1.SelectedNode;
            string fileName = tBoxName.Text;

            if (fileName != "")
            {
                if (sNode != null)
                {
                    string savePath = string.Format("..\\{0}\\{1}", sNode.FullPath, string.Format(fileName+".xml") );

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
                        MessageBox.Show(string.Format("{0}이(가) 추가됐습니다 !", fileName));
                        tBoxName.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("중복된 파일명입니다!");
                    }
                }
            }
            else
            {
                MessageBox.Show("이름은 한 글자 이상 입력해주세요!");
                tBoxName.Text = string.Empty;
            }
        }

        /////////
        /// 파일 삭제
        private void btnDelFile_Click(object sender, EventArgs e)
        {
            var sNode = treeView1.SelectedNode;

            if (sNode != null && sNode.Parent != null)
            {
                if (MessageBox.Show("폴더를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string deletePath = string.Format("..\\{0}", string.Format(sNode.FullPath+".xml"));

                    File.Delete(deletePath);
                    treeView1.Nodes.Remove(sNode);

                    MessageBox.Show(string.Format("{0}이(가) 삭제됐습니다 !", sNode.Text));
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
            int nLevel = sNode.Level;

            if (sNode != null)
            {
                _f1._selectedNode = sNode;
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
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            var sNode = treeView1.SelectedNode;
            _f1.btnSave.Visible = false;
            _f1._selectedNode = sNode;
            if (sNode != null)
            {
                if (sNode.Level > 0)
                {
                    string savePath = string.Format("..\\{0}\\{1}", sNode.FullPath, "save_file.xml");
                    FileInfo saved = new FileInfo(savePath);
                    if (saved.Exists)
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
                    else
                    {
                        _f1.isUse();
                        _f1.lblTitle.Visible = true;
                        _f1.lblTitle.Text = sNode.Text;
                        _f1.cBoxMethod.Text = _f1._methods[0];
                        _f1.tBoxURL.Text = string.Empty;
                        _f1.tBoxCookie.Text = string.Empty;
                        _f1.tBoxMsg.Text = string.Empty;
                    }
                }
                else
                {
                    _f1.lblTitle.Visible = false;
                    _f1.cBoxMethod.Text = _f1._methods[0];
                    _f1.tBoxURL.Text = string.Empty;
                    _f1.tBoxCookie.Text = string.Empty;
                    _f1.tBoxMsg.Text = string.Empty;

                    _f1.notUse();
                }
            }
        }


    }
}
