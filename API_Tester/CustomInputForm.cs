using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_Tester
{
    public partial class CustomInputForm : Form
    {
        Repository _rt = null;
        string _title = string.Empty;
        string _buttonType = string.Empty;
        public string _name = string.Empty;
        public string _type = string.Empty;

        public CustomInputForm()
        {
            InitializeComponent();
            lblTitle.Text = _title;
        }

        public CustomInputForm(Repository repository)
        {
            InitializeComponent();
            this._rt = repository;
            lblTitle.Text = _title;
        }

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        
        public string ButtonText
        {
            get { return btnOK.Text; }
            set { btnOK.Text = value; }
        }

        public string GetName
        {
            get { return tBoxName.Text; }
            set { tBoxName.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _name = tBoxName.Text;
            //if (_type == TypeEnum.Type.CreateFile.ToString() || _type == TypeEnum.Type.CreateFolder.ToString())
            //{
            //    // 타입이 Create로 시작하면
            //    btnOK.Text = "➕ Create";
            //}
            //else if (_type == TypeEnum.Type.RenameFile.ToString() || _type == TypeEnum.Type.RenameFolder.ToString())
            //{
            //    // 타입이 Rename으로 시작한다면

            //    btnOK.Text = "📄 Rename";
            //}
            if (_type == TypeEnum.Type.CreateFolder.ToString())
            {
                _rt.AddFolder(sender, e);
                btnOK.Text = "➕ Create";
            }
            else if (_type == TypeEnum.Type.CreateFile.ToString())
            {
                _rt.AddFile(sender, e);
                btnOK.Text = "➕ Create";
            }
            else if(_type == TypeEnum.Type.RenameFolder.ToString())
            {
                _rt.RenameFolder(sender, e);
                btnOK.Text = "📄 Rename";
            }
            else if(_type == TypeEnum.Type.RenameFile.ToString())
            {
                _rt.RenameFile();
                btnOK.Text = "📄 Rename";
            }
            else
            {
                CustomMessageBox.ShowMessage("에러", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
