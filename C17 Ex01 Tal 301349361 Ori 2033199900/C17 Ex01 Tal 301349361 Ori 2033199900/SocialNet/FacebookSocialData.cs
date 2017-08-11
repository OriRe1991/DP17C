using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    public class FacebookSocialData : IDataSociable
    {
        private User m_LoggedInUser;

        public List<string> GetLastPosts()
        {
            throw new NotImplementedException();
        }

        public string GetFullName()
        {
            return m_LoggedInUser.Name;
        }

        public List<string> GetPhotos()
        {
            throw new NotImplementedException();
        }

        public string GetProfilePictureUrl()
        {
            return m_LoggedInUser.PictureLargeURL;
        }

        public List<string> GetTaggedFriendsNameList()
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
                    if (tag.User.Id != m_LoggedInUser.Id)
                    {
                        retVal.Add(tag.User.Name);
                    }
                }

            }

            return retVal;
        }

        public void LogIn()
        {
            LoginResult result = FacebookService.Login("1955252128038346",
                    // TODO: remove unused credential
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
                    "user_games_activity",
                    "user_hometown",
                    "user_likes",
                    "user_location",
                    "user_managed_groups",
                    "user_photos",
                    "user_posts",
                    "user_relationships",
                    "user_relationship_details",
                    "user_religion_politics",
                    "user_tagged_places",
                    "user_videos",
                    "user_website",
                    "user_work_history",
                    "read_custom_friendlists",
                    "read_page_mailboxes",
                    "manage_pages",
                    "publish_pages",
                    "publish_actions"
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
        }

        public string GetThemePhotoUrl()
        {
            return m_LoggedInUser.Cover.SourceURL;
        }
    }

}
