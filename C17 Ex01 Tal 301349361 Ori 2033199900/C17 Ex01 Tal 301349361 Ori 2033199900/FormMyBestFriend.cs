using System;
using System.Windows.Forms;
using System.Threading;
using C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class FormMyBestFriend : Form
    {
        private enum WightPlaneOption
        {
            MostLike,
            MostComment,
            MostTagged
        }

        private WightPlaneOption m_WightPlaneOption;

        private ControlData m_ControlData;

        public FormMyBestFriend()
        {
            InitializeComponent();
            comboBoxSelectPriority.Items.Add("Most Comment");
            comboBoxSelectPriority.Items.Add("Most Like");
            comboBoxSelectPriority.Items.Add("Most Tagged");
            m_ControlData = ControlData.GetInstance();

            /// sending the methods to the function to implement the strategy
            m_ControlData.AppLogic.SetFriendListSorting(mostLikedFirends, mostCommenstFriend, mostTaggedFriends);
        }

        private void FormMyBestFriend_Load(object sender, EventArgs e)
        {
            this.Show();
        }

        private void FetchElement()
        {
            var bestFriend = m_ControlData.AppLogic.GetMyBestFriend();
            LableFriendName.Invoke(new Action(() => LableFriendName.Text = bestFriend.FullName));
            pictureBoxFriendProfilePic.LoadAsync(bestFriend.ProfilePictureUrl);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private int mostTaggedFriends()
        {
            int retVal = 0;
            switch (m_WightPlaneOption)
            {
                case WightPlaneOption.MostLike:
                    retVal = 2;
                    break;
                case WightPlaneOption.MostComment:
                    retVal = 3;
                    break;
                case WightPlaneOption.MostTagged:
                    retVal = 10;
                    break;
                default:
                    break;
            }

            return retVal;
        }

        private int mostLikedFirends()
        {
            int retVal = 0;
            switch (m_WightPlaneOption)
            {
                case WightPlaneOption.MostLike:
                    retVal = 10;
                    break;
                case WightPlaneOption.MostComment:
                    retVal = 3;
                    break;
                case WightPlaneOption.MostTagged:
                    retVal = 5;
                    break;
                default:
                    break;
            }

            return retVal;
        }

        private int mostCommenstFriend()
        {
            int retVal = 0;
            switch (m_WightPlaneOption)
            {
                case WightPlaneOption.MostLike:
                    retVal = 2;
                    break;
                case WightPlaneOption.MostComment:
                    retVal = 10;
                    break;
                case WightPlaneOption.MostTagged:
                    retVal = 5;
                    break;
                default:
                    break;
            }

            return retVal;
        }

        private void comboBoxSelectPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_WightPlaneOption = (WightPlaneOption)comboBoxSelectPriority.SelectedIndex;
        }

        private void buttonConfirmSelection_Click(object sender, EventArgs e)
        {
            LableFriendName.Text = "Loading Friend...";
            pictureBoxFriendProfilePic.ImageLocation = null;
            new Thread(FetchElement).Start();
        }
    }
}
