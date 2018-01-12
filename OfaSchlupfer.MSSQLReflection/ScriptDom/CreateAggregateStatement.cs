using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateAggregateStatement : TSqlStatement {
        private SchemaObjectName _name;

        private AssemblyName _assemblyName;

        private List<ProcedureParameter> _parameters = new List<ProcedureParameter>();

        private DataTypeReference _returnType;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public AssemblyName AssemblyName {
            get {
                return this._assemblyName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._assemblyName = value;
            }
        }

        public List<ProcedureParameter> Parameters {
            get {
                return this._parameters;
            }
        }

        public DataTypeReference ReturnType {
            get {
                return this._returnType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._returnType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.AssemblyName?.Accept(visitor);
            for (int i=0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
            this.ReturnType?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
