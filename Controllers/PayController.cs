using Microsoft.AspNetCore.Mvc;
using WriteOffDebts.Models;

namespace WriteOffDebts.Controllers
{
    public class PayController : Controller
    {
        [HttpGet]
        public IActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pay(PayModel model, int? debtorId)
        {
            Console.WriteLine("Я ЗАПУСТИЛСЯ");
            return RedirectToAction("Debtors", "Debtor");
        }
    }
}