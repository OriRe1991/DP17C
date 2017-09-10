namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    public static class SocialDataFactory
    {
        public enum SocialNetwork
        {
            Facebook = 0,
            twitter = 1
        }

        /// <summary>
        /// creates dynamic social network data object to enable future support in other social net. (facebook, google+, twitter, linkedIn, etc.)
        /// </summary>
        /// <returns>Instance of social network data</returns>
        public static IDataSociable GetSocialNetwork(SocialNetwork i_SocialNetworkId = SocialNetwork.Facebook)
        {
            IDataSociable retVal = null;

            switch (i_SocialNetworkId)
            {
                case SocialNetwork.Facebook:
                    retVal = new FacebookSocialData();
                    break;
                case SocialNetwork.twitter:
                    throw new System.Exception("No twitter implementation avilable");
                    ///break;
                default:
                    break;
            }
            
            return retVal;
        }
    }
}
