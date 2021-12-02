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

        #region get all report
        [HttpGet]
        public async Task<IActionResult> GetAllLabReport()
        {
            try
            {
                var labtests = await repository.GetAllLabReport();
                if (labtests == null)
                {
                    return NotFound();
                }
                return Ok(labtests);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region get all lab report VM
        [HttpGet("VM")]
        public async Task<ActionResult<IEnumerable<LabReportViewModel>>> GetAllLabReportVM()
        {
            return await repository.GetAllLabReportVM();
        }

        #endregion

        #region get a lab report

        [HttpGet("{id}")]
        //[Route("GetLabReport/{id}")]
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
