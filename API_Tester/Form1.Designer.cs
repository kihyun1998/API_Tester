
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.URL = new System.Windows.Forms.Label();
            this.btnRequest = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnNom = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tBoxRst = new System.Windows.Forms.TextBox();
            this.btnLeft = new System.Windows.Forms.PictureBox();
            this.btnRight = new System.Windows.Forms.PictureBox();
            this.tBoxMsg = new API_Tester.Custom.CustomTextBox();
            this.tBoxCookie = new API_Tester.Custom.CustomTextBox();
            this.tBoxURL = new API_Tester.Custom.CustomTextBox();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Font = new System.Drawing.Font("궁서", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(29, 58);
            this.label1.MaximumSize = new System.Drawing.Size(200, 32);
            this.label1.MinimumSize = new System.Drawing.Size(200, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Tester";
            // 
            // cBoxMethod
            // 
            this.cBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxMethod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBoxMethod.FormattingEnabled = true;
            this.cBoxMethod.Location = new System.Drawing.Point(112, 157);
            this.cBoxMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cBoxMethod.Name = "cBoxMethod";
            this.cBoxMethod.Size = new System.Drawing.Size(106, 20);
            this.cBoxMethod.TabIndex = 1;
            this.cBoxMethod.TabStop = false;
            this.cBoxMethod.SelectedIndexChanged += new System.EventHandler(this.cBoxMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("궁서체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(38, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Method";
            // 
            // URL
            // 
            this.URL.AutoSize = true;
            this.URL.Font = new System.Drawing.Font("궁서체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.URL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.URL.Location = new System.Drawing.Point(235, 157);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(31, 15);
            this.URL.TabIndex = 3;
            this.URL.Text = "URL";
            // 
            // btnRequest
            // 
            this.btnRequest.Font = new System.Drawing.Font("궁서체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRequest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRequest.Location = new System.Drawing.Point(864, 198);
            this.btnRequest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(130, 49);
            this.btnRequest.TabIndex = 5;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("궁서체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMsg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMsg.Location = new System.Drawing.Point(46, 251);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(47, 15);
            this.lblMsg.TabIndex = 8;
            this.lblMsg.Text = "msg =";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Location = new System.Drawing.Point(37, 102);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(957, 10);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("궁서체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(22, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cookie =";
            // 
            // titleBar
            // 
            this.titleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleBar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.titleBar.Controls.Add(this.btnRight);
            this.titleBar.Controls.Add(this.btnLeft);
            this.titleBar.Controls.Add(this.btnNom);
            this.titleBar.Controls.Add(this.btnMax);
            this.titleBar.Controls.Add(this.btnMin);
            this.titleBar.Controls.Add(this.btnX);
            this.titleBar.Location = new System.Drawing.Point(0, -2);
            this.titleBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1027, 30);
            this.titleBar.TabIndex = 14;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseUp);
            // 
            // btnNom
            // 
            this.btnNom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNom.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnNom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNom.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNom.ForeColor = System.Drawing.Color.White;
            this.btnNom.Location = new System.Drawing.Point(960, 3);
            this.btnNom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNom.Name = "btnNom";
            this.btnNom.Size = new System.Drawing.Size(28, 25);
            this.btnNom.TabIndex = 18;
            this.btnNom.TabStop = false;
            this.btnNom.Text = "+";
            this.btnNom.UseVisualStyleBackColor = false;
            this.btnNom.Click += new System.EventHandler(this.btnNom_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMax.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMax.ForeColor = System.Drawing.Color.White;
            this.btnMax.Location = new System.Drawing.Point(960, 3);
            this.btnMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(28, 24);
            this.btnMax.TabIndex = 15;
            this.btnMax.TabStop = false;
            this.btnMax.Text = "ㅁ";
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMin.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Location = new System.Drawing.Point(930, 3);
            this.btnMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(28, 25);
            this.btnMin.TabIndex = 15;
            this.btnMin.TabStop = false;
            this.btnMin.Text = "ㅡ";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnX
            // 
            this.btnX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnX.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(990, 3);
            this.btnX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(28, 25);
            this.btnX.TabIndex = 15;
            this.btnX.TabStop = false;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(37, 297);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 10);
            this.panel1.TabIndex = 19;
            // 
            // tBoxRst
            // 
            this.tBoxRst.Enabled = false;
            this.tBoxRst.Location = new System.Drawing.Point(37, 333);
            this.tBoxRst.Multiline = true;
            this.tBoxRst.Name = "tBoxRst";
            this.tBoxRst.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxRst.Size = new System.Drawing.Size(957, 192);
            this.tBoxRst.TabIndex = 21;
            // 
            // btnLeft
            // 
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.Location = new System.Drawing.Point(3, 3);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(23, 24);
            this.btnLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLeft.TabIndex = 19;
            this.btnLeft.TabStop = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.Location = new System.Drawing.Point(3, 3);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(23, 24);
            this.btnRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRight.TabIndex = 20;
            this.btnRight.TabStop = false;
            this.btnRight.Visible = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // tBoxMsg
            // 
            this.tBoxMsg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxMsg.BorderColor = System.Drawing.Color.Gray;
            this.tBoxMsg.BorderSize = 2;
            this.tBoxMsg.Location = new System.Drawing.Point(112, 251);
            this.tBoxMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxMsg.Multiline = false;
            this.tBoxMsg.Name = "tBoxMsg";
            this.tBoxMsg.Padding = new System.Windows.Forms.Padding(6);
            this.tBoxMsg.PasswordChar = false;
            this.tBoxMsg.Size = new System.Drawing.Size(735, 26);
            this.tBoxMsg.TabIndex = 18;
            this.tBoxMsg.UnderlinedStyle = true;
            // 
            // tBoxCookie
            // 
            this.tBoxCookie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxCookie.BorderColor = System.Drawing.Color.Gray;
            this.tBoxCookie.BorderSize = 2;
            this.tBoxCookie.Location = new System.Drawing.Point(112, 206);
            this.tBoxCookie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxCookie.Multiline = false;
            this.tBoxCookie.Name = "tBoxCookie";
            this.tBoxCookie.Padding = new System.Windows.Forms.Padding(6);
            this.tBoxCookie.PasswordChar = false;
            this.tBoxCookie.Size = new System.Drawing.Size(735, 26);
            this.tBoxCookie.TabIndex = 17;
            this.tBoxCookie.UnderlinedStyle = true;
            // 
            // tBoxURL
            // 
            this.tBoxURL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxURL.BorderColor = System.Drawing.Color.Gray;
            this.tBoxURL.BorderSize = 2;
            this.tBoxURL.Location = new System.Drawing.Point(285, 158);
            this.tBoxURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxURL.Multiline = false;
            this.tBoxURL.Name = "tBoxURL";
            this.tBoxURL.Padding = new System.Windows.Forms.Padding(6);
            this.tBoxURL.PasswordChar = false;
            this.tBoxURL.Size = new System.Drawing.Size(703, 26);
            this.tBoxURL.TabIndex = 16;
            this.tBoxURL.UnderlinedStyle = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1020, 560);
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
            this.Controls.Add(this.URL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBoxMethod);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1020, 560);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.titleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label URL;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnNom;
        private Custom.CustomTextBox tBoxURL;
        private Custom.CustomTextBox tBoxCookie;
        private Custom.CustomTextBox tBoxMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tBoxRst;
        private System.Windows.Forms.PictureBox btnLeft;
        private System.Windows.Forms.PictureBox btnRight;
    }
}

