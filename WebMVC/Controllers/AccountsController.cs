using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;
using BLL.Services.Interfaces;

namespace WebMVC.Controllers
{
    public class AccountsController : Controller
    {
        //private readonly MainContext _context;
        private readonly IAccountService _accountService;

        //public AccountsController(MainContext context)
        //{
        //    _context = context;
        //}

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Accounts
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Account.ToListAsync());
        //}

        public async Task<IActionResult> Index()
        {
            var accounts = await _accountService.GetAllAsync();
            return View(accounts);
        }

        // GET: Accounts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var account = await _context.Account
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(account);
        //}

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = await _accountService.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }


        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Email,PasswordHash,CreatedAt,UpdatedAt")] Account account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(account);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(account);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PasswordHash,CreatedAt,UpdatedAt")] Account account)
        {
            if (ModelState.IsValid)
            {
                await _accountService.AddAsync(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var account = await _context.Account.FindAsync(id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(account);
        //}

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = await _accountService.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PasswordHash,CreatedAt,UpdatedAt")] Account account)
        //{
        //    if (id != account.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(account);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AccountExists(account.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(account);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PasswordHash,CreatedAt,UpdatedAt")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _accountService.UpdateAsync(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AccountExists(account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var account = await _context.Account
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(account);
        //}

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = await _accountService.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var account = await _context.Account.FindAsync(id);
        //    if (account != null)
        //    {
        //        _context.Account.Remove(account);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account != null)
            {
                await _accountService.DeleteAsync(account);
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool AccountExists(int id)
        //{
        //    return _context.Account.Any(e => e.Id == id);
        //}
        private async Task<bool> AccountExists(int id)
        {
            return await _accountService.GetByIdAsync(id) != null;
        }
    }
}
