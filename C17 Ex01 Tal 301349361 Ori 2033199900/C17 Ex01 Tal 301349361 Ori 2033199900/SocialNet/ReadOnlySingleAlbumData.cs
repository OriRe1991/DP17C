namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    public class ReadOnlySingleAlbumData
    {
        private string m_AlbumName;

        public string AlbumName
        {
            get
            {
                return m_AlbumName;
            }
        }

        private string m_FirstPicUrl;

        public string FirstPicUrl
        {
            get
            {
                return m_FirstPicUrl;
            }
        }

        /// <summary>
        /// create readonly instance from SingleAlbumData
        /// </summary>
        /// <param name="i_SingleAlbumData"></param>
        public ReadOnlySingleAlbumData(SingleAlbumData i_SingleAlbumData)
        {
            m_AlbumName = i_SingleAlbumData.AlbomName;
            m_FirstPicUrl = i_SingleAlbumData.FirstPicUrl;
        }
    }
}
