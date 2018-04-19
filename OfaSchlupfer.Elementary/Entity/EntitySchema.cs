namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    [JsonObject]
    public class EntitySchema : IEntityDispatcherFactory {
        private Dictionary<string, IMetaEntity> _MetaEntityByName;

        [JsonIgnore]
        public IEntityDispatcherFactory EntityDispatcherFactory { get; set; }

        public EntitySchema() {
        }

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
                if (entityTypeName is null) {
                    if (!(metaEntity.EntityTypeName is null)) {
                        n.Add(metaEntity.EntityTypeName, metaEntity);
                    }
                } else {
                    n.Add(entityTypeName, metaEntity);
                }
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
            var metaEntity = this.GetMetaEntity(entityTypeName);
#warning missing create custom type
            if (metaEntity is IMetaEntityFlexible metaEntityArrayValues) {
                return new EntityFlexible(metaEntityArrayValues, null);
            }
            return null;
        }

        [JsonProperty]
        public List<IMetaEntity> MetaEntities {
            get {
                return new List<IMetaEntity>(this._MetaEntityByName.Values.Where(_ => !(_.EntityTypeName is null)));
            }
            set {
                if (!(value is null)) {
                    foreach (var metaEntity in value) {
                        this.Add(null, metaEntity);
                    }
                }
            }
        }
    }
}
