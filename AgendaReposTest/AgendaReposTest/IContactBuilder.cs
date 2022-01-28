using AgendaDomain;
using AutoFixture;
using System;

namespace AgendaReposTest
{
    public class IContactBuilder : BaseBuilder<IContact>
    {
        protected IContactBuilder() : base()
        {
        }

        public static IContactBuilder One()
        {
            return new IContactBuilder();
        }

        public IContactBuilder Model()
        {
            _mock.SetupGet(c => c.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(t => t.Nome).Returns(_fixture.Create<string>());

            return this;
        }

        public IContactBuilder WithId(Guid id)
        {
            _mock.SetupGet(c => c.Id).Returns(id);
            return this;
        }

        public IContactBuilder WithName(string name)
        {
            _mock.SetupGet(n => n.Nome).Returns(name);
            return this;
        }
    }
}
