﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic;
using C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class AppForm : Form
    {
        private const int k_NumberOfPostFromWall = 3;

        private string m_richTextBoxNewPostDefaultTest = string.Empty;

        private ILogicInterface m_LogicApp;

        private List<PictureBox> m_ViewedAlbumCovers;

        private List<Label> m_ViewdAlbumsLabels;

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
            m_ViewedAlbumCovers = groupBoxAlbumCovers.Controls.OfType<PictureBox>().ToList();
            m_ViewdAlbumsLabels = groupBoxAlbumCovers.Controls.OfType<Label>().ToList();
            m_ControlData = ControlData.GetInstance();
            m_LogicApp = m_ControlData.AppLogic;
            m_richTextBoxNewPostDefaultTest = richTextBoxNewPost.Text;

            m_FormLogin = new FormLogin();
            m_FormLogin.ShowDialog();
            if (!m_ControlData.IsConnected)
            {
                Dispose();
            }

            var entityData = m_LogicApp.GetEntityData();
            Show();
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
            flowLayoutPanelWall.Controls.Clear();
            List<SocialPost> postList = null;
            try
            {
                postList = m_ControlData.AppLogic.GetLastPostFromWall(k_NumberOfPostFromWall);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            List<AlbumData> viewedAlbumsData = null;
            try
            {
                viewedAlbumsData = m_LogicApp.GetFirstAlbumsData(m_ViewedAlbumCovers.Count);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (viewedAlbumsData != null && viewedAlbumsData.Count > 0)
            {
                int albumIdx = 0;
                foreach (var viewedAlbumData in viewedAlbumsData)
                {
                    m_ViewedAlbumCovers[albumIdx].LoadAsync(viewedAlbumData.FirstPicUrl);
                    m_ViewdAlbumsLabels[albumIdx].Text = viewedAlbumData.AlbomName;
                    albumIdx++;
                }
            }
        }

        private void AppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_ControlData.UserData.RememberLogIn && m_ControlData.IsConnected)
            {
                m_ControlData.UserData.Connected = true;
                try
                {
                    m_ControlData.UserData.SaveUserDataToJson();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
            m_ControlData.UserData.UserAccessToken = null;
            m_ControlData.AppLogic.LogOutUser(On_Logout);
        }

        public void On_Logout()
        {
            m_ControlData.UserData.DeleteUserDataFile();
            this.Dispose();
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                m_ControlData.AppLogic.CreateNewPost(this.richTextBoxNewPost.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            restToDefaultTextrichTextBox();
            updatePageView();
        }

        private void buttonWhosMyBFF_Click(object sender, EventArgs e)
        {
            FormMyBestFriend myBeasFriendWindow = new FormMyBestFriend();
            myBeasFriendWindow.ShowDialog();
        }

        private void richTextBoxNewPost_MouseDown(object sender, MouseEventArgs e)
        {
            if (richTextBoxNewPost.Text == m_richTextBoxNewPostDefaultTest)
            {
                richTextBoxNewPost.Clear();
            }
        }

        private void richTextBoxNewPost_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBoxNewPost.Text) || string.IsNullOrWhiteSpace(richTextBoxNewPost.Text))
            {
                restToDefaultTextrichTextBox();
            }
        }

        private void restToDefaultTextrichTextBox()
        {
            richTextBoxNewPost.Text = m_richTextBoxNewPostDefaultTest;
        }
    }
}
