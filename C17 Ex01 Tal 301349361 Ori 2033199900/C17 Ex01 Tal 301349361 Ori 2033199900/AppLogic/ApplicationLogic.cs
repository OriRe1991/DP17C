using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic
{
    class ApplicationLogic : ILogicInterface
    {
        private IDataSociable m_UserSocialData;

        public UserData LogInToSocialNetwork()
        {
            UserData retVal = null;
            LogInAction();
            retVal = InitUserData();
            return retVal;
        }

        private void LogInAction()
        {
            m_UserSocialData = SocialDataFactory.GetSocialNetwork();
            m_UserSocialData.LogIn();
        }

        private UserData InitUserData()
        {
            UserData retVal = new UserData();

            retVal.FullName = m_UserSocialData.GetFullName();
            retVal.ProfilePictureUrl = m_UserSocialData.GetProfilePictureUrl();
            retVal.ThemePictureUrl = m_UserSocialData.GetThemePhotoUrl();

            return retVal;
        }


        // TODO: remove this function
        public List<string> Data()
        {
            List<string> retVal = new List<string>();
            if (m_UserSocialData == null)
            {
                throw new Exception("not Loged On");
            }

            return retVal;
        }
    }
}
