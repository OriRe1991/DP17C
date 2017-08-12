﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    public class FacebookSocialData : IDataSociable
    {
        private static int s_ConnectionlimitationDefault = 25;
        private User m_LoggedInUser;

        private string m_AccessToken;

        public string GetFullName()
        {
            return m_LoggedInUser.Name;
        }

        public List<SocialPhotoData> GetPhotos(int i_NumberOfPhotos)
        {
            List<SocialPhotoData> retVal = new List<SocialPhotoData>();
            //// temporery incress the collection size
            FacebookService.s_CollectionLimit = i_NumberOfPhotos;

            var taggedPhotos = m_LoggedInUser.PhotosTaggedIn.ToList();

            //// return the collection size to the defauld one
            FacebookService.s_CollectionLimit = s_ConnectionlimitationDefault;

            foreach (var photo in taggedPhotos)
            {
                List<EntityData> friendsInPhotos = null;
                if (photo.Tags != null && photo.Tags.Count > 0)
                {
                    friendsInPhotos = new List<EntityData>();
                    foreach (var tag in photo.Tags)
                    {
                        friendsInPhotos.Add(new EntityData
                        {
                            UserId = tag.User.Id,
                            FullName = tag.User.Name,
                            ProfilePictureUrl = tag.User.PictureLargeURL
                        });
                    }

                    retVal.Add(new SocialPhotoData
                    {
                        FriendsInPhotos = friendsInPhotos,
                        PhotoUrl = photo.PictureNormalURL
                    });
                }
            }

            return retVal;
        }

        public string GetProfilePictureUrl()
        {
            return m_LoggedInUser.PictureLargeURL;
        }

        public void LogIn(string i_SocialToken = null)
        {
            s_ConnectionlimitationDefault = FacebookService.s_CollectionLimit;
            LoginResult result = null;
            if (i_SocialToken != null)
            {
                try
                {
                    result = FacebookService.Connect(i_SocialToken);
                }
                catch
                {
                    result = null;
                }
            }

            if (result == null || string.IsNullOrEmpty(result.AccessToken))
            {
                try
                {
                    result = FacebookService.Login(
                            "1955252128038346",
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
                            "publish_actions");
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Unable to connect to Facebook at the moment, more info: {0}{1}", Environment.NewLine, e.Message));
                }
            }

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
                m_AccessToken = result.AccessToken;
            }
            else
            {
                throw new Exception("Unable to connect to facebook");
            }
        }

        public string GetAccessToken()
        {
            return m_AccessToken;
        }

        public string GetThemePhotoUrl()
        {
            return m_LoggedInUser.Cover.SourceURL;
        }

        public List<AlbumData> GetLastAlbums(int i_Number)
        {
            List<AlbumData> retVal = new List<AlbumData>();
            var albumsOrdered = m_LoggedInUser.Albums.Where(ua => ua.Photos.Count > 0).OrderByDescending(ua => ua.CreatedTime).ToList();
            var firstAlbums = albumsOrdered.Take(i_Number).ToList();
            foreach (var albom in firstAlbums)
            {
                // TODO:
                var picThumb = albom.Photos.FirstOrDefault();
                string picUrl = string.Empty;
                if (picThumb != null)
                {
                    picUrl = picThumb.ThumbURL;
                }

                retVal.Add(new AlbumData
                {
                    AlbomName = albom.Name,
                    FirstPicUrl = picUrl
                });
            }

            return retVal;
        }

        public string CreateAlbum(string i_AlbumName, string i_AlbumDescription, List<string> i_PhotosUrl)
        {
            var newAlbum = m_LoggedInUser.CreateAlbum(i_AlbumName, i_AlbumDescription);
            string tempPicLocation = Environment.CurrentDirectory + @"\temp.jpg";
            foreach (var photo in i_PhotosUrl)
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(photo), tempPicLocation);
                }

                newAlbum.UploadPhoto(tempPicLocation);
            }

            return newAlbum.Id;
        }

        public bool CreatePostNewAlbumWithFriendsName(string i_PostText, string i_PostPictureUrl, string[] i_TaggedUserIDs)
        {
            StringBuilder tagedUserIdBuilder = null;
            if (i_TaggedUserIDs != null && i_TaggedUserIDs.Length > 0)
            {
                tagedUserIdBuilder = new StringBuilder();
                foreach (string userId in i_TaggedUserIDs)
                {
                    if (tagedUserIdBuilder.Length > 0)
                    {
                        tagedUserIdBuilder.Append(",");
                    }

                    tagedUserIdBuilder.Append(userId);
                }
            }

            string taggedFriends = (tagedUserIdBuilder != null) ? tagedUserIdBuilder.ToString() : null;
            var status = m_LoggedInUser.PostStatus(i_StatusText: i_PostText, i_PictureURL: i_PostPictureUrl, i_TaggedFriendIDs: taggedFriends);

            return status.CreatedTime.Value.Month > 0;
        }

        public string GetFirstName()
        {
            return m_LoggedInUser.FirstName;
        }

        public string GetMyUserId()
        {
            return m_LoggedInUser.Id;
        }

        public bool IsLogedOn()
        {
            bool retVal = m_LoggedInUser != null;
            retVal = !string.IsNullOrEmpty(m_AccessToken) && retVal;
            return retVal;
        }

        public void LogOut(Action i_PostLogOutAction)
        {
            FacebookService.Logout(i_PostLogOutAction);
        }

        /// <summary>
        /// simple status sender wrapper without any taged or photos.
        /// </summary>
        /// <param name="i_PostData"></param>
        /// <returns>true if published post successfully</returns>
        public bool CreateNewPostStatus(string i_PostData)
        {
            return CreatePostNewAlbumWithFriendsName(i_PostData, null, null);
        }

        public List<SocialPost> GetLastPost(int i_NumberOfPosts)
        {
            List<SocialPost> retVal = null;
            if (m_LoggedInUser.WallPosts == null)
            {
                throw new Exception("Unable to get Posts from user");
            }

            if (m_LoggedInUser.WallPosts.Count > 0)
            {
                retVal = new List<SocialPost>();
                var wallPosts = m_LoggedInUser.WallPosts.OrderByDescending(wp => wp.CreatedTime).ToList();
                if (wallPosts.Count > i_NumberOfPosts)
                {
                    wallPosts = wallPosts.Take(i_NumberOfPosts).ToList();
                }

                foreach (var post in wallPosts)
                {
                    retVal.Add(new SocialPost
                    {
                        Message = post.Message,
                        NameFrom = post.Name,
                        PictureUrl = post.PictureURL,
                        NumberOfReaction = post.LikedBy.Count
                    });
                }
            }

            return retVal;
        }

        public List<string> GetTaggedFriendsNameList()
        {
            throw new NotImplementedException();
        }

        public List<string> GetLastPosts()
        {
            throw new NotImplementedException();
        }
    }
}
