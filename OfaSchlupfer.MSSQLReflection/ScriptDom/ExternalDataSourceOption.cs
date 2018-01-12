using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ExternalDataSourceOption : TSqlFragment {
        private ExternalDataSourceOptionKind _optionKind;

        public ExternalDataSourceOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
