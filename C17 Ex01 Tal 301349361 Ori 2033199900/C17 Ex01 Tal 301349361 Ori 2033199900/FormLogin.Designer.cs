namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    partial class FormLogin
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.checkBoxSaveAccessToken = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(100, 151);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(94, 24);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // checkBoxSaveAccessToken
            // 
            this.checkBoxSaveAccessToken.AutoSize = true;
            this.checkBoxSaveAccessToken.Location = new System.Drawing.Point(100, 181);
            this.checkBoxSaveAccessToken.Name = "checkBoxSaveAccessToken";
            this.checkBoxSaveAccessToken.Size = new System.Drawing.Size(94, 17);
            this.checkBoxSaveAccessToken.TabIndex = 1;
            this.checkBoxSaveAccessToken.Text = "Remember me";
            this.checkBoxSaveAccessToken.UseVisualStyleBackColor = true;
            this.checkBoxSaveAccessToken.CheckedChanged += new System.EventHandler(this.checkBoxSaveAccessToken_CheckedChanged);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkBoxSaveAccessToken);
            this.Controls.Add(this.LoginButton);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.CheckBox checkBoxSaveAccessToken;
    }
}