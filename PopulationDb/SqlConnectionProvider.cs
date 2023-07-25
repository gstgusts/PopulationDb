using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace PopulationDb
{
    public class SqlConnectionProvider
    {
        private string _connectionString;
        public SqlConnectionProvider()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            _connectionString = configuration.GetConnectionString("PopulationDbConnectionString");
        }

        public SqlConnection GetConnection()
        { 
            return new SqlConnection(_connectionString);
        }
    }
}
