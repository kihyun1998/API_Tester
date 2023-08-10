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

namespace API_Tester
{
    public partial class Repository : Form
    {

        string _rootPath;
        Thread _thread = null;

        public Repository()
        {
            InitializeComponent();
        }

        public Repository(string rootPath)
        {
            InitializeComponent();
            _rootPath = rootPath;
        }

        public void LoadTree()
        {
            _thread = new Thread(new ThreadStart(Run));
        }

        private void Run()
        {

        }
    }
}
