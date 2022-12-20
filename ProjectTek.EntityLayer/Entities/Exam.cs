using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.EntityLayer.Entities
{
    public class Exam:BaseEntity
    {
        public Exam() {
            examQuestions = new HashSet<ExamQuestion>();
        }
        public string ExamTitle { get; set; }
        public DateTime CreatedDate { get; set; }

        public WiredArticle Article { get; set; }
        public int WiredArticleId { get; set; }

        public ICollection<ExamQuestion> examQuestions { get; set; }    
    }
}
