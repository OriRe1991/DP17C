using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic.Features
{
    public class MyBestFriend
    {
        private static float s_TaggedPhotosWight = 2;

        private static float s_CommenstWight = 1.5f;

        private static float s_LikesWight = 1;

        private IDataSociable m_SocialData = null;

        public MyBestFriend(IDataSociable i_SocialData)
        {
            if (i_SocialData == null)
            {
                throw new Exception("Now valid social network givin");
            }

            m_SocialData = i_SocialData;
        }

        //// Likes in post on wall, tagged photos x 2, comments x 1.5, like photos
        public void GenerateBestFriends()
        {
            var posts = m_SocialData.GetLastPost(-1);

        }

    }
}
