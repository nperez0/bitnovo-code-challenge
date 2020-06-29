using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bitnovo.Common;
using Bitnovo.Customers.Domain.Aggregates;

namespace Bitnovo.Customers.Infrastructure.Data
{
    public class CustomerRespository : ICustomerRepository
    {
        readonly Context _context;

        public CustomerRespository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAll()
            => await _context
                .Customers
                .Include(c => c.User)
                .ToListAsync();

        public async Task<Maybe<Customer>> GetById(int id)
            => await _context
                .Customers
                .Include(c => c.User)
                .SingleOrDefaultAsync(c => c.Id == id);

        public async Task Add(Customer customer)
        {
            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Customer customer)
        {
            _context.Customers.Update(customer);

            await _context.SaveChangesAsync();
        }


    }
}
