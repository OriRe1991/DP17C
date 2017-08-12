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

        public Dictionary<int, EntityData> GetMostTaggedFriends(int i_NumberOfFriends, Dictionary<string, int> i_FriendsTaggedCount, Dictionary<string, EntityData> i_FriendsTaggedData)
        {
            Dictionary<int, EntityData> retVal = new Dictionary<int, EntityData>();
            var mostTagged = i_FriendsTaggedCount.OrderBy(kvp => kvp.Value).Take(i_NumberOfFriends).ToList();
            foreach (var friend in i_FriendsTaggedCount)
            {
                retVal[friend.Value] = i_FriendsTaggedData[friend.Key];
            }

            return retVal;
        }

        public Dictionary<string, EntityData> GetTaggedFriendsNameList(List<SocialPhotoData> i_TaggedFriends)
        {
            Dictionary<string, EntityData> retVal = new Dictionary<string, EntityData>();

            foreach (var photo in i_TaggedFriends)
            {
                foreach (var friend in photo.FriendsInPhotos)
                {
                    if (friend.UserId != m_SocialData.GetMyUserId())
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

        public string CreateNewAlbum(Dictionary<string, EntityData> i_FriendsTaggedData, params string[] i_FrindName)
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
