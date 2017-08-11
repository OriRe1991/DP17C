namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    partial class AppForm
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
            this.LogInBtn = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.GetDataBtn = new System.Windows.Forms.Button();
            this.listBoxTest = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LogInBtn
            // 
            this.LogInBtn.Location = new System.Drawing.Point(256, 159);
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.Size = new System.Drawing.Size(156, 56);
            this.LogInBtn.TabIndex = 0;
            this.LogInBtn.Text = "LogIn";
            this.LogInBtn.UseVisualStyleBackColor = true;
            this.LogInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(256, 286);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(0, 29);
            this.labelTest.TabIndex = 1;
            // 
            // GetDataBtn
            // 
            this.GetDataBtn.Enabled = false;
            this.GetDataBtn.Location = new System.Drawing.Point(631, 56);
            this.GetDataBtn.Name = "GetDataBtn";
            this.GetDataBtn.Size = new System.Drawing.Size(255, 102);
            this.GetDataBtn.TabIndex = 2;
            this.GetDataBtn.Text = "Get Test Data";
            this.GetDataBtn.UseVisualStyleBackColor = true;
            this.GetDataBtn.Click += new System.EventHandler(this.GetDataBtn_Click);
            // 
            // listBoxTest
            // 
            this.listBoxTest.FormattingEnabled = true;
            this.listBoxTest.ItemHeight = 29;
            this.listBoxTest.Location = new System.Drawing.Point(631, 479);
            this.listBoxTest.Name = "listBoxTest";
            this.listBoxTest.Size = new System.Drawing.Size(494, 468);
            this.listBoxTest.TabIndex = 3;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1292, 720);
            this.Controls.Add(this.listBoxTest);
            this.Controls.Add(this.GetDataBtn);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.LogInBtn);
            this.Name = "AppForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogInBtn;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Button GetDataBtn;
        private System.Windows.Forms.ListBox listBoxTest;
    }
}

