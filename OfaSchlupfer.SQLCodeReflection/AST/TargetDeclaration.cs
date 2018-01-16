namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TargetDeclaration : TSqlFragment {
        private EventSessionObjectName _objectName;

        public EventSessionObjectName ObjectName {
            get {
                return this._objectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._objectName = value;
            }
        }

        public List<EventDeclarationSetParameter> TargetDeclarationParameters { get; } = new List<EventDeclarationSetParameter>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ObjectName?.Accept(visitor);
            this.TargetDeclarationParameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
