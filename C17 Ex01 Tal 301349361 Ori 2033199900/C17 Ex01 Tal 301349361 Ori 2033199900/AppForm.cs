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
            //LogicApp = new ApplicationLogic();
            m_ControlData = ControlData.GetInstance();
            m_LogicApp = m_ControlData.AppLogic;
            //////////////////////////////////////////////////////////////

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
            updateViewedAlbumCovers();
            ProfileNameLable.Text = entityData.FullName;
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
            updateViewedAlbumCovers();
        }
    }
}
