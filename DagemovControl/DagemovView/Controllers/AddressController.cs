using DagemovView.Data;
using DagemovView.Data.Entities;
using DagemovView.Models.Address;
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
        /*
                CRUD COUNTRIES        
         */
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
            if (ModelState.IsValid)
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
        public async Task<IActionResult> CountryDetails(int? id)
        {
            
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }          
            var country = await _context.Countries
                .Include(s=>s.States)
                .ThenInclude(c=>c.Citys)
                .ThenInclude(st=>st.Streets)
                .FirstOrDefaultAsync( c=> c.Id == id);
            if (country==null)
            {
                return NotFound();
            }
            return View(country);
        }
        [HttpGet]
        public async Task<IActionResult> CountryDelete(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }
            var country = await _context.Countries
               .Include(s => s.States)
               .ThenInclude(c => c.Citys)
               .ThenInclude(st => st.Streets)
               .FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CountryDelete(int id)
        {
            if (_context.Countries == null)
            {
                return Problem("Entity set 'DataContext.Countries'  is null.");
            }
            var country = await _context.Countries.FindAsync(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> CountryEdit(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }
            var country = await _context.Countries
               .Include(s => s.States)
               .ThenInclude(c => c.Citys)
               .ThenInclude(st => st.Streets)
               .FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CountryEdit(int? id,Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Update(country);
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
        /*
            CRUD STATES         
         */
        [HttpGet]
        public async Task<IActionResult> CreateState(int? id)
        {            
            if(id == null)
            {
                return NotFound();
            }

            Country country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            AddState model = new()
            {
                CountryId = country.Id,
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateState(AddState model)
        {
            if (ModelState.IsValid)
            {                               
                State state = new()
                {
                    Citys= new List<City>(),
                    Country=await _context.Countries.FindAsync(model.CountryId),
                    Name=model.Name,
                };

                _context.Add(state);
                try{
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(CountryDetails), new { Id = model.CountryId });
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
            return View(model);
        }
    }
}
