namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExecuteInsertSource : InsertSource {
        private ExecuteSpecification _execute;

        public ExecuteSpecification Execute {
            get {
                return this._execute;
            }

            set {
                this.UpdateTokenInfo(value);
                this._execute = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Execute?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
