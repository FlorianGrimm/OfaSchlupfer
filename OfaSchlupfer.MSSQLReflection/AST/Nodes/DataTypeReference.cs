#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using OfaSchlupfer.MSSQLReflection.Model;

    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class DataTypeReference : SqlNode {
        public DataTypeReference() : base() { }
        public DataTypeReference(ScriptDom.DataTypeReference src) : base(src) {
            this.Name = Copier.Copy<SchemaObjectName>(src.Name);
        }
        public SchemaObjectName Name;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class XmlDataTypeReference : DataTypeReference {
        public XmlDataTypeReference() : base() { }
        public XmlDataTypeReference(ScriptDom.XmlDataTypeReference src) : base(src) {
            this.XmlDataTypeOption = src.XmlDataTypeOption;
            this.XmlSchemaCollection = Copier.Copy<SchemaObjectName>(src.XmlSchemaCollection);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.XmlDataTypeOption XmlDataTypeOption;
        public SchemaObjectName XmlSchemaCollection;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.XmlSchemaCollection?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class ParameterizedDataTypeReference : DataTypeReference {
        public ParameterizedDataTypeReference() : base() { }
        public ParameterizedDataTypeReference(ScriptDom.ParameterizedDataTypeReference src) : base(src) {
            Copier.CopyList(this.Parameters, src.Parameters);
        }
        public List<Literal> Parameters { get; } = new List<Literal>();
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Parameters.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SqlDataTypeReference : ParameterizedDataTypeReference {
        public SqlDataTypeReference() : base() { }
        public SqlDataTypeReference(ScriptDom.SqlDataTypeReference src) : base(src) {
            this.SqlDataTypeOption = (ModelSqlSystemDataType)src.SqlDataTypeOption;
        }
        public ModelSqlSystemDataType SqlDataTypeOption;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class UserDataTypeReference : ParameterizedDataTypeReference {
        public UserDataTypeReference() : base() { }
        public UserDataTypeReference(ScriptDom.UserDataTypeReference src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
