#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class DropObjectsStatement : TSqlStatement {
        public List<SchemaObjectName> Objects { get; } = new List<SchemaObjectName>();

        public bool IsIfExists { get; set; }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Objects.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
