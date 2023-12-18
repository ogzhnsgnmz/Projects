using AutoMapper;
using BP.Api.Data.Models;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.APİ.Service
{
    public class ContactManager : IContactService
    {
        IMapper mapper;

        public ContactManager(IMapper Mapper)
        {
            Mapper = mapper;
        }

        public ContactDVO GetContactById(int id)
        {
            Contact dbContact = getFakeContact();


            //ContactDVO resultContact = new ContactDVO();

            ContactDVO result = mapper.Map(dbContact, resultContact);

            return result;
        }

        private Contact getFakeContact()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "Oğuzhan",
                LastName = "X"
            };
        }
    }
}
