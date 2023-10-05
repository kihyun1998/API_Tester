
namespace API_Tester
{
    partial class Repository
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.titleBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFileAdd = new System.Windows.Forms.Button();
            this.btnFileDel = new System.Windows.Forms.Button();
            this.btnFolderDel = new System.Windows.Forms.Button();
            this.btnFolderAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("나눔고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeView1.Location = new System.Drawing.Point(12, 48);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(254, 423);
            this.treeView1.TabIndex = 1;
            this.treeView1.TabStop = false;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // titleBar
            // 
            this.titleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleBar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.titleBar.Location = new System.Drawing.Point(-1, -1);
            this.titleBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(286, 43);
            this.titleBar.TabIndex = 15;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.btnFolderAdd);
            this.panel1.Controls.Add(this.btnFolderDel);
            this.panel1.Controls.Add(this.btnFileAdd);
            this.panel1.Controls.Add(this.btnFileDel);
            this.panel1.Location = new System.Drawing.Point(-1, 514);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 45);
            this.panel1.TabIndex = 16;
            // 
            // btnFileAdd
            // 
            this.btnFileAdd.BackgroundImage = global::API_Tester.Properties.Resources.document_add;
            this.btnFileAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFileAdd.FlatAppearance.BorderSize = 0;
            this.btnFileAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileAdd.Location = new System.Drawing.Point(236, 6);
            this.btnFileAdd.Name = "btnFileAdd";
            this.btnFileAdd.Size = new System.Drawing.Size(31, 31);
            this.btnFileAdd.TabIndex = 5;
            this.btnFileAdd.UseVisualStyleBackColor = true;
            this.btnFileAdd.Click += new System.EventHandler(this.btnFileAdd_Click);
            // 
            // btnFileDel
            // 
            this.btnFileDel.BackgroundImage = global::API_Tester.Properties.Resources.document_del;
            this.btnFileDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFileDel.FlatAppearance.BorderSize = 0;
            this.btnFileDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileDel.Location = new System.Drawing.Point(236, 6);
            this.btnFileDel.Name = "btnFileDel";
            this.btnFileDel.Size = new System.Drawing.Size(31, 31);
            this.btnFileDel.TabIndex = 6;
            this.btnFileDel.UseVisualStyleBackColor = true;
            this.btnFileDel.Click += new System.EventHandler(this.btnFileDel_Click);
            // 
            // btnFolderDel
            // 
            this.btnFolderDel.BackgroundImage = global::API_Tester.Properties.Resources.folder;
            this.btnFolderDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFolderDel.FlatAppearance.BorderSize = 0;
            this.btnFolderDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderDel.Location = new System.Drawing.Point(188, 6);
            this.btnFolderDel.Name = "btnFolderDel";
            this.btnFolderDel.Size = new System.Drawing.Size(31, 31);
            this.btnFolderDel.TabIndex = 7;
            this.btnFolderDel.UseVisualStyleBackColor = true;
            this.btnFolderDel.Click += new System.EventHandler(this.btnFolderDel_Click);
            // 
            // btnFolderAdd
            // 
            this.btnFolderAdd.BackgroundImage = global::API_Tester.Properties.Resources.add_folder;
            this.btnFolderAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFolderAdd.FlatAppearance.BorderSize = 0;
            this.btnFolderAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderAdd.Location = new System.Drawing.Point(188, 6);
            this.btnFolderAdd.Name = "btnFolderAdd";
            this.btnFolderAdd.Size = new System.Drawing.Size(31, 31);
            this.btnFolderAdd.TabIndex = 8;
            this.btnFolderAdd.UseVisualStyleBackColor = true;
            this.btnFolderAdd.Click += new System.EventHandler(this.btnFolderAdd_Click);
            // 
            // Repository
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(278, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Repository";
            this.Text = "Repository";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnFileAdd;
        private System.Windows.Forms.Button btnFileDel;
        private System.Windows.Forms.Button btnFolderDel;
        private System.Windows.Forms.Button btnFolderAdd;
    }
}