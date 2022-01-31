using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Data;
using DAW_Lab2_Sgr15.Models;
using DAW_Lab2_Sgr15.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAW_Lab2_Sgr15.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(SongContext context) : base(context) { }

        public async Task<List<User>> GetAllUsersWithPlaylists()
        {
            return await _context.Users.Include(u => u.Playlists).ToListAsync();
        }

        public async Task<User> GetByName(string name)
        {
            return await _context.Users
                .Where(u => u.Name.Equals(name))
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdWithPlaylists(int id)
        {
            return await _context.Users
                .Include(u => u.Playlists)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

        }

        public async Task<bool> AddSongToUser(User user, int songId)
        {
            Song song = await _context.Songs.Include(ps => ps.UserSongs).Where(s => s.SongId == songId).FirstOrDefaultAsync();

            song.UserSongs.Add(new UserSong()
            {
                User = user,
                Song = song
            });

            return true;
        }

        public async Task<User> GetByIdWithRoles(int id)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<User> GetByIdWithInfo(int id)
        {
            return await _context.Users
                .Include(u => u.PersonalInfo)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
