using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BackupRestoreFileInfo : TSqlFragment {
        private List<ValueExpression> _items = new List<ValueExpression>();

        private BackupRestoreItemKind _itemKind;

        public List<ValueExpression> Items {
            get {
                return this._items;
            }
        }

        public BackupRestoreItemKind ItemKind {
            get {
                return this._itemKind;
            }

            set {
                this._itemKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Items.Count; i < count; i++) {
                this.Items[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
