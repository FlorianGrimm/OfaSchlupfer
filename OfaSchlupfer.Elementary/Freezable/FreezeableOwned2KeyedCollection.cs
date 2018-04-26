namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public sealed class FreezeableOwned2KeyedCollection<TOwner, TKey1, TKey2, TValue>
        : IFreezeable
        , IList<TValue>
        where TKey1 : class, IEquatable<TKey1>
        where TKey2 : class, IEquatable<TKey2>
        where TValue : class {
        private readonly TOwner _Owner;
        private readonly Func<TValue, TKey1> _GetKey1;
        private readonly Func<TValue, TKey2> _GetKey2;
        private readonly IEqualityComparer<TKey1> _KeyComparer1;
        private readonly IEqualityComparer<TKey2> _KeyComparer2;
        private readonly Action<TOwner, TValue> _ActionOnInsertSet;
        private readonly List<TValue> _Items;
        private int _IsFrozen;
        private Dictionary<TKey1, TValue> _ItemsByKey1;
        private Dictionary<TKey2, TValue> _ItemsByKey2;

        public FreezeableOwned2KeyedCollection(
            TOwner owner,
            Func<TValue, TKey1> getKey1,
            IEqualityComparer<TKey1> keyComparer1,
            Func<TValue, TKey2> getKey2,
            IEqualityComparer<TKey2> keyComparer2,
            Action<TOwner, TValue> actionOnInsertSet
            ) {
            if (getKey1 is null) { throw new ArgumentNullException(nameof(getKey1)); }
            if (getKey2 is null) { throw new ArgumentNullException(nameof(getKey2)); }

            this._Items = new List<TValue>();
            this._Owner = owner;
            this._GetKey1 = getKey1;
            this._GetKey2 = getKey2;
            this._KeyComparer1 = keyComparer1;
            this._KeyComparer2 = keyComparer2;
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

        public List<TValue> FindByKey(TKey1 key) {
            if (this._IsFrozen == 0) {
                var result = new List<TValue>();
                if ((object)key != null) {
                    var items = this._Items.ToArray();
                    foreach (var item in items) {
                        var itemKey = this._GetKey1(item);
                        if (this._KeyComparer1.Equals(itemKey, key)) {
                            result.Add(item);
                        }
                    }
                }
                return result;
            } else {
                if ((object)this._ItemsByKey1 == null) {
                    BuildDictionaries();
                }
                {
                    var result = new List<TValue>();
                    if ((object)key != null) {
                        if (this._ItemsByKey1.TryGetValue(key, out var item)) {
                            result.Add(item);
                        }
                    }
                    return result;
                }
            }
        }

        public List<TValue> FindByKey2(TKey2 key) {
            if (this._IsFrozen == 0) {
                var result = new List<TValue>();
                if ((object)key != null) {
                    var items = this._Items.ToArray();
                    foreach (var item in items) {
                        var itemKey = this._GetKey2(item);
                        if (this._KeyComparer2.Equals(itemKey, key)) {
                            result.Add(item);
                        }
                    }
                }
                return result;
            } else {
                if ((object)this._ItemsByKey1 == null) {
                    BuildDictionaries();
                }
                {
                    var result = new List<TValue>();
                    if ((object)key != null) {
                        if (this._ItemsByKey2.TryGetValue(key, out var item)) {
                            result.Add(item);
                        }
                    }
                    return result;
                }
            }
        }

        private void BuildDictionaries() {
            var count = this._Items.Count;
            var dict1 = new Dictionary<TKey1, TValue>(count, this._KeyComparer1);
            var dict2 = new Dictionary<TKey2, TValue>(this._Items.Count, this._KeyComparer2);
            foreach (var item in this._Items) {
                var itemKey1 = this._GetKey1(item);
                var itemKey2 = this._GetKey2(item);
                if (!(itemKey1 is null)) {
                    dict1[itemKey1] = item;
                }
                if (!(itemKey2 is null)) {
                    dict2[itemKey2] = item;
                }
            }
            this._ItemsByKey1 = dict1;
            this._ItemsByKey2 = dict2;
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
