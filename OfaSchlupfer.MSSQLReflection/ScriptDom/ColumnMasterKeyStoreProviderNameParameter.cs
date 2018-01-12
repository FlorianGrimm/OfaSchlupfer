using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnMasterKeyStoreProviderNameParameter : ColumnMasterKeyParameter {
        private StringLiteral _name;

        public StringLiteral Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
        }
    }
}
