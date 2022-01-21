using AgendaDomain;
using System;
using System.Collections.Generic;

namespace AgendaDAL
{
    public interface ITelephones
    {
        List<ITelephone> GetAllFromContact(Guid contactId);

    }
}
