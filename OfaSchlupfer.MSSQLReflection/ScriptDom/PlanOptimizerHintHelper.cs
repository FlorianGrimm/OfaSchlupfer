namespace OfaSchlupfer.ScriptDom {
    internal class PlanOptimizerHintHelper : OptionsHelper<OptimizerHintKind> {
        internal static readonly PlanOptimizerHintHelper Instance = new PlanOptimizerHintHelper();

        private PlanOptimizerHintHelper() {
            base.AddOptionMapping(OptimizerHintKind.RobustPlan, "ROBUST", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.ShrinkDBPlan, "SHRINKDB", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.AlterColumnPlan, "ALTERCOLUMN", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.KeepPlan, "KEEP", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.KeepFixedPlan, "KEEPFIXED", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.CheckConstraintsPlan, "CHECKCONSTRAINTS", SqlVersionFlags.TSql90AndAbove);
        }
    }
}
