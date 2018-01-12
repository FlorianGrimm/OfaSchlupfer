using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterTableFileTableNamespaceStatement : AlterTableStatement {
        private bool _isEnable;

        public bool IsEnable {
            get {
                return this._isEnable;
            }

            set {
                this._isEnable = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
        }
    }
}
