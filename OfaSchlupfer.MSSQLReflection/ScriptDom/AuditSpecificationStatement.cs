using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AuditSpecificationStatement : TSqlStatement {
        private OptionState _auditState;

        private List<AuditSpecificationPart> _parts = new List<AuditSpecificationPart>();

        private Identifier _specificationName;

        private Identifier _auditName;

        public OptionState AuditState {
            get {
                return this._auditState;
            }

            set {
                this._auditState = value;
            }
        }

        public List<AuditSpecificationPart> Parts {
            get {
                return this._parts;
            }
        }

        public Identifier SpecificationName {
            get {
                return this._specificationName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._specificationName = value;
            }
        }

        public Identifier AuditName {
            get {
                return this._auditName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._auditName = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Parts.Count; i < count; i++) {
                this.Parts[i].Accept(visitor);
            }
            this.SpecificationName?.Accept(visitor);
            this.AuditName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
