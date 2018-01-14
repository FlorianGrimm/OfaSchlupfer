namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class KillQueryNotificationSubscriptionStatement : TSqlStatement {
        private Literal _subscriptionId;

        public Literal SubscriptionId {
            get {
                return this._subscriptionId;
            }

            set {
                this.UpdateTokenInfo(value);
                this._subscriptionId = value;
            }
        }

        public bool All { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SubscriptionId?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
