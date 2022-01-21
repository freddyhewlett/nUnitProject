using AgendaDominio;
using System;

namespace AgendaInfra
{
    public interface IContactRepository
    {
        IContact Get(Guid id);
    }
}
