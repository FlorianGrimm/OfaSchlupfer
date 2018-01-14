using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class ExternalFileFormatStatement : TSqlStatement {
        private Identifier _name;

        private ExternalFileFormatType _formatType;

        private List<ExternalFileFormatOption> _externalFileFormatOptions = new List<ExternalFileFormatOption>();

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public ExternalFileFormatType FormatType {
            get {
                return this._formatType;
            }

            set {
                this._formatType = value;
            }
        }

        public List<ExternalFileFormatOption> ExternalFileFormatOptions {
            get {
                return this._externalFileFormatOptions;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i = 0, count = this.ExternalFileFormatOptions.Count; i < count; i++) {
                this.ExternalFileFormatOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
