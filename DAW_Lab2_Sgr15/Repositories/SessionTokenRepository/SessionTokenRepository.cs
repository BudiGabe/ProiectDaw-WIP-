using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Data;
using DAW_Lab2_Sgr15.Models;
using Microsoft.EntityFrameworkCore;

namespace DAW_Lab2_Sgr15.Repositories
{
    public class SessionTokenRepository: GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(SongContext context) : base(context)
        {

        }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
