using PersistenceSystem.abstractions.mappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.abstractions
{
    public abstract class VirtualLazyList<T> : IList<T>
    {
        protected AbstractMapper _loader;

        protected IList<T> _data;

        public VirtualLazyList(AbstractMapper loader)
        {
            _loader = loader;
        }


        public abstract List<T> GetData();



        public T this[int index]
        {
            get
            {
                if (_data == null)
                    _data = GetData();

                return _data[index];
            }

            set
            {
                if (_data == null)
                    _data = GetData();

                _data[index] = value;
            }
        }

        public int Count
        {
            get
            {
                if (_data == null)
                    _data = GetData();

                return _data.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                if (_data == null)
                    _data = GetData();

                return _data.IsReadOnly;
            }
        }

        public void Add(T item)
        {
            if (_data == null)
                _data = GetData();

            _data.Add(item);
        }

        public void Clear()
        {
            if (_data == null)
                _data = GetData();

            _data.Clear();
        }

        public bool Contains(T item)
        {
            if (_data == null)
                _data = GetData();

            return _data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (_data == null)
                _data = GetData();

            _data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_data == null)
                _data = GetData();

            return _data.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            if (_data == null)
                _data = GetData();

            return _data.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (_data == null)
                _data = GetData();

            _data.Insert(index, item);
        }

        public bool Remove(T item)
        {
            if (_data == null)
                _data = GetData();

            return _data.Remove(item);
        }

        public void RemoveAt(int index)
        {
            if (_data == null)
                _data = GetData();

            _data.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (_data == null)
                _data = GetData();

            return _data.GetEnumerator();
        }
    }
}
