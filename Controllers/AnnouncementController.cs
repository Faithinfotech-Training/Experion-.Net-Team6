using cmsRestApi.Models;
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
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementRepo announcementRepository;
        public AnnouncementController(IAnnouncementRepo _p)
        {
            announcementRepository = _p;
        }
        #region Get Announcements
        [HttpGet]
        [Route("GetAnnouncements")]
        public async Task<IActionResult> GetAnnouncements()
        {
            try
            {
                var announcements = await announcementRepository.GetAnnouncements();
                if (announcements == null)
                {
                    return NotFound();
                }
                return Ok(announcements);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion
        #region Get patient details by id
        [HttpGet]
        [Route("GetAnnouncementById")]
        public async Task<IActionResult> GetAnnouncementById(int id)
        {
            try
            {
                var exp = await announcementRepository.GetAnnouncementById(id);
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
        #region Add Announcement

        [HttpPost]
        [Route("AddAnnouncements")]
        public async Task<IActionResult> AddAnnouncements(TblAnnouncements announcements)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var annouId = await announcementRepository.AddAnnouncements(announcements);
                    if (annouId != null)
                    {
                        return Ok(annouId);
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
        [Route("UpdateAnnouncement")]
        public async Task<IActionResult> UpdateAnnouncement(TblAnnouncements announcements)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await announcementRepository.UpdateAnnouncement(announcements);
                    return Ok(announcements);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
        #region Update IsActive by Id
        [HttpGet]
        // [Authorize]
        [Route("IsActive/{id}")]
        public async Task<IActionResult> UpdateAnnouncementByActive(int id)
        {
            try
            {
                var exp = await announcementRepository.UpdateAnnouncementByActive(id);
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
