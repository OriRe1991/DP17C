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
        private IDataSociable m_UserSocialData;
        private AlbumDataManager m_AlbomDataManager;
        public AlbumDataManager AlbomDataManager
        
        {
            get
            {
                if (m_AlbomDataManager == null)
                {
                    m_AlbomDataManager = new AlbumDataManager(m_UserSocialData);
                }
                return m_AlbomDataManager;
            }
       }

        public bool RememberMe { get; set; }

        public void LogInToSocialNetwork(string i_SocialToken = null)
        {
            m_UserSocialData = SocialDataFactory.GetSocialNetwork();
            m_UserSocialData.LogIn(i_SocialToken);
        }

        public EntityData GetUserData()
        {
            if (m_UserSocialData == null)
            {
                throw new Exception("not Loged On");
            }

            EntityData retVal = new EntityData();

            retVal.FullName = m_UserSocialData.GetFullName();
            retVal.ProfilePictureUrl = m_UserSocialData.GetProfilePictureUrl();
            retVal.ThemePictureUrl = m_UserSocialData.GetThemePhotoUrl();

            return retVal;
        }

        public List<AlbumData> GetFirstAlbumsData(int i_NumberOfAlbums)
        {
            if (m_UserSocialData == null)
            {
                throw new Exception("not Loged On");
            }

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
    }
}
