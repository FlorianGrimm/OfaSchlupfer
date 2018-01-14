#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CheckConstraintDefinition : ConstraintDefinition {
        private BooleanExpression _checkCondition;

        public BooleanExpression CheckCondition {
            get {
                return this._checkCondition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._checkCondition = value;
            }
        }

        public bool NotForReplication { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CheckCondition?.Accept(visitor);
        }
    }
}
