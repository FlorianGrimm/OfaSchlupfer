namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public sealed class FreezeableCollection<T>
        : IFreezeable, IList<T> {
        private readonly List<T> _Items;
        private int _IsFrozen;
        public FreezeableCollection() {
            this._Items = new List<T>();
        }

        public FreezeableCollection(IEnumerable<T> items) : this() {
            if ((object)items != null) {
                this._Items.AddRange(items);
            }
        }

        public T this[int index] {
            get {
                return this._Items[index];
            }

            set {
                this.ThrowIfFrozen();
                this._Items[index] = value;
            }
        }

        public int Count => this._Items.Count;

        public bool IsReadOnly => (this._IsFrozen == 1);

        public void Add(T item) {
            this.ThrowIfFrozen();
            this._Items.Add(item);
        }

        public void AddRange(IEnumerable<T> items) {
            this.ThrowIfFrozen();
            this._Items.AddRange(items);
        }

        public void Clear() {
            this.ThrowIfFrozen();
            this._Items.Clear();
        }

        public bool Contains(T item) {
            return this._Items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            this._Items.CopyTo(array, arrayIndex);
        }


        public IEnumerator<T> GetEnumerator() {
            return this._Items.GetEnumerator();
        }

        public int IndexOf(T item) {
            this.ThrowIfFrozen();
            return this._Items.IndexOf(item);
        }

        public void Insert(int index, T item) {
            this.ThrowIfFrozen();
            this._Items.Insert(index, item);
        }


        public bool Remove(T item) {
            this.ThrowIfFrozen();
            return this._Items.Remove(item);
        }

        public void RemoveAt(int index) {
            this.ThrowIfFrozen();
            this._Items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this._Items.GetEnumerator();
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
