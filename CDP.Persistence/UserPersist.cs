using Microsoft.EntityFrameworkCore;
using CDP.Domain.Identity;
using CDP.Persistence.Context;
using CDP.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDP.Persistence
{
    public class UserPersist : GeralPersist, IUserPersist
    {
        private readonly CDPContext _context;
        public UserPersist(CDPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username.ToLower());
        }
    }
}
