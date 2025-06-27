using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CORE.entities
{
    public class Users
    {
        public int Id { get; set; }
    
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string ?Email { get; set; }
        public int Age { get; set; }
        public int AgeGoupId { get; set; } //צריך להגדיר FK
        public int TotalPoints { get; set; }    
        public int Level { get; set; }
        public string? Role { get; set; } = "user";
        public DateTime CraetedTime { get; set; }

    }
}
