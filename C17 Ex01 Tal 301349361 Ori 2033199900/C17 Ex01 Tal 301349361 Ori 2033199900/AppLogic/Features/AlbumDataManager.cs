using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic.Features
{
    internal class AlbumDataManager
    {
        private IDataSociable m_SocialData = null;
        private Dictionary<string, int> friendsTaggedCount = null;

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

        public List<AlbumData> GetAlbumsData(int i_NumberOfAlbums)
        {
            List<AlbumData> retVal = null;

            retVal = m_SocialData.GetLastAlbums(i_NumberOfAlbums);

            return retVal;
        }

        public Dictionary<string, int> GetMostTaggedFriends()
        {
            Dictionary<string, int> friendsTaggedCount = new Dictionary<string, int>();

            foreach (var photo in TaggedFriends)
            {
                foreach (var friend in photo.FriendsInPhotos)
                {
                    if (!friendsTaggedCount.ContainsKey(friend.UserId))
                    {
                        friendsTaggedCount[friend.UserId] = 0;
                    }

                    friendsTaggedCount[friend.UserId]++;
                }
            }

            return friendsTaggedCount;
        }

        public Dictionary<string, UserData> GetTaggedFriendsNameList()
        {
            Dictionary<string, UserData> retVal = new Dictionary<string, UserData>();

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

        public string CreateNewAlbum(string i_FriendUserId, string i_FrindName)
        {
            string albumName = string.Format("{0} And {1}", m_SocialData.GetFirstName(), i_FrindName);
            string albumDescription = string.Format("{0}, Photos.", albumName);
            return m_SocialData.CreateAlbum(albumName, albumDescription);
        }
    }
}
