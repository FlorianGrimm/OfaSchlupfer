namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class QueueStatement : TSqlStatement {
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

        public List<QueueOption> QueueOptions { get; } = new List<QueueOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.QueueOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
