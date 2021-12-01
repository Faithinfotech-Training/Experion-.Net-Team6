using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using cmsRestApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cmsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabtestController : ControllerBase
    {
        ILabTestRepository labTestRepository;

        public LabtestController(ILabTestRepository labTestRepository)
        {
            this.labTestRepository = labTestRepository;
        }

        #region Get Labtest prescribed
        [HttpGet]
        public async Task<IActionResult> GetLabTests()
        {
            try
            {
                var labtests = await labTestRepository.GetPrescriptionTests();
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
        #region Get Labtests by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLabTestById(int id)
        {
            try
            {
                var labTest = await labTestRepository.GetPrescriptionTestbyId(id);
                if (labTest == null)
                {
                    return NotFound();
                }
                return Ok(labTest);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion

        #region Lab Test view For Lab Technician
        [HttpGet("labtech")]
        public async Task<IActionResult> GetLabTestView()
        {
            try
            {
                var labtests = await labTestRepository.GetLabTestView();
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

        //Add a Staff 
        [HttpPost]
        public async Task<IActionResult> AddPrescriptionLabTest([FromBody] TblPrescriptionTest test)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var PrescriptionTestId = await labTestRepository.AddPrescriptionTest(test);
                    if (PrescriptionTestId > 0)
                    {
                        return Ok(PrescriptionTestId);
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


        #region Lab form view
        [HttpGet("GetFormView/{LogId}")]
        public async Task<IActionResult> GetFormView(int LogId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var PrescriptionTestId = await labTestRepository.GetFormView(LogId);
                    if (PrescriptionTestId != null)
                    {
                        return Ok(PrescriptionTestId);
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
        //Update Staff 
        [HttpPut]

        public async Task<IActionResult> PrescriptionLabTest([FromBody] TblPrescriptionTest test)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await labTestRepository.UpdatePrescriptionTest(test);

                    return Ok();


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
