#pragma warning disable SA1402
#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;

    public interface ISqlCodeType {
        ISqlCodeType GetResolvedCodeType();

        void SetResolvedCodeType(ISqlCodeType sqlCodeType);
    }
}
