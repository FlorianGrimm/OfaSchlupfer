using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PrivilegeSecurityElement80 : SecurityElement80 {
        private List<Privilege80> _privileges = new List<Privilege80>();

        private SchemaObjectName _schemaObjectName;

        private List<Identifier> _columns = new List<Identifier>();

        public List<Privilege80> Privileges {
            get {
                return this._privileges;
            }
        }

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public List<Identifier> Columns {
            get {
                return this._columns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.Privileges.Count; i < count; i++) {
                this.Privileges[i].Accept(visitor);
            }
            this.SchemaObjectName?.Accept(visitor);
            int j = 0;
            for (int count2 = this.Columns.Count; j < count2; j++) {
                this.Columns[j].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
