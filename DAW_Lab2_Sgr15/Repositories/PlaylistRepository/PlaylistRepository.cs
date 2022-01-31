using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Data;
using DAW_Lab2_Sgr15.Models;
using DAW_Lab2_Sgr15.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAW_Lab2_Sgr15.Repositories
{
    public class PlaylistRepository: GenericRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(SongContext context): base(context) { }


        public Task<List<Playlist>> GetAllPlaylistsOfSong()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Playlist>> GetAllPlaylistsOfUser(int userId)
        {
            return await _context.Playlists
                .Include(p => p.PlaylistSongs)
                .ThenInclude(ps => ps.Song)
                .Where(pl => pl.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> AddSongToPlaylist(Playlist playlist, int songId)
        {
            Song song = await _context.Songs.Include(ps => ps.PlaylistSongs).Where(s => s.SongId == songId).FirstOrDefaultAsync();

            song.PlaylistSongs.Add(new PlaylistSong()
            {
                Playlist = playlist,
                Song = song
            });

            return true;
        }
    }
}
