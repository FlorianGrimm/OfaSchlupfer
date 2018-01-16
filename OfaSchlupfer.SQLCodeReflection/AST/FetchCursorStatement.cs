namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FetchCursorStatement : CursorStatement {
        private FetchType _fetchType;

        public FetchType FetchType {
            get {
                return this._fetchType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fetchType = value;
            }
        }

        public List<VariableReference> IntoVariables { get; } = new List<VariableReference>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FetchType?.Accept(visitor);
            this.IntoVariables.Accept(visitor);
        }
    }
}
