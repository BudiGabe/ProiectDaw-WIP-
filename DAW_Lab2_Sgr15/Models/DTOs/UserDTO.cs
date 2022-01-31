using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Lab2_Sgr15.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserSong> UserSongs { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public List<Playlist> Playlists { get; set; }

        public UserDTO(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.PersonalInfo = user.PersonalInfo;
            this.Playlists = new List<Playlist>();
            this.UserSongs = new List<UserSong>();
        }
    }
}
