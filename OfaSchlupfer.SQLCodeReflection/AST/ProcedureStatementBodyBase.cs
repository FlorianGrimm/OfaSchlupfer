namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ProcedureStatementBodyBase : TSqlStatement {

        private StatementList _statementList;

        private MethodSpecifier _methodSpecifier;

        public List<ProcedureParameter> Parameters { get; } = new List<ProcedureParameter>();

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
            this.Parameters.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
