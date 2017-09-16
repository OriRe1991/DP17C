namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class FormMyBestFriend
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
            this.comboBoxSelectPriority = new System.Windows.Forms.ComboBox();
            this.labelMethodDescription = new System.Windows.Forms.Label();
            this.buttonConfirmSelection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriendProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // Headder
            // 
            this.Headder.AutoSize = true;
            this.Headder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Headder.Location = new System.Drawing.Point(113, 115);
            this.Headder.Name = "Headder";
            this.Headder.Size = new System.Drawing.Size(454, 48);
            this.Headder.TabIndex = 0;
            this.Headder.Text = "My Very Best Friend Is:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(248, 617);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(160, 53);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "OK, Got it!";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // pictureBoxFriendProfilePic
            // 
            this.pictureBoxFriendProfilePic.Location = new System.Drawing.Point(121, 188);
            this.pictureBoxFriendProfilePic.Margin = new System.Windows.Forms.Padding(7);
            this.pictureBoxFriendProfilePic.Name = "pictureBoxFriendProfilePic";
            this.pictureBoxFriendProfilePic.Size = new System.Drawing.Size(429, 323);
            this.pictureBoxFriendProfilePic.TabIndex = 7;
            this.pictureBoxFriendProfilePic.TabStop = false;
            // 
            // LableFriendName
            // 
            this.LableFriendName.AutoSize = true;
            this.LableFriendName.Location = new System.Drawing.Point(228, 539);
            this.LableFriendName.Name = "LableFriendName";
            this.LableFriendName.Size = new System.Drawing.Size(0, 29);
            this.LableFriendName.TabIndex = 8;
            // 
            // comboBoxSelectPriority
            // 
            this.comboBoxSelectPriority.FormattingEnabled = true;
            this.comboBoxSelectPriority.Location = new System.Drawing.Point(255, 46);
            this.comboBoxSelectPriority.Name = "comboBoxSelectPriority";
            this.comboBoxSelectPriority.Size = new System.Drawing.Size(201, 37);
            this.comboBoxSelectPriority.TabIndex = 9;
            this.comboBoxSelectPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectPriority_SelectedIndexChanged);
            // 
            // labelMethodDescription
            // 
            this.labelMethodDescription.AutoSize = true;
            this.labelMethodDescription.Location = new System.Drawing.Point(66, 49);
            this.labelMethodDescription.Name = "labelMethodDescription";
            this.labelMethodDescription.Size = new System.Drawing.Size(176, 29);
            this.labelMethodDescription.TabIndex = 10;
            this.labelMethodDescription.Text = "Best Friend By:";
            // 
            // buttonConfirmSelection
            // 
            this.buttonConfirmSelection.Location = new System.Drawing.Point(463, 41);
            this.buttonConfirmSelection.Name = "buttonConfirmSelection";
            this.buttonConfirmSelection.Size = new System.Drawing.Size(91, 56);
            this.buttonConfirmSelection.TabIndex = 11;
            this.buttonConfirmSelection.Text = "Go!";
            this.buttonConfirmSelection.UseVisualStyleBackColor = true;
            this.buttonConfirmSelection.Click += new System.EventHandler(this.buttonConfirmSelection_Click);
            // 
            // FormMyBestFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 710);
            this.Controls.Add(this.buttonConfirmSelection);
            this.Controls.Add(this.labelMethodDescription);
            this.Controls.Add(this.comboBoxSelectPriority);
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
        private System.Windows.Forms.ComboBox comboBoxSelectPriority;
        private System.Windows.Forms.Label labelMethodDescription;
        private System.Windows.Forms.Button buttonConfirmSelection;
    }
}