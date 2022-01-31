using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Lab2_Sgr15.Models
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
