using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using cmsRestApi.Repository;
using cmsRestApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cmsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EMailController : ControllerBase
    {
        ILabReportVMRepository labrepository;
        IPatientRepo patrepo;

        public EMailController(
            ILabReportVMRepository _labrepository,
            IPatientRepo _patrepo

            
            )
        {
            labrepository = _labrepository;
            patrepo = _patrepo;
        }

        [HttpGet]
        [Route("SendMail/{id}")]
        public async Task<IActionResult> SendMail(int id)
        {
            List<LabReportViewModel> report = await labrepository.GetLabReportByReportId(id);
            var patientId = report[0].PatientId;
            TblPatient pat = await patrepo.GetPatientById(patientId);
            var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("iclinichealthcarepvtltd@gmail.com", "iclinic09!");
            var mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("iclinichealthcarepvtltd@gmail.com");
            mailMessage.To.Add(pat.EmailId);
            mailMessage.Subject = "Lab Test Report";
            mailMessage.IsBodyHtml = true;

            //body begins here
            mailMessage.Body += " <h1 style='color: Red;'><center>IClinic Health Care<center></h1>\n ";
            mailMessage.Body += " <h3><center>Lab Test Report<center></h3><br><br> ";
            mailMessage.Body += "<hr>";
            mailMessage.Body += "<div style='font-size: 1.2em; font-family:Lucida Console;'>";
            mailMessage.Body += "<table><tbody><tr>";
            mailMessage.Body += "<td>Pateint Id</td><td>" + pat.PatientId +"</td></tr>";
            mailMessage.Body += "<tr><td>Pateint name</td><td>" + pat.PatientName + "</td></tr>";
            mailMessage.Body += "<tr><td>Consulted Doctor</td><td>Dr." + report[0].DoctorName + "</td></tr>";
            mailMessage.Body += "<tr><td>Test Done by</td><td>" + report[0].StaffName + "</td></tr>";
            mailMessage.Body += "<tr><td>Date Of Appoitment</td><td>" + report[0].DateOfAppointment + "</td><tr>";
            mailMessage.Body += "</tbody></table><hr>";
            mailMessage.Body += "<table><thead><tr><th>Test</th><th>Result</th></tr></thead><tbody><tr>";
            mailMessage.Body += "<td>" + report[0].TestOneName + "</td>";
            mailMessage.Body += "<td>" + report[0].ObservedResultOne + "</td> </tr>";
            if (report[0].TestTwoName != null)
            {
                mailMessage.Body += "<tr>";
                mailMessage.Body += "<td>" + report[0].TestTwoName + "</td>" ;
                mailMessage.Body += "<td>" + report[0].ObservedResultTwo + "</td>";
                mailMessage.Body += "<tr>";
            }
            if (report[0].TestThreeName != null)
            {
                mailMessage.Body += "<tr>";
                mailMessage.Body += "<td>" + report[0].TestThreeName + "</td>";
                mailMessage.Body += "<td>" + report[0].ObservedResultThree + "</td>";
                mailMessage.Body += "<tr>";
            }
            mailMessage.Body += "</tr></tbody></table?</div><br><br>";
            mailMessage.Body += "<hr> Thank You for visitng IClinic <hr>";
            //mailMessage.Attachments.Add(new System.Net.Mail.Attachment(ModelState, "example.text",""))
            await client.SendMailAsync(mailMessage);
            return Ok();
        }
    }
}

