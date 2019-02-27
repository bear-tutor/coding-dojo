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

        // TODO: Create new student
        // TODO: Get a student's information by Id
        /*
            ตัว Api (Get a student's information by Id)
            จะถูกนำไปแสดงผลบนมือถือ โดยบนมือถือจะแสดงผลข้อมูลเป็นแบบนี้

            ชื่อนักเรียน: Sakul
            ผลการเรียน
            Computer programming (4 หน่วยกิต) ได้เกรด A
            Basic mathematics (3 หน่วยกิต) ได้เกรด F
            Basic mathematics (3 หน่วยกิต) ได้เกรด C
         */

        // TODO: (Optional) Get all students
        // TODO: (Optional) Update student by Id
        // TODO: (Optional) Delete student by Id
    }
}