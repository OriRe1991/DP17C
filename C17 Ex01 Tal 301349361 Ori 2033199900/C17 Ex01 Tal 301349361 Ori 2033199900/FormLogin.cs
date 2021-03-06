﻿using System;
using System.IO;
using System.Windows.Forms;
using C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class FormLogin : Form
    {
        private ControlData m_ControlData;

        public FormLogin()
        {
            InitializeComponent();
            m_ControlData = ControlData.GetInstance();
        }
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
            loginAction();
        }

        private void loginAction()
        {
            logIn();
            m_ControlData.IsConnected = m_ControlData.AppLogic.IsConnected();
            this.Close();
        }

        private void logIn()
        {
            LoginButton.Text = "LoginIn...";
            m_ControlData.AppLogic.RememberMe = checkBoxSaveAccessToken.Checked;
            m_ControlData.UserData.RememberLogIn = m_ControlData.AppLogic.RememberMe;
            UserData TempUserData = UserData.LoadUserDataFromJson();
            try
            {
                if (TempUserData != null && TempUserData.RememberLogIn)
                {
                    m_ControlData.UserData = UserData.LoadUserDataFromJson();
                    m_ControlData.AppLogic.LogInToSocialNetwork(m_ControlData.UserData.UserAccessToken);
                }
                else
                {
                    m_ControlData.AppLogic.LogInToSocialNetwork();
                    m_ControlData.UserData.UserAccessToken = m_ControlData.AppLogic.GetEntityData().AccessToken;
                }

                m_ControlData.IsConnected = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxSaveAccessToken_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists(m_ControlData.UserData.GetUserDataFilePath()))
            {
                File.Delete(m_ControlData.UserData.GetUserDataFilePath());
            }
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            if (m_ControlData.UserData.Connected || m_ControlData.UserData.RememberLogIn)
            {
                loginAction();
            }
        }
    }
}
