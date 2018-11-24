using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MailX.Models
{
    public class User
    {
        public int Id { get; set; }
        public int VkId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Sex { get; set; }    //1 - female, 2 - male, 0 - undefined
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public ICollection<Letter> Letters { get; set; }

        public User()
        {
            Letters = new HashSet<Letter>();
        }
    }
}