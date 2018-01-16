namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ServerAuditStatement : TSqlStatement {
        private Identifier _auditName;

        private AuditTarget _auditTarget;

        private BooleanExpression _predicateExpression;

        public Identifier AuditName {
            get {
                return this._auditName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._auditName = value;
            }
        }

        public AuditTarget AuditTarget {
            get {
                return this._auditTarget;
            }

            set {
                this.UpdateTokenInfo(value);
                this._auditTarget = value;
            }
        }

        public List<AuditOption> Options { get; } = new List<AuditOption>();

        public BooleanExpression PredicateExpression {
            get {
                return this._predicateExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._predicateExpression = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.AuditName?.Accept(visitor);
            this.AuditTarget?.Accept(visitor);
            this.Options.Accept(visitor);
            this.PredicateExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
