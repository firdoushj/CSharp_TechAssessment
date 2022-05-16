using System;
using System.ComponentModel.DataAnnotations;

namespace ExamApp
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
