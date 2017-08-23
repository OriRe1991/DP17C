using System;
using System.Windows.Forms;
using C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem;
using System.Threading;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class FormMyBestFriend : Form
    {
        private ControlData m_ControlData;

        public FormMyBestFriend()
        {
            InitializeComponent();
            m_ControlData = ControlData.GetInstance();
        }

        private void FormMyBestFriend_Load(object sender, EventArgs e)
        {
            this.Show();
            new Thread(FetchElement).Start();

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
    }
}
