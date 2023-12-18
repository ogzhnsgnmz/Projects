using BP.APİ.Service;
using BP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IConfiguration configuration;
        IContactService contact;

        public ContactController(IConfiguration Configuration, IContactService Contact)
        {
            configuration = Configuration;
            contact = Contact;
        }

        [ResponseCache(Duration = 10)]
        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return contact.GetContactById(id);
        }
        
        [HttpPost]
        public ContactDVO CreateContact(ContactDVO contact)
        {
            //create contact on db
            return contact;
        }
    }
}
