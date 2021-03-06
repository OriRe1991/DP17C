﻿using System;
using System.Collections.Generic;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    public class SocialPost
    {
        public string GeneratedFriendUserId { get; set; }

        public string Message { get; set; }

        public string PictureUrl { get; set; }

        public EntityData PostWritter { get; set; }

        public List<EntityData> Comments { get; set; }

        public List<EntityData> EntityReactedToPost { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
