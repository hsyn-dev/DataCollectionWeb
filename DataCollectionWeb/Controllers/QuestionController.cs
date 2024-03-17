using DataCollectionWeb.Models;
using DataCollectionWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataCollectionWeb.Controllers
{
    public class QuestionController : Controller
    {
        private readonly DataCollectionDbContext _db;
        public QuestionController(DataCollectionDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int Id, QuestionVM questionVM)
        {
            List<QuestionAnswretable> questionTables = new List<QuestionAnswretable>(); 


            //var item2 = _db.QuestionTables.Select(e => e.QuestionneirId).ToList();
            var QAtable = _db.QuestionAnswretables.ToList();


            for (int i = Id; i < 3;)
            {
                if (i == 0)
                {
               
                    ViewBag.firstgroup = _db.QuestionTables
                     .Where(e => e.QuestionneirId == 0)
                     .Select(e => e.Tittle)
                      .ToList();
                    return View( );

                }
                if (i == 1)
                {
                    ViewBag.secondgroup = _db.QuestionTables
                     .Where(e => e.QuestionneirId == 1)
                     .Select(e => e.Tittle)
                      .ToList();
                    return View( );
                }
                if (i == 2)
                {
                    ViewBag.thirdgroup = _db.QuestionTables
                     .Where(e => e.QuestionneirId == 2)
                     .Select(e => e.Tittle)
                      .ToList();
                    return View();
                }


            }


            return RedirectToAction("testpage");

        }

        [HttpPost]
        public IActionResult Index(int id, List<int> QuestionIds, List<int> AnswerIds)
        {
            int lastUserId = _db.UserTables.OrderByDescending(u => u.UserId).Select(u => u.UserId).FirstOrDefault();

            for (int i = 0; i < QuestionIds.Count; i++)
            {
                int questionId = QuestionIds[i];
                int answerId = AnswerIds[i];

                UserQuestionAnswreTable userAnswer = new UserQuestionAnswreTable
                {
                    UserId = lastUserId,
                    QuestionId = questionId,
                    Answer = answerId
                };

                _db.UserQuestionAnswreTables.Add(userAnswer);
            }

            _db.SaveChanges(); // Save changes after adding all user answers

            return RedirectToAction("Index", new { Id = id + 1 });
        }

        public IActionResult testpage()
        {

            return View();
        }

    }
}
