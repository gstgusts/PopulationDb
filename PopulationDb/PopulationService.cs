using Microsoft.Data.SqlClient;
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
        public void GetRegions()
        {
            var connection = new SqlConnection("Data Source=GUSTSASUS\\MSSQLSERVER2;Initial Catalog=Population;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "select * from Region";
            cmd.CommandType = CommandType.Text;

            try { 
                connection.Open();
                Console.WriteLine("Connection opened");

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString("Name"));
                }

                connection.Close();
                Console.WriteLine("Connection closed");
            }
            catch (Exception ex) {
                throw;  
            }

        }
    }
}
