using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class GenericConfigurationOption : DatabaseConfigurationSetOption {
        private IdentifierOrScalarExpression _genericOptionState;

        public IdentifierOrScalarExpression GenericOptionState {
            get {
                return this._genericOptionState;
            }
            set {
                this._genericOptionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
