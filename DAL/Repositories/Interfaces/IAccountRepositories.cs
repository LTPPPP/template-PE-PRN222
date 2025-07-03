using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IAccountRepositories
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(object id);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(object id);

    }
}
