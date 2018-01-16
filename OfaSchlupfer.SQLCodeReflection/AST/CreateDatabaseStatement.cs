namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateDatabaseStatement : TSqlStatement, ICollationSetter {
        private Identifier _databaseName;

        private ContainmentDatabaseOption _containment;

        private AttachMode _attachMode;

        private Identifier _databaseSnapshot;

        private MultiPartIdentifier _copyOf;

        private Identifier _collation;

        public Identifier DatabaseName {
            get {
                return this._databaseName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._databaseName = value;
            }
        }

        public ContainmentDatabaseOption Containment {
            get {
                return this._containment;
            }

            set {
                this.UpdateTokenInfo(value);
                this._containment = value;
            }
        }

        public List<FileGroupDefinition> FileGroups { get; } = new List<FileGroupDefinition>();

        public List<FileDeclaration> LogOn { get; } = new List<FileDeclaration>();

        public List<DatabaseOption> Options { get; } = new List<DatabaseOption>();

        public AttachMode AttachMode {
            get {
                return this._attachMode;
            }

            set {
                this._attachMode = value;
            }
        }

        public Identifier DatabaseSnapshot {
            get {
                return this._databaseSnapshot;
            }

            set {
                this.UpdateTokenInfo(value);
                this._databaseSnapshot = value;
            }
        }

        public MultiPartIdentifier CopyOf {
            get {
                return this._copyOf;
            }

            set {
                this.UpdateTokenInfo(value);
                this._copyOf = value;
            }
        }

        public Identifier Collation {
            get {
                return this._collation;
            }

            set {
                this.UpdateTokenInfo(value);
                this._collation = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DatabaseName?.Accept(visitor);
            this.Containment?.Accept(visitor);
            this.FileGroups.Accept(visitor);
            this.LogOn.Accept(visitor);
            this.Options.Accept(visitor);
            this.DatabaseSnapshot?.Accept(visitor);
            this.CopyOf?.Accept(visitor);
            this.Collation?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
