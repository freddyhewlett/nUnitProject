using AgendaDomain;
using AutoFixture;
using Moq;
using System;

namespace AgendaReposTest
{
    public class IContactBuilder
    {
        private readonly Mock<IContact> _mockContact;
        private readonly Fixture _fixture;

        protected IContactBuilder(Mock<IContact> mockContact, Fixture fixture)
        {
            _mockContact = mockContact;
            _fixture = fixture;
        }

        public static IContactBuilder One()
        {
            return new IContactBuilder(new Mock<IContact>(), new Fixture());
        }

        public IContact Build()
        {
            return _mockContact.Object;
        }

        public Mock<IContact> Get()
        {
            return _mockContact;
        }

        public IContactBuilder Model()
        {
            _mockContact.SetupGet(c => c.Id).Returns(_fixture.Create<Guid>());
            _mockContact.SetupGet(t => t.Nome).Returns(_fixture.Create<string>());

            return this;
        }

        public IContactBuilder WithId(Guid id)
        {
            _mockContact.SetupGet(c => c.Id).Returns(id);
            return this;
        }

        public IContactBuilder WithName(string name)
        {
            _mockContact.SetupGet(n => n.Nome).Returns(name);
            return this;
        }

        
    }
}
