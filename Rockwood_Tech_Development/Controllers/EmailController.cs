using Rockwood.Models;
using Rockwood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rockwood_Tech_Development.Controllers
{
    [Authorize]
    public class EmailController : ApiController
    {
        private EmailService _emailService = new EmailService();
        public IHttpActionResult Get()
        {
            var emails = _emailService.GetEmails();
            return Ok(emails);
        }
        public IHttpActionResult Post(EmailCreate email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEmailService();

            if (!service.CreateEmail(email))
                return InternalServerError();
            return Ok();
        }
        private EmailService CreateEmailService()
        {

            var emailService = new EmailService();
            return emailService;
        }
    }
}
