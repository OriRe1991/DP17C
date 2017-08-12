using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic;
using C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class AppForm : Form
    {
        private ILogicInterface m_LogicApp;

        List<PictureBox> m_ViewedAlbumCovers;
        List<Label> m_ViewdAlbumsLabels;

        private ControlData m_ControlData;

        private FormLogin m_FormLogin;

        private FormCreateAlbum m_FormCreateAlbum;

        public FormCreateAlbum CreateAlbumForm
        {
            get
            {
                if (m_FormCreateAlbum == null)
                {
                    m_FormCreateAlbum = new FormCreateAlbum();
                }

                return m_FormCreateAlbum;
            }
        }

        public AppForm()
        {
            InitializeComponent();
            m_ViewedAlbumCovers = (this.groupBoxAlbumCovers.Controls.OfType<PictureBox>()).ToList();
            m_ViewdAlbumsLabels = (this.groupBoxAlbumCovers.Controls.OfType<Label>()).ToList();
            m_ControlData = ControlData.GetInstance();
            m_LogicApp = m_ControlData.AppLogic;

            m_FormLogin = new FormLogin();
            m_FormLogin.ShowDialog();


            if (!m_ControlData.Isconnected)
            {
                this.Dispose();
            }

            var entityData = m_LogicApp.GetEntityData();
            this.Show();
            pictureBoxProfilePic.LoadAsync(entityData.ProfilePictureUrl);
            pictureBoxCoverPhoto.LoadAsync(entityData.ThemePictureUrl);
            updatePageView();
            ProfileNameLable.Text = entityData.FullName;
        }

        private void ClearCreateAlbumForm()
        {
            m_FormCreateAlbum = null;
        }

        private void updatePageView()
        {
            updateRecentAlbumView();
            updateWall();
        }

        private void updateWall()
        {
            List<SocialPost> postList = m_ControlData.AppLogic.GetLastPostFromWall(3);
            int idx = 0;
            if (postList != null)
            {
                foreach (var post in postList)
                {

                    PostBox newPost = new PostBox();
                    newPost.Name = string.Format("PostBox{0}", idx);
                    newPost.PostDate = post.CreatedTime.ToLongDateString();
                    newPost.PostText = post.Message;
                    newPost.PostPictureUrl = post.PictureUrl;
                    newPost.PostLikes(post.EntityReactedToPost.Count);
                    this.Controls.Add(newPost);
                    flowLayoutPanelWall.Controls.Add(newPost);
                    idx++;
                }
            }
        }

        private void updateRecentAlbumView()
        {
            List<AlbumData> viewedAlbumsData = m_LogicApp.GetFirstAlbumsData(m_ViewedAlbumCovers.Count);
            int albumIdx = 0;

            foreach (var viewedAlbumData in viewedAlbumsData)
            {
                m_ViewedAlbumCovers[albumIdx].LoadAsync(viewedAlbumData.FirstPicUrl);
                m_ViewdAlbumsLabels[albumIdx].Text = viewedAlbumData.AlbomName;
                albumIdx++;
            }
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_ControlData.UserData.RememberLogIn || m_ControlData.Isconnected)
            {
                m_ControlData.UserData.Connected = true;
                m_ControlData.UserData.saveUserDataToJson();
            }
        }

        private void buttonCreateAlbum_Click(object sender, EventArgs e)
        {
            CreateAlbumForm.ShowDialog();
            updatePageView();
            ClearCreateAlbumForm();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            ProfileNameLable.Parent = pictureBoxCoverPhoto;
            ProfileNameLable.BackColor = Color.Transparent;
            ProfileNameLable.TextAlign = ContentAlignment.TopLeft;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_ControlData.UserData.Connected = false;
            m_ControlData.AppLogic.LogOutUser(On_Logout);
        }

        public void On_Logout()
        {
            this.Dispose();
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            m_ControlData.AppLogic.CreateNewPost(this.richTextBoxNewPost.Text);
            richTextBoxNewPost.Clear();
            updatePageView();
        }
    }
}
