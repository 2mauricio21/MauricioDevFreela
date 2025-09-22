using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<SkillDTO>> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT ID, Description FROM Skills";

                var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

                return skills.ToList();
            }
        }
    }
}
