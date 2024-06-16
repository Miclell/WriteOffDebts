using Microsoft.AspNetCore.Mvc;
using WriteOffDebts.Models;
using System.Linq;
using System.Security.Claims;
using WriteOffDebts.Data;

namespace WriteOffDebts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtorApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DebtorApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DebtorApi
        [HttpGet]
        public ActionResult<IEnumerable<DebtorModel>> GetDebtors()
        {
            // Получаем текущего пользователя
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Возвращаем должников только для текущего пользователя
            return _context.Debtors.Where(d => d.UserId == userId).ToList();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<DebtorModel>> GetAllDebtors()
        {
            // Возвращаем всех должников из базы данных
            return _context.Debtors.ToList();
        }
    }
}
