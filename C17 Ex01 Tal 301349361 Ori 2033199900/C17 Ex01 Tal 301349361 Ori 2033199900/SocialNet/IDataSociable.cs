using System;
using System.Collections.Generic;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    /// <summary>
    /// social network interface in to disconnect the dependencies to one network (i.e. Facebook)
    /// </summary>
    public interface IDataSociable
    {
        void LogIn(string i_SocialToken = null);

        void LogOut(Action i_PostLogOutAction);

        bool IsLogedOn();

        string GetFullName();

        string GetFirstName();

        string GetMyUserId();

        string GetAccessToken();

        string GetProfilePictureUrl();

        string GetThemePhotoUrl();

        AlbumsData GetLastAlbums(int i_Number);

        List<SocialPhotoData> GetPhotos(int i_NumberOfPhotos);

        string CreateAlbum(string i_AlbumName, string i_AlbumDescription, List<string> i_PhotosUrl);

        bool CreatePostNewAlbumWithFriendsName(string i_PostText, string i_PostPictureUrl, string[] i_TaggedUserIDs);

        bool CreateNewPostStatus(string i_PostData);

        List<SocialPost> GetLastPost(int i_NumberOfPosts);

        List<SocialLikedPage> GetLikedPages();
    }
}
