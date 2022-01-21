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
        public void GetContactWithPhoneList()
        {
            //Monta
                //CriarMoq IContaxt
                //Moq função GetById de IContact
                //Criar moq ITelephone
                //Moq função GetAllFromContact

            //Executa
                //Chamar metodo GetById de ContactRepository

            //Verifica
                //Verificar se o contact retornado contem os mesmos dados do moq de IContao com a lista de telefones do moq ITelefone
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
