﻿
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
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.URL = new System.Windows.Forms.Label();
            this.btnRequest = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxRst = new System.Windows.Forms.TextBox();
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnNom = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.tBoxMsg = new API_Tester.Custom.CustomTextBox();
            this.tBoxCookie = new API_Tester.Custom.CustomTextBox();
            this.tBoxURL = new API_Tester.Custom.CustomTextBox();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Font = new System.Drawing.Font("궁서", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(140, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Tester";
            // 
            // cBoxMethod
            // 
            this.cBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxMethod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBoxMethod.FormattingEnabled = true;
            this.cBoxMethod.Location = new System.Drawing.Point(238, 260);
            this.cBoxMethod.Name = "cBoxMethod";
            this.cBoxMethod.Size = new System.Drawing.Size(121, 23);
            this.cBoxMethod.TabIndex = 1;
            this.cBoxMethod.TabStop = false;
            this.cBoxMethod.SelectedIndexChanged += new System.EventHandler(this.cBoxMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("궁서체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(152, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Method";
            // 
            // URL
            // 
            this.URL.AutoSize = true;
            this.URL.Font = new System.Drawing.Font("궁서체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.URL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.URL.Location = new System.Drawing.Point(440, 261);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(39, 19);
            this.URL.TabIndex = 3;
            this.URL.Text = "URL";
            // 
            // btnRequest
            // 
            this.btnRequest.Font = new System.Drawing.Font("궁서체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRequest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRequest.Location = new System.Drawing.Point(1122, 309);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(118, 49);
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
            this.lblMsg.Location = new System.Drawing.Point(151, 354);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(59, 19);
            this.lblMsg.TabIndex = 8;
            this.lblMsg.Text = "msg =";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(150, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 10);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Location = new System.Drawing.Point(150, 205);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1090, 10);
            this.panel2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("궁서체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(121, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cookie =";
            // 
            // tBoxRst
            // 
            this.tBoxRst.Location = new System.Drawing.Point(147, 453);
            this.tBoxRst.Multiline = true;
            this.tBoxRst.Name = "tBoxRst";
            this.tBoxRst.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxRst.Size = new System.Drawing.Size(1084, 223);
            this.tBoxRst.TabIndex = 13;
            // 
            // titleBar
            // 
            this.titleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleBar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.titleBar.Controls.Add(this.btnNom);
            this.titleBar.Controls.Add(this.btnMax);
            this.titleBar.Controls.Add(this.btnMin);
            this.titleBar.Controls.Add(this.btnX);
            this.titleBar.Location = new System.Drawing.Point(0, -2);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1275, 45);
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
            this.btnNom.Location = new System.Drawing.Point(1180, 5);
            this.btnNom.Name = "btnNom";
            this.btnNom.Size = new System.Drawing.Size(41, 37);
            this.btnNom.TabIndex = 18;
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
            this.btnMax.Location = new System.Drawing.Point(1180, 5);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(41, 37);
            this.btnMax.TabIndex = 15;
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
            this.btnMin.Location = new System.Drawing.Point(1137, 5);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(41, 37);
            this.btnMin.TabIndex = 15;
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
            this.btnX.Location = new System.Drawing.Point(1223, 5);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(41, 37);
            this.btnX.TabIndex = 15;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // tBoxMsg
            // 
            this.tBoxMsg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxMsg.BorderColor = System.Drawing.Color.Gray;
            this.tBoxMsg.BorderSize = 2;
            this.tBoxMsg.Location = new System.Drawing.Point(238, 354);
            this.tBoxMsg.Multiline = false;
            this.tBoxMsg.Name = "tBoxMsg";
            this.tBoxMsg.Padding = new System.Windows.Forms.Padding(7);
            this.tBoxMsg.PasswordChar = false;
            this.tBoxMsg.Size = new System.Drawing.Size(801, 32);
            this.tBoxMsg.TabIndex = 18;
            this.tBoxMsg.UnderlinedStyle = true;
            // 
            // tBoxCookie
            // 
            this.tBoxCookie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxCookie.BorderColor = System.Drawing.Color.Gray;
            this.tBoxCookie.BorderSize = 2;
            this.tBoxCookie.Location = new System.Drawing.Point(238, 309);
            this.tBoxCookie.Multiline = false;
            this.tBoxCookie.Name = "tBoxCookie";
            this.tBoxCookie.Padding = new System.Windows.Forms.Padding(7);
            this.tBoxCookie.PasswordChar = false;
            this.tBoxCookie.Size = new System.Drawing.Size(801, 32);
            this.tBoxCookie.TabIndex = 17;
            this.tBoxCookie.UnderlinedStyle = true;
            // 
            // tBoxURL
            // 
            this.tBoxURL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBoxURL.BorderColor = System.Drawing.Color.Gray;
            this.tBoxURL.BorderSize = 2;
            this.tBoxURL.Location = new System.Drawing.Point(503, 260);
            this.tBoxURL.Multiline = false;
            this.tBoxURL.Name = "tBoxURL";
            this.tBoxURL.Padding = new System.Windows.Forms.Padding(7);
            this.tBoxURL.PasswordChar = false;
            this.tBoxURL.Size = new System.Drawing.Size(737, 32);
            this.tBoxURL.TabIndex = 16;
            this.tBoxURL.UnderlinedStyle = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1269, 757);
            this.Controls.Add(this.tBoxMsg);
            this.Controls.Add(this.tBoxCookie);
            this.Controls.Add(this.tBoxURL);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.tBoxRst);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBoxMethod);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.titleBar.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxRst;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnNom;
        private Custom.CustomTextBox tBoxURL;
        private Custom.CustomTextBox tBoxCookie;
        private Custom.CustomTextBox tBoxMsg;
    }
}

