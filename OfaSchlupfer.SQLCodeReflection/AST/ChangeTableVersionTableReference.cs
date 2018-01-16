#pragma warning disable SA1600 // Elements must be documented
namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ChangeTableVersionTableReference : TableReferenceWithAliasAndColumns {
        private SchemaObjectName _target;

        public SchemaObjectName Target {
            get {
                return this._target;
            }

            set {
                this.UpdateTokenInfo(value);
                this._target = value;
            }
        }

        public List<Identifier> PrimaryKeyColumns { get; } = new List<Identifier>();

        public List<ScalarExpression> PrimaryKeyValues { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Target?.Accept(visitor);
            this.PrimaryKeyColumns.Accept(visitor);
            this.PrimaryKeyValues.Accept(visitor);
        }
    }
}
