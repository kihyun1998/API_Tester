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
    public partial class YesOrNoMessageBox : Form
    {
        public YesOrNoMessageBox()
        {
            InitializeComponent();
        }

        public Image MessageIcon
        {
            get { return pBox.Image; }
            set { pBox.Image = value; }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value;  }
        }
    }
}
