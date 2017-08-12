using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class PostBox : UserControl
    {
        public PostBox()
        {
            InitializeComponent();
        }

        public string PostDate
        {
            get
            {
                return this.labelPostDate.Text;
            }

            set
            {
                this.labelPostDate.Text = value;
            }
        }

        public string PostText
        {
            get
            {
                return this.labelPostText.Text;
            }

            set
            {
                this.labelPostText.Text = value;
            }
        }

        public string PostPictureUrl
        {
            get
            {
                return this.pictureBoxPostPicture.ImageLocation;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                this.pictureBoxPostPicture.ImageLocation = value;
                this.pictureBoxPostPicture.Height = 300;
            }
        }

        public void PostLikes(int numberOfLikes)
        {
            this.labelPostLikes.Text = string.Format("{0} liked it", numberOfLikes);
        }
    }
}
