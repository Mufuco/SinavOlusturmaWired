using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.EntityLayer.Entities
{
    public class Answer:BaseEntity
    {
        public string QuestionAnswer { get; set; }

        
        public int ExamQuestionId { get; set; }
        public bool State { get; set; }

        public ExamQuestion examQuestion { get; set; }  
    }
}
