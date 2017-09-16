using System;
using System.IO;
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
        private static int s_ConnectionlimitationDefault = 50;

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
                            "pages_show_list",
                            "publish_actions");
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Unable to connect to Facebook at the moment, more info: {0}{1}", Environment.NewLine, e.Message));
                }
            }

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                try
                {
                    m_LoggedInUser = result.LoggedInUser;
                    m_AccessToken = result.AccessToken;
                }
                catch
                {
                    throw new Exception("Unable to get the User basic data");
                }
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
            if (m_LoggedInUser == null || m_LoggedInUser.Cover == null)
            {
                throw new Exception("Unable to get user cover photo");
            }

            return m_LoggedInUser.Cover.SourceURL;
        }

        public AlbumsData GetLastAlbums(int i_Number)
        {
            List<Album> firstAlbums = null;
            AlbumsData retVal = new AlbumsData();
            try
            {
                var albumsOrdered = m_LoggedInUser.Albums.Where(ua => ua.Photos.Count > 0).OrderByDescending(ua => ua.CreatedTime).ToList();
                firstAlbums = albumsOrdered.Take(i_Number).ToList();
            }
            catch
            {
                throw new Exception("Oops, looks like we cannot retrive you'r album data");
            }

            if (firstAlbums != null && firstAlbums.Count > 0)
            {
                foreach (var albom in firstAlbums)
                {
                    // TODO:
                    var picThumb = albom.Photos.FirstOrDefault();
                    string picUrl = string.Empty;
                    if (picThumb != null)
                    {
                        picUrl = picThumb.ThumbURL;
                    }

                    retVal.AddNewAlbum(new SingleAlbumData
                    {
                        AlbomName = albom.Name,
                        FirstPicUrl = picUrl
                    });
                }
            }

            return retVal;
        }

        public string CreateAlbum(string i_AlbumName, string i_AlbumDescription, List<string> i_PhotosUrl)
        {
            string tempPicLocation = Environment.CurrentDirectory + @"\temp.jpg";
            Album newAlbum = null;
            if (i_PhotosUrl == null && i_PhotosUrl.Count <= 0)
            {
                throw new Exception("Try to create album with frind without ant photos");
            }

            try
            {
                newAlbum = m_LoggedInUser.CreateAlbum(i_AlbumName, i_AlbumDescription);
            }
            catch
            {
                throw new Exception("Unable to create an album at this time ,can be no premitions");
            }

            foreach (var photo in i_PhotosUrl)
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(photo), tempPicLocation);
                }

                string photoTitle = string.Format("Look at {0}, Such Fun!", i_AlbumDescription);
                try
                {
                    newAlbum.UploadPhoto(tempPicLocation, photoTitle);
                }
                catch
                {
                }
            }

            File.Delete(tempPicLocation);
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
            try
            {
                var status = m_LoggedInUser.PostStatus(i_StatusText: i_PostText, i_PictureURL: i_PostPictureUrl, i_TaggedFriendIDs: taggedFriends);
                return status.CreatedTime.Value.Month > 0;
            }
            catch
            {
                throw new Exception("Oops... Unable to Post at this time");
            }
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
            m_LoggedInUser.ReFetch();
            if (m_LoggedInUser.WallPosts == null)
            {
                throw new Exception("Unable to get Posts from user");
            }

            if (m_LoggedInUser.WallPosts.Count > 0)
            {
                retVal = new List<SocialPost>();
                var wallPosts = m_LoggedInUser.WallPosts.OrderByDescending(wp => wp.CreatedTime).ToList();
                if (i_NumberOfPosts > 0 && wallPosts.Count > i_NumberOfPosts)
                {
                    wallPosts = wallPosts.Take(i_NumberOfPosts).ToList();
                }

                foreach (var post in wallPosts)
                {
                    List<EntityData> reactedEntitys = new List<EntityData>();
                    List<EntityData> commentsEntitys = new List<EntityData>();
                    foreach (var reacton in post.LikedBy)
                    {
                        reactedEntitys.Add(new EntityData
                        {
                            FullName = reacton.Name,
                            UserId = reacton.Id,
                            ProfilePictureUrl = reacton.PictureLargeURL
                        });
                    }

                    foreach (var comment in post.Comments)
                    {
                        commentsEntitys.Add(new EntityData
                        {
                            FullName = comment.From.Name,
                            UserId = comment.From.Id,
                            ProfilePictureUrl = comment.From.PictureLargeURL
                        });
                    }

                    EntityData postCreatodData = new EntityData()
                    {
                        FullName = post.From.Name,
                        UserId = post.From.Id,
                        ProfilePictureUrl = post.From.PictureLargeURL
                    };

                    //// wrapping the object with poco data
                    retVal.Add(new SocialPost
                    {
                        GeneratedFriendUserId = post.From.Id,
                        Message = post.Message,
                        PostWritter = postCreatodData,
                        PictureUrl = post.PictureURL,
                        CreatedTime = post.CreatedTime.GetValueOrDefault(DateTime.MinValue),
                        EntityReactedToPost = reactedEntitys,
                        Comments = commentsEntitys
                    });
                }
            }

            return retVal;
        }

        public List<SocialLikedPage> GetLikedPages()
        {
            List<SocialLikedPage> retVal = null;
            var pagesLiked = m_LoggedInUser.LikedPages;

            if (pagesLiked != null && pagesLiked.Count > 0)
            {
                retVal = new List<SocialLikedPage>();
                foreach (var page in pagesLiked)
                {
                    retVal.Add(new SocialLikedPage
                    {
                        PageId = page.Id,
                        Name = page.Name,
                        PictureUrl = page.PictureNormalURL,
                        Description = page.Description
                    });
                }
            }

            return retVal;
        }
                
    }
}
