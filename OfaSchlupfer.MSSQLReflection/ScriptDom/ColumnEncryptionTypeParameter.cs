using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnEncryptionTypeParameter : ColumnEncryptionDefinitionParameter {
        private ColumnEncryptionType _encryptionType;

        public ColumnEncryptionType EncryptionType {
            get {
                return this._encryptionType;
            }
            set {
                this._encryptionType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
