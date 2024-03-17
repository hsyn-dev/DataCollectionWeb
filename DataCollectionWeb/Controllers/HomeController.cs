using DataCollectionWeb.Models;
using DataCollectionWeb.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;
namespace DataCollectionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataCollectionDbContext _db;
        private readonly IWebHostEnvironment _env;
        public HomeController(ILogger<HomeController> logger, DataCollectionDbContext db, IWebHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserTable userform)
        {
            if (ModelState.IsValid)
            {
                _db.Add(userform);

                _db.SaveChanges();
 
                return RedirectToAction("Guid");
            }
            return View();
        }
        //Guid  action  : 
        [HttpGet]
        public IActionResult Guid(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Guid(UserTable userTable)
        {
          
            return RedirectToAction("RecordPage");
        }
        // recordpage action  : 

        public IActionResult RecordPage(int id, UserStoryTable userStory, int currentIndex = 0)
        {
            string wwwrootPath = Path.Combine(_env.WebRootPath, "StoriesAudio");
            var audioFileContent = Directory.GetFiles(wwwrootPath).Select(Path.GetFileName).ToArray();
            if (currentIndex >= audioFileContent.Length)
            {
              
                return RedirectToAction("TestPage");
            }
            ViewBag.CurrentIndex = currentIndex;
            ViewBag.AudioFileContent = audioFileContent[currentIndex];
            ViewBag.TotalFilesCount = audioFileContent.Length;  
            return View(userStory);
        }
        [HttpPost]
        public IActionResult RecordPage(string data, UserStoryTable userStoryTable, StoryTable storyTable, UserTable userTable, IFormFile audioFile, int currentIndex = 0)
        {

            if (audioFile != null && audioFile.Length > 0)
            {
                string wwwrootPath = Path.Combine(_env.WebRootPath, "audiorecordsaved");
                string fileName = System.Guid.NewGuid().ToString() + Path.GetExtension(audioFile.FileName);
                string filePath = Path.Combine(wwwrootPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    audioFile.CopyTo(stream);
                }
                int number;

                if (!int.TryParse(data, out number))
                {
                  

                    return BadRequest("Invalid data format. Please provide a valid integer.");
                }
                int lastUserId = _db.UserTables.OrderByDescending(u => u.UserId).Select(u => u.UserId).FirstOrDefault();
                var test = new UserStoryTable()
                {
                    UserId = lastUserId,
                    StoryId = number,
                    StoryRecorded = fileName
                };
                _db.UserStoryTables.Add(test);
                _db.SaveChanges();
                return RedirectToAction("Index", "Question", new { currentIndex = currentIndex + 1 });
            }
            return RedirectToAction("Index" );
        }
    }
}