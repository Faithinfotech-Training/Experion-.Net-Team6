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
    public class PatientController : ControllerBase
    {
        IPatientRepo patientRepository;
        public PatientController(IPatientRepo _p)
        {
            patientRepository = _p;
        }
        #region Get Patients
        [HttpGet]
        [Route("GetPatients")]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var patients = await patientRepository.GetPatients();
                if (patients == null)
                {
                    return NotFound();
                }
                return Ok(patients);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion
        #region Get patient details by id
        [HttpGet]
        [Route("GetPatientById")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var exp = await patientRepository.GetPatientById(id);
                if (exp == null)
                {
                    return NotFound();
                }
                return Ok(exp);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion
        #region Add employee

        [HttpPost]
        [Route("AddPatient")]
        public async Task<IActionResult> AddPatient(TblPatient patient)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var patientId = await patientRepository.AddPatient(patient);
                    if (patientId != null)
                    {
                        return Ok(patientId);
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
        #region Update Patient
        [HttpPut]
        // [Authorize]
        [Route("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(TblPatient patient)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await patientRepository.UpdatePatient(patient);
                    return Ok(patient);
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
