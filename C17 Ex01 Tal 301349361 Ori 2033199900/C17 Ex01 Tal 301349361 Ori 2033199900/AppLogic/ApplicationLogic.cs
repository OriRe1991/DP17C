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
        private AlbomDataManager m_AlbomDataManager;

        public void LogInToSocialNetwork()
        {
            m_UserSocialData = SocialDataFactory.GetSocialNetwork();
            m_UserSocialData.LogIn();
        }

        public UserData GetUserData()
        {
            if (m_UserSocialData == null)
            {
                throw new Exception("not Loged On");
            }

            UserData retVal = new UserData();

            retVal.FullName = m_UserSocialData.GetFullName();
            retVal.ProfilePictureUrl = m_UserSocialData.GetProfilePictureUrl();
            retVal.ThemePictureUrl = m_UserSocialData.GetThemePhotoUrl();

            return retVal;
        }

        public List<AlbumData> GetFirstAlbumData(int i_NumberOfAlbum)
        {
            if (m_UserSocialData == null)
            {
                throw new Exception("not Loged On");
            }

            if (m_AlbomDataManager == null)
            {
                m_AlbomDataManager = new AlbomDataManager(m_UserSocialData);
            }

            return m_AlbomDataManager.GetAlbomData(i_NumberOfAlbum);
        }

    }
}
