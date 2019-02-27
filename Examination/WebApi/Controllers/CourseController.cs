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
    public class CourseController
    {
        public static List<CourseInfo> Courses { get; private set; }

        static CourseController()
        {
            Courses = new List<CourseInfo>
            {
                new CourseInfo("c01", "Computer programming", 4)
                {
                    Criteria = new List<ScoringCriteria>
                    {
                        new ScoringCriteria("A", 90),
                        new ScoringCriteria("B", 80),
                        new ScoringCriteria("C", 70),
                        new ScoringCriteria("D", 60),
                        new ScoringCriteria("F", 0),
                    }
                },
                new CourseInfo("c02", "Basic mathematics", 3)
                {
                    Criteria = new List<ScoringCriteria>
                    {
                        new ScoringCriteria("A", 80),
                        new ScoringCriteria("B", 71),
                        new ScoringCriteria("C", 61),
                        new ScoringCriteria("D", 51),
                        new ScoringCriteria("F", 0),
                    }
                }
            };
        }

        // TODO: Create new course

        // TODO: (Optional) Get all courses
        // TODO: (Optional) Update course by Id
        // TODO: (Optional) Delete course by Id
    }
}