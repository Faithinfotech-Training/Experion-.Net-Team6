using cmsRestApi.Models;
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
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("log/{id}")]
        public async Task<IActionResult> GetPatientLogViewModel(int id)
        {
            try
            {
                var logview = await repo.GetPatientLogViewModel(id);
                if (logview != null)
                {
                    return Ok(logview);

                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> AddPatientLog([FromBody] TblPatientLog log)
        {
            //check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await repo.AddPatientLog(log);
                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
