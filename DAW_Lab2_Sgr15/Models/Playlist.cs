using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Lab2_Sgr15.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs{ get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
