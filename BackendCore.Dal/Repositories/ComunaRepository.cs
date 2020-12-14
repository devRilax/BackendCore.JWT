using BackendCore.Dal.EntityModels;
using BackendCore.Entity;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCore.Dal.Repositories
{
    public class ComunaRepository : BaseDal
    {
        public ComunaRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<int> CreateWithQuery(Comuna entity)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                string query = @"INSERT INTO Comuna (Description) VALUES (@description)
                                 SELECT SCOPE_IDENTITY()";

                var insert = await connection.QueryAsync<int>(query, new { description = entity.Name });
                return insert.Single();
            }

        }

        public async Task<long> CreateWithSP(Comuna entity)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                string SP_INSERT = "Comuna_Insert";
                var parameters = new { name = entity.Name, createdAt = entity.CreatedAt };

                var insert =  await connection.ExecuteScalarAsync<long>(SP_INSERT, parameters, commandType: CommandType.StoredProcedure);

                return insert;
            }

        }

        public async Task<List<Comuna>> All()
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                string SP_ALL = "Comuna_All";
                var result = await connection.QueryAsync<Comuna>(SP_ALL, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<Comuna> ById(long id)
        {
            Comuna find = null;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                string SP_BY_ID = "Comuna_by_id";

                var parametros = new { id = id };
                var result = await connection.QueryAsync<Comuna>(SP_BY_ID, parametros, commandType: CommandType.StoredProcedure);

                find = result.FirstOrDefault();
            }

            return find;
        }

        //dapper contrib
        public async Task TestDapperContrib(ComunaEntity entity)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                //var insert = await connection.InsertAsync(entity);
                //var byId = await connection.GetAsync<ComunaEntity>(25);
                //var all = await connection.GetAllAsync<ComunaEntity>();
                var updated = await connection.UpdateAsync(new ComunaEntity { Id = 25, Name = "Traiguién modificado" });
                var ok = false;
            }

        }
    }
}
