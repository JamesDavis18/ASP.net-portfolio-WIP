using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationLanding
{
    public class ContactModel : PageModel
    {
        string name = "";
        string email = ""; 

        //public string PostedMessage { get; set; }
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Company { get; set; }
        [BindProperty]
        public string Message { get; set; }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    //SendMail(Name, Email, Company, Message);
        //    if (!ModelState.IsValid)
        //    {
        //        return Redirect("contact.cshtml");
        //    }
        //}
        
        //(string name, string email, string messageBody)
        public void SendMail()
        {
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(name, email);
            mailMessage.To.Add(new MailAddress(name, "jamesd6502@gmail.com"));
            mailMessage.Subject = "An enquiry from -" + name;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "Hello,<b>\n\n This is a test response from an ASP.NET webpage</b>" + Message;

            //"mail.jdportfolio.co.uk"
            using (var client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("jamesdavis6598@gmail.com", "portfolioPassword");
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                client.Timeout = 20000;
                client.Send(mailMessage);
            }
        }

        public void OnGet(int id)
        {
            ViewData["Message"] = "Your message has been sent[viewdata]";
            Message = "Your message has been sent [property]";
        }

        //private void Buttonsend_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        SendMail();
        //        //lblmsg.Text = "Comments";
        //        sendStatus.visible = true;
        //        sendStatus.FontBold = true;
        //        sendStatus.Text = "Messsage Sent";

        //    }
        //    catch (Exception)
        //    {
        //        Response.StatusCode = 400;
        //    }
        //}
    }
}