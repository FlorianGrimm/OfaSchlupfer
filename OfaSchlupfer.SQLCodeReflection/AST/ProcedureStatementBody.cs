namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ProcedureStatementBody : ProcedureStatementBodyBase {
        private ProcedureReference _procedureReference;

        public ProcedureReference ProcedureReference {
            get {
                return this._procedureReference;
            }

            set {
                this.UpdateTokenInfo(value);
                this._procedureReference = value;
            }
        }

        public bool IsForReplication { get; set; }

        public List<ProcedureOption> Options { get; } = new List<ProcedureOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ProcedureReference?.Accept(visitor);
            this.Options.Accept(visitor);
        }
    }
}
