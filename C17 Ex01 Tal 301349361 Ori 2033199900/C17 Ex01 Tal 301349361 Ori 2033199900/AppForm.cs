using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic;
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
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            labelTest.Text = "Start opration...";
            m_LogicApp.LogInToSocialNetwork();
            GetDataBtn.Enabled = true;
        }

        private void GetDataBtn_Click(object sender, EventArgs e)
        {
            labelTest.Text += "\nGetting Photos";
            var listData = m_LogicApp.Data();
            ///////////////////////////////
            // PhotosTaggedIn return 0
            //////////////////////////////
            foreach (var item in listData)
            {
                listBoxTest.Items.Add(item);
            }
        }
    }
}
