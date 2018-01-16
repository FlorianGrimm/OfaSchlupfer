namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ColumnEncryptionKeyStatement : TSqlStatement {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<ColumnEncryptionKeyValue> ColumnEncryptionKeyValues { get; } = new List<ColumnEncryptionKeyValue>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.ColumnEncryptionKeyValues.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
