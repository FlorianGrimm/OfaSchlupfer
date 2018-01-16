namespace OfaSchlupfer.SQLCodeReflection.AST {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.AST;

    public class AlterVisitor : OfaSchlupfer.AST.TSqlConcreteFragmentVisitor {
        public override void ExplicitVisit(CreateProcedureStatement node) {
            base.ExplicitVisit(node);
        }
    }
}
