using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MethodSpecifier : TSqlFragment {
        private Identifier _assemblyName;

        private Identifier _className;

        private Identifier _methodName;

        public Identifier AssemblyName {
            get {
                return this._assemblyName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._assemblyName = value;
            }
        }

        public Identifier ClassName {
            get {
                return this._className;
            }

            set {
                this.UpdateTokenInfo(value);
                this._className = value;
            }
        }

        public Identifier MethodName {
            get {
                return this._methodName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._methodName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.AssemblyName?.Accept(visitor);
            this.ClassName?.Accept(visitor);
            this.MethodName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
