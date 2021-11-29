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
    public class PaymentController : ControllerBase
    {
        IPaymentRepo paymentRepository;
        public PaymentController(IPaymentRepo _p)
        {
            paymentRepository = _p;
        }
        #region Get Payments
        [HttpGet]
        [Route("GetPayments")]
        public async Task<IActionResult> GetPayments()
        {
            try
            {
                var payments = await paymentRepository.GetPayments();
                if (payments == null)
                {
                    return NotFound();
                }
                return Ok(payments);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion
        #region Get payment details by id
        [HttpGet]
        [Route("GetPaymentById")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            try
            {
                var exp = await paymentRepository.GetPaymentById(id);
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
        #region Add payment

        [HttpPost]
        [Route("AddPayment")]
        public async Task<IActionResult> AddPayment(TblPayment payment)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var paymentId = await paymentRepository.AddPayment(payment);
                    if (paymentId != null)
                    {
                        return Ok(payment);
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
    }
}
