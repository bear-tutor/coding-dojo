using System.Collections.Generic;

namespace WebApi.Models
{
    public class StudentExamResult
    {
        public string StudentName { get; set; }
        public List<CourseExamResult> Courses { get; set; }
    }

    public class CourseExamResult
    {
        public string Name { get; set; }
        public double Credit { get; set; }
        public string Grade { get; set; }
    }
}