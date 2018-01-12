using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ExternalFileFormatOption : TSqlFragment {
        private ExternalFileFormatOptionKind _optionKind;

        public ExternalFileFormatOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
