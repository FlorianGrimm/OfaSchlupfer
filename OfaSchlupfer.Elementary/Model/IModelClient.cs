namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Entity;

    public interface IModelClient {
        ModelRepository ModelRepository { get; set; }

        IEntity CreateEntityByExternalTypeName(string typeName);
    }
}
