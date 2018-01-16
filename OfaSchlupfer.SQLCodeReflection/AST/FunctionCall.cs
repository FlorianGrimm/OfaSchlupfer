namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FunctionCall : PrimaryExpression {
        private CallTarget _callTarget;

        private Identifier _functionName;

        private UniqueRowFilter _uniqueRowFilter;

        private OverClause _overClause;

        private WithinGroupClause _withinGroupClause;

        public CallTarget CallTarget {
            get {
                return this._callTarget;
            }

            set {
                this.UpdateTokenInfo(value);
                this._callTarget = value;
            }
        }

        public Identifier FunctionName {
            get {
                return this._functionName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._functionName = value;
            }
        }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public UniqueRowFilter UniqueRowFilter {
            get {
                return this._uniqueRowFilter;
            }

            set {
                this._uniqueRowFilter = value;
            }
        }

        public OverClause OverClause {
            get {
                return this._overClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._overClause = value;
            }
        }

        public WithinGroupClause WithinGroupClause {
            get {
                return this._withinGroupClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._withinGroupClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CallTarget?.Accept(visitor);
            this.FunctionName?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.OverClause?.Accept(visitor);
            this.WithinGroupClause?.Accept(visitor);
        }
    }
}
