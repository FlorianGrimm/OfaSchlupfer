using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ListenerIPEndpointProtocolOption : EndpointProtocolOption {
        private bool _isAll;

        private Literal _iPv6;

        private IPv4 _iPv4PartOne;

        private IPv4 _iPv4PartTwo;

        public bool IsAll {
            get {
                return this._isAll;
            }
            set {
                this._isAll = value;
            }
        }

        public Literal IPv6 {
            get {
                return this._iPv6;
            }
            set {
                base.UpdateTokenInfo(value);
                this._iPv6 = value;
            }
        }

        public IPv4 IPv4PartOne {
            get {
                return this._iPv4PartOne;
            }
            set {
                base.UpdateTokenInfo(value);
                this._iPv4PartOne = value;
            }
        }

        public IPv4 IPv4PartTwo {
            get {
                return this._iPv4PartTwo;
            }
            set {
                base.UpdateTokenInfo(value);
                this._iPv4PartTwo = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            if (this.IPv6 != null) {
                this.IPv6.Accept(visitor);
            }
            if (this.IPv4PartOne != null) {
                this.IPv4PartOne.Accept(visitor);
            }
            if (this.IPv4PartTwo != null) {
                this.IPv4PartTwo.Accept(visitor);
            }
        }
    }
}
