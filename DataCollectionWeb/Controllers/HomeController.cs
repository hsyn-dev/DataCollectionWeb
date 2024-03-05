using DataCollectionWeb.Models;
using DataCollectionWeb.Models.ViewModel;
 
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataCollectionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataCollectionDbContext _db ;

        public HomeController(ILogger<HomeController> logger , DataCollectionDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }   

        public IActionResult Register()
        {
 
            return View( );
        }
        [HttpPost]
        
        public IActionResult Register(UserTable userform)
        {
            
            if(ModelState.IsValid)
            {
               
                  _db.Add(userform);
                _db.SaveChanges();
              
                int lastUserId = _db.UserTables.OrderByDescending(u => u.UserId).Select(u => u.UserId).FirstOrDefault();

                return RedirectToAction("Guid", new { id = lastUserId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Guid()
        {
            return View(); 
        }

        [HttpPost]
  
        public IActionResult Guid(int id)
        {
            int lastUserId = _db.UserTables.OrderByDescending(u => u.UserId).Select(u => u.UserId).FirstOrDefault();


            return RedirectToAction("Record", new { id = lastUserId });
        }


        public IActionResult Record(int id)
        {
            int lastUserId = _db.UserTables.OrderByDescending(u => u.UserId).Select(u => u.UserId).FirstOrDefault();

            return View(); 
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
