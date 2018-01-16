namespace OfaSchlupfer.AST {
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
            this.Name?.Accept(visitor);
            this.QueueOptions.Accept(visitor);
            this.OnFileGroup?.Accept(visitor);
        }
    }
}
