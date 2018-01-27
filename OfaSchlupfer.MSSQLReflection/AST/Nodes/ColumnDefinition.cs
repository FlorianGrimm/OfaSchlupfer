#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1512,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ColumnDefinition : ColumnDefinitionBase {
        public ColumnDefinition() : base() { }
        public ColumnDefinition(ScriptDom.ColumnDefinition src) : base(src) {
            this.ComputedColumnExpression = Copier.Copy<ScalarExpression>(src.ComputedColumnExpression);
            this.IsPersisted = src.IsPersisted;
            this.DefaultConstraint = Copier.Copy<DefaultConstraintDefinition>(src.DefaultConstraint);
            this.IdentityOptions = Copier.Copy<IdentityOptions>(src.IdentityOptions);
            this.IsRowGuidCol = src.IsRowGuidCol;
            Copier.CopyList(this.Constraints, src.Constraints);
            this.GeneratedAlways = src.GeneratedAlways;
            this.IsHidden = src.IsHidden;
        }
        public ScalarExpression ComputedColumnExpression;
        public bool IsPersisted;
        public DefaultConstraintDefinition DefaultConstraint;
        public IdentityOptions IdentityOptions;
        public bool IsRowGuidCol;
        public List<ConstraintDefinition> Constraints { get; } = new List<ConstraintDefinition>();

        // public ColumnStorageOptions StorageOptions;
        // public IndexDefinition Index;
        public ScriptDom.GeneratedAlwaysType? GeneratedAlways;
        public bool IsHidden;

        // public ColumnEncryptionDefinition Encryption;
        public bool IsMasked;
        public StringLiteral MaskingFunction;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ComputedColumnExpression?.Accept(visitor);
            this.DefaultConstraint?.Accept(visitor);
            this.IdentityOptions?.Accept(visitor);
            this.Constraints.Accept(visitor);
            // this.StorageOptions?.Accept(visitor);
            // this.Index?.Accept(visitor);
            // this.Encryption?.Accept(visitor);
            this.MaskingFunction?.Accept(visitor);
        }
    }
}
