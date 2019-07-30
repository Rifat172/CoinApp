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
            if (Email == HelperRegex.RemoveSpace(((User)obj).Email) &&
                Password == HelperRegex.RemoveSpace(((User)obj).Password))
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -190816841;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}