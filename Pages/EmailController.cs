using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreEmailApi.Models;
using NetCoreEmailApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreEmailApi.Pages
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                var data = new
                {
                    msg = "Thanks for contacting me! I'll definitely get back to you very soon!",
                    successMsg = "Email sent was successful"
                };
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
