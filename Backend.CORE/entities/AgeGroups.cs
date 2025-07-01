using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CORE.entities
{
    public class AgeGroups
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string ?Description { get; set; }
        public  int MinAge { get; set; }
        public int MaxAge { get; set; }

    }
}
