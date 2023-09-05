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

        public string GetName
        {
            get { return tBoxName.Text; }
            set { tBoxName.Text = value; }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _name = tBoxName.Text;

            if(_type == TypeEnum.Type.Folder.ToString())
            {
                _rt.AddFolder(sender, e);
            }
            else if (_type == TypeEnum.Type.File.ToString())
            {
                _rt.AddFile(sender, e);
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
