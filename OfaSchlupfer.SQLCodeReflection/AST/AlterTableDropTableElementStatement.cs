namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableDropTableElementStatement : AlterTableStatement {
        public List<AlterTableDropTableElement> AlterTableDropTableElements { get; } = new List<AlterTableDropTableElement>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.AlterTableDropTableElements.Accept(visitor);
        }
    }
}
