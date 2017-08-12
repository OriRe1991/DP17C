namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class PostBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.labelPostDate = new System.Windows.Forms.Label();
            this.labelPostText = new System.Windows.Forms.Label();
            this.pictureBoxPostPicture = new System.Windows.Forms.PictureBox();
            this.labelPostLikes = new System.Windows.Forms.Label();
            this.flowLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.labelPostDate);
            this.flowLayoutPanelMain.Controls.Add(this.labelPostText);
            this.flowLayoutPanelMain.Controls.Add(this.pictureBoxPostPicture);
            this.flowLayoutPanelMain.Controls.Add(this.labelPostLikes);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 5);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(362, 62);
            this.flowLayoutPanelMain.TabIndex = 5;
            // 
            // labelPostDate
            // 
            this.labelPostDate.AutoSize = true;
            this.labelPostDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPostDate.Location = new System.Drawing.Point(3, 0);
            this.labelPostDate.Name = "labelPostDate";
            this.labelPostDate.Size = new System.Drawing.Size(356, 13);
            this.labelPostDate.TabIndex = 0;
            this.labelPostDate.Text = "PostDate";
            // 
            // labelPostText
            // 
            this.labelPostText.AutoSize = true;
            this.labelPostText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPostText.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostText.Location = new System.Drawing.Point(3, 13);
            this.labelPostText.Name = "labelPostText";
            this.labelPostText.Size = new System.Drawing.Size(356, 20);
            this.labelPostText.TabIndex = 1;
            this.labelPostText.Text = "PostText";
            // 
            // pictureBoxPostPicture
            // 
            this.pictureBoxPostPicture.ErrorImage = null;
            this.pictureBoxPostPicture.InitialImage = null;
            this.pictureBoxPostPicture.Location = new System.Drawing.Point(3, 36);
            this.pictureBoxPostPicture.Name = "pictureBoxPostPicture";
            this.pictureBoxPostPicture.Size = new System.Drawing.Size(356, 10);
            this.pictureBoxPostPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPostPicture.TabIndex = 2;
            this.pictureBoxPostPicture.TabStop = false;
            // 
            // labelPostLikes
            // 
            this.labelPostLikes.AutoSize = true;
            this.labelPostLikes.Location = new System.Drawing.Point(3, 49);
            this.labelPostLikes.Name = "labelPostLikes";
            this.labelPostLikes.Size = new System.Drawing.Size(75, 13);
            this.labelPostLikes.TabIndex = 3;
            this.labelPostLikes.Text = "labelPostLikes";
            // 
            // PostBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Name = "PostBox";
            this.Size = new System.Drawing.Size(368, 81);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Label labelPostDate;
        private System.Windows.Forms.Label labelPostText;
        private System.Windows.Forms.PictureBox pictureBoxPostPicture;
        private System.Windows.Forms.Label labelPostLikes;
    }
}
