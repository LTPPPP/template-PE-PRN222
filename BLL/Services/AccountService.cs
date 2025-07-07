using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
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
        private readonly HubConnection? _connection;
        private bool _connected = false;

        public AccountService(IAccountRepositories repo)
        {
            _repo = repo;

            // Setup SignalR client connection for external notifications
            try
            {
                _connection = new HubConnectionBuilder()
                    .WithUrl("http://localhost:7075/DataSignalRChanel")
                    .Build();
            }
            catch
            {
                _connection = null;
            }
        }

        public async Task AddAsync(Account item)
        {
            await _repo.AddAsync(item);
        }

        public async Task DeleteAsync(object id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Account> GetByIdAsync(object id) => await _repo.GetByIdAsync(id);

        public async Task UpdateAsync(Account item)
        {
            await _repo.UpdateAsync(item);
        }

        public async Task NotifyLoadAsync()
        {
            if (_connection != null)
            {
                try
                {
                    if (!_connected || _connection.State != HubConnectionState.Connected)
                    {
                        await _connection.StartAsync();
                        _connected = true;
                    }

                    await _connection.InvokeAsync("SendAllLoad");
                }
                catch (Exception ex)
                {
                    // Log error or handle as needed
                    Console.WriteLine($"SignalR notification failed: {ex.Message}");
                }
            }
        }
    }
}
