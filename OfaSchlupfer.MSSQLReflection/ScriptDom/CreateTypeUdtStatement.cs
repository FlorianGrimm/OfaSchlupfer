using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateTypeUdtStatement : CreateTypeStatement {
        private AssemblyName _assemblyName;

        public AssemblyName AssemblyName {
            get {
                return this._assemblyName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._assemblyName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            this.AssemblyName?.Accept(visitor);
        }
    }
}
