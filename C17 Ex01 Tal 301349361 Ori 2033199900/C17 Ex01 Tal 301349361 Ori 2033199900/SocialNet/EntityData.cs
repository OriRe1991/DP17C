﻿namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    public class EntityData
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string ThemePictureUrl { get; set; }

        public string AccessToken { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
