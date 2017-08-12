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
            return AlbomDataManager.GetTaggedFriendsNameList();
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
            AlbomDataManager.CreateNewAlbum(i_UserIds);
        }

        public bool CreateNewPost(string i_PostData)
        {
            return UserSocialData.CreateNewPostStatus(i_PostData);
        }
    }
}
