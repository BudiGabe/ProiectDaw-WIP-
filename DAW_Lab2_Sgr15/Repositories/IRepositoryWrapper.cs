using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Repositories;

namespace DAW_Lab2_Sgr15.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISongRepository Song { get; }
        IPlaylistRepository Playlist { get; }
        ISessionTokenRepository SessionToken { get; }
        Task SaveAsync();
    }
}
