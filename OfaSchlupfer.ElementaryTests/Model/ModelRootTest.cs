#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.

namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    using Xunit;
    public class ModelRootTest {
        [Fact]
        public void ModelRoot_1_Test() {
            var modelRoot = new ModelRoot();
            modelRoot.Name = "Hugo";
            var modelRepository = new ModelRepository();
            modelRepository.Name = "PWA";
            modelRoot.Repositories.Add(modelRepository);
            //modelRepository.ReferenceRepositoryModel
        }

        [Fact]
        public void ModelRoot_Json_Test() {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddOfaSchlupferModel();
            services.AddOfaSchlupferEntity();
            //services.AddHttpClient((builder) => { });
            var serviceProvider = services.BuildServiceProvider();
            string jsonModelRoot = null;
            object modelRoot1 = null;
            object modelRoot2 = null;
            {
                using (var scope = serviceProvider.CreateScope()) {
                    var scopedServiceProvider = scope.ServiceProvider;
                    var modelRoot = scopedServiceProvider.GetRequiredService<ModelRoot>();
                    modelRoot.Name = "Gna";
                    Assert.NotNull(modelRoot.ServiceProvider);
                    var modelRepository = modelRoot.CreateRepository("Hugo", null);
                    Assert.Equal(1, modelRoot.Repositories.Count);

                    var settings = new JsonSerializerSettings();
                    settings.Formatting = Formatting.Indented;
                    jsonModelRoot = modelRoot.SerializeToJson(settings);
                    Assert.Contains("Gna", jsonModelRoot);
                    Assert.Contains("Hugo", jsonModelRoot);
                    modelRoot1 = modelRoot;
                }
            }
            {
                using (var scope = serviceProvider.CreateScope()) {
                    var scopedServiceProvider = scope.ServiceProvider;
                    var modelRoot = ModelRoot.DeserializeFromJson(jsonModelRoot, null, scopedServiceProvider);
                    Assert.NotNull(modelRoot.ServiceProvider);
                    Assert.Same(scopedServiceProvider, modelRoot.ServiceProvider);
                    Assert.Equal("Gna", modelRoot.Name);
                    Assert.Equal(1, modelRoot.Repositories.Count);
                    Assert.Equal("Hugo", modelRoot.Repositories[0].Name);
                    Assert.Same(modelRoot, modelRoot.Repositories[0].Owner);

                    var modelRootAgain = scopedServiceProvider.GetRequiredService<ModelRoot>();
                    Assert.Same(modelRoot, modelRootAgain);
                    modelRoot2 = modelRoot;
                }
            }

            // to ensure scoping works
            Assert.NotSame(modelRoot1, modelRoot2);
        }
    }
}
