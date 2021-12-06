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
    public class StaffController : ControllerBase
    {
        IStaffRepository staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        //Get all Staffs
        [HttpGet]
        [Route("GetAllStaff")]
        public async Task<IActionResult> GetStaffs()
        {
            try
            {
                var staffs = await staffRepository.GetStaffs();
                if (staffs == null)
                {
                    return NotFound();
                }
                return Ok(staffs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Get Staff by Id
        [HttpGet]
        [Route("GetStaff/{id}")]
        public async Task<ActionResult<TblStaff>> GetEmployeebyId(int id)
        {

            var result = await staffRepository.GetStaffbyId(id);

            if (result == null)
            {
                return null;
            }
            return result;


        }
        //Add a Staff 
        [HttpPost]
        [Route("Addstaff")]
        public async Task<IActionResult> AddStaff([FromBody] TblStaff staff)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var StaffId = await staffRepository.AddStaff(staff);
                    if (StaffId > 0)
                    {
                        return Ok(StaffId);
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


        //Update Staff 
        [HttpPut]
        [Route("putstaff")]
        public async Task<IActionResult> UpdateStaff([FromBody] TblStaff staff)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await staffRepository.UpdateStaff(staff);

                    return Ok();


                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        [HttpGet("getstaffid/{userName}")]
        public async Task<IActionResult> GetStaffId(string userName)
        {
            if (userName!=null)
            {
                try
                {
                    var staffId=await staffRepository.GetStaffId(userName);
                    var id = staffId[0].StaffId;
                    return Ok(id);


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
