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
    public class ExamController
    {
        public static List<ExamResultInfo> ExamResults { get; private set; }

        static ExamController()
        {
            ExamResults = new List<ExamResultInfo>();
        }

        // TODO: Create new exam result
        
        // TODO: (Optional) Get all exam results
        // TODO: (Optional) Update exam result by Id
        // TODO: (Optional) Delete exam result by Id
    }
}