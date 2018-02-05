using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.BR.EmailService.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(string subject, string message, string receiver);
    }
}
