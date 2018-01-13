namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class KillQueryNotificationSubscriptionStatement : TSqlStatement {
        private Literal _subscriptionId;

        private bool _all;

        public Literal SubscriptionId {
            get {
                return this._subscriptionId;
            }

            set {
                this.UpdateTokenInfo(value);
                this._subscriptionId = value;
            }
        }

        public bool All {
            get {
                return this._all;
            }

            set {
                this._all = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SubscriptionId?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
