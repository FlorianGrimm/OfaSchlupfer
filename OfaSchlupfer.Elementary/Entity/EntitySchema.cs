namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EntitySchema : IEntityDispatcherFactory {
        private Dictionary<string, IMetaEntity> _MetaEntityByName;

        public IEntityDispatcherFactory EntityDispatcherFactory { get; set; }
        public EntitySchema(
            IEntityDispatcherFactory entityDispatcherFactory
            ) {
            this.EntityDispatcherFactory = entityDispatcherFactory;
            this._MetaEntityByName = new Dictionary<string, IMetaEntity>();
        }

        public void Add(string entityTypeName, IMetaEntity metaEntity) {
            while (true) {
                var o = this._MetaEntityByName;
                var n = new Dictionary<string, IMetaEntity>(o);
                n.Add(entityTypeName, metaEntity);
                if (ReferenceEquals(System.Threading.Interlocked.CompareExchange(ref this._MetaEntityByName, n, o), o)) { break; }
            }
        }

        public IMetaEntity GetMetaEntity(string entityTypeName) {
            var result = this._MetaEntityByName.GetValueOrDefault(entityTypeName);
            if (result != null) { return result; }
            // this.EntityDispatcherFactory.GetEntityFactory(entityTypeName)
            return null;
        }

        //public IMetaEntity GetMetaEntity(string entityTypeName) => this._MetaEntityByName.GetValueOrDefault(entityTypeName);

        public IEntityFactory GetEntityFactory(string entityTypeName) {
            var result = this.GetEntityFactoryLocal(entityTypeName);
            if (result != null) { return result; }
            result = this.EntityDispatcherFactory?.GetEntityFactory(entityTypeName);
            if (result != null) { return result; }
            return null;
        }

        public IEntityFactory GetEntityFactoryLocal(string entityTypeName) {
            return null;
        }

        public IEntity CreateEntity(string entityTypeName) {
            return null;
        }
    }
}
