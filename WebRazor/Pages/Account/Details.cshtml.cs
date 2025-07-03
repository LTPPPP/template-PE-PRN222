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
    public class DetailsModel : PageModel
    {
        //private readonly DAL.Data.MainContext _context;
        private readonly IAccountService _accountService;
        //public DetailsModel(DAL.Data.MainContext context)
        //{
        //    _context = context;
        //}

        public DetailsModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public DAL.Models.Account Account { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var account = await _context.Account.FirstOrDefaultAsync(m => m.Id == id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        Account = account;
        //    }
        //    return Page();
        //}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = await _accountService.GetByIdAsync(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }
    }
}
