using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Lab2_Sgr15.Models.DTOs
{
    public class CreatePlaylistDTO
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
