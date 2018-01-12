using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class FullTextIndexOption : TSqlFragment {
        private FullTextIndexOptionKind _optionKind;

        public FullTextIndexOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
