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
    public class EventController : ControllerBase
    {
            IEventRepo eventRepository;
            public EventController(IEventRepo _p)
            {
                eventRepository = _p;
            }
            #region Get Patients
            [HttpGet]
            [Route("GetEvents")]
            public async Task<IActionResult> GetEvents()
            {
                try
                {
                    var events = await eventRepository.GetEvents();
                    if (events == null)
                    {
                        return NotFound();
                    }
                    return Ok(events);
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            #endregion
            #region Get event details by id
            [HttpGet]
            [Route("GetEventById")]
            public async Task<IActionResult> GetEventById(int id)
            {
                try
                {
                    var exp = await eventRepository.GetEventById(id);
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
            #region Add event

            [HttpPost]
            [Route("AddEvent")]
            public async Task<IActionResult> AddEvent(TblEvents events)
            {
                //check the validation of body
                if (ModelState.IsValid)
                {
                    try
                    {
                        var eventId = await eventRepository.AddEvent(events);
                        if (eventId != null)
                        {
                            return Ok(eventId);
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
            #region Update event
            [HttpPut]
            // [Authorize]
            [Route("UpdateEvent")]
            public async Task<IActionResult> UpdateEvent(TblEvents events)
            {
                //Check the validation of body
                if (ModelState.IsValid)
                {
                    try
                    {
                        await eventRepository.UpdateEvent(events);
                        return Ok(events);
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
            #endregion
            #region Update event by Id
            [HttpPut]
            // [Authorize]
            [Route("{id}")]
            public async Task<IActionResult> getEvent(int id)
            {
                try
                {
                    var exp = await eventRepository.getEvent(id);
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
            #region Update IsActive by Id
            [HttpGet]
            // [Authorize]
            [Route("IsActive/{id}")]
            public async Task<IActionResult> UpdateEventByActive(int id)
            {
                try
                {
                    var exp = await eventRepository.UpdateEventByActive(id);
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

