using DagemovView.Data;
using DagemovView.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DagemovView.Controllers
{
    public class AddressController : Controller
    {
        private readonly DataContext _context;

        public AddressController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Countries
                .Include(s=>s.States)
                .ThenInclude(c=>c.Citys)
                .ThenInclude(st=>st.Streets)
                .ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> CreateAddress()
        {
            Adress adress = new Adress()
            {
                Countries = new List<Country>(),
            };
            return View(adress);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAddress(Adress adress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adress);
                try
                {
                    //Implementation only with the users
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Duplicate Adress in this User");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }               
            }
            return View(adress);
        }
        public async Task<IActionResult> CreateCountry()
        {
            Country country = new Country()
            {
                States = new List<State>(),
            };
            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(country);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Duplicate Country Name in dataBase");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(country);
        }
    }
}
