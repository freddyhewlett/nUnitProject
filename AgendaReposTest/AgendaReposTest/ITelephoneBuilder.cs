using AgendaDomain;
using System;
using AutoFixture;

namespace AgendaReposTest
{
    public class ITelephoneBuilder : BaseBuilder<ITelephone>
    {
        protected ITelephoneBuilder() : base()
        {
        }

        public static ITelephoneBuilder One()
        {
            return new ITelephoneBuilder();
        }

        public ITelephoneBuilder Model()
        {
            _mock.SetupGet(c => c.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(t => t.Numero).Returns(_fixture.Create<string>());
            _mock.SetupGet(t => t.ContatoId).Returns(_fixture.Create<Guid>());

            return this;
        }

        public ITelephoneBuilder WithId(Guid id)
        {
            _mock.SetupGet(c => c.Id).Returns(id);
            return this;
        }

        public ITelephoneBuilder WithNumber(string numero)
        {
            _mock.SetupGet(t => t.Numero).Returns(numero);
            return this;
        }

        public ITelephoneBuilder WithContactId(Guid contactId)
        {
            _mock.SetupGet(t => t.ContatoId).Returns(contactId);
            return this;
        }
    }
}
