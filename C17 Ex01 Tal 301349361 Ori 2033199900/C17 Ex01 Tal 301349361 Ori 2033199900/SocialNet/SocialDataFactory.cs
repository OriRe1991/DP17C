using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    static class SocialDataFactory
    {
        /// <summary>
        /// creates dynamic social network data object to enable future support in other social net. (facebook, google+, twitter, linkedIn, etc.)
        /// </summary>
        /// <returns>Instance of social network data</returns>
        public static IDataSociable GetSocialNetwork(int i_SocialNetworkId = 0)
        {
            IDataSociable retVal;

            retVal = new FacebookSocialData();

            return retVal;
        }
    }
}
