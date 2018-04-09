namespace OfaSchlupfer.ModelSharePointOnline {
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.SharePoint.Client;

    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.Model;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISPORepositoryModel : IReferenceRepositoryModel {
    }

    public class SPORepositoryModelType : ReferenceRepositoryModelType {
        public SPORepositoryModelType(
            IServiceProvider serviceProvider, 
            IHttpClientDispatcherFactory httpClientDispatcherFactory
            ) : base(serviceProvider, httpClientDispatcherFactory) {
            this.Name = "SPO";
            this.Description = "Read access to SharePointOnline sources.";
        }

        public override IReferenceRepositoryModel CreateReferenceRepositoryModel() {
            try {
                return this.ServiceProvider.GetRequiredService<ISPORepositoryModel>();
            } catch {
                return new SPORepositoryModel();
            }
        }
    }

    public class SPORepositoryModel : ISPORepositoryModel, IReferenceRepositoryModel {
        public SPORepositoryModel() {
        }

        public RepositoryConnectionString ConnectionString { get; set; }
        public ModelRepository ModelRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ModelSchema ModelSchema { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ModelDefinition ModelDefinition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Microsoft.ProjectServer.Client.ProjectContext GetProjectContext() {
            var projectContext = new Microsoft.ProjectServer.Client.ProjectContext(this.ConnectionString.Url);
            var securePassword = new System.Security.SecureString();
            foreach (var c in this.ConnectionString.Password) securePassword.AppendChar(c);
            var onlineCredentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(this.ConnectionString.User, securePassword);
            projectContext.Credentials = onlineCredentials;
            string authCookieValue = onlineCredentials.GetAuthenticationCookie(new Uri(this.ConnectionString.Url));
            if (authCookieValue != null && authCookieValue.StartsWith("SPOIDCRL=")) {
                authCookieValue = authCookieValue.Substring("SPOIDCRL=".Length);
            }
            var site = projectContext.Site;
            projectContext.Load(site);
            projectContext.ExecuteQuery();
            return projectContext;
        }
        // http://tomaszrabinski.pl/wordpress/2013/03/18/connecting-to-office-365-using-client-side-object-model-and-web-services/

        public async Task<List<Microsoft.ProjectServer.Client.PublishedProject>> ReadProjectListAsync(Microsoft.ProjectServer.Client.ProjectContext projectContext) {
            if (projectContext == null) {
                projectContext = GetProjectContext();
            }

            var projects = projectContext.Projects;
            projectContext.Load(projects);
            var executeQueryTask = projectContext.ExecuteQueryAsync();
            await executeQueryTask;
            var result = new List<Microsoft.ProjectServer.Client.PublishedProject>();
            foreach (Microsoft.ProjectServer.Client.PublishedProject publishedProject in projectContext.Projects) {
                result.Add(publishedProject);
            }
            return result;
        }

        public List<Microsoft.ProjectServer.Client.PublishedProject> ReadProjectList(Microsoft.ProjectServer.Client.ProjectContext projectContext) {
            if (projectContext == null) {
                projectContext = GetProjectContext();
            }
            projectContext.DisableReturnValueCache = true;

            //projectContext.Phases
            //projectContext.Stages
            //projectContext.Calendars
            //projectContext.EnterpriseProjectTypes
            //projectContext.EnterpriseResources
            //projectContext.EntityTypes
            //projectContext.LookupTables
            //projectContext.ProjectDetailPages
            //projectContext.ServerVersion
            //projectContext.TimeSheetPeriods
            //projectContext.WorkflowActivities

            var projectsToLoad = projectContext.Projects.IncludeWithDefaultProperties();
            var projectsLoaded = projectContext.LoadQuery(projectsToLoad);
            projectContext.ExecuteQuery();
            var result = new List<Microsoft.ProjectServer.Client.PublishedProject>();
            foreach (Microsoft.ProjectServer.Client.PublishedProject publishedProject in projectsLoaded) {
                result.Add(publishedProject);
            }
            return result;
        }

        public async Task<object> ReadProjectAsync(Microsoft.ProjectServer.Client.ProjectContext projectContext, Guid projectId) {
            if (projectContext == null) {
                projectContext = GetProjectContext();
            }

            var project = projectContext.Projects.GetByGuid(projectId);
            projectContext.Load(project);

            var assignmentsToLoad = project.Assignments.IncludeWithDefaultProperties();
            var assignmentsLoaded = projectContext.LoadQuery(assignmentsToLoad);
            var executeQueryTask = projectContext.ExecuteQueryAsync();
            await executeQueryTask;
            return null;
        }

        public List<string> BuildSchema(string metadataContent) {
            throw new NotImplementedException();
        }
    }
}
