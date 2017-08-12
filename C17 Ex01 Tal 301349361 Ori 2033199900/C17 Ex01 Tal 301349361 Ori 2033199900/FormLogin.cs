using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic;
using C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class FormLogin : Form
    {
        private ControlData m_ControlData;
        private ILogicInterface m_AppLogic;

        public FormLogin(ILogicInterface i_LogicApp)
        {
            m_AppLogic = i_LogicApp;
            InitializeComponent();
            m_ControlData = ControlData.GetInstance();
        }
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
            logIn();
            this.Close();
        }

        private void logIn()
        {
            LoginButton.Text = "LoginIn...";
            if ((m_ControlData.UserData = UserData.LoadUserDataFromJson()) != null)
            {
                m_AppLogic.LogInToSocialNetwork(m_ControlData.UserData.UserAccessToken);
            }
            else
            {
                m_AppLogic.LogInToSocialNetwork();
                m_ControlData.UserData = new UserData();
            }
        }

        private void checkBoxSaveAccessToken_CheckedChanged(object sender, EventArgs e)
        {
            m_AppLogic.RememberMe = (sender as CheckBox).Checked;
            m_ControlData.UserData.RememberLogIn = m_AppLogic.RememberMe;
            if (File.Exists(m_ControlData.UserData.GetUserDataFilePath()))
            {
                File.Delete(m_ControlData.UserData.GetUserDataFilePath());
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_ControlData.Isconnected = m_AppLogic.IsConnected();
        }
    }
}
