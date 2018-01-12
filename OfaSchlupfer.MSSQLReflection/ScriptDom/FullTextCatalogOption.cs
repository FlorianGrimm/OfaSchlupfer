using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class FullTextCatalogOption : TSqlFragment {
        private FullTextCatalogOptionKind _optionKind;

        public FullTextCatalogOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
