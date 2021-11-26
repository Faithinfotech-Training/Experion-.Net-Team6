using cmsRestApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientLogController : ControllerBase
    {
        //repository injection
        IPatientLogRepository repo;

        public PatientLogController(IPatientLogRepository repo)
        {
            this.repo = repo;
        }

        //operations
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientLog(int id)
        {
            try
            {
                var log = await repo.GetPatientLog(id);
                if (log != null)
                {
                    return Ok(log);
                }
                return null;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
