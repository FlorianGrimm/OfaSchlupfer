using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExternalFileFormatUseDefaultTypeOption : ExternalFileFormatOption {
        private ExternalFileFormatUseDefaultType _externalFileFormatUseDefaultType;

        public ExternalFileFormatUseDefaultType ExternalFileFormatUseDefaultType {
            get {
                return this._externalFileFormatUseDefaultType;
            }
            set {
                this._externalFileFormatUseDefaultType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
