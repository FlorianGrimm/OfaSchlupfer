using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ExternalTableOption : TSqlFragment {
        private ExternalTableOptionKind _optionKind;

        public ExternalTableOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
