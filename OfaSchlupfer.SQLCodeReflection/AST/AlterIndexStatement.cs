namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterIndexStatement : IndexStatement {
        private AlterIndexType _alterIndexType;

        private PartitionSpecifier _partition;

        private List<SelectiveXmlIndexPromotedPath> _promotedPaths = new List<SelectiveXmlIndexPromotedPath>();

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

        public List<SelectiveXmlIndexPromotedPath> PromotedPaths {
            get {
                return this._promotedPaths;
            }
        }

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
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            if (base.OnName != null) {
                base.OnName.Accept(visitor);
            }
            for (int i = 0, count = base.IndexOptions.Count; i < count; i++) {
                base.IndexOptions[i].Accept(visitor);
            }
            this.Partition?.Accept(visitor);
            int j = 0;
            for (int count2 = this.PromotedPaths.Count; j < count2; j++) {
                this.PromotedPaths[j].Accept(visitor);
            }
            this.XmlNamespaces?.Accept(visitor);
        }
    }
}
