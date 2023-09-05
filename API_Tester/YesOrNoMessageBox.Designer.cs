
namespace API_Tester
{
    partial class YesOrNoMessageBox
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
            this.btnYes = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.btnNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.ForestGreen;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnYes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnYes.Location = new System.Drawing.Point(398, 113);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(83, 43);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMessage.Location = new System.Drawing.Point(182, 24);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(90, 23);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Message";
            // 
            // pBox
            // 
            this.pBox.Image = global::API_Tester.Properties.Resources.question_sky;
            this.pBox.Location = new System.Drawing.Point(12, 12);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(151, 144);
            this.pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox.TabIndex = 2;
            this.pBox.TabStop = false;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Red;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNo.Location = new System.Drawing.Point(309, 113);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(83, 43);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            // 
            // YesOrNoMessageBox
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 168);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YesOrNoMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message";
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Button btnNo;
    }
}