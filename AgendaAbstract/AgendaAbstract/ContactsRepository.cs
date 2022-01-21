using AgendaDAL;
using AgendaDomain;
using System;
using System.Collections.Generic;

namespace AgendaRepos
{
    public class ContactsRepository
    {
        private readonly IContacts _contacts;
        private readonly ITelephones _telephones;

        public ContactsRepository(IContacts contacts, ITelephones telephones)
        {
            _contacts = contacts;
            _telephones = telephones;
        }

        public IContact GetById(Guid id)
        {
            IContact contact = _contacts.Get(id);
            List<ITelephone> phoneList = _telephones.GetAllFromContact(id);
            contact.Telephones = phoneList;
            return contact;
        }
    }
}
