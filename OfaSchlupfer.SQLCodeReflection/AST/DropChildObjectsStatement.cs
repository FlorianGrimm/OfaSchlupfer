namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class DropChildObjectsStatement : TSqlStatement {

        public List<ChildObjectName> Objects { get; } = new List<ChildObjectName>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Objects.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
