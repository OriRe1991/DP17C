namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class FormLogin
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
            this.LableWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(199, 336);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(219, 54);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // checkBoxSaveAccessToken
            // 
            this.checkBoxSaveAccessToken.AutoSize = true;
            this.checkBoxSaveAccessToken.Location = new System.Drawing.Point(199, 404);
            this.checkBoxSaveAccessToken.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.checkBoxSaveAccessToken.Name = "checkBoxSaveAccessToken";
            this.checkBoxSaveAccessToken.Size = new System.Drawing.Size(206, 33);
            this.checkBoxSaveAccessToken.TabIndex = 1;
            this.checkBoxSaveAccessToken.Text = "Remember me";
            this.checkBoxSaveAccessToken.UseVisualStyleBackColor = true;
            this.checkBoxSaveAccessToken.CheckedChanged += new System.EventHandler(this.checkBoxSaveAccessToken_CheckedChanged);
            // 
            // LableWelcome
            // 
            this.LableWelcome.AutoSize = true;
            this.LableWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableWelcome.Location = new System.Drawing.Point(104, 107);
            this.LableWelcome.Name = "LableWelcome";
            this.LableWelcome.Size = new System.Drawing.Size(429, 69);
            this.LableWelcome.TabIndex = 2;
            this.LableWelcome.Text = "Welcome Back";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(530, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please Login to your facebook account";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 582);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LableWelcome);
            this.Controls.Add(this.checkBoxSaveAccessToken);
            this.Controls.Add(this.LoginButton);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.Shown += new System.EventHandler(this.FormLogin_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.CheckBox checkBoxSaveAccessToken;
        private System.Windows.Forms.Label LableWelcome;
        private System.Windows.Forms.Label label1;
    }
}