namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ExecutableEntity : TSqlFragment {
        public List<ExecuteParameter> Parameters { get; } = new List<ExecuteParameter>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            int i = 0;
            for (int count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
