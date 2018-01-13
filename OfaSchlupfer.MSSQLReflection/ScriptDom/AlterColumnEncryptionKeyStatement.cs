namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterColumnEncryptionKeyStatement : ColumnEncryptionKeyStatement {
        private ColumnEncryptionKeyAlterType _alterType;

        public ColumnEncryptionKeyAlterType AlterType {
            get {
                return this._alterType;
            }

            set {
                this._alterType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
