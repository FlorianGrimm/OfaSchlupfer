using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SelectSetVariable : SelectElement {
        private VariableReference _variable;

        private ScalarExpression _expression;

        private AssignmentKind _assignmentKind;

        public VariableReference Variable {
            get {
                return this._variable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public AssignmentKind AssignmentKind {
            get {
                return this._assignmentKind;
            }

            set {
                this._assignmentKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
