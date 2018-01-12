using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class FunctionStatementBody : ProcedureStatementBodyBase {
        private SchemaObjectName _name;

        private FunctionReturnType _returnType;

        private List<FunctionOption> _options = new List<FunctionOption>();

        private OrderBulkInsertOption _orderHint;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public FunctionReturnType ReturnType {
            get {
                return this._returnType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._returnType = value;
            }
        }

        public List<FunctionOption> Options {
            get {
                return this._options;
            }
        }

        public OrderBulkInsertOption OrderHint {
            get {
                return this._orderHint;
            }

            set {
                this.UpdateTokenInfo(value);
                this._orderHint = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
            this.ReturnType?.Accept(visitor);
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            this.OrderHint?.Accept(visitor);
        }
    }
}
