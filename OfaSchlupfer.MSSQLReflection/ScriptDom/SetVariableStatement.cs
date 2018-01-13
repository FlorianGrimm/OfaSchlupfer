using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetVariableStatement : TSqlStatement {
        private VariableReference _variable;

        private SeparatorType _separatorType;

        private Identifier _identifier;

        private bool _functionCallExists;

        private List<ScalarExpression> _parameters = new List<ScalarExpression>();

        private ScalarExpression _expression;

        private CursorDefinition _cursorDefinition;

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

        public SeparatorType SeparatorType {
            get {
                return this._separatorType;
            }

            set {
                this._separatorType = value;
            }
        }

        public Identifier Identifier {
            get {
                return this._identifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public bool FunctionCallExists {
            get {
                return this._functionCallExists;
            }

            set {
                this._functionCallExists = value;
            }
        }

        public List<ScalarExpression> Parameters {
            get {
                return this._parameters;
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

        public CursorDefinition CursorDefinition {
            get {
                return this._cursorDefinition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._cursorDefinition = value;
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
            this.Identifier?.Accept(visitor);
            for (int i = 0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
            this.Expression?.Accept(visitor);
            this.CursorDefinition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
