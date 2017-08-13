using System;
using System.Collections.Generic;
using System.Linq;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic.Features
{
    public class MyBestFriendManager
    {
        private const int k_TaggedPhotosWight = 4;

        private const int k_CommenstWight = 2;

        private const int k_LikesWight = 1;

        private Dictionary<string, int> m_FriendShipMap = new Dictionary<string, int>();

        private Dictionary<string, int> FriendShipMap
        {
            get
            {
                if (m_FriendShipMap == null)
                {
                    m_FriendShipMap = new Dictionary<string, int>();
                }

                return m_FriendShipMap;
            }
        }
        
        private IDataSociable m_SocialData = null;

        public MyBestFriendManager(IDataSociable i_SocialData)
        {
            if (i_SocialData == null)
            {
                throw new Exception("Now valid social network givin");
            }

            m_SocialData = i_SocialData;
        }

        private void UpdateFriendCounter(string i_FirendsId, int i_AddValue)
        {
            if (i_FirendsId != m_SocialData.GetMyUserId())
            {
                if (!FriendShipMap.ContainsKey(i_FirendsId))
                {
                    FriendShipMap[i_FirendsId] = 0;
                }

                FriendShipMap[i_FirendsId] += i_AddValue;
            }
        }

        //// Likes in post on wall, tagged photos x 2, comments x 1.5, like photos
        public void GenerateBestFriendsData(Dictionary<string, List<SocialPhotoData>> i_FriendsPhotos)
        {
            var posts = m_SocialData.GetLastPost(-1);
            foreach (var post in posts)
            {
                UpdateFriendCounter(post.GeneratedFriendUserId, k_CommenstWight);
                foreach (var entity in post.EntityReactedToPost)
                {
                    UpdateFriendCounter(entity.UserId, k_LikesWight);
                }
            }

            foreach (var friend in i_FriendsPhotos)
            {
                int calculatedTotalPhotosWight = friend.Value.Count * k_TaggedPhotosWight;
                UpdateFriendCounter(friend.Key, calculatedTotalPhotosWight);
            }
        }

        public string GetMyBestFriendId(Dictionary<string, List<SocialPhotoData>> i_FriendsPhotos)
        {
            GenerateBestFriendsData(i_FriendsPhotos);
            var myVeryBestFriends = FriendShipMap.OrderByDescending(fsm => fsm.Value).ToList();
            string bestOfFriendsId = myVeryBestFriends.First().Key;
            return bestOfFriendsId;
        }
    }
}
