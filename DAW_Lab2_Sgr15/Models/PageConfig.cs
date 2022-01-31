using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Lab2_Sgr15.Models
{
    public class PageConfig
    {
        public int Id { get; set; }
        public string BackgroundColor{ get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
