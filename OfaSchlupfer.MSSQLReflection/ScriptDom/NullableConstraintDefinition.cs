using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class NullableConstraintDefinition : ConstraintDefinition {
        private bool _nullable;

        public bool Nullable {
            get {
                return this._nullable;
            }

            set {
                this._nullable = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
