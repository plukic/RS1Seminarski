using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.BR.EmailService.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string subject, string username, string password, string receiver);
    }
}
