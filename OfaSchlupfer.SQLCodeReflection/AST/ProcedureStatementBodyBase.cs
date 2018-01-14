using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class ProcedureStatementBodyBase : TSqlStatement {
        private List<ProcedureParameter> _parameters = new List<ProcedureParameter>();

        private StatementList _statementList;

        private MethodSpecifier _methodSpecifier;

        public List<ProcedureParameter> Parameters {
            get {
                return this._parameters;
            }
        }

        public StatementList StatementList {
            get {
                return this._statementList;
            }

            set {
                this.UpdateTokenInfo(value);
                this._statementList = value;
            }
        }

        public MethodSpecifier MethodSpecifier {
            get {
                return this._methodSpecifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._methodSpecifier = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
