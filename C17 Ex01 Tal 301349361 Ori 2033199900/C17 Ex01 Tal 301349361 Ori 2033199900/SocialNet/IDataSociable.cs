using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    public interface IDataSociable
    {
        void LogIn();
        string GetFullName();
        string GetFirstName();
        string GetUserId();
        string GetProfilePictureUrl();
        string GetThemePhotoUrl();
        List<AlbumData> GetLastAlbums(int i_Number);
        List<SocialPhotoData> GetPhotos();
        List<string> GetTaggedFriendsNameList();
        List<string> GetLastPosts();
        string CreateAlbum(string i_AlbumName, string i_AlbumDescription);
        void CreatePostNewAlbumWithFriendsName(string i_PostText, string i_PostPictureUrl, string[] i_TaggedUserIDs);
    }
}
