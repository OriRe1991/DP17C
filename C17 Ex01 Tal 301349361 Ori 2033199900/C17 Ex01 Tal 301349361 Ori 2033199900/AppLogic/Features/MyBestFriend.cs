using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic.Features
{
    public class MyBestFriend
    {
        private IDataSociable m_SocialData = null;

        public MyBestFriend(IDataSociable i_SocialData)
        {
            if (i_SocialData == null)
            {
                throw new Exception("Now valid social network givin");
            }

            m_SocialData = i_SocialData;
        }


    }
}
