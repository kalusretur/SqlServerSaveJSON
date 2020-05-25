using Autofac;
using demoSqlSaveJson.Application.Queries.DemoQueries;

namespace demoSqlSaveJson.Infraestructure.AutofacModule
{
    public class QueriesModule : Autofac.Module
    {
        public string _queriesConnectionString { get; }
        public QueriesModule(string queriesConnectionString) => _queriesConnectionString = queriesConnectionString;

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new DemoQueries(_queriesConnectionString)).As<IDemoQueries>().InstancePerLifetimeScope();
        }
    }
}
