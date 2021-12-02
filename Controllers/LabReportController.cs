using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using cmsRestApi.Repository;
using cmsRestApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cmsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabReportController : ControllerBase
    {
        ILabReportVMRepository repository;

        public LabReportController(ILabReportVMRepository _repo)
        {
            repository = _repo;
        }


        #region get all lab report
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabReportViewModel>>> GetAllLabReport()
        {
            return await repository.GetAllLabReport();
        }

        #endregion

        #region get a lab report

        [HttpGet()]
        [Route("GetLabReport/{id}")]
        public async Task<IActionResult> GetLabReport(int id)
        {
            try
            {
                var report = await repository.GetLabReport(id);
                if (report == null)
                {
                    return NotFound();
                }
                return Ok(report);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion

        #region add a lab report

        [HttpPost]
        [Route("AddReport")]
        public async Task<IActionResult> AddDoctor([FromBody] TblLabReport report)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var repID = await repository.AddLabReport(report);
                    if (repID > 0)
                    {
                        return Ok(repID);
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

        #endregion
    }
}
