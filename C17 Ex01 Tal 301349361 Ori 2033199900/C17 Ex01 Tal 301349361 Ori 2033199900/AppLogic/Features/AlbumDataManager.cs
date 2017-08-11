using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic.Features
{
    internal class AlbumDataManager
    {
        private IDataSociable m_SocialData = null;
        private Dictionary<string, int> m_FriendsTaggedCount = null;

        private Dictionary<string, int> FriendsTaggedCount
        {
            get
            {
                if (m_FriendsTaggedCount == null)
                {
                    inittaggedFriendsData();
                }

                return m_FriendsTaggedCount;
            }
        }

        private Dictionary<string, EntityData> m_FriendsTaggedData = null;

        private Dictionary<string, EntityData> FriendsTaggedData
        {
            get
            {
                if (m_FriendsTaggedData == null)
                {
                    inittaggedFriendsData();
                }

                return m_FriendsTaggedData;
            }
        }

        private List<SocialPhotoData> m_TaggedFriends = null;

        private List<SocialPhotoData> TaggedFriends
        {
            get
            {
                if (m_SocialData == null)
                {
                    throw new Exception("Try to retrive data without SocialData Connection");
                }

                if (m_TaggedFriends == null)
                {
                    m_TaggedFriends = m_SocialData.GetPhotos();
                }

                return m_TaggedFriends;
            }
        }

        public AlbumDataManager(IDataSociable i_SocialData)
        {
            if (i_SocialData == null)
            {
                throw new Exception("Now valid social network givin");
            }

            m_SocialData = i_SocialData;
        }

        private void inittaggedFriendsData()
        {
            m_FriendsTaggedCount = new Dictionary<string, int>();
            m_FriendsTaggedData = new Dictionary<string, EntityData>();

            foreach (var photo in TaggedFriends)
            {
                foreach (var friend in photo.FriendsInPhotos)
                {
                    if (!m_FriendsTaggedCount.ContainsKey(friend.UserId))
                    {
                        m_FriendsTaggedCount[friend.UserId] = 0;
                    }

                    if (!m_FriendsTaggedData.ContainsKey(friend.UserId))
                    {
                        m_FriendsTaggedData[friend.UserId] = friend;
                    }

                    m_FriendsTaggedCount[friend.UserId]++;
                }
            }
        }

        public List<AlbumData> GetAlbumsData(int i_NumberOfAlbums)
        {
            List<AlbumData> retVal = null;

            retVal = m_SocialData.GetLastAlbums(i_NumberOfAlbums);

            return retVal;
        }

        public Dictionary<int, EntityData> GetMostTaggedFriends(int i_NumberOfFriends)
        {
            Dictionary<int, EntityData> retVal = new Dictionary<int, EntityData>();
            var mostTagged = FriendsTaggedCount.OrderBy(kvp => kvp.Value).Take(i_NumberOfFriends).ToList();
            foreach (var friend in FriendsTaggedCount)
            {
                retVal[friend.Value] = FriendsTaggedData[friend.Key];
            }

            return retVal;
        }

        public Dictionary<string, EntityData> GetTaggedFriendsNameList()
        {
            Dictionary<string, EntityData> retVal = new Dictionary<string, EntityData>();

            foreach (var photo in TaggedFriends)
            {
                foreach (var friend in photo.FriendsInPhotos)
                {
                    if (friend.UserId != m_SocialData.GetUserId())
                    {
                        if (!retVal.ContainsKey(friend.UserId))
                        {
                            retVal[friend.UserId] = friend;
                        }
                    }
                }
            }

            return retVal;
        }

        public string CreateNewAlbum(params string[] i_FrindName)
        {
            if (i_FrindName != null && i_FrindName.Length > 0)
            {
                StringBuilder albumName = new StringBuilder(string.Format("{0} And ", m_SocialData.GetFirstName()));
                foreach (var friend in i_FrindName)
                {
                    albumName.Append(friend);
                }

                string albumDescription = string.Format("{0}, Photos.", albumName);
                return m_SocialData.CreateAlbum(albumName.ToString(), albumDescription);
            }
            else
            {
                throw new Exception("Try to Create Friends Album with no friends");
            }
        }
    }
}
