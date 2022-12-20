using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTek.CoreLayer.Repositoires.ExamQuesitonRep;

namespace ProjectTek.Controllers
{
    public class ExamQuestionController : Controller
    {
       private readonly IExamQuestionReadRepository _questionRead;

        public ExamQuestionController(IExamQuestionReadRepository questionRead)
        {
            _questionRead = questionRead;
        }

        public IActionResult SolveExam(int id)
        {
            var list = _questionRead.GetAll().Where(x=>x.ExamId==id).Include(a => a.answers).ToList();
           
            
            int wiredId = _questionRead.GetAll().Include(x => x.exam).FirstOrDefault(a => a.ExamId == id).exam.WiredArticleId;
            ViewBag.i = wiredId;
            
           
            return View(list);
        }
    }
}
