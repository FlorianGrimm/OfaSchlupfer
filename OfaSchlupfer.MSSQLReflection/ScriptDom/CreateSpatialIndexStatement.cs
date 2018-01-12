using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateSpatialIndexStatement : TSqlStatement {
        private Identifier _name;

        private SchemaObjectName _object;

        private Identifier _spatialColumnName;

        private SpatialIndexingSchemeType _spatialIndexingScheme;

        private List<SpatialIndexOption> _spatialIndexOptions = new List<SpatialIndexOption>();

        private IdentifierOrValueExpression _onFileGroup;

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SchemaObjectName Object {
            get {
                return this._object;
            }
            set {
                base.UpdateTokenInfo(value);
                this._object = value;
            }
        }

        public Identifier SpatialColumnName {
            get {
                return this._spatialColumnName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._spatialColumnName = value;
            }
        }

        public SpatialIndexingSchemeType SpatialIndexingScheme {
            get {
                return this._spatialIndexingScheme;
            }
            set {
                this._spatialIndexingScheme = value;
            }
        }

        public List<SpatialIndexOption> SpatialIndexOptions {
            get {
                return this._spatialIndexOptions;
            }
        }

        public IdentifierOrValueExpression OnFileGroup {
            get {
                return this._onFileGroup;
            }
            set {
                base.UpdateTokenInfo(value);
                this._onFileGroup = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Object?.Accept(visitor);
            this.SpatialColumnName?.Accept(visitor);
            for (int i=0, count = this.SpatialIndexOptions.Count; i < count; i++) {
                this.SpatialIndexOptions[i].Accept(visitor);
            }
            this.OnFileGroup?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
