#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using OfaSchlupfer.MSSQLReflection.AST;
    using OfaSchlupfer.MSSQLReflection.Model;

    public class TypeVisitor : SqlConcreteFragmentVisitor {
        private SqlCodeScope scope;

        public TypeVisitor(SqlCodeScope scope) {
            this.scope = scope;
        }

        public override void ExplicitVisit(SqlDataTypeReference node) {
            var name = node.Name;
            var parameters = node.Parameters;
            SqlName typename = SqlName.From(node.Name);
            var sqlDataTypeOption = node.SqlDataTypeOption;
            short length = 0;
            bool isMax = false;
            byte precision = 0;
            byte scale = 0;
            string collationName = null;
            foreach (var parameter in parameters) {
                {
                    if (parameter is MaxLiteral) {
                        isMax = true;
                        continue;
                    }
                }
                {
                    if (parameter is IntegerLiteral lengthLiteral) {
                        short.TryParse(lengthLiteral.Value, out length);
                        continue;
                    }
                }

                // TODO: float(1,2)
                // TODO: collationName
            }
            if (sqlDataTypeOption != ModelSystemDataType.None) {
                // happyness
                var scalarType = new ModelTypeScalar();
                scalarType.Name = typename;
                scalarType.MaxLength = (isMax) ? ((short)-1) : length;
                scalarType.Precision = precision;
                scalarType.Scale = scale;
                scalarType.SystemDataType = sqlDataTypeOption;
                scalarType.CollationName = collationName;
                node.Analyse.ResultType = new SqlCodeType(scalarType);
            } else {
                if (System.Diagnostics.Debugger.IsAttached) {
                    System.Diagnostics.Debugger.Break();
                }
                var resolved = this.scope.ResolveObject(typename, null);
                if (resolved != null) {
                    if (resolved is ModelType modelType) {
                        node.Analyse.ResultType = new SqlCodeType(modelType);
                    }
                }
                /*
                var sqlName = SqlName.Parse(name.BaseIdentifier.Value, ObjectLevel.Object);
                var sqlSysName = SqlName.Root.Child("sys", ObjectLevel.Schema).Child(sqlName.Name, ObjectLevel.Object);
                var sqlCodeType = this.currentScopeRef.Current.ResolveObject(sqlSysName, null) as ISqlCodeType;
                SetAnalyseSqlCodeType(node.Analyse, sqlCodeType);
                */
            }
        }

        public override void ExplicitVisit(UserDataTypeReference node) {
            var name = node.Name;
            var parameters = node.Parameters;
            if (System.Diagnostics.Debugger.IsAttached) {
                System.Diagnostics.Debugger.Break();
            }
            node.Analyse.ResultType = null;
            base.ExplicitVisit(node);
        }
    }
}
