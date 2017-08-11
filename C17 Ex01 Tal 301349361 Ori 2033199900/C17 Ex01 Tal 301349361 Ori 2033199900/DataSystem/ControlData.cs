using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.DataSystem
{
    public class ControlData
    {
        public UserData UserData { get; set; }

        public bool Isconnected { get; set; }

        private static ControlData m_Instance;

        public static ControlData GetInstance()
        {
            if (m_Instance == null)
            {
                m_Instance = new ControlData();
            }

            return m_Instance;
        }

        private ControlData ()
        {
            UserData = new UserData();
        }
    }
}
