using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileGroupDefinition : TSqlFragment {
        private Identifier _name;

        private List<FileDeclaration> _fileDeclarations = new List<FileDeclaration>();

        private bool _isDefault;

        private bool _containsFileStream;

        private bool _containsMemoryOptimizedData;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<FileDeclaration> FileDeclarations {
            get {
                return this._fileDeclarations;
            }
        }

        public bool IsDefault {
            get {
                return this._isDefault;
            }

            set {
                this._isDefault = value;
            }
        }

        public bool ContainsFileStream {
            get {
                return this._containsFileStream;
            }

            set {
                this._containsFileStream = value;
            }
        }

        public bool ContainsMemoryOptimizedData {
            get {
                return this._containsMemoryOptimizedData;
            }

            set {
                this._containsMemoryOptimizedData = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.FileDeclarations.Count; i < count; i++) {
                this.FileDeclarations[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
