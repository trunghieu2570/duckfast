using DuckFast.Database;
using DuckFast.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckFast.Common.Services
{
    public interface IUserAccountService
    {
        public Task<IEnumerable<UserAccount>> GetUserAccounts();
        public Task<UserAccount?> GetUserAccount(string id);
        public Task<UserAccount> AddUserAccount(UserAccount UserAccount);
        public Task DeleteUserAccount(string id);
        public Task<UserAccount> UpdateUserAccount(UserAccount UserAccount);
    }
    public class UserAccountService : IUserAccountService
    {
        private readonly DuckFastDataContext _context;

        public UserAccountService(DuckFastDataContext context)
        {
            _context = context;
        }

        public Task<UserAccount> AddUserAccount(UserAccount UserAccount)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAccount(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccount?> GetUserAccount(string id)
        {
            return await _context.UserAccounts!.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserAccount>> GetUserAccounts()
        {
            return await _context.UserAccounts!.ToListAsync();
        }

        public Task<UserAccount> UpdateUserAccount(UserAccount UserAccount)
        {
            throw new NotImplementedException();
        }
    }
}
