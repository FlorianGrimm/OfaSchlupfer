using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileStreamOnDropIndexOption : IndexOption, IFileStreamSpecifier {
        private IdentifierOrValueExpression _fileStreamOn;

        public IdentifierOrValueExpression FileStreamOn {
            get {
                return this._fileStreamOn;
            }
            set {
                base.UpdateTokenInfo(value);
                this._fileStreamOn = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FileStreamOn?.Accept(visitor);
        }
    }
}
