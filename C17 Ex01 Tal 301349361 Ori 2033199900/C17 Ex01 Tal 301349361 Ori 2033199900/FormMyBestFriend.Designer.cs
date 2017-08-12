namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    partial class FormMyBestFriend
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
            this.Headder = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.pictureBoxFriendProfilePic = new System.Windows.Forms.PictureBox();
            this.LableFriendName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriendProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // Headder
            // 
            this.Headder.AutoSize = true;
            this.Headder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Headder.Location = new System.Drawing.Point(113, 34);
            this.Headder.Name = "Headder";
            this.Headder.Size = new System.Drawing.Size(454, 48);
            this.Headder.TabIndex = 0;
            this.Headder.Text = "My Very Best Friend Is:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(248, 536);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(160, 53);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "OK, Got it!";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // pictureBoxFriendProfilePic
            // 
            this.pictureBoxFriendProfilePic.Location = new System.Drawing.Point(121, 107);
            this.pictureBoxFriendProfilePic.Margin = new System.Windows.Forms.Padding(7);
            this.pictureBoxFriendProfilePic.Name = "pictureBoxFriendProfilePic";
            this.pictureBoxFriendProfilePic.Size = new System.Drawing.Size(429, 323);
            this.pictureBoxFriendProfilePic.TabIndex = 7;
            this.pictureBoxFriendProfilePic.TabStop = false;
            // 
            // LableFriendName
            // 
            this.LableFriendName.AutoSize = true;
            this.LableFriendName.Location = new System.Drawing.Point(228, 458);
            this.LableFriendName.Name = "LableFriendName";
            this.LableFriendName.Size = new System.Drawing.Size(180, 29);
            this.LableFriendName.TabIndex = 8;
            this.LableFriendName.Text = "Loading Firnd...";
            // 
            // FormMyBestFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 625);
            this.Controls.Add(this.LableFriendName);
            this.Controls.Add(this.pictureBoxFriendProfilePic);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.Headder);
            this.Name = "FormMyBestFriend";
            this.Text = "FormMyBestFriend";
            this.Load += new System.EventHandler(this.FormMyBestFriend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriendProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Headder;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.PictureBox pictureBoxFriendProfilePic;
        private System.Windows.Forms.Label LableFriendName;
    }
}