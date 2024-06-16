using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WriteOffDebts.Data;
using WriteOffDebts.Models;

namespace WriteOffDebts.Controllers
{
    public class DebtorController : Controller
    {
        private readonly AppDbContext _context;

        public DebtorController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Debtors()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddDebtor()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddDebtor(AddDebtorModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelStateValue in ModelState.Values)
                    foreach (var error in modelStateValue.Errors)
                        Console.WriteLine(error.ErrorMessage);

                return View(model);
            }

            // Получаем текущего пользователя
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.Include(u => u.Debtors).FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return Unauthorized();
            }

            var debtor = new DebtorModel
            {
                FullName = model.FullName,
                DebtAmount = model.DebtAmount,
                InterestRate = model.InterestRate,
                DebtDate = model.DebtDate,
                PhotoPath = model.PhotoPath,
                UserId = user.Id
            };

            _context.Debtors.Add(debtor);
            await _context.SaveChangesAsync();

            return RedirectToAction("Personal", "User");
        }

        [HttpPost]
        public async Task<IActionResult> GoToPay(int debtorId)
        {
            var debtor = await _context.Debtors.FindAsync(debtorId);

            _context.Debtors.Remove(debtor);
            await _context.SaveChangesAsync();

            return RedirectToAction("Pay", "Pay");
        }
    }
}