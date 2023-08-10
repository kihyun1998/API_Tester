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
        Thread _thread = null;

        public Repository()
        {
            InitializeComponent();
            ListDirectory(treeView1, _rootPath);
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
            foreach (var file in directoryInfo.GetFiles())
            {
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            }

            return directoryNode;
        }



        public void LoadTree()
        {
            _thread = new Thread(new ThreadStart(Run));
            _thread.Start();
        }

        private void Run()
        {
            MessageBox.Show("start");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                string folderName = tBoxFolderName.Text;
                string selectPath = string.Format("..\\{0}\\{1}", treeView1.SelectedNode.FullPath, folderName);
                MessageBox.Show(selectPath);
                DirectoryInfo createDir = new DirectoryInfo(selectPath);
                createDir.Create();

                treeView1.SelectedNode.Nodes.Add(new TreeNode(folderName));
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)  //삭제 고치기 위처럼 path 고치면됨
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null)
            {
                string path = treeView1.SelectedNode.FullPath;
          
                Directory.Delete(path, recursive: true);
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                tBoxFolderName.Enabled = true;
            }
            else
            {
                tBoxFolderName.Enabled = false; 
            }
        }
    }
}
