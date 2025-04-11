using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Services
{
    public class NotifierService
    {
        private UserService UserService;

        public NotifierService(UserService UserService)
        {
            this.UserService = UserService;
        }

        public void NotifyCustomer(string username)
        {
            string customerEmail = UserService.GetByUsername(username).Email;
            if (!String.IsNullOrEmpty(customerEmail))
            {
                try
                {
                    //construct the email message and send it, implementation ignored
                }
                catch (Exception ex)
                {
                    //log the emailing error, implementation ignored
                }
            }
        }
    }
}
