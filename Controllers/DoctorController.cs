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
    public class DoctorController : ControllerBase
    {
        IDoctorRepository repository;

        public DoctorController(IDoctorRepository _p)
        {
            repository = _p;
        }


        #region get all doctors
        //controllers
        [HttpGet]
        [Route("GetAllDoctor")]
        public async Task<ActionResult<IEnumerable<TblDoctor>>> GetAllDoctor()
        {
            return await repository.GetAllDoctor();
        }

        #endregion

        [HttpGet()]
        [Route("GetADoctor/{id}")]
        public async Task<IActionResult> GetADoctor(int id)
        {
            try
            {
                var doctor = await repository.GetADoctor(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                return Ok(doctor);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #region get all Specialization

        [HttpGet]
        [Route("GetAllSpecialization")]
        public async Task<ActionResult<IEnumerable<TblSpecialization>>> GetAllSpecialization()
        {
            return await repository.GetAllSpecialization();
        }


        #endregion

        #region Add a doctor

        [HttpPost]
        [Route("AddDoctor")]
        public async Task<IActionResult> AddDoctor([FromBody] TblDoctor doctor)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var DocID = await repository.AddDoctor(doctor);
                    if (DocID > 0)
                    {
                        return Ok(DocID);
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

        #region Update doctor

        [HttpPut]
        [Route("Putdoctor")]
        public async Task<IActionResult> PutDoctor(TblDoctor doctor)
        {
            try
            {
                var doc = await repository.PutDoctor(doctor);
                if (doc == null)
                {
                    return NotFound();
                }
                return Ok(doc);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion



    }
}
