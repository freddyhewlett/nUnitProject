using AgendaDomain;
using System;

namespace AgendaDAL
{
    public interface IContacts
    {
        IContact Get(Guid id);
    }
}
