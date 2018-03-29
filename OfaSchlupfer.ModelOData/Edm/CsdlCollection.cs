namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    public class CsdlCollection<T> : Collection<T> {
        private readonly Action<T> _ActionOnInsertSet;
        public CsdlCollection(Action<T> actionOnInsertSet) {
            this._ActionOnInsertSet = actionOnInsertSet;
        }

        protected override void InsertItem(int index, T item) {
            if ((object)_ActionOnInsertSet != null) {
                _ActionOnInsertSet(item);
            }
            base.InsertItem(index, item);

        }

        protected override void SetItem(int index, T item) {
            if ((object)_ActionOnInsertSet != null) {
                _ActionOnInsertSet(item);
            }
            base.SetItem(index, item);
        }

        public void Broadcast() {
            if ((object)_ActionOnInsertSet != null) {
                var items = new List<T>(this);
                foreach (var item in items) {
                    _ActionOnInsertSet(item);
                }
            }
        }
    }
}
