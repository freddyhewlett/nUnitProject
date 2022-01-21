using System;

namespace AgendaDomain
{
    public interface ITelephone
    {
        Guid Id { get; set; }
        string Numero { get; set; }
        Guid ContatoId { get; set; }
    }
}
