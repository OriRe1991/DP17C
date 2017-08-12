namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class FormCreateAlbum
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
            this.CheckedListBoxTaggedFriends = new System.Windows.Forms.CheckedListBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckedListBoxTaggedFriends
            // 
            this.CheckedListBoxTaggedFriends.FormattingEnabled = true;
            this.CheckedListBoxTaggedFriends.Location = new System.Drawing.Point(12, 51);
            this.CheckedListBoxTaggedFriends.Name = "CheckedListBoxTaggedFriends";
            this.CheckedListBoxTaggedFriends.Size = new System.Drawing.Size(174, 154);
            this.CheckedListBoxTaggedFriends.TabIndex = 0;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(12, 211);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(120, 38);
            this.buttonDone.TabIndex = 1;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // FormCreateAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.CheckedListBoxTaggedFriends);
            this.Name = "FormCreateAlbum";
            this.Text = "FormCreateAlbum";
            this.Load += new System.EventHandler(this.FormCreateAlbum_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CheckedListBoxTaggedFriends;
        private System.Windows.Forms.Button buttonDone;
    }
}