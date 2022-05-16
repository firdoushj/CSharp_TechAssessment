using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamApp
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual Language Language { get; set; }
    }
}
