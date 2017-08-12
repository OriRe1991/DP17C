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
                return labelPostDate.Text;
            }

            set
            {
                labelPostDate.Text = value;
            }
        }

        public string PostText
        {
            get
            {
                return labelPostText.Text;
            }

            set
            {
                labelPostText.Text = value;
            }
        }

        public string PostPictureUrl
        {
            get
            {
                return pictureBoxPostPicture.ImageLocation;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                pictureBoxPostPicture.ImageLocation = value;
                pictureBoxPostPicture.Height = 300;
            }
        }

        public void PostLikes(int numberOfLikes)
        {
            labelPostLikes.Text = string.Format("{0} liked it", numberOfLikes);
        }
    }
}
