#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class DropObjectsStatement : SqlStatement {
        public List<SchemaObjectName> Objects { get; } = new List<SchemaObjectName>();

        public bool IsIfExists { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Objects.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
