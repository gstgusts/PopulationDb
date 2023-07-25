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
            var connection = _connectionProvider.GetConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "select * from Region";
            cmd.CommandType = CommandType.Text;

            try { 
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
            catch (Exception ex) {
                throw;  
            }

        }

        public Region? GetRegionById(int id)
        {
            var connection = _connectionProvider.GetConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "select * from Region where Id=@id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();

                var reader = cmd.ExecuteReader();

                Region? region = null;

                while (reader.Read())
                {
                    region = new Region(reader.GetInt32("Id"), reader.GetString("Name"));
                }

                connection.Close();

                return region;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Region> GetRegionsByName(string name)
        {
            var connection = _connectionProvider.GetConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "select * from Region where Name like @name";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@name", $"%{name}%");

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
