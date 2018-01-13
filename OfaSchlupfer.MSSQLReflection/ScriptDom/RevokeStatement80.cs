namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RevokeStatement80 : SecurityStatementBody80 {
        private bool _grantOptionFor;

        private bool _cascadeOption;

        private Identifier _asClause;

        public bool GrantOptionFor {
            get {
                return this._grantOptionFor;
            }

            set {
                this._grantOptionFor = value;
            }
        }

        public bool CascadeOption {
            get {
                return this._cascadeOption;
            }

            set {
                this._cascadeOption = value;
            }
        }

        public Identifier AsClause {
            get {
                return this._asClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._asClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.AsClause?.Accept(visitor);
        }
    }
}
