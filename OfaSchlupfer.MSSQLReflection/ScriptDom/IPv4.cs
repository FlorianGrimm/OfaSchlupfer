using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IPv4 : TSqlFragment {
        private Literal _octetOne;

        private Literal _octetTwo;

        private Literal _octetThree;

        private Literal _octetFour;

        public Literal OctetOne {
            get {
                return this._octetOne;
            }
            set {
                base.UpdateTokenInfo(value);
                this._octetOne = value;
            }
        }

        public Literal OctetTwo {
            get {
                return this._octetTwo;
            }
            set {
                base.UpdateTokenInfo(value);
                this._octetTwo = value;
            }
        }

        public Literal OctetThree {
            get {
                return this._octetThree;
            }
            set {
                base.UpdateTokenInfo(value);
                this._octetThree = value;
            }
        }

        public Literal OctetFour {
            get {
                return this._octetFour;
            }
            set {
                base.UpdateTokenInfo(value);
                this._octetFour = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OctetOne?.Accept(visitor);
            this.OctetTwo?.Accept(visitor);
            this.OctetThree?.Accept(visitor);
            this.OctetFour?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
