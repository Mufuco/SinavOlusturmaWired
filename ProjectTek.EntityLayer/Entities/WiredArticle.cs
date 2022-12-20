using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.EntityLayer.Entities
{
    public class WiredArticle:BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public string Link { get; set; }

        public ICollection<Exam> exams { get; set; }    

    }
}
