namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class SequenceStatement : TSqlStatement {
        private SchemaObjectName _name;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<SequenceOption> SequenceOptions { get; } = new List<SequenceOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.SequenceOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
