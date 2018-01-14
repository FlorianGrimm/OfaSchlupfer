namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class DropChildObjectsStatement : TSqlStatement {

        public List<ChildObjectName> Objects { get; } = new List<ChildObjectName>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            int i = 0;
            for (int count = this.Objects.Count; i < count; i++) {
                this.Objects[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
