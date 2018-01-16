namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterIndexStatement : IndexStatement {
        private AlterIndexType _alterIndexType;

        private PartitionSpecifier _partition;

        private XmlNamespaces _xmlNamespaces;

        public bool All { get; set; }

        public AlterIndexType AlterIndexType {
            get {
                return this._alterIndexType;
            }

            set {
                this._alterIndexType = value;
            }
        }

        public PartitionSpecifier Partition {
            get {
                return this._partition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._partition = value;
            }
        }

        public List<SelectiveXmlIndexPromotedPath> PromotedPaths { get; } = new List<SelectiveXmlIndexPromotedPath>();

        public XmlNamespaces XmlNamespaces {
            get {
                return this._xmlNamespaces;
            }

            set {
                this.UpdateTokenInfo(value);
                this._xmlNamespaces = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.OnName?.Accept(visitor);
            this.IndexOptions.Accept(visitor);
            this.Partition?.Accept(visitor);
            this.PromotedPaths.Accept(visitor);
            this.XmlNamespaces?.Accept(visitor);
        }
    }
}
