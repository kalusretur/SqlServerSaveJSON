using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace demoSqlSaveJson.Application.Queries.DemoQueries
{
    public class DemoQueries : IDemoQueries
    {
        private string _connectionString = string.Empty;
        public DemoQueries(string constr) => _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentException(nameof(constr));


        public async Task<int> SaveJson(string model)
        {
            var result = default(int);
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    await cn.OpenAsync();
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@json", model);
                    var demo = await cn.ExecuteAsync("SP_SaveJsonDB", queryParameters, commandType: CommandType.StoredProcedure);
                }

                result = 1;
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return result;
        }
    }
}
