using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Models;
using DAW_Lab2_Sgr15.Repositories;

namespace DAW_Lab2_Sgr15.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        public Task<List<User>> GetAllUsersWithPlaylists();
        public Task<User> GetByName(string name);
        public Task<User> GetUserByIdWithPlaylists(int id);
        public Task<bool> AddSongToUser(User user, int songId);
        Task<User> GetByIdWithRoles(int id);
        public Task<User> GetByIdWithInfo(int id);
    }
}
