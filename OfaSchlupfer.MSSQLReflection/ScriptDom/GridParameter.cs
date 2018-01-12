using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class GridParameter : TSqlFragment {
        private GridParameterType _parameter;

        private ImportanceParameterType _value;

        public GridParameterType Parameter {
            get {
                return this._parameter;
            }
            set {
                this._parameter = value;
            }
        }

        public ImportanceParameterType Value {
            get {
                return this._value;
            }
            set {
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
