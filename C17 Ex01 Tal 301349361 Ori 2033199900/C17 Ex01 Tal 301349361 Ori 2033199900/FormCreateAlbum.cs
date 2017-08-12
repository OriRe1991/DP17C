using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class FormCreateAlbum : Form
    {
        private ControlData m_ControlData;

        public FormCreateAlbum()
        {
            InitializeComponent();
            m_ControlData = ControlData.GetInstance();
        }

        private void FormCreateAlbum_Load(object sender, EventArgs e)
        {
            var taggedFriendsNames = m_ControlData.AppLogic.GetTaggedFriends();
            foreach (var entity in taggedFriendsNames)
            {
                CheckedListBoxTaggedFriends.Items.Add(entity.Value);
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            List<string> selectedFriends = new List<string>();
            foreach (var item in CheckedListBoxTaggedFriends.SelectedItems)
            {
                selectedFriends.Add((item as EntityData).ToString());
            }

            m_ControlData.AppLogic.CreateAlbumWithFriend(selectedFriends.ToArray());
            this.Dispose();
        }
    }
}
