using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepositories _repo;

        public AccountService(IAccountRepositories repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(Account item) => await _repo.AddAsync(item);
        public async Task DeleteAsync(object id) => await _repo.DeleteAsync(id);
        public async Task<IEnumerable<Account>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Account> GetByIdAsync(object id) => await _repo.GetByIdAsync(id);
        public async Task UpdateAsync(Account item) => await _repo.UpdateAsync(item);
    }

}
