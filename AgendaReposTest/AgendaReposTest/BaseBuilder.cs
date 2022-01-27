using AgendaDomain;
using AutoFixture;
using Moq;
using System;

namespace AgendaReposTest
{
    public class BaseBuilder<T> where T : class
    {
        protected readonly Fixture _fixture;
        protected readonly Mock<T> _mock;

        protected BaseBuilder()
        {
            _fixture = new Fixture();
            _mock = new Mock<T>();
        }

        public T Build()
        {
            return _mock.Object;
        }

        public Mock<T> Get()
        {
            return _mock;
        }
    }
}
