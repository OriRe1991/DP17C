﻿namespace C17_Ex01_Tal_301349361_Ori_2033199900
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
            this.components = new System.ComponentModel.Container();
            this.labelTest = new System.Windows.Forms.Label();
            this.listBoxTest = new System.Windows.Forms.ListBox();
            this.pictureBoxCoverPhoto = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBoxProfilePic = new System.Windows.Forms.PictureBox();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTest.Location = new System.Drawing.Point(23, 290);
            this.labelTest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(0, 57);
            this.labelTest.TabIndex = 1;
            // 
            // listBoxTest
            // 
            this.listBoxTest.FormattingEnabled = true;
            this.listBoxTest.ItemHeight = 29;
            this.listBoxTest.Location = new System.Drawing.Point(1087, 448);
            this.listBoxTest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxTest.Name = "listBoxTest";
            this.listBoxTest.Size = new System.Drawing.Size(494, 468);
            this.listBoxTest.TabIndex = 3;
            // 
            // pictureBoxCoverPhoto
            // 
            this.pictureBoxCoverPhoto.Location = new System.Drawing.Point(222, 2);
            this.pictureBoxCoverPhoto.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.pictureBoxCoverPhoto.Name = "pictureBoxCoverPhoto";
            this.pictureBoxCoverPhoto.Size = new System.Drawing.Size(1911, 698);
            this.pictureBoxCoverPhoto.TabIndex = 5;
            this.pictureBoxCoverPhoto.TabStop = false;
            // 
            // pictureBoxProfilePic
            // 
            this.pictureBoxProfilePic.Location = new System.Drawing.Point(264, 404);
            this.pictureBoxProfilePic.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.pictureBoxProfilePic.Name = "pictureBoxProfilePic";
            this.pictureBoxProfilePic.Size = new System.Drawing.Size(373, 357);
            this.pictureBoxProfilePic.TabIndex = 6;
            this.pictureBoxProfilePic.TabStop = false;
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfileName.Location = new System.Drawing.Point(651, 580);
            this.textBoxProfileName.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.Size = new System.Drawing.Size(228, 90);
            this.textBoxProfileName.TabIndex = 7;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2227, 991);
            this.Controls.Add(this.textBoxProfileName);
            this.Controls.Add(this.pictureBoxProfilePic);
            this.Controls.Add(this.pictureBoxCoverPhoto);
            this.Controls.Add(this.listBoxTest);
            this.Controls.Add(this.labelTest);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AppForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AppForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.ListBox listBoxTest;
        private System.Windows.Forms.PictureBox pictureBoxCoverPhoto;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox pictureBoxProfilePic;
        private System.Windows.Forms.TextBox textBoxProfileName;
    }
}

