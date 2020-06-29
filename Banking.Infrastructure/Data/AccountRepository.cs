using Bitnovo.Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitnovo.Banking.Infrastructure.Data
{
    public class AccountRepository : IAccountRepository
    {
        readonly Context _context;

        public AccountRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetByCustomerIds(IEnumerable<int> customerIds)
             => await _context.Accounts
                    .Where(a => customerIds.Contains(a.Id))
                    .ToListAsync();
    }
}
