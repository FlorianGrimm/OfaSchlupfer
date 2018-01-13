namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class GoToStatement : TSqlStatement {
        private Identifier _labelName;

        public Identifier LabelName {
            get {
                return this._labelName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._labelName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.LabelName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
