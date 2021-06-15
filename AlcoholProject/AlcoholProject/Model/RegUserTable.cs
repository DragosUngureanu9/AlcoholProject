using System;
using System.Collections.Generic;
using System.Text;

namespace AlcoholProject.Model
{
    public class RegUserTable
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}
