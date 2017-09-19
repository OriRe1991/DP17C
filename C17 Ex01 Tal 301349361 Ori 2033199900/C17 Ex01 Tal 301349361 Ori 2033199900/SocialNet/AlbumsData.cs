using System;
using System.Collections;
using System.Collections.Generic;

namespace C17_Ex01_Tal_301349361_Ori_2033199900.SocialNet
{
    public class AlbumsData : IEnumerable
    {
        private List<SingleAlbumData> m_AlbumDataList;

        public void AddNewAlbum(SingleAlbumData i_AlbumToAdd)
        {
            if (m_AlbumDataList == null)
            {
                m_AlbumDataList = new List<SingleAlbumData>();
            }

            m_AlbumDataList.Add(i_AlbumToAdd);
        }

        public int GetNumberOfElement()
        {
            int retVal = 0;

            if (m_AlbumDataList != null)
            {
                retVal = m_AlbumDataList.Count;
            }

            return retVal;
        }

        public IEnumerator GetEnumerator()
        {
            return new AlbumDataIterator(this);
        }

        public class AlbumDataIterator : IEnumerator
        {
            private AlbumsData m_Collection;

            private int? m_CurrentIndex = null;

            public AlbumDataIterator(AlbumsData i_Collection)
            {
                m_Collection = i_Collection;
            }

            public object Current
            {
                get
                {
                    /// the values return will always be 0 until a MoveNext() is issued, no need to return an Exception.
                    return new ReadOnlySingleAlbumData(m_Collection.m_AlbumDataList[m_CurrentIndex.GetValueOrDefault(0)]);
                }
            }

            public bool MoveNext()
            {
                /// if index is null then this is the firat time moving the iterator, init with 0 and return 0 for the first time.
                if (m_CurrentIndex == null)
                {
                    m_CurrentIndex = 0;
                }
                else
                {
                    m_CurrentIndex++;
                }

                return m_Collection.m_AlbumDataList.Count > m_CurrentIndex;
            }

            public void Reset()
            {
                m_CurrentIndex = 0;
            }
        }
    }
}
