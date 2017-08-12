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

        public Dictionary<int, EntityData> GetMostTaggedFriends(int i_NumberOfFriends, Dictionary<string, List<SocialPhotoData>> i_FriendsTaggedPhotos, Dictionary<string, EntityData> i_FriendsTaggedData)
        {
            Dictionary<int, EntityData> retVal = new Dictionary<int, EntityData>();
            var mostTagged = i_FriendsTaggedPhotos.OrderBy(kvp => kvp.Value.Count).Take(i_NumberOfFriends).ToList();
            foreach (var friend in i_FriendsTaggedPhotos)
            {
                retVal[friend.Value.Count] = i_FriendsTaggedData[friend.Key];
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

        public string CreateNewAlbum(Dictionary<string, EntityData> i_FriendsTaggedData, Dictionary<string, List<SocialPhotoData>> i_FriendsTaggedPhotos, params string[] i_FrindsIds)
        {
            if (i_FrindsIds != null && i_FrindsIds.Length > 0)
            {
                StringBuilder albumName = new StringBuilder(string.Format("{0} And ", m_SocialData.GetFirstName()));
                List<string> PhotosUrl = new List<string>();
                foreach (var friend in i_FrindsIds)
                {
                    albumName.Append(i_FriendsTaggedData[friend].FullName);
                    foreach (var photo in i_FriendsTaggedPhotos[friend])
                    {
                        PhotosUrl.Add(photo.PhotoUrl);
                    }
                }

                string albumDescription = string.Format("{0}, Photos.", albumName);
                return m_SocialData.CreateAlbum(albumName.ToString(), albumDescription, PhotosUrl);
            }
            else
            {
                throw new Exception("Try to Create Friends Album with no friends");
            }
        }
    }
}
