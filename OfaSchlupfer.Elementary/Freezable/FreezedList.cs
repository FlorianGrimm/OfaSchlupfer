namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class FreezedList {
        public static FreezedList<T> Create<T>(IEnumerable<T> src, bool safeToUse = false) => new FreezedList<T>(src, safeToUse);

        public static FreezedList<T> AsFreezedList<T>(this IEnumerable<T> src, bool safeToUse = false) => new FreezedList<T>(src, safeToUse);
    }
    public sealed class FreezedList<T> : IList<T> {
        IList<T> _Items;
        public FreezedList(IEnumerable<T> items, bool safeToUse) {
            if (items == null) {
                this._Items = new T[0];
            } else {
                if (items is IList<T> itemAsList) {
                    if (safeToUse) {
                        this._Items = itemAsList;
                    } else {
                        var a = new T[itemAsList.Count];
                        itemAsList.CopyTo(a, 0);
                        this._Items = a;
                    }
                } else if (items is ICollection<T> itemAsCollection) {
                    var a = new T[itemAsCollection.Count];
                    itemAsCollection.CopyTo(a, 0);
                    this._Items = a;
                } else {
                    this._Items = new List<T>(items);
                }
            }
        }

        public T this[int index] { get { return this._Items[index]; } set { throw new NotSupportedException(); } }

        public int Count => this._Items.Count;

        public bool IsReadOnly => true;

        public void Add(T item) { throw new NotSupportedException(); }

        public void Clear() { throw new NotSupportedException(); }

        public bool Contains(T item) => this._Items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => this._Items.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => this._Items.GetEnumerator();

        public int IndexOf(T item) => this._Items.IndexOf(item);

        public void Insert(int index, T item) { throw new NotSupportedException(); }

        public bool Remove(T item) { throw new NotSupportedException(); }

        public void RemoveAt(int index) { throw new NotSupportedException(); }

        IEnumerator IEnumerable.GetEnumerator() => this._Items.GetEnumerator();
    }
}
