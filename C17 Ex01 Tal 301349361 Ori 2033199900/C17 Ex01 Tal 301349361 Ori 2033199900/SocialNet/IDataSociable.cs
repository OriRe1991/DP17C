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
        string GetProfilePictureUrl();
        string GetThemePhotoUrl();
        List<AlbumData> GetLastAlboms(int i_Number);
        List<string> GetPhotos();
        List<string> GetTaggedFriendsNameList();
        List<string> GetLastPosts();
    }
}
