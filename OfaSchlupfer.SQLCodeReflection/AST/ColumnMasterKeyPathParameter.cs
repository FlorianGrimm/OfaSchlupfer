namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ColumnMasterKeyPathParameter : ColumnMasterKeyParameter {
        private StringLiteral _path;

        public StringLiteral Path {
            get {
                return this._path;
            }

            set {
                this.UpdateTokenInfo(value);
                this._path = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Path?.Accept(visitor);
        }
    }
}
