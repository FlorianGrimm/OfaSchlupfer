namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IdentityOptions : TSqlFragment {
        private ScalarExpression _identitySeed;

        private ScalarExpression _identityIncrement;

        private bool _isIdentityNotForReplication;

        public ScalarExpression IdentitySeed {
            get {
                return this._identitySeed;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identitySeed = value;
            }
        }

        public ScalarExpression IdentityIncrement {
            get {
                return this._identityIncrement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identityIncrement = value;
            }
        }

        public bool IsIdentityNotForReplication {
            get {
                return this._isIdentityNotForReplication;
            }

            set {
                this._isIdentityNotForReplication = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.IdentitySeed?.Accept(visitor);
            this.IdentityIncrement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
