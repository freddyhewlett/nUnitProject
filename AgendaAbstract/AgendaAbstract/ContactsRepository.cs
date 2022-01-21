using AgendaDAL;
using System;

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


    }
}
