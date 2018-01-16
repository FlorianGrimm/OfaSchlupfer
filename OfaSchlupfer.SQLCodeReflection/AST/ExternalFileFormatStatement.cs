namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ExternalFileFormatStatement : TSqlStatement {
        private Identifier _name;

        private ExternalFileFormatType _formatType;

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

        public List<ExternalFileFormatOption> ExternalFileFormatOptions { get; } = new List<ExternalFileFormatOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.ExternalFileFormatOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
