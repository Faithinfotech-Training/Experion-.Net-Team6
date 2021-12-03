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
    public class EMailController : ControllerBase
    {
        IPatientRepo patientRepository;

        public EMailController(IPatientRepo _p)
        {
            patientRepository = _p;
        }

        [HttpPost]
        [Route("SendMail/{id}")]
        public async Task<IActionResult> SendMail([FromBody] TblLabReport report, int id )
        {
            var exp = await patientRepository.GetPatientById(id);
            var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("aneesmohammed0@gmail.com", "timetochange");
            var mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("aneesmohammed0@gmail.com");
            mailMessage.To.Add(exp.EmailId);
            //mailMessage.IsBodyHtml = true;
            mailMessage.Body = " Lab Test Details - IClinic " + Environment.NewLine;
            mailMessage.Body += report.TestOne + " " ;
            mailMessage.Body += report.ObservedResultOne + Environment.NewLine;
            if(report.TestTwo != null)
            {
                mailMessage.Body += report.TestTwo + " ";
                mailMessage.Body += report.ObservedResultTwo + Environment.NewLine;
            }
            if (report.TestTwo != null)
            {
                mailMessage.Body += report.TestThree + " ";
                mailMessage.Body += report.ObservedResultThree + Environment.NewLine;
            }
            await client.SendMailAsync(mailMessage);
            return Ok();
        }
    }
}

