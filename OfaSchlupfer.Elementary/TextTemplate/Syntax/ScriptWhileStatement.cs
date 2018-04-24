
namespace OfaSchlupfer.TextTemplate.Syntax {
    [ScriptSyntax("while statement", "while <expression> ... end")]
    public class ScriptWhileStatement : ScriptLoopStatementBase {
        public ScriptExpression Condition { get; set; }

        protected override void EvaluateImpl(TemplateContext context) {
            var index = 0;
            BeforeLoop(context);
            while (context.StepLoop(this)) {
                var conditionResult = context.ToBool(Condition.Span, context.Evaluate(Condition));
                if (!conditionResult) {
                    break;
                }

                if (!Loop(context, index++, index, false)) {
                    break;
                }
            };
            AfterLoop(context);
        }

        public override void Write(TemplateRewriterContext context) {
            context.Write("while").ExpectSpace();
            context.Write(Condition);
            context.ExpectEos();
            context.Write(Body);
            context.ExpectEnd();
        }
        
        public override string ToString() {
            return $"while {Condition} ... end";
        }
    }
}