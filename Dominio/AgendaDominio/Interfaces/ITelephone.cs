using System;

namespace AgendaDominio
{
    public interface ITelephone
    {
        Guid Id { get; set; }
        string Numero { get; set; }
        Guid ContatoId { get; set; }
    }
}
