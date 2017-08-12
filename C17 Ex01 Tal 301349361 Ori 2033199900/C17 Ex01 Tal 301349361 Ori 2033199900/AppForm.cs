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

        private List<PictureBox> m_ViewedAlbumCovers;

        private List<Label> m_ViewedAlbumCoversLabels;

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
            m_ViewedAlbumCovers = new List<PictureBox>();
            m_ViewedAlbumCoversLabels = new List<Label>();
            InitializeComponent();
            m_ViewedAlbumCovers.Add(pictureBoxAlbumCover1);
            m_ViewedAlbumCovers.Add(pictureBoxAlbumCover2);
            m_ViewedAlbumCovers.Add(pictureBoxCoverAlbum3);
            m_ViewedAlbumCovers.Add(pictureBoxAlbumCover4);
            m_ViewedAlbumCoversLabels.Add(labelPictureBoxCoverAlbum1);
            m_ViewedAlbumCoversLabels.Add(labelPictureBoxCoverAlbum2);
            m_ViewedAlbumCoversLabels.Add(labelPictureBoxCoverAlbum3);
            m_ViewedAlbumCoversLabels.Add(labelPictureBoxCoverAlbum4);          
            m_ControlData = ControlData.GetInstance();
            m_LogicApp = m_ControlData.AppLogic;
            m_FormLogin = new FormLogin();
            m_FormLogin.ShowDialog();
            m_ControlData = ControlData.GetInstance();
            if(!m_ControlData.Isconnected)
            {
                this.Dispose();
            }

            var entityData = m_LogicApp.GetEntityData();
            pictureBoxProfilePic.LoadAsync(entityData.ProfilePictureUrl);
            pictureBoxCoverPhoto.LoadAsync(entityData.ThemePictureUrl);
            updatePageView();
            ProfileNameLable.Text = entityData.FullName;
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
            if(postList != null)
            {
                foreach (var post in postList)
                {
                    if (post.Message.Length > 0)
                    {
                        Label newPost = new Label();
                        newPost.Name = string.Format("LabelPost{0}", idx);
                        newPost.Text = post.Message;
                        newPost.Font = new Font(Font.FontFamily, 18);
                        newPost.ForeColor = Color.Black;
                        this.Controls.Add(newPost);
                        flowLayoutPanelWall.Controls.Add(newPost);
                    }
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
                m_ViewedAlbumCoversLabels[albumIdx].Text = viewedAlbumData.AlbomName;
                albumIdx++;
            }
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_ControlData.UserData.RememberLogIn)
            {
                m_ControlData.UserData.saveUserDataToJson();
            }
        }

        private void buttonCreateAlbum_Click(object sender, EventArgs e)
        {
            m_FormCreateAlbum = CreateAlbumForm;
            CreateAlbumForm.ShowDialog();
            updatePageView();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            ProfileNameLable.Parent = pictureBoxCoverPhoto;
            ProfileNameLable.BackColor = Color.Transparent;
            ProfileNameLable.TextAlign = ContentAlignment.TopLeft;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
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
