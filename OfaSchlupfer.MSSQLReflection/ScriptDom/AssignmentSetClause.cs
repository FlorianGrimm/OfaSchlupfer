using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AssignmentSetClause : SetClause {
        private VariableReference _variable;

        private ColumnReferenceExpression _column;

        private ScalarExpression _newValue;

        private AssignmentKind _assignmentKind;

        public VariableReference Variable {
            get {
                return this._variable;
            }
            set {
                base.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public ColumnReferenceExpression Column {
            get {
                return this._column;
            }
            set {
                base.UpdateTokenInfo(value);
                this._column = value;
            }
        }

        public ScalarExpression NewValue {
            get {
                return this._newValue;
            }
            set {
                base.UpdateTokenInfo(value);
                this._newValue = value;
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
            this.Column?.Accept(visitor);
            this.NewValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
