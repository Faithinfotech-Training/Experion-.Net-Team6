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
    public class PrescMedicineController : ControllerBase
    {

        IPrescMedicineRepo prescmedicineRepository;
        public PrescMedicineController(IPrescMedicineRepo _p)
        {
            prescmedicineRepository = _p;
        }

        #region Get PrescMedicine
        [HttpGet]
        [Route("GetPrescMedicines")]
        public async Task<IActionResult> GetPrescMedicines()
        {
            try
            {
                var medicines = await prescmedicineRepository.GetPrescMedicines();
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
        #region Add prescmedicine

        [HttpPost]
        [Route("AddPrescMedicine")]
        public async Task<IActionResult> AddPrescMedicine(TblPrescriptionMedicine prescmedicine)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var medicineId = await prescmedicineRepository.AddPrescMedicine(prescmedicine);
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
        #region Update PrescMedicine
        [HttpPut]
        [Route("UpdatePrescMedicine")]
        public async Task<IActionResult> UpdatePrescMedicine(TblPrescriptionMedicine prescmedicine)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await prescmedicineRepository.UpdatePrescMedicine(prescmedicine);
                    return Ok(prescmedicine);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
        #region Get prescmedicine details by id
        [HttpGet]
        [Route("GetPrescMedicineById")]
        public async Task<IActionResult> GetPrescMedicineById(int id)
        {
            try
            {
                var exp = await prescmedicineRepository.GetPrescMedicineById(id);
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
