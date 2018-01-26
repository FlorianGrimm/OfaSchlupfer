namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    internal interface IDataMaskingSetter {
        bool IsMasked {
            get;
            set;
        }

        StringLiteral MaskingFunction {
            get;
            set;
        }
    }
}
