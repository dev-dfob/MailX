using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MailX.Controllers
{
    public class LettersController : ApiController
    {
        public IEnumerable<string> GetAllLetters()
        {
            return new string[] { "value1", "value2" };
        }

        public string GetItem(int id)
        {
            return "value";
        }

        [HttpPost]
        public void CreateLetter([FromBody]string value)
        {
        }

        [HttpPut]
        public void EditLetter(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        public void RemoveLetter(int id)
        {
        }
    }
}
