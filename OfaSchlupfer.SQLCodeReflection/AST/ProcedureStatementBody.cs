using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class ProcedureStatementBody : ProcedureStatementBodyBase {
        private ProcedureReference _procedureReference;

        private List<ProcedureOption> _options = new List<ProcedureOption>();

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

        public List<ProcedureOption> Options {
            get {
                return this._options;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ProcedureReference?.Accept(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }
}
