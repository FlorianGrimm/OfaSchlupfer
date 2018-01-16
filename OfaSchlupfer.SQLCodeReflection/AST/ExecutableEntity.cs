namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ExecutableEntity : TSqlFragment {
        public List<ExecuteParameter> Parameters { get; } = new List<ExecuteParameter>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Parameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
