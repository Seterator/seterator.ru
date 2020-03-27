#nullable enable
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
namespace Seterator.Services
{
    internal class MemoryCache : IMemoryCache
    {
        static MemoryCache? instance;
        public static MemoryCache Instance {
            get
            {
                if (instance == null) instance = new MemoryCache();
                return instance;
            }
        }
        class CacheEntry : ICacheEntry
        {
            public delegate object ValueGetter(object key);
            public delegate void ValueSetter(object key, object value);
            object key;
            ValueGetter getValue;
            ValueSetter setValue;
            public CacheEntry(object key, ValueGetter getter, ValueSetter setter)
            {
                this.key = key;
                getValue = getter;
                setValue = setter;
            }

            public object Value
            {
                get => getValue(key);
                set => setValue(key, value);
            }
            public object Key => key;

            #region bullshit implementation
            public DateTimeOffset? AbsoluteExpiration { get => DateTime.MaxValue; set { } }
            public TimeSpan? AbsoluteExpirationRelativeToNow { get => TimeSpan.MaxValue; set { } }

            public IList<IChangeToken> ExpirationTokens => new List<IChangeToken>();

            public IList<PostEvictionCallbackRegistration> PostEvictionCallbacks => new List<PostEvictionCallbackRegistration>();

            public CacheItemPriority Priority
            {
                get => CacheItemPriority.Normal;
                set { }
            }
            public long? Size { get => 0; set { } }
            public TimeSpan? SlidingExpiration { get => TimeSpan.MaxValue; set { } }
            void IDisposable.Dispose() { }
            #endregion
        }
        Dictionary<int, object> values = new Dictionary<int, object>();
        public MemoryCache() { }
        public ICacheEntry CreateEntry(object key)
        {
            return new CacheEntry(key.GetHashCode(), GetValue, UpdateOrSetValue);
        }
        public void Remove(object key)
        {
            values.Remove(key.GetHashCode());
        }

        protected void UpdateOrSetValue(object key, object value)
        {
            if (values.ContainsKey(key.GetHashCode()))
            {
                values[key.GetHashCode()] = value;
            }
            else
            {
                values.Add(key.GetHashCode(), value);
            }
        }
        protected object GetValue(object key)
        {
            return values[key.GetHashCode()];
        }
        public bool TryGetValue(object key, out object? value)
        {
            if (values.ContainsKey(key.GetHashCode()))
            {
                value = values[key.GetHashCode()];
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
        public void Dispose() { }
    }
}
