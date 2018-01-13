namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class XmlDataTypeReference : DataTypeReference {
        private XmlDataTypeOption _xmlDataTypeOption;

        private SchemaObjectName _xmlSchemaCollection;

        public XmlDataTypeOption XmlDataTypeOption {
            get {
                return this._xmlDataTypeOption;
            }

            set {
                this._xmlDataTypeOption = value;
            }
        }

        public SchemaObjectName XmlSchemaCollection {
            get {
                return this._xmlSchemaCollection;
            }

            set {
                this.UpdateTokenInfo(value);
                this._xmlSchemaCollection = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.XmlSchemaCollection?.Accept(visitor);
        }
    }
}
