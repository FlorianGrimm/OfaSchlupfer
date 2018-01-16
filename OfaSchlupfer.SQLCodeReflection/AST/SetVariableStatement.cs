namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SetVariableStatement : TSqlStatement {
        private VariableReference _variable;

        private Identifier _identifier;

        private ScalarExpression _expression;

        private CursorDefinition _cursorDefinition;

        public VariableReference Variable {
            get {
                return this._variable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public SeparatorType SeparatorType { get; set; }

        public Identifier Identifier {
            get {
                return this._identifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public bool FunctionCallExists { get; set; }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

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

        public AssignmentKind AssignmentKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.Identifier?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.Expression?.Accept(visitor);
            this.CursorDefinition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
