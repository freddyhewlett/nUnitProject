using AgendaDominio;
using System;
using System.Collections.Generic;

namespace AgendaInfra
{
    public interface ITelephoneRepository
    {
        List<ITelephone> GetAllFromContact(Guid contactId);

    }
}
