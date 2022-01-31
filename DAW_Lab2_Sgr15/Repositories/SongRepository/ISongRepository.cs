using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Models;
using DAW_Lab2_Sgr15.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace DAW_Lab2_Sgr15.Repositories
{
    public interface ISongRepository: IGenericRepository<Song>
    {
        public Task<List<Song>> GetSongsOfUser(int id);
        public Task<List<User>> GetUsersOfSong(int songId);
        public Task<List<Song>> GetSongsOfPlaylist(int id);
        public Task<Song> GetByName(string name);
        public Task<bool> CheckIfExists(string name);
    }
}
