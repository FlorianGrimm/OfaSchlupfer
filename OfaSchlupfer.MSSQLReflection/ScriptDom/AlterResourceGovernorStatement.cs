using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterResourceGovernorStatement : TSqlStatement {
        private AlterResourceGovernorCommandType _command;

        private SchemaObjectName _classifierFunction;

        public AlterResourceGovernorCommandType Command {
            get {
                return this._command;
            }

            set {
                this._command = value;
            }
        }

        public SchemaObjectName ClassifierFunction {
            get {
                return this._classifierFunction;
            }

            set {
                this.UpdateTokenInfo(value);
                this._classifierFunction = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ClassifierFunction?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
