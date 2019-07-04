using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Email
{
    public interface IEmailSender
    {
        //Sends Email with the given information 
        Task<SendEmailResponse> SendEmailAsync(string UserEmail, string emailSubject, string message);
    }
}
