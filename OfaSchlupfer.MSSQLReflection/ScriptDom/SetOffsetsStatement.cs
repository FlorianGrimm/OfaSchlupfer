using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetOffsetsStatement : SetOnOffStatement {
        private SetOffsets _options;

        public SetOffsets Options {
            get {
                return this._options;
            }
            set {
                this._options = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
