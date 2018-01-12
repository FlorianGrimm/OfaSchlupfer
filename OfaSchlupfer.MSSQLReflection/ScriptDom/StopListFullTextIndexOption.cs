using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class StopListFullTextIndexOption : FullTextIndexOption {
        private bool _isOff;

        private Identifier _stopListName;

        public bool IsOff {
            get {
                return this._isOff;
            }
            set {
                this._isOff = value;
            }
        }

        public Identifier StopListName {
            get {
                return this._stopListName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._stopListName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StopListName?.Accept(visitor);
        }
    }
}
