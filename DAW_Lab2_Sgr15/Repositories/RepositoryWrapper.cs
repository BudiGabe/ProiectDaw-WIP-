using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Data;
using DAW_Lab2_Sgr15.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace DAW_Lab2_Sgr15.Repositories
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly SongContext _context;
        private IUserRepository _user;
        private ISongRepository _song;
        private IPlaylistRepository _playlist;
        private ISessionTokenRepository _sessionToken;
        public RepositoryWrapper(SongContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public ISongRepository Song
        {
            get
            {
                if (_song == null) _song = new SongRepository(_context);
                return _song;
            }
        }

        public IPlaylistRepository Playlist
        {
            get
            {
                if (_playlist== null) _playlist = new PlaylistRepository(_context);
                return _playlist;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
