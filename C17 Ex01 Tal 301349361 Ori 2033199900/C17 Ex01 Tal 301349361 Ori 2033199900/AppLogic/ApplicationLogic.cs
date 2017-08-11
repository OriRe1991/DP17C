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

        public string LogInToSocialNetwork()
        {
            string retVal = string.Empty;
            retVal = LogInAction();
            return retVal;
        }

        private string LogInAction()
        {
            m_UserSocialData = SocialDataFactory.GetSocialNetwork();
            return m_UserSocialData.LogIn();
        }


        // TODO: remove this function
        public List<string> Data()
        {
            List<string> retVal = new List<string>();
            if (m_UserSocialData == null)
            {
                throw new Exception("not Loged On");
            }

            //var photos = m_LoggedInUser.PhotosTaggedIn;
            //foreach (var photo in photos)
            //{
            //    foreach (var tag in photo.Tags)
            //    {
            //        if (tag.User.Id != m_LoggedInUser.Id)
            //        {
            //            retVal.Add(tag.User.Name);
            //        }
            //    }
                
            //}

            return retVal;
        }
    }
}
