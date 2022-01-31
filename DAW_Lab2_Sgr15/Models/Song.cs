using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Lab2_Sgr15.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }

        public ICollection<UserSong> UserSongs { get; set; }

        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
