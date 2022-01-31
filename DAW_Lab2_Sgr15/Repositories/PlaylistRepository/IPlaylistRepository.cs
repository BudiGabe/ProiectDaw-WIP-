using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Models;
using DAW_Lab2_Sgr15.Repositories;

namespace DAW_Lab2_Sgr15.Repositories
{
    public interface IPlaylistRepository: IGenericRepository<Playlist>
    {
        public Task<List<Playlist>> GetAllPlaylistsOfSong();
        public Task<List<Playlist>> GetAllPlaylistsOfUser(int userId);
        public Task<bool> AddSongToPlaylist(Playlist playlist, int songId);

    }
}
