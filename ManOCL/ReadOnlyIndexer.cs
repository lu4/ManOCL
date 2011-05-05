using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ManOCL
{
    public class ReadOnlyIndexer<T> : IEnumerable<T>, IList<T>
    {
        internal T[] data;

        private static Int32 Count(IEnumerable<T> data)
        {
            Int32 count = 0;

			IEnumerator<T> enumerator = data.GetEnumerator();

			while (enumerator.MoveNext()) count++;
			
            return count;
        }

        private static T[] GetData(IEnumerable<T> data)
        {
            return GetData(data, Count(data));
        }

        private static T[] GetData(IEnumerable<T> data, Int32 count)
        {
            Int32 index = 0;

            T[] result = new T[count];

            foreach (T value in data) result[index++] = value;

            return result;
        }

        public ReadOnlyIndexer(params T[] data)
        {
            this.data = (T[])data.Clone();
        }

        public ReadOnlyIndexer(IEnumerable<T> data)
        {
            this.data = GetData(data);
        }

        public ReadOnlyIndexer(ICollection<T> data)
        {
            this.data = GetData(data, data.Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in data)
            {
                yield return t;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T t in data)
            {
                yield return t;
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(data, item);
        }

        void IList<T>.Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(data, item) > -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        int ICollection<T>.Count
        {
            get { return data.Length; }
        }

        public bool IsReadOnly
        {
            get { return data.IsReadOnly; }
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
