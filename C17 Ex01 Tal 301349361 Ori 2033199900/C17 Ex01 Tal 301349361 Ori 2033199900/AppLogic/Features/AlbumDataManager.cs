using C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.AppLogic.Features
{
    internal class AlbumDataManager
    {
        private IDataSociable m_SocialData = null;
        public AlbumDataManager(IDataSociable i_SocialData)
        {
            m_SocialData = i_SocialData;
        }

        public List<AlbumData> GetAlbumsData(int i_NumberOfAlbums)
        {
            List<AlbumData> retVal = null;

            retVal = m_SocialData.GetLastAlbums(i_NumberOfAlbums);

            return retVal;

        }
    }
}
