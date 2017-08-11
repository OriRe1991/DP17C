using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class AppForm : Form
    {
        private ILogicInterface m_LogicApp;
        private List<PictureBox> m_ViewedAlbumCovers;
        private List<Label> m_ViewedAlbumCoversLabels;
        private UserData m_UserData;
        private FormLogin m_FormLogin
        public AppForm()
        {
            m_ViewedAlbumCovers = new List<PictureBox>();
            m_ViewedAlbumCoversLabels = new List<Label>();
            InitializeComponent();
            m_ViewedAlbumCovers.Add(pictureBox1);
            m_ViewedAlbumCovers.Add(pictureBox2);
            m_ViewedAlbumCovers.Add(pictureBox3);
            m_ViewedAlbumCovers.Add(pictureBox4);
            m_ViewedAlbumCoversLabels.Add(labelPictureBox1);
            m_ViewedAlbumCoversLabels.Add(labelPictureBox2);
            m_ViewedAlbumCoversLabels.Add(labelPictureBox3);
            m_ViewedAlbumCoversLabels.Add(labelPictureBox4);

            // TODO:
            //////////////////////////////////////////////////////////////
            m_LogicApp = new ApplicationLogic();
            //////////////////////////////////////////////////////////////

            login();
            m_FormLogin.ShowDialog();

            var userData = m_LogicApp.GetUserData();
            pictureBoxProfilePic.LoadAsync(userData.ProfilePictureUrl);
            pictureBoxCoverPhoto.LoadAsync(userData.ThemePictureUrl);
            updateViewedAlbumCovers();
            ProfileNameLable.Text = userData.FullName;
        }

        private void login()
        {
            if(m_LogicApp.RememberMe)
            {
                UserData.
            }
        }

        private void updateViewedAlbumCovers()
        {
           List<AlbumData> viewedAlbumsData = m_LogicApp.GetFirstAlbumsData(m_ViewedAlbumCovers.Count);
            int albumIdx = 0;
            foreach (var viewedAlbumData in viewedAlbumsData)
            {
                m_ViewedAlbumCovers[albumIdx].LoadAsync(viewedAlbumData.FirstPicUrl);
                m_ViewedAlbumCoversLabels[albumIdx].Text = viewedAlbumData.AlbomName;
                albumIdx++;
            }
        }

        private void labelPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
