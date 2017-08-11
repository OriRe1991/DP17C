using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    interface IDataSociable
    {
        string LogIn();
        string GetName();
        string GetProfilePictureUrl();
        List<string> GetPhotos();
        List<string> GetTaggedFriendsNameList();
        List<string> GetLastPosts();
    }
}
