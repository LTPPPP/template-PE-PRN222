using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AccountRepositories : IAccountRepositories
    {
        private readonly MainContext _context;

        public AccountRepositories(MainContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Account item)
        {
            await _context.Account.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var item = await _context.Account.FindAsync(id);
            if (item != null)
            {
                _context.Account.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(object id)
        {
            return await _context.Account.FindAsync(id);
        }

        public async Task UpdateAsync(Account item)
        {
            _context.Account.Update(item);
            await _context.SaveChangesAsync();
        }
    }

}
