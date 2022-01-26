using AgendaDomain;
using Moq;
using System;
using AutoFixture;

namespace AgendaReposTest
{
    public class ITelephoneBuilder
    {
        private readonly Mock<ITelephone> _mockTelephone;
        private readonly Fixture _fixture;

        protected ITelephoneBuilder(Mock<ITelephone> mockTelephone, Fixture fixture)
        {
            _mockTelephone = mockTelephone;
            _fixture = fixture;
        }

        public static ITelephoneBuilder One()
        {
            return new ITelephoneBuilder(new Mock<ITelephone>(), new Fixture());
        }

        public ITelephone Build()
        {
            return _mockTelephone.Object;
        }

        public ITelephoneBuilder Model()
        {
            _mockTelephone.SetupGet(c => c.Id).Returns(_fixture.Create<Guid>());
            _mockTelephone.SetupGet(t => t.Numero).Returns(_fixture.Create<string>());
            _mockTelephone.SetupGet(t => t.ContatoId).Returns(_fixture.Create<Guid>());

            return this;
        }

        public ITelephoneBuilder WithId(Guid id)
        {
            _mockTelephone.SetupGet(c => c.Id).Returns(id);
            return this;
        }

        public ITelephoneBuilder WithNumber(string numero)
        {
            _mockTelephone.SetupGet(t => t.Numero).Returns(numero);
            return this;
        }

        public ITelephoneBuilder WithContactId(Guid contactId)
        {
            _mockTelephone.SetupGet(t => t.ContatoId).Returns(contactId);
            return this;
        }
    }
}
