using AgendaDAL;
using NUnit.Framework;
using AgendaDomain;
using AutoFixture;
using System;
using AgendaDALTest;

namespace AgendaInfraTest
{
    [TestFixture]
    public class ContactsTest : BaseTest
    {
        private Contacts _contacts;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contacts = new Contacts();
            _fixture = new Fixture();
        }

        [Test]
        public void AddContactTest()
        {
            //Monta
            Contact contact = _fixture.Create<Contact>();

            //Executa
            _contacts.AddContact(contact);

            //Verifica
            Assert.True(true);
        }

        [Test]
        public void GetContactTest()
        {
            //Monta
            Contact contact = _fixture.Create<Contact>();

            //Executa
            _contacts.AddContact(contact);
            Contact contactResult = _contacts.GetContact(contact.Id);

            //Verifica
            Assert.AreEqual(contact.Id, contactResult.Id);
            Assert.AreEqual(contact.Nome, contactResult.Nome);
        }
        
        [TearDown]
        public void TearDown()
        {
            _contacts = null;
            _fixture = null;
        }
    }
}
