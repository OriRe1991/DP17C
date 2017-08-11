﻿using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic;
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
        public AppForm()
        {
            InitializeComponent();
            // TODO:
            //////////////////////////////////////////////////////////////
            m_LogicApp = new ApplicationLogic();
            //////////////////////////////////////////////////////////////

            FormLogin loginForm = new FormLogin(m_LogicApp);
            loginForm.ShowDialog();

            var userData = m_LogicApp.GetUserData();
            pictureBoxProfilePic.LoadAsync(userData.ProfilePictureUrl);
            pictureBoxCoverPhoto.LoadAsync(userData.ThemePictureUrl);
            ProfileNameLable.Text = userData.FullName;
        }

 

        private void AppForm_Load(object sender, EventArgs e)
        {

        }

    }
}
