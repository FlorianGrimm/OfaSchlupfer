namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class InsertStatement : DataModificationStatement {
        private InsertSpecification _insertSpecification;

        public InsertSpecification InsertSpecification {
            get {
                return this._insertSpecification;
            }

            set {
                this.UpdateTokenInfo(value);
                this._insertSpecification = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.InsertSpecification?.Accept(visitor);
        }
    }
}
