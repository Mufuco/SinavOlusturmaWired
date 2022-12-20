using Microsoft.AspNetCore.Mvc;
using ProjectTek.CoreLayer.Repositoires.ExamRep;
using ProjectTek.EntityLayer.Entities;

namespace ProjectTek.Controllers
{
    public class ExamController : Controller
    {
        readonly private IExamReadRepository _examRead;
        readonly private IExamWriteRepository _examWrite;

        public ExamController(IExamReadRepository examRead, IExamWriteRepository examWrite)
        {
            _examRead = examRead;
            _examWrite = examWrite;
        }

        [HttpGet]
        public ActionResult AddExam()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddExam(string TitleTd, int TitleTr, string True4, string True3, string True2, string True1, string Question1, string Question2, string Question3, string Question4, string[] Answer1, string[] Answer2, string[] Answer3, string[] Answer4)
        {
            
            ExamQuestion quest1 = new() { Question = Question1, ExamId = 2 };
            ExamQuestion quest2 = new() { Question = Question2, ExamId = 2 };
            ExamQuestion quest3 = new() { Question = Question3, ExamId = 2 };
            ExamQuestion quest4 = new() { Question = Question4, ExamId = 2 };


            foreach (var item in Answer1)
            {
                if (item == True1)
                {
                    quest1.answers.Add(new()
                    {
                        QuestionAnswer =item,
                        State = true

                    });
                }
                else
                    quest1.answers.Add(new()
                    {
                        QuestionAnswer = item,
                        State = false

                    });
            }


            foreach (var item in Answer2)
            {
                if (item == True2)
                {
                    quest2.answers.Add(new()
                    {
                        QuestionAnswer = item,
                        State = true

                    });
                }
                else
                    quest2.answers.Add(new()
                    {
                        QuestionAnswer = item,
                        State = false

                    });
            }


            foreach (var item in Answer3)
            {
                if (item == True3)
                {
                    quest3.answers.Add(new()
                    {
                        QuestionAnswer = item,
                        State = true

                    });
                }
                else
                    quest3.answers.Add(new()
                    {
                        QuestionAnswer = item,
                        State = false

                    });
            }


            foreach (var item in Answer4)
            {
                if (item == True4)
                {
                    quest4.answers.Add(new()
                    {
                        QuestionAnswer = item,
                        State = true

                    });
                }
                else
                    quest4.answers.Add(new()
                    {
                        QuestionAnswer = item,
                        State = false
                    });
            }


            Exam exam = new()
            {
                ExamTitle = TitleTd,
                WiredArticleId = TitleTr,
                CreatedDate = DateTime.Now,
                examQuestions = new HashSet<ExamQuestion>
                {
                    quest1,
                    quest2,
                    quest3,
                    quest4,

                }
            };

            _examWrite.Add(exam);
            _examWrite.SaveChanges();

            return View();
            
        }
        [HttpGet]
        public ActionResult ExamList()
        {

            var exams = _examRead.GetAll().ToList();
            return View(exams);
        }
        public IActionResult ExamDelete(int id)
        {
            Exam DeleteItem = _examRead.GetById(id);
            _examWrite.Remove(DeleteItem);
            _examWrite.SaveChanges();
            return RedirectToAction("ExamList", "Exam");
        }

    }
}
