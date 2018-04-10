namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class FreezeableOwnedDictionary<TOwner, TKey, TValue>
        : IFreezeable, IDictionary<TKey, TValue> {
        private readonly TOwner _Owner;
        private readonly Action<TOwner, TValue> _ActionOnInsertSet;
        private readonly Dictionary<TKey, TValue> _Items;
        private int _IsFrozen;

        public FreezeableOwnedDictionary(TOwner owner, Action<TOwner, TValue> actionOnInsertSet) {
            this._Owner = owner;
            this._ActionOnInsertSet = actionOnInsertSet;
            this._Items = new Dictionary<TKey, TValue>();
        }

        public FreezeableOwnedDictionary(TOwner owner, Action<TOwner, TValue> actionOnInsertSet, IEqualityComparer<TKey> comparer) {
            this._Owner = owner;
            this._ActionOnInsertSet = actionOnInsertSet;
            this._Items = new Dictionary<TKey, TValue>(comparer);
        }

        public FreezeableOwnedDictionary(TOwner owner, Action<TOwner, TValue> actionOnInsertSet, IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) {
            this._Owner = owner;
            this._ActionOnInsertSet = actionOnInsertSet;
            this._Items = new Dictionary<TKey, TValue>(dictionary, comparer);
        }

        public TValue this[TKey key] {
            get {
                return this._Items[key];
            }

            set {
                this.ThrowIfFrozen();
                if ((object)value == null) { throw new ArgumentNullException("Items"); }
                this._Items[key] = value;
                this._ActionOnInsertSet?.Invoke(this._Owner, value);
            }
        }

        public ICollection<TKey> Keys => ((IDictionary<TKey, TValue>)this._Items).Keys;

        public ICollection<TValue> Values => ((IDictionary<TKey, TValue>)this._Items).Values;

        public int Count => this._Items.Count;

        public bool IsReadOnly => (this._IsFrozen == 1);

        public void Add(TKey key, TValue value) {
            this.ThrowIfFrozen();
            if ((object)value == null) { throw new ArgumentNullException("Items"); }
            this._Items.Add(key, value);
            this._ActionOnInsertSet?.Invoke(this._Owner, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item) {
            this.Add(item.Key, item.Value);
        }

        public void Clear() {
            this.ThrowIfFrozen();
            this._Items.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) {
            return ((IDictionary<TKey, TValue>)this._Items).Contains(item);
        }

        public bool ContainsKey(TKey key) {
            return this._Items.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
            ((IDictionary<TKey, TValue>)this._Items).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
            return ((IDictionary<TKey, TValue>)this._Items).GetEnumerator();
        }

        public bool Remove(TKey key) {
            this.ThrowIfFrozen();
            return this._Items.Remove(key);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) {
            this.ThrowIfFrozen();
            return ((IDictionary<TKey, TValue>)this._Items).Remove(item);
        }

        public bool TryGetValue(TKey key, out TValue value) {
            return this._Items.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IDictionary<TKey, TValue>)this._Items).GetEnumerator();
        }

        public bool Freeze() {
            if (System.Threading.Interlocked.CompareExchange(ref this._IsFrozen, 1, 0) == 0) {
                foreach (var item in this._Items.Values) {
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
