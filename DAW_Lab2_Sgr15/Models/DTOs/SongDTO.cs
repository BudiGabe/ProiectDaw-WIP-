using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Lab2_Sgr15.Models.DTOs
{
    public class SongDTO
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public List<User> Users{ get; set; }
        public List<Playlist> Playlists { get; set; }

        public SongDTO(Song song)
        {
            this.SongId = song.SongId;
            this.Name = song.Name;
            this.Popularity = song.Popularity;
            this.Users = new List<User>();
            this.Playlists = new List<Playlist>();
        }
    }
}
