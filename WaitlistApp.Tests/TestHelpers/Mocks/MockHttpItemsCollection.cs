using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitlistApp.Tests.TestHelpers.Mocks
{
    public class MockHttpItemsCollection : IDictionary
    {
        private Dictionary<object, object> _items = new Dictionary<object, object>();

        public object this[object key]
        {
            get
            {
                object value = null;
                _items.TryGetValue(key, out value);
                return value;
            }
            set
            {
                _items[key] = value;
            }
        }

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public ICollection Keys
        {
            get
            {
                return _items.Keys;
            }
        }

        public object SyncRoot
        {
            get
            {
                return null;
            }
        }

        public ICollection Values
        {
            get
            {
                return _items.Values;
            }
        }

        public void Add(object key, object value)
        {
            _items.Add(key, value);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(object key)
        {
            return _items.ContainsKey(key);
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public void Remove(object key)
        {
            _items.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
