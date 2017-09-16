﻿using System;
using System.Collections.Generic;
using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic
{
    public interface ILogicInterface
    {
        bool RememberMe { get; set; }

        void LogInToSocialNetwork(string i_SocialToken = null);

        void LogOutUser(Action i_PostLogOutAction);

        bool IsConnected();

        EntityData GetEntityData();

        AlbumsData GetFirstAlbumsData(int i_NumberOfAlbums);

        Dictionary<string, EntityData> GetTaggedFriends();

        void CreateAlbumWithFriend(params string[] i_UserIds);

        bool CreateNewPost(string i_PostData);

        List<SocialPost> GetLastPostFromWall(int i_NumberOfPosts);

        EntityData GetMyBestFriend();

        List<SocialLikedPage> GetLikedPages();

        void SetFriendListSorting(Action i_SortingLogic);
    }
}
