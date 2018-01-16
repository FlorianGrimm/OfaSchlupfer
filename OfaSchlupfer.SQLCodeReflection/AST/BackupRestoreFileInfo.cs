namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class BackupRestoreFileInfo : TSqlFragment {
        private BackupRestoreItemKind _itemKind;
        
        public List<ValueExpression> Items { get; } = new List<ValueExpression>();

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
            this.Items.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
