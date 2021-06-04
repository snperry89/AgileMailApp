using Rockwood.Data;
using Rockwood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockwood.Services
{
    public class EmailService
    {
        
        public bool CreateEmail(EmailCreate model)
        {
            var entity =
                new Email()
                {
                    Subject = model.Subject,
                    EmailRecipient = model.EmailRecipient,
                    Body = model.Body
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Emails.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmailListItem> GetEmails()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Emails
                        .Select(
                        e =>
                            new EmailListItem
                            {
                                EmailId = e.EmailId,
                                Subject = e.Subject,
                                EmailRecipient = e.EmailRecipient,
                                Body = e.Body
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
