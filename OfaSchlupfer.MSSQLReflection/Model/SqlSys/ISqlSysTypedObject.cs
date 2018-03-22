#pragma warning disable SA1600 // Elements must be documented
namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    /// <summary>
    /// we will see
    /// </summary>
    public interface ISqlSysTypedObject {
        short system_type_id { get; }

        int user_type_id { get; }

        short max_length { get; }

        byte precision { get; }

        byte scale { get; }

        string collation_name { get; }

        bool is_nullable { get; }
    }
}
