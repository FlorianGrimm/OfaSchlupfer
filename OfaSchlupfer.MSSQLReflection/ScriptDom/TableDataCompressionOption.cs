using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TableDataCompressionOption : TableOption {
        private DataCompressionOption _dataCompressionOption;

        public DataCompressionOption DataCompressionOption {
            get {
                return this._dataCompressionOption;
            }
            set {
                base.UpdateTokenInfo(value);
                this._dataCompressionOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataCompressionOption?.Accept(visitor);
        }
    }
}
