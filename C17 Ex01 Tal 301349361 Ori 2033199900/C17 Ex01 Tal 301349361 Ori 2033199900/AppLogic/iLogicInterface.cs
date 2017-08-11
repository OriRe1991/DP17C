using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;
using System.Collections.Generic;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic
{
    public interface ILogicInterface
    {
        void LogInToSocialNetwork();
        UserData GetUserData();
        List<AlbumData> GetFirstAlbumsData(int i_NumberOfAlbums);
        Dictionary<string, UserData> GetTaggedFriends();
        void CreateAlbumWithFriend(params string[] i_UserIds);
    }
}
