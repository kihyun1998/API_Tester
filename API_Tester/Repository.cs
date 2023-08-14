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
            // 파일도 tree view에 등록
            //foreach (var file in directoryInfo.GetFiles())
            //{
            //    directoryNode.Nodes.Add(new TreeNode(file.Name));
            //}

            return directoryNode;
        }



        //public void LoadTree()
        //{
        //    _thread = new Thread(new ThreadStart(Run));
        //    _thread.Start();
        //}

        //private void Run()
        //{
        //    MessageBox.Show("start");
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var sNode = treeView1.SelectedNode;
            string folderName = tBoxFolderName.Text;
       
            if (folderName != "")
            {
                if (sNode != null)
                {
                
                    string selectPath = string.Format("..\\{0}\\{1}", sNode.FullPath, folderName);

                    DirectoryInfo createDir = new DirectoryInfo(selectPath);
                    if (!createDir.Exists)
                    {
                        createDir.Create();
                        sNode.Nodes.Add(new TreeNode(folderName));
                        MessageBox.Show(string.Format("{0}이(가) 추가됐습니다 !", folderName));
                        tBoxFolderName.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("중복된 폴더 명입니다!");
                    }
                }
            }
            else
            {
                MessageBox.Show("이름은 한 글자 이상 입력해주세요!");
                tBoxFolderName.Text = string.Empty;
            }
        }



        private void btnMinus_Click(object sender, EventArgs e)  //삭제 고치기 위처럼 path 고치면됨
        {
            var sNode = treeView1.SelectedNode;

            if (sNode != null && sNode.Parent != null)
            {
                if (MessageBox.Show("폴더를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string selectPath = string.Format("..\\{0}", sNode.FullPath);
                    Directory.Delete(selectPath, recursive: true);
                    treeView1.Nodes.Remove(sNode);

                    MessageBox.Show(string.Format("{0}이(가) 삭제됐습니다 !", sNode.Text));
                    tBoxFolderName.Text = string.Empty;
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
                if (nLevel > 0) // 레벨 1 이상
                {
                    btnAdd.Visible = false;
                    tBoxFolderName.Visible = false;

                    btnDelete.Visible = true;
                    //_f1.btnSave.Visible = true;
                }
                else // 레벨 0 
                {
                    btnAdd.Visible = true;
                    tBoxFolderName.Visible = true;

                    btnDelete.Visible = false;
                    //_f1.btnSave.Visible = false;
                }
                tBoxFolderName.Enabled = true;
                //_isSelected = true;
            }
            else
            {
                _f1._selectedNode = null;
                tBoxFolderName.Enabled = false;
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
                    string savePath = string.Format("..\\{0}\\{1}", sNode.FullPath, "save_file");
                    FileInfo saved = new FileInfo(savePath);
                    if (saved.Exists)
                    {
                        string[] saveData = System.IO.File.ReadAllLines(savePath);
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
                        _f1.cBoxMethod.Text = string.Empty;
                        _f1.tBoxURL.Text = string.Empty;
                        _f1.tBoxCookie.Text = string.Empty;
                        _f1.tBoxMsg.Text = string.Empty;
                    }
                }
                else
                {
                    _f1.lblTitle.Visible = false;
                    _f1.cBoxMethod.Text = "GET";
                    _f1.tBoxURL.Text = string.Empty;
                    _f1.tBoxCookie.Text = string.Empty;
                    _f1.tBoxMsg.Text = string.Empty;

                    _f1.notUse();
                }
            }
        }
    }
}
