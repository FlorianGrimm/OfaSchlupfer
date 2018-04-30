namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public sealed class FreezableOwnedCollection<TOwner, TValue>
        : IFreezeable
        , IList<TValue>
        where TValue : class {
        private readonly TOwner _Owner;
        private readonly Action<TOwner, TValue> _ActionOnInsertSet;
        private readonly List<TValue> _Items;
        private int _IsFrozen;

        public FreezableOwnedCollection(TOwner owner, Action<TOwner, TValue> actionOnInsertSet) {
            this._Items = new List<TValue>();
            this._Owner = owner;
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
