namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterSymmetricKeyStatement : SymmetricKeyStatement {
        private bool _isAdd;

        public bool IsAdd {
            get {
                return this._isAdd;
            }

            set {
                this._isAdd = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            for (int i = 0, count = base.EncryptingMechanisms.Count; i < count; i++) {
                base.EncryptingMechanisms[i].Accept(visitor);
            }
        }
    }
}
