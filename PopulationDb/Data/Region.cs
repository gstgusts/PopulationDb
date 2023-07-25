using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationDb.Data
{
    public class Region
    {
        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
