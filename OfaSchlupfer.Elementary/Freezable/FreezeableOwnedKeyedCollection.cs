namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    public interface IFreezeableOwnedKeyedCollection<TKey, TValue>
        : IFreezeable
        , IList<TValue>
        where TKey : IEquatable<TKey>
        where TValue : class {
        void AddRange(IEnumerable<TValue> items);
        List<TValue> FindByKey(TKey key);

        TValue GetValueOrDefault(TKey key, TValue defaultValue = default(TValue));
    }

    public sealed class FreezeableOwnedKeyedCollection<TOwner, TKey, TValue>
        : IFreezeable
        , IList<TValue>
        , IFreezeableOwnedKeyedCollection<TKey, TValue>
        where TKey : IEquatable<TKey>
        where TValue : class {
        private readonly TOwner _Owner;
        private readonly Func<TValue, TKey> _GetKey;
        private readonly IEqualityComparer<TKey> _KeyComparer;
        private readonly Action<TOwner, TValue> _ActionOnInsertSet;
        private readonly List<TValue> _Items;
        private int _IsFrozen;
        private Dictionary<TKey, TValue> _ItemsByKey;

        public FreezeableOwnedKeyedCollection(
            TOwner owner,
            Func<TValue, TKey> getKey,
            IEqualityComparer<TKey> keyComparer,
            Action<TOwner, TValue> actionOnInsertSet
            ) {
            if ((object)getKey == null) { throw new ArgumentNullException(nameof(getKey)); }

            this._Items = new List<TValue>();
            this._Owner = owner;
            this._GetKey = getKey;
            this._KeyComparer = keyComparer;
            this._ActionOnInsertSet = actionOnInsertSet;
        }

        public TValue this[int index] {
            get {
                return this._Items[index];
            }
            set {
                this.ThrowIfFrozen();
                if (value is null) { throw new ArgumentNullException("Items"); }
                this._Items[index] = value;
                this._ActionOnInsertSet?.Invoke(this._Owner, value);
            }
        }

        public void AddRange(IEnumerable<TValue> items) {
            if (!(items is null)) {
                foreach (var item in items) {
                    if (!(item is null)) {
                        this.Add(item);
                    }
                }
            }
        }

        public int Count => this._Items.Count;

        public bool IsReadOnly => (this._IsFrozen == 1);

        public void Add(TValue item) {
            this.ThrowIfFrozen();
            if (item is null) { throw new ArgumentNullException(nameof(item)); }
            this._Items.Add(item);
            this._ActionOnInsertSet?.Invoke(this._Owner, item);
        }

        public void Clear() {
            this.ThrowIfFrozen();
            this._Items.Clear();
        }

        public bool Contains(TValue item) {
            return this._Items.Contains(item);
        }

        public void CopyTo(TValue[] array, int arrayIndex) {
            this._Items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TValue> GetEnumerator() => this._Items.GetEnumerator();

        public int IndexOf(TValue item) {
            return this._Items.IndexOf(item);
        }

        public void Insert(int index, TValue item) {
            this.ThrowIfFrozen();
            if (item is null) { throw new ArgumentNullException(nameof(item)); }
            this._Items.Insert(index, item);
            this._ActionOnInsertSet?.Invoke(this._Owner, item);
        }

        public bool Remove(TValue item) {
            this.ThrowIfFrozen();
            return this._Items.Remove(item);
        }

        public void RemoveAt(int index) {
            this.ThrowIfFrozen();
            this._Items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() => this._Items.GetEnumerator();

        public List<TValue> FindByKey(TKey key) {
            if (this._IsFrozen == 0) {
                var result = new List<TValue>();
                if ((object)key != null) {
                    var items = this._Items.ToArray();
                    foreach (var item in items) {
                        var itemKey = this._GetKey(item);
                        if (itemKey.Equals(key)) {
                            result.Add(item);
                        }
                    }
                }
                return result;
            } else {
                if ((object)this._ItemsByKey == null) {
                    var dict = new Dictionary<TKey, TValue>(this._Items.Count, this._KeyComparer);
                    foreach (var item in this._Items) {
                        var itemKey = this._GetKey(item);
                        dict[itemKey] = item;
                    }
                    this._ItemsByKey = dict;
                }
                {
                    var result = new List<TValue>();
                    if ((object)key != null) {
                        if (this._ItemsByKey.TryGetValue(key, out var item)) {
                            result.Add(item);
                        }
                    }
                    return result;
                }
            }
        }

        public TValue GetValueOrDefault(TKey key, TValue defaultValue = default(TValue)) {
            if (this._IsFrozen == 0) {
                if ((object)key != null) {
                    var items = this._Items.ToArray();
                    foreach (var item in items) {
                        var itemKey = this._GetKey(item);
                        if (itemKey.Equals(key)) {
                            return item;
                        }
                    }
                }
                return defaultValue;
            } else {
                if ((object)this._ItemsByKey == null) {
                    var dict = new Dictionary<TKey, TValue>(this._Items.Count, this._KeyComparer);
                    foreach (var item in this._Items) {
                        var itemKey = this._GetKey(item);
                        dict[itemKey] = item;
                    }
                    this._ItemsByKey = dict;
                }
                {
                    if ((object)key != null) {
                        if (this._ItemsByKey.TryGetValue(key, out var item)) {
                            return item;
                        }
                    }
                    return defaultValue;
                }
            }
        }

        public bool Freeze() {
            if (System.Threading.Interlocked.CompareExchange(ref this._IsFrozen, 1, 0) == 0) {
                foreach (var item in this._Items) {
                    if (item is IFreezeable freezeable) {
                        freezeable.Freeze();
                    }
                }
                return true;
            } else {
                return false;
            }
        }

        public bool IsFrozen() => (this._IsFrozen == 1);
    }
}
