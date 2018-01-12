using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class MessageTypeStatementBase : TSqlStatement {
        private Identifier _name;

        private MessageValidationMethod _validationMethod;

        private SchemaObjectName _xmlSchemaCollectionName;

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public MessageValidationMethod ValidationMethod {
            get {
                return this._validationMethod;
            }
            set {
                this._validationMethod = value;
            }
        }

        public SchemaObjectName XmlSchemaCollectionName {
            get {
                return this._xmlSchemaCollectionName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._xmlSchemaCollectionName = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.XmlSchemaCollectionName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
