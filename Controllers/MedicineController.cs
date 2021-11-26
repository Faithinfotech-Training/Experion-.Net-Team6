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
    public class MedicineController : ControllerBase
    {

        IMedicineRepo medicineRepository;
        public MedicineController(IMedicineRepo _p)
        {
            medicineRepository = _p;
        }

        #region Get Patients
        [HttpGet]
        [Route("GetMedicines")]
        public async Task<IActionResult> GetMedicines()
        {
            try
            {
                var medicines = await medicineRepository.GetMedicines();
                if (medicines == null)
                {
                    return NotFound();
                }
                return Ok(medicines);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion
        #region Add medicine

        [HttpPost]
        [Route("AddMedicine")]
        public async Task<IActionResult> AddMedicine(TblMasterMedicine medicine)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var medicineId = await medicineRepository.AddMedicine(medicine);
                    if (medicineId != null)
                    {
                        return Ok(medicineId);
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
        #region Update Medicine
        [HttpPut]
        [Route("UpdateMedicine")]
        public async Task<IActionResult> UpdateMedicine(TblMasterMedicine medicine)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await medicineRepository.UpdateMedicine(medicine);
                    return Ok(medicine);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
        #region Get medicine details by id
        [HttpGet]
        [Route("GetMedicineById")]
        public async Task<IActionResult> GetMedicineById(int id)
        {
            try
            {
                var exp = await medicineRepository.GetMedicineById(id);
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

    }
}
