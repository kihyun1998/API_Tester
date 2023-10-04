
namespace API_Tester
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cBoxMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRequest = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.PictureBox();
            this.btnLeft = new System.Windows.Forms.PictureBox();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.btnNom = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tBoxRst = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tBoxMsg = new API_Tester.Custom.CustomTextBox();
            this.tBoxCookie = new API_Tester.Custom.CustomTextBox();
            this.tBoxURL = new API_Tester.Custom.CustomTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxMethod
            // 
            this.cBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxMethod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBoxMethod.FormattingEnabled = true;
            this.cBoxMethod.IntegralHeight = false;
            this.cBoxMethod.ItemHeight = 15;
            this.cBoxMethod.Location = new System.Drawing.Point(128, 197);
            this.cBoxMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxMethod.Name = "cBoxMethod";
            this.cBoxMethod.Size = new System.Drawing.Size(121, 23);
            this.cBoxMethod.TabIndex = 1;
            this.cBoxMethod.TabStop = false;
            this.cBoxMethod.SelectedIndexChanged += new System.EventHandler(this.cBoxMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(39, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Method :";
            // 
            // btnRequest
            // 
            this.btnRequest.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRequest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRequest.Location = new System.Drawing.Point(987, 248);
            this.btnRequest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(149, 61);
            this.btnRequest.TabIndex = 5;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("나눔고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMsg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMsg.Location = new System.Drawing.Point(58, 314);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(66, 21);
            this.lblMsg.TabIndex = 8;
            this.lblMsg.Text = "Body :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Location = new System.Drawing.Point(42, 128);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1094, 12);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(40, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cookie :";
            // 
            // titleBar
            // 
            this.titleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleBar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.titleBar.Controls.Add(this.btnMin);
            this.titleBar.Controls.Add(this.btnRight);
            this.titleBar.Controls.Add(this.btnLeft);
            this.titleBar.Controls.Add(this.lblProgramName);
            this.titleBar.Controls.Add(this.btnNom);
            this.titleBar.Controls.Add(this.btnMax);
            this.titleBar.Controls.Add(this.btnX);
            this.titleBar.Location = new System.Drawing.Point(0, -2);
            this.titleBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1190, 44);
            this.titleBar.TabIndex = 14;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseUp);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMin.BackgroundImage = global::API_Tester.Properties.Resources.minus;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Location = new System.Drawing.Point(1049, 4);
            this.btnMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(32, 31);
            this.btnMin.TabIndex = 24;
            this.btnMin.TabStop = false;
            this.btnMin.UseVisualStyleBackColor = false;
            // 
            // btnRight
            // 
            this.btnRight.Image = global::API_Tester.Properties.Resources.free_icon_right_arrow_271228;
            this.btnRight.Location = new System.Drawing.Point(3, 4);
            this.btnRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(26, 30);
            this.btnRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRight.TabIndex = 20;
            this.btnRight.TabStop = false;
            this.btnRight.Visible = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Image = global::API_Tester.Properties.Resources.free_icon_left_arrow_271220;
            this.btnLeft.Location = new System.Drawing.Point(3, 4);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(26, 30);
            this.btnLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLeft.TabIndex = 19;
            this.btnLeft.TabStop = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblProgramName.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProgramName.Location = new System.Drawing.Point(50, -1);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(206, 46);
            this.lblProgramName.TabIndex = 23;
            this.lblProgramName.Text = "API Tester";
            this.lblProgramName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblProgramName_MouseDown);
            this.lblProgramName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblProgramName_MouseMove);
            this.lblProgramName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblProgramName_MouseUp);
            // 
            // btnNom
            // 
            this.btnNom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNom.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnNom.BackgroundImage = global::API_Tester.Properties.Resources.overlapping_squares;
            this.btnNom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNom.FlatAppearance.BorderSize = 0;
            this.btnNom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNom.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNom.ForeColor = System.Drawing.Color.White;
            this.btnNom.Location = new System.Drawing.Point(1096, 6);
            this.btnNom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNom.Name = "btnNom";
            this.btnNom.Size = new System.Drawing.Size(32, 31);
            this.btnNom.TabIndex = 18;
            this.btnNom.TabStop = false;
            this.btnNom.UseVisualStyleBackColor = false;
            this.btnNom.Click += new System.EventHandler(this.btnNom_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMax.BackgroundImage = global::API_Tester.Properties.Resources.square;
            this.btnMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMax.ForeColor = System.Drawing.Color.White;
            this.btnMax.Location = new System.Drawing.Point(1096, 7);
            this.btnMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(32, 30);
            this.btnMax.TabIndex = 15;
            this.btnMax.TabStop = false;
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnX
            // 
            this.btnX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnX.BackgroundImage = global::API_Tester.Properties.Resources.close;
            this.btnX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(1147, 7);
            this.btnX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(32, 31);
            this.btnX.TabIndex = 15;
            this.btnX.TabStop = false;
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(42, 371);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 12);
            this.panel1.TabIndex = 19;
            // 
            // tBoxRst
            // 
            this.tBoxRst.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tBoxRst.Location = new System.Drawing.Point(42, 416);
            this.tBoxRst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxRst.Multiline = true;
            this.tBoxRst.Name = "tBoxRst";
            this.tBoxRst.ReadOnly = true;
            this.tBoxRst.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxRst.Size = new System.Drawing.Size(1093, 239);
            this.tBoxRst.TabIndex = 21;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(36, 62);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 35);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "Title";
            this.lblTitle.Visible = false;
            // 
            // tBoxMsg
            // 
            this.tBoxMsg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxMsg.BorderColor = System.Drawing.Color.Gray;
            this.tBoxMsg.BorderSize = 2;
            this.tBoxMsg.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tBoxMsg.Location = new System.Drawing.Point(128, 314);
            this.tBoxMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxMsg.Multiline = false;
            this.tBoxMsg.Name = "tBoxMsg";
            this.tBoxMsg.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.tBoxMsg.PasswordChar = false;
            this.tBoxMsg.Size = new System.Drawing.Size(812, 34);
            this.tBoxMsg.TabIndex = 18;
            this.tBoxMsg.UnderlinedStyle = true;
            this.tBoxMsg.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tBoxCookie
            // 
            this.tBoxCookie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxCookie.BorderColor = System.Drawing.Color.Gray;
            this.tBoxCookie.BorderSize = 2;
            this.tBoxCookie.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tBoxCookie.Location = new System.Drawing.Point(128, 258);
            this.tBoxCookie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxCookie.Multiline = false;
            this.tBoxCookie.Name = "tBoxCookie";
            this.tBoxCookie.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.tBoxCookie.PasswordChar = false;
            this.tBoxCookie.Size = new System.Drawing.Size(812, 34);
            this.tBoxCookie.TabIndex = 17;
            this.tBoxCookie.UnderlinedStyle = true;
            this.tBoxCookie.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tBoxURL
            // 
            this.tBoxURL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxURL.BorderColor = System.Drawing.Color.Gray;
            this.tBoxURL.BorderSize = 2;
            this.tBoxURL.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tBoxURL.Location = new System.Drawing.Point(338, 197);
            this.tBoxURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxURL.Multiline = false;
            this.tBoxURL.Name = "tBoxURL";
            this.tBoxURL.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.tBoxURL.PasswordChar = false;
            this.tBoxURL.Size = new System.Drawing.Size(798, 34);
            this.tBoxURL.TabIndex = 16;
            this.tBoxURL.UnderlinedStyle = true;
            this.tBoxURL.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(283, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 26;
            this.label1.Text = "URL :";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::API_Tester.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(-6034, -4189);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(33, 33);
            this.btnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSave.TabIndex = 24;
            this.btnSave.TabStop = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1188, 700);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tBoxRst);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tBoxMsg);
            this.Controls.Add(this.tBoxCookie);
            this.Controls.Add(this.tBoxURL);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBoxMethod);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1166, 700);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnNom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnLeft;
        private System.Windows.Forms.PictureBox btnRight;
        private System.Windows.Forms.Label lblProgramName;
        public System.Windows.Forms.ComboBox cBoxMethod;
        public Custom.CustomTextBox tBoxCookie;
        public Custom.CustomTextBox tBoxMsg;
        public Custom.CustomTextBox tBoxURL;
        public System.Windows.Forms.PictureBox btnSave;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tBoxRst;
        private System.Windows.Forms.Button btnMin;
    }
}

