using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Data;
using DAW_Lab2_Sgr15.Migrations;
using DAW_Lab2_Sgr15.Models;
using DAW_Lab2_Sgr15.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Win32.SafeHandles;


namespace DAW_Lab2_Sgr15.Repositories
{
    public class SongRepository: GenericRepository<Song>, ISongRepository
    {
        public SongRepository(SongContext context) : base(context) { }

        public async Task<List<User>> GetUsersOfSong(int songId)
        {
            return await _context.Songs
                .Join(_context.UserSongs,
                    song => song.SongId,
                    userSong => userSong.SongId,
                    (song, userSong) => new
                    {
                        SongId= userSong.SongId,
                        User = userSong.User
                    }
                )
                .Where(entry => entry.SongId == songId)
                .Select(entry => entry.User)
                .ToListAsync();
        }


        public async Task<List<Song>> GetSongsOfUser(int id)
        {
            return await _context.Songs
                .Join(_context.UserSongs,
                    song => song.SongId,
                    userSong => userSong.SongId,
                    (song, userSong) => new
                    {
                        UserId = userSong.UserId,
                        Song = userSong.Song
                    }
                )
                .Where(entry => entry.UserId == id)
                .Select(entry => entry.Song)
                .ToListAsync();
        }

        public async Task<List<Song>> GetSongsOfPlaylist(int id)
        {
            return await _context.Songs
                .Join(_context.PlaylistSongs,
                    song => song.SongId,
                    ps => ps.SongId,
                    (song, ps) => new
                    {
                        PlaylistId = ps.PlaylistId,
                        Song = ps.Song
                    })
                .Where(entry => entry.PlaylistId == id)
                .Select(entry => entry.Song)
                .ToListAsync();
        }

        public async Task<Song> GetByName(string name)
        {
            return await _context.Songs.Where(song => song.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIfExists(string name)
        {
            return await _context.Songs.AnyAsync(song => song.Name.Equals(name));
        }
    }
}
