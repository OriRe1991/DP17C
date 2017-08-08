using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic
{
    class ApplicationLogic : ILogicInterface
    {
        private User m_LoggedInUser;

        public string LogInToFacebook()
        {
            string retVal = string.Empty;
            retVal = LogInAction();
            return retVal;
        }

        public string LogInAction()
        {
            LoginResult result = FacebookService.Login("1955252128038346",
                // requestes authoritys
                        //////////////////////////////////////////////////////////////////
                         "public_profile",
                         "user_education_history",
                         "user_birthday",
                         "user_actions.video",
                         "user_actions.news",
                         "user_actions.music",
                         "user_actions.fitness",
                         "user_actions.books",
                         "user_about_me",
                         "user_friends",
                         "publish_actions",
                         "user_events",
                         "user_games_activity"
                       //////////////////////////////////////////////////////////////////////
                         );

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
            }
            else
            {
                throw new Exception("Unable to connect to facebook");
            }

            return m_LoggedInUser.FirstName + " " + m_LoggedInUser.LastName;
        }

        public List<string> Data()
        {
            List<string> retVal = new List<string>();
            if (m_LoggedInUser == null)
            {
                throw new Exception("not Loged On");
            }

            var photos = m_LoggedInUser.PhotosTaggedIn;
            foreach (var photo in photos)
            {
                foreach (var tag in photo.Tags)
                {
                    retVal.Add(tag.User.FirstName + " " + tag.User.LastName);
                }
                
            }

            return retVal;
        }
    }
}
