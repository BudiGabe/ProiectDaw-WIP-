using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Lab2_Sgr15.Models.DTOs
{
    public class PlaylistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlaylistSong> PlaylistSongs { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public PlaylistDTO(Playlist playlist)
        {
            Id = playlist.Id;
            Name = playlist.Name;
            UserId = playlist.UserId;
            User = new User();
            PlaylistSongs = new List<PlaylistSong>(playlist.PlaylistSongs);
        }
    }
}
