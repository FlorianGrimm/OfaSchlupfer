namespace OfaSchlupfer.ScriptDom {
    internal enum IndexAffectingStatement {
        AlterTableAddElement,
        AlterTableAlterIndexRebuild,
        AlterTableRebuildOnePartition,
        AlterTableRebuildAllPartitions,
        AlterIndexSet,
        AlterIndexRebuildOnePartition,
        AlterIndexRebuildAllPartitions,
        AlterIndexReorganize,
        CreateColumnStoreIndex,
        CreateIndex,
        CreateTable,
        CreateType,
        CreateXmlIndex,
        CreateOrAlterFunction,
        DeclareTableVariable,
        CreateSpatialIndex,
        CreateTableInlineIndex,
        AlterTableAlterColumn,
        AlterIndexResume
    }
}
