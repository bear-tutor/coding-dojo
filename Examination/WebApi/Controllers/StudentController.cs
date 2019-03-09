using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController
    {
        public static List<StudentInfo> Students { get; private set; }

        static StudentController()
        {
            Students = new List<StudentInfo>();
        }

        // Create new student
        [HttpPost]
        public void Post([FromBody]StudentInfo newStudent)
        {
            newStudent.Id = Guid.NewGuid().ToString();
            Students.Add(newStudent);
        }

        // Get a student's information by Id
        /*
            ตัว Api (Get a student's information by Id)
            จะถูกนำไปแสดงผลบนมือถือ โดยบนมือถือจะแสดงผลข้อมูลเป็นแบบนี้

            ชื่อนักเรียน: Sakul
            ผลการเรียน
            Computer programming (4 หน่วยกิต) ได้เกรด A
            Basic mathematics (3 หน่วยกิต) ได้เกรด F
            Basic mathematics (3 หน่วยกิต) ได้เกรด C
         */
        [HttpGet("{id}")]
        public StudentExamResult Get(string id)
        {
            // ไปหานักเรียนที่รหัสตรงกันมาซะ
            var selectedStudent = Students.FirstOrDefault(it => it.Id == id);
            if (selectedStudent == null)
            {
                return null;
            }

            var result = new StudentExamResult();
            result.StudentName = selectedStudent.FullName;
            result.Courses = new List<CourseExamResult>();

            // ดึงผลการสอบของนักเรียนคนนั้นๆออกมา
            var examResults = ExamController.ExamResults.Where(it => it.StudentId == id);

            // สร้างผลการสอบ + ตัดเกรด
            foreach (var exam in examResults)
            {
                var selectedCourse = CourseController.Courses.FirstOrDefault(it => it.Id == exam.CourseId);
                var grade = selectedCourse.Criteria.OrderByDescending(it => it.RequiredScore).FirstOrDefault(it => exam.Score >= it.RequiredScore).Grade;

                result.Courses.Add(new CourseExamResult
                {
                    Name = selectedCourse.Name,
                    Credit = selectedCourse.Credit,
                    Grade = grade
                });
            }

            return result;
        }

        // Get all students
        [HttpGet]
        public IEnumerable<StudentInfo> Get()
        {
            return Students;
        }
        // TODO: (Optional) Update student by Id
        // TODO: (Optional) Delete student by Id
    }
}