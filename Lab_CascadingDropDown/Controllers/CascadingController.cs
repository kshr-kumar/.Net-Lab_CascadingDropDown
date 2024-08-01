using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CascadingController : Controller
    {

        AppDbContext _db;
        public CascadingController(AppDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult Country() 
        {
            var co = _db.Countries.ToList();
            return new JsonResult(co); 
        }
        public JsonResult City(int id) 
        {
            var ci = _db.Cities.Where(e => e.Country.CountryId == id).ToList(); 
            return new JsonResult(ci); 
        }
    }
}
