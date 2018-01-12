using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class QueryStoreOption : TSqlFragment {
        private QueryStoreOptionKind _optionKind;

        public QueryStoreOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
