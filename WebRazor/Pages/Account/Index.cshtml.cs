using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;
using BLL.Services.Interfaces;

namespace WebRazor.Pages.Account
{
    public class IndexModel : PageModel
    {
        //private readonly MainContext _context;
        private readonly IAccountService _accountService;

        //public IndexModel(MainContext context)
        //{
        //    _context = context;
        //}

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<DAL.Models.Account> Account { get; set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    Account = await _context.Account.ToListAsync();
        //}

        public async Task OnGetAsync()
        {
            var accounts = await _accountService.GetAllAsync();
            Account = accounts.ToList();
        }
    }
}
