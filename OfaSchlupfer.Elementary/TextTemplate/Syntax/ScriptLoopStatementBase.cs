namespace OfaSchlupfer.TextTemplate.Syntax {
    /// <summary>
    /// Base class for a loop statement
    /// </summary>
    public abstract class ScriptLoopStatementBase : ScriptStatement {
        public ScriptBlockStatement Body { get; set; }


        protected virtual void BeforeLoop(TemplateContext context) {
        }

        /// <summary>
        /// Base implementation for a loop single iteration
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="index">The index in the loop</param>
        /// <param name="localIndex"></param>
        /// <param name="isLast"></param>
        /// <returns></returns>
        protected virtual bool Loop(TemplateContext context, int index, int localIndex, bool isLast) {
            // Setup variable
            context.SetValue(ScriptVariable.LoopFirst, index == 0);
            var even = (index & 1) == 0;
            context.SetValue(ScriptVariable.LoopEven, even);
            context.SetValue(ScriptVariable.LoopOdd, !even);
            context.SetValue(ScriptVariable.LoopIndex, index);

            context.Evaluate(Body);

            // Return must bubble up to call site
            if (context.FlowState == ScriptFlowState.Return) {
                return false;
            }

            // If we need to break, restore to none state
            var result = context.FlowState != ScriptFlowState.Break;
            context.FlowState = ScriptFlowState.None;
            return result;
        }

        protected virtual void AfterLoop(TemplateContext context) {
        }

        public override object Evaluate(TemplateContext context) {
            // Notify the context that we enter a loop block (used for variable with scope Loop)
            context.EnterLoop(this);            
            try {
                EvaluateImpl(context);
            }
            finally {
                // Level scope block
                context.ExitLoop(this);

                // Revert to flow state to none unless we have a return that must be handled at a higher level
                if (context.FlowState != ScriptFlowState.Return) {
                    context.FlowState = ScriptFlowState.None;
                }
            }
            return null;
        }
        protected abstract void EvaluateImpl(TemplateContext context);
    }
}