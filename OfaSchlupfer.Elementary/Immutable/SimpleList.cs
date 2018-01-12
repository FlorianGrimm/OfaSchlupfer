namespace OfaSchlupfer.Elementary.Immutable {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SimpleList<T> {
        public T Value;
        public SimpleList<T> Next;

        public SimpleList(SimpleList<T> next, T value) {
            this.Next = next;
            this.Value = value;
        }

        public static void Add(ref SimpleList<IFreezeReceiver> field, IFreezeReceiver freezeReceiver) {
            field = new SimpleList<IFreezeReceiver>(field, freezeReceiver);
        }
    }
}
