using AgendaDAL;
using AgendaDomain;
using AgendaRepos;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
        public void GetContactWithPhoneListTest()
        {
            List<ITelephone> testPhoneList = new List<ITelephone>();
            Guid testContactId = Guid.NewGuid();
            Guid testPhoneId = Guid.NewGuid();

            //Monta
            Mock<IContact> mockContact = IContactBuilder.One().WithId(testContactId).WithName("Ghost").Get();
            mockContact.SetupSet(t => t.Telephones = It.IsAny<List<ITelephone>>())
                .Callback<List<ITelephone>>(p => testPhoneList = p);
            
            _contacts.Setup(c => c.Get(testContactId)).Returns(mockContact.Object);

            ITelephone mockPhone = ITelephoneBuilder.One()
                .Model()
                .WithId(testPhoneId)
                .WithContactId(testContactId)
                .Build();
            
            _telephones.Setup(t => t.GetAllFromContact(testContactId)).Returns(new List<ITelephone> { mockPhone });

            //Executa
            IContact result = _contactRepository.GetById(testContactId);
            mockContact.SetupGet(t => t.Telephones).Returns(testPhoneList);

            //Verifica
            //Verificar se o contact retornado contem os mesmos dados do moq de IContato com a lista de telefones do moq ITelefone
            Assert.AreEqual(mockContact.Object.Id, result.Id);
            Assert.AreEqual(mockContact.Object.Nome, result.Nome);
            Assert.AreEqual(result.Telephones.Count, 1);
            Assert.AreEqual(mockPhone.Numero, result.Telephones[0].Numero);
            Assert.AreEqual(mockPhone.Id, result.Telephones[0].Id);
            Assert.AreEqual(mockContact.Object.Id, result.Telephones[0].ContatoId);
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
