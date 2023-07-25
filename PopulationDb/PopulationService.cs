using Microsoft.Data.SqlClient;
using PopulationDb.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationDb
{
    public class PopulationService
    {
        private readonly SqlConnectionProvider _connectionProvider;
        public PopulationService()
        {
            _connectionProvider = new SqlConnectionProvider();
        }

        public IEnumerable<Region> GetRegions()
        {
            return ExecuteSql("select * from Region");
        }

        public Region? GetRegionById(int id)
        {
            var parameters = new Dictionary<string, object>
              {
                  { "@id", id}
              };

            var regions = ExecuteSql("select * from Region where Id=@id", parameters);

            return regions.FirstOrDefault();
        }

        public IEnumerable<Region> GetRegionsByName(string name)
        {
            var parameters = new Dictionary<string, object>
              {
                  { "@name", $"%{name}%"}
              };

            return ExecuteSql("select * from Region where Name like @name", parameters);
        }

        private IEnumerable<Region> ExecuteSql(string sql, Dictionary<string, object>? parameters = null)
        {
            var connection = _connectionProvider.GetConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            if (parameters != null && parameters.Any())
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            try
            {
                connection.Open();

                var reader = cmd.ExecuteReader();

                var items = new List<Region>();

                while (reader.Read())
                {
                    items.Add(new Region(reader.GetInt32("Id"), reader.GetString("Name")));
                }

                connection.Close();

                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
