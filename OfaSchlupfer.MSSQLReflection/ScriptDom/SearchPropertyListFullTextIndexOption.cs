using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SearchPropertyListFullTextIndexOption : FullTextIndexOption {
        private bool _isOff;

        private Identifier _propertyListName;

        public bool IsOff {
            get {
                return this._isOff;
            }
            set {
                this._isOff = value;
            }
        }

        public Identifier PropertyListName {
            get {
                return this._propertyListName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._propertyListName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.PropertyListName?.Accept(visitor);
        }
    }
}
