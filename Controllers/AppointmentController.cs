﻿using System;
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
    public class AppointmentController : ControllerBase
    {
        IAppointmentRepository appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        //Get all Staffs
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            try
            {
                var appointments = await appointmentRepository.GetAppointment();
                if (appointments == null)
                {
                    return NotFound();
                }
                return Ok(appointments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Get Staff by Id
        [HttpGet("{id}")]

        public async Task<ActionResult<TblAppointment>> GetAppointmentbyId(int id)
        {

            var result = await appointmentRepository.GetAppointmentbyId(id);

            if (result == null)
            {
                return null;
            }
            return result;


        }

        //Get Staff by Id
        [HttpGet]
        [Route("GetbyDoctor")]

        public async Task<List<TblAppointment>> GetAppointmentbyDoctorId(int id)
        {

            var result = await appointmentRepository.GetAppointmentbyDoctorId(id);

            if (result == null)
            {
                return null;
            }
            return result;


        }
        //Add a Staff 
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] TblAppointment appointment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var appointmentId = await appointmentRepository.AddAppointment(appointment);
                    if (appointmentId > 0)
                    {
                        return Ok(appointmentId);
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

        public async Task<IActionResult> UpdateAppointment([FromBody] TblAppointment appointment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await appointmentRepository.UpdateAppointment(appointment);

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
