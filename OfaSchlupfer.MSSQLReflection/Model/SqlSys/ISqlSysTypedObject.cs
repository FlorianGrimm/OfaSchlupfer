namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
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
