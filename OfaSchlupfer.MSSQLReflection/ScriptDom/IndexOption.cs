using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class IndexOption : TSqlFragment {
        private IndexOptionKind _optionKind;

        public IndexOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
