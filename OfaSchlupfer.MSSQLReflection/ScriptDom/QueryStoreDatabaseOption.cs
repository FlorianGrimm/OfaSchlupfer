using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueryStoreDatabaseOption : DatabaseOption {
        private bool _clear;

        private bool _clearAll;

        private OptionState _optionState;

        private List<QueryStoreOption> _options = new List<QueryStoreOption>();

        public bool Clear {
            get {
                return this._clear;
            }
            set {
                this._clear = value;
            }
        }

        public bool ClearAll {
            get {
                return this._clearAll;
            }
            set {
                this._clearAll = value;
            }
        }

        public OptionState OptionState {
            get {
                return this._optionState;
            }
            set {
                this._optionState = value;
            }
        }

        public List<QueryStoreOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }
}
