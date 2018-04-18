namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.Rest;

    using OfaSchlupfer.Elementary;

    public class EntityDispatcherFactory : IEntityDispatcherFactory {
        public readonly IServiceProvider ServiceProvider;
        public readonly EntityOptions Options;
        private IEntityConcreteFactory[] _EntityFactories;
        private Dictionary<string, IEntityConcreteFactory> _FactoryByAuthenticationMode;

        // EntityOptions
        public EntityDispatcherFactory(
            IServiceProvider serviceProvider
            , IOptions<EntityOptions> options) {
            this.Options = options.Value ?? new EntityOptions();
        }

        public EntityDispatcherFactory(
          IServiceProvider serviceProvider
          , EntityOptions options) {
            this.Options = options ?? new EntityOptions();
        }

        public IEntityFactory GetEntityFactory(string entityTypeName) {
            var cmp = StringComparer.OrdinalIgnoreCase;
            Todo.Soon("Desision array sorted dictionary");
            var entityFactories = this.GetEntityFactories();
            int pos = Array.BinarySearch(entityFactories, entityTypeName, new NameComparer());
            if (pos >= 0) {
                return entityFactories[pos];
            }
            //foreach (var factory in entityFactories) {
            //    var factoryEntityTypeName = factory.GetEntityTypeName();
            //    if (cmp.Equals(factoryEntityTypeName, entityTypeName)) {
            //        return factory;
            //    }
            //}
            return null;
        }



        public IEntity CreateEntity(string entityTypeName) {
            var factory = GetEntityFactory(entityTypeName);
            if (factory != null) {
                return factory.CreateEntity(entityTypeName);
            }
            return null;
        }

        private IEntityConcreteFactory[] GetEntityFactories() {
            if (this._EntityFactories != null) {
                return this._EntityFactories;
            }
            if (this.Options.Factories.Count > 0) {
                this._EntityFactories = this.Options.Factories
                    .OrderBy(_ => _.GetEntityTypeName(), StringComparer.OrdinalIgnoreCase)
                    .ToArray();
                return this._EntityFactories;
            }
            {
                var serivces = this.ServiceProvider.GetServices<IEntityConcreteFactory>();
                this._EntityFactories = (serivces ?? new IEntityConcreteFactory[0])
                    .OrderBy(_ => _.GetEntityTypeName(), StringComparer.OrdinalIgnoreCase)
                    .ToArray();
            }
            return this._EntityFactories;
        }

        private struct NameComparer : IComparer {
            public int Compare(object x, object y) {
                throw new NotImplementedException();
            }
        }
    }
}
