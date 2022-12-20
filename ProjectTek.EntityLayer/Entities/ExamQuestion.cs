using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.EntityLayer.Entities
{
    public class ExamQuestion:BaseEntity
    {
        public ExamQuestion()
        {
          answers=new HashSet<Answer>();
        }

        public int ExamId { get; set; }
 
        public string Question { get; set; }

        public Exam exam { get; set; }
        
        public ICollection<Answer> answers { get; set; }    
    }
}
