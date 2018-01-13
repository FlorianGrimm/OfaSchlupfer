namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateQueueStatement : QueueStatement {
        private IdentifierOrValueExpression _onFileGroup;

        public IdentifierOrValueExpression OnFileGroup {
            get {
                return this._onFileGroup;
            }

            set {
                this.UpdateTokenInfo(value);
                this._onFileGroup = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            int i = 0;
            for (int count = base.QueueOptions.Count; i < count; i++) {
                base.QueueOptions[i].Accept(visitor);
            }
            if (this.OnFileGroup != null) {
                this.OnFileGroup.Accept(visitor);
            }
        }
    }
}
