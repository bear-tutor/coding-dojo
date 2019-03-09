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

        // Create new exam result
        [HttpPost]
        public void Post([FromBody]ExamResultInfo examResult)
        {
            examResult.Id = Guid.NewGuid().ToString();
            ExamResults.Add(examResult);
        }

        // Get all exam results
        [HttpGet]
        public IEnumerable<ExamResultInfo> Get()
        {
            return ExamResults;
        }

        // TODO: (Optional) Update exam result by Id
        // TODO: (Optional) Delete exam result by Id
    }
}