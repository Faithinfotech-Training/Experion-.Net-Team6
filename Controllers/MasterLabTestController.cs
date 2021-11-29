using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cmsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterLabTestController : ControllerBase
    {

        IMasterLabTest masterlabtestRepository;

        public MasterLabTestController(IMasterLabTest masterlabtestRepository)
        {
            this.masterlabtestRepository = masterlabtestRepository;
        }

        #region Get Labtests results available
        [HttpGet]
        public async Task<IActionResult> GetLabTests()
        {
            try
            {
                var labtests = await masterlabtestRepository.GetLabTests();
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
                var labTest = await masterlabtestRepository.GetLabTestbyId(id);
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

    }
}
