using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ProcedureReferenceName : TSqlFragment {
        private ProcedureReference _procedureReference;

        private VariableReference _procedureVariable;

        public ProcedureReference ProcedureReference {
            get {
                return this._procedureReference;
            }

            set {
                this.UpdateTokenInfo(value);
                this._procedureReference = value;
            }
        }

        public VariableReference ProcedureVariable {
            get {
                return this._procedureVariable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._procedureVariable = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ProcedureReference?.Accept(visitor);
            this.ProcedureVariable?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
