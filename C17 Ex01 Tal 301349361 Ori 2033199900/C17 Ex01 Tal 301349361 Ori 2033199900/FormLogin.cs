using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C17_Ex01_Tal_301349361_Ori_2033199900
{
    public partial class FormLogin : Form
    {
        private ILogicInterface m_AppLogic;
        public FormLogin(ILogicInterface i_LogicApp)
        {
            m_AppLogic = i_LogicApp;
            InitializeComponent();
        }
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginButton.Text = "LoginIn...";
            m_AppLogic.LogInToSocialNetwork();
            this.Close();
        }

        private void checkBoxSaveAccessToken_CheckedChanged(object sender, EventArgs e)
        {
            m_AppLogic.RememberMe = (sender as CheckBox).Checked;
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
