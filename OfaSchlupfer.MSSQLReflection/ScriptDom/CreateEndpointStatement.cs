namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateEndpointStatement : AlterCreateEndpointStatementBase, IAuthorization {
        private Identifier _owner;

        public Identifier Owner {
            get {
                return this._owner;
            }

            set {
                this.UpdateTokenInfo(value);
                this._owner = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.Name?.Accept(visitor);
            base.Affinity?.Accept(visitor);
            for (int i = 0, count = base.ProtocolOptions.Count; i < count; i++) {
                base.ProtocolOptions[i].Accept(visitor);
            }
            for (int j = 0, count2 = base.PayloadOptions.Count; j < count2; j++) {
                base.PayloadOptions[j].Accept(visitor);
            }
            this.Owner?.Accept(visitor);
        }
    }
}
