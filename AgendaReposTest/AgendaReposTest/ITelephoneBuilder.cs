using AgendaDomain;
using Moq;
using System;

namespace AgendaReposTest
{
    public class ITelephoneBuilder
    {
        private Mock<ITelephone> _mockTelephone;

        protected ITelephoneBuilder(Mock<ITelephone> mockTelephone)
        {
            _mockTelephone = mockTelephone;
        }

        public ITelephoneBuilder One()
        {
            return new ITelephoneBuilder(new Mock<ITelephone>());
        }

        public ITelephone Build()
        {
            return _mockTelephone.Object;
        }



        //mockTelephone.SetupGet(c => c.Id).Returns(testPhoneId);
        //mockTelephone.SetupGet(t => t.Numero).Returns("1234-1234");
        //mockTelephone.SetupGet(n => n.ContatoId).Returns(testContactId);
    }
}
