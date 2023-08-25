using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Application.ViewModels.Users
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string TelNo { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
