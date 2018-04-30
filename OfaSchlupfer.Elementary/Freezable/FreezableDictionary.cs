namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public sealed class FreezableDictionary<TKey, TValue>
        : IFreezeable, IDictionary<TKey, TValue> {
        private readonly Dictionary<TKey, TValue> _Items;
        private int _IsFrozen;

        public FreezableDictionary() {
            this._Items = new Dictionary<TKey, TValue>();
        }

        public FreezableDictionary(IEqualityComparer<TKey> comparer) {
            this._Items = new Dictionary<TKey, TValue>(comparer);
        }

        public FreezableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) {
            this._Items = new Dictionary<TKey, TValue>(dictionary, comparer);
        }

        public TValue this[TKey key] {
            get {
                return this._Items[key];
            }

            set {
                this.ThrowIfFrozen();
                this._Items[key] = value;
            }
        }

        public ICollection<TKey> Keys => ((IDictionary<TKey, TValue>)this._Items).Keys;

        public ICollection<TValue> Values => ((IDictionary<TKey, TValue>)this._Items).Values;

        public int Count => this._Items.Count;

        public bool IsReadOnly => (this._IsFrozen == 1);

        public void Add(TKey key, TValue value) {
            this.ThrowIfFrozen();
            this._Items.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item) {
            this.ThrowIfFrozen();
            ((IDictionary<TKey, TValue>)this._Items).Add(item);
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
