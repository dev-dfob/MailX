using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MailX.Models
{
    public class Letter
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string EmailSource { get; set; }
        public string EmailDestination { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}