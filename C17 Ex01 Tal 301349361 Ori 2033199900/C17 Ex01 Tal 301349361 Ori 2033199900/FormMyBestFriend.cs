using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem;

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
            var bestFriend = m_ControlData.AppLogic.GetMyBestFriend();
            LableFriendName.Text = bestFriend.FullName;
            pictureBoxFriendProfilePic.LoadAsync(bestFriend.ProfilePictureUrl);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
