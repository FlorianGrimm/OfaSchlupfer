namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class SecurityStatementBody80 : TSqlStatement {
        private SecurityElement80 _securityElement80;

        private SecurityUserClause80 _securityUserClause80;

        public SecurityElement80 SecurityElement80 {
            get {
                return this._securityElement80;
            }

            set {
                this.UpdateTokenInfo(value);
                this._securityElement80 = value;
            }
        }

        public SecurityUserClause80 SecurityUserClause80 {
            get {
                return this._securityUserClause80;
            }

            set {
                this.UpdateTokenInfo(value);
                this._securityUserClause80 = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SecurityElement80?.Accept(visitor);
            this.SecurityUserClause80?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
