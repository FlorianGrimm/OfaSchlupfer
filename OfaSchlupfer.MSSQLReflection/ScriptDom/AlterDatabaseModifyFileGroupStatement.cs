using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseModifyFileGroupStatement : AlterDatabaseStatement {
        private Identifier _fileGroup;

        private Identifier _newFileGroupName;

        private bool _makeDefault;

        private ModifyFileGroupOption _updatabilityOption;

        private AlterDatabaseTermination _termination;

        public Identifier FileGroup {
            get {
                return this._fileGroup;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileGroup = value;
            }
        }

        public Identifier NewFileGroupName {
            get {
                return this._newFileGroupName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._newFileGroupName = value;
            }
        }

        public bool MakeDefault {
            get {
                return this._makeDefault;
            }

            set {
                this._makeDefault = value;
            }
        }

        public ModifyFileGroupOption UpdatabilityOption {
            get {
                return this._updatabilityOption;
            }

            set {
                this._updatabilityOption = value;
            }
        }

        public AlterDatabaseTermination Termination {
            get {
                return this._termination;
            }

            set {
                this.UpdateTokenInfo(value);
                this._termination = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FileGroup?.Accept(visitor);
            this.NewFileGroupName?.Accept(visitor);
            this.Termination?.Accept(visitor);
        }
    }
}
