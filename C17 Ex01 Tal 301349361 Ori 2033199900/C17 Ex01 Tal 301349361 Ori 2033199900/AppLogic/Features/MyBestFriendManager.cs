using System;
using System.Collections.Generic;
using System.Linq;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic.Features
{
    public class MyBestFriendManager
    {
        //private const int k_TaggedPhotosWight = 4;

        //private const int k_CommenstWight = 2;

        //private const int k_LikesWight = 1;

        private Func<int> m_LikedWightLogic;
        private Func<int> m_CommenstWightLogic;
        private Func<int> m_TaggedWightLogic;

        private Dictionary<string, EntityData> m_FriendsData;

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
                UpdateFriendCounter(post.GeneratedFriendUserId, m_CommenstWightLogic.Invoke());
                validateFrindInList(post.PostWritter);
                foreach (var entity in post.EntityReactedToPost)
                {
                    UpdateFriendCounter(entity.UserId, m_LikedWightLogic.Invoke());
                    validateFrindInList(entity);
                }
            }

            foreach (var friend in i_FriendsPhotos)
            {
                int calculatedTotalPhotosWight = friend.Value.Count * m_TaggedWightLogic.Invoke();
                UpdateFriendCounter(friend.Key, calculatedTotalPhotosWight);
            }
        }

        private void validateFrindInList(EntityData i_FriendEntityData)
        {
            if (!m_FriendsData.ContainsKey(i_FriendEntityData.UserId))
            {
                m_FriendsData[i_FriendEntityData.UserId] = i_FriendEntityData;
            }
        }

        public string GetMyBestFriendId(Dictionary<string, List<SocialPhotoData>> i_FriendsPhotos, Dictionary<string, EntityData> i_FriendsData)
        {
            m_FriendsData = i_FriendsData;
            GenerateBestFriendsData(i_FriendsPhotos);
            var myVeryBestFriends = FriendShipMap.OrderByDescending(fsm => fsm.Value).ToList();
            string bestOfFriendsId = myVeryBestFriends.First().Key;
            return bestOfFriendsId;
        }

        public void SetFriendsSortingLogic(Func<int> i_LikedWightLogic, Func<int> i_CommenstWightLogic, Func<int> i_TaggedWightLogic)
        {
            m_LikedWightLogic = i_LikedWightLogic;
            m_CommenstWightLogic = i_CommenstWightLogic;
            m_TaggedWightLogic = i_TaggedWightLogic;
        }
    }
}
