namespace OfaSchlupfer.Model {
    public interface IRepositoryType {
        string Name { get; }
        string Description { get; }
        IRepository CreateRepository();
    }
}