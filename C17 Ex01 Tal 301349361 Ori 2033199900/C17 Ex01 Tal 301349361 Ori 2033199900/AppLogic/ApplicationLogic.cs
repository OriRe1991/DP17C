using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;
using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic.Features;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic
{
    public class ApplicationLogic : ILogicInterface
    {
        private static int s_NumberOfPhotosToRetrive = 50;
        public bool RememberMe { get; set; }

        private IDataSociable m_UserSocialData;

        private IDataSociable UserSocialData
        {
            get
            {
                if (m_UserSocialData == null)
                {
                    throw new Exception("not Loged On");
                }

                return m_UserSocialData;
            }
        }

        private Dictionary<string, EntityData> m_FriendsData = null;

        private Dictionary<string, EntityData> FriendsData
        {
            get
            {
                if (m_FriendsData == null)
                {
                    inittaggedFriendsData();
                }

                return m_FriendsData;
            }
        }

        private Dictionary<string, List<SocialPhotoData>> m_FriendsPhotos = null;

        private Dictionary<string, List<SocialPhotoData>> FriendsPhotos
        {
            get
            {
                if (m_FriendsPhotos == null)
                {
                    inittaggedFriendsData();
                }

                return m_FriendsPhotos;
            }
        }

        private List<SocialPhotoData> m_TaggedFriends = null;

        private List<SocialPhotoData> TaggedFriends
        {
            get
            {
                if (UserSocialData == null)
                {
                    throw new Exception("Try to retrive data without SocialData Connection");
                }

                if (m_TaggedFriends == null)
                {
                    m_TaggedFriends = UserSocialData.GetPhotos(s_NumberOfPhotosToRetrive);
                }

                return m_TaggedFriends;
            }
        }

        private void inittaggedFriendsData()
        {
            m_FriendsData = new Dictionary<string, EntityData>();
            m_FriendsPhotos = new Dictionary<string, List<SocialPhotoData>>();

            foreach (var photo in TaggedFriends)
            {
                foreach (var friend in photo.FriendsInPhotos)
                {
                    if (!string.IsNullOrEmpty(friend.UserId) && friend.UserId != m_UserSocialData.GetMyUserId())
                    {
                        if (!m_FriendsData.ContainsKey(friend.UserId))
                        {
                            m_FriendsData[friend.UserId] = friend;
                        }

                        if (!m_FriendsPhotos.ContainsKey(friend.UserId))
                        {
                            m_FriendsPhotos[friend.UserId] = new List<SocialPhotoData>();
                        }

                        m_FriendsPhotos[friend.UserId].Add(photo);
                    }
                }
            }
        }

        private AlbumDataManager m_AlbomDataManager = null;

        private AlbumDataManager AlbomDataManager
        {
            get
            {
                if (m_AlbomDataManager == null)
                {
                    m_AlbomDataManager = new AlbumDataManager(UserSocialData);
                }

                return m_AlbomDataManager;
            }
       }

        public void LogInToSocialNetwork(string i_SocialToken = null)
        {
            m_UserSocialData = SocialDataFactory.GetSocialNetwork();
            UserSocialData.LogIn(i_SocialToken);
        }

        public EntityData GetEntityData()
        {
            EntityData retVal = new EntityData();

            retVal.FullName = UserSocialData.GetFullName();
            retVal.ProfilePictureUrl = UserSocialData.GetProfilePictureUrl();
            retVal.ThemePictureUrl = UserSocialData.GetThemePhotoUrl();
            retVal.AccessToken = UserSocialData.GetAccessToken();
            return retVal;
        }

        public List<AlbumData> GetFirstAlbumsData(int i_NumberOfAlbums)
        {
            return AlbomDataManager.GetAlbumsData(i_NumberOfAlbums);
        }

        public Dictionary<string, EntityData> GetTaggedFriends()
        {
            return AlbomDataManager.GetTaggedFriendsNameList(TaggedFriends);
        }

        public bool IsConnected()
        {
            return m_UserSocialData.IsLogedOn();
        }

        public void LogOutUser(Action i_PostLogOutAction)
        {
            m_UserSocialData.LogOut(i_PostLogOutAction);
        }

        public void CreateAlbumWithFriend(params string[] i_UserIds)
        {
            AlbomDataManager.CreateNewAlbum(FriendsData, FriendsPhotos, i_UserIds);
        }

        public bool CreateNewPost(string i_PostData)
        {
            return UserSocialData.CreateNewPostStatus(i_PostData);
        }

        public List<SocialPost> GetLastPostFromWall(int i_NumberOfPosts)
        {
            return m_UserSocialData.GetLastPost(i_NumberOfPosts);
        }
    }
}
