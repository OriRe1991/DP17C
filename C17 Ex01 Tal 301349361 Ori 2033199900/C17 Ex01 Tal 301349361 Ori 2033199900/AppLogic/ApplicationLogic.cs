using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;
using C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic.Features;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic
{
    class ApplicationLogic : ILogicInterface
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
        private AlbumDataManager m_AlbomDataManager;
        public AlbumDataManager AlbomDataManager
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

        public EntityData GetUserData()
        {
            EntityData retVal = new EntityData();

            retVal.FullName = UserSocialData.GetFullName();
            retVal.ProfilePictureUrl = UserSocialData.GetProfilePictureUrl();
            retVal.ThemePictureUrl = UserSocialData.GetThemePhotoUrl();

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

        public void CreateAlbumWithFriend(params string[] i_UserIds)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected()
        {
            return m_UserSocialData.IsLogedOn();
        }

        public void LogOutUser(Action i_PostLogOutAction)
        {
            m_UserSocialData.LogOut(i_PostLogOutAction);
        }
    }
}
