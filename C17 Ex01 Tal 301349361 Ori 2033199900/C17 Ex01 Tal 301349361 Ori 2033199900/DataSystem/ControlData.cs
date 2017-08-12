using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem
{
    public class ControlData
    {
        public UserData UserData { get; set; }

        public bool Isconnected { get; set; }

        public ApplicationLogic AppLogic
        {
            get
            {
                if(m_AppLogic == null)
                {
                    m_AppLogic = new ApplicationLogic();
                }

                return m_AppLogic;
            }
        }

        private static ControlData m_Instance;
        private ApplicationLogic m_AppLogic;

        public static ControlData GetInstance()
        {
            if (m_Instance == null)
            {
                m_Instance = new ControlData();
            }

            return m_Instance;
        }

        private ControlData()
        {
            UserData = UserData.LoadUserDataFromJson();
        }
    }
}
