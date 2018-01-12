using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CharacterSetPayloadOption : PayloadOption {
        private bool _isSql;

        public bool IsSql {
            get {
                return this._isSql;
            }
            set {
                this._isSql = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
