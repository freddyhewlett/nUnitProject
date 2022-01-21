using AgendaDAL;
using AgendaRepos;
using Moq;
using NUnit.Framework;
using System;

namespace AgendaReposTest
{
    [TestFixture]
    public class ContactRepositoryTest
    {
        private Mock<IContacts> _contacts;
        private Mock<ITelephones> _telephones;
        private ContactsRepository _contactRepository;

        [SetUp]
        public void SetUp()
        {
            _contacts = new Mock<IContacts>();
            _telephones = new Mock<ITelephones>();
            _contactRepository = new ContactsRepository(_contacts.Object, _telephones.Object);
        }

        [Test]
        public void Test()
        {

        }

        [TearDown]
        public void TearDown()
        {
            _contacts = null;
            _telephones = null;
            _contactRepository = null;
        }
    }
}
