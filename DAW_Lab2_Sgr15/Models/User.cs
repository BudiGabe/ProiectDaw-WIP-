using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAW_Lab2_Sgr15.Models
{
    public class User: IdentityUser<int>
    {
        public string Name { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public ICollection<UserSong> UserSongs { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public User(): base()
        {
            
        }
    }
}
