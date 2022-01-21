using System;
using System.Collections.Generic;

namespace AgendaDomain
{
    public interface IContact
    {
        Guid Id { get; set; }
        string Nome { get; set; }
        List<ITelephone> Telephones { get; set; }
    }
}
