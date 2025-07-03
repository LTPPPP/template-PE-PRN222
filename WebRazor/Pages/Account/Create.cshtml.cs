using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Data;
using DAL.Models;
using BLL.Services.Interfaces;

namespace WebRazor.Pages.Account
{
    public class CreateModel : PageModel
    {
        //private readonly DAL.Data.MainContext _context;

        private readonly IAccountService _accountService;

        //public CreateModel(DAL.Data.MainContext context)
        //{
        //    _context = context;
        //}

        public CreateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DAL.Models.Account Account { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Account.Add(Account);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _accountService.AddAsync(Account);
            return RedirectToPage("./Index");
        }
    }
}
