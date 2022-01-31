using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Models;

namespace DAW_Lab2_Sgr15.Repositories
{
    public interface ISessionTokenRepository: IGenericRepository<SessionToken>
    {
        Task<SessionToken> GetByJTI(string jti);
    }
}
