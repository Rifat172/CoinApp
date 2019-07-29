using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            if (this.Email == HelperRegex.ReplaceSpace(((User)obj).Email) &&
                this.Password == HelperRegex.ReplaceSpace(((User)obj).Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}