using demoSqlSaveJson.Application.ViewModel;
using System.Threading.Tasks;

namespace demoSqlSaveJson.Application.Queries.DemoQueries
{
    public interface IDemoQueries
    {
        Task<int> SaveJson(string model);
    }
}
