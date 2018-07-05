using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftApp.Interfaces;

namespace GiftApp.Classes
{
    class Gift: ICollection<IPartOfGift>
    {
        ICollection<IPartOfGift> _collection;
        string _nameOfGift;
             
        public int Count => _collection.Count();

        public bool IsReadOnly => _collection.IsReadOnly;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public Gift(ICollection<IPartOfGift> collection, string nameOfGift)
        {
            _nameOfGift = nameOfGift;
            _collection = collection;
                                
        }


        public void Add(IPartOfGift item)
        {
            _collection.Add(item);
        }

        public void Clear()
        {
            _collection.Clear();
        }
        
        public bool Contains(IPartOfGift item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(IPartOfGift[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

       
        public string GetNameOfGift()
        {
            return _nameOfGift;
        }
            

        public bool Remove(IPartOfGift item)
        {
            return _collection.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public int GetGiftWeight()
        {
            int _giftWeight = 0;
            foreach (IPartOfGift item in _collection)
            {
                _giftWeight = _giftWeight + item.GetWeight();
            }
            return _giftWeight;
        }

        public IEnumerable<IPartOfGift> SortByWeight()
        { 

            var _sortedlist = from a in _collection
                              orderby a.GetWeight()
                              select a;

            return _sortedlist;
                   }

        public IEnumerable<IPartOfGift> FindBySugarCount(int minCount, int maxCount)
        {
            var _resultList = from a in _collection
                              where (a.GetSugarCount() > minCount && a.GetSugarCount() < maxCount)
                              select a;

            return _resultList;

            }


           

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IPartOfGift> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
    }
    }

