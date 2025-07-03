using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(object id);
        Task AddAsync(Account item);
        Task UpdateAsync(Account item);
        Task DeleteAsync(object id);

    }
}
