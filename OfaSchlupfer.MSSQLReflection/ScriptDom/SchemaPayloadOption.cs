using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SchemaPayloadOption : PayloadOption {
        private bool _isStandard;

        public bool IsStandard {
            get {
                return this._isStandard;
            }
            set {
                this._isStandard = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
