using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaInfra;
using NUnit.Framework;
using AgendaDominio;
using AutoFixture;

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

        [Test]
        public void GetAllTest()
        {
            //Monta
            Contact contact1 = _fixture.Create<Contact>();
            Contact contact2 = _fixture.Create<Contact>();
            Contact contact3 = _fixture.Create<Contact>();

            //Executa
            _contacts.AddContact(contact1);
            _contacts.AddContact(contact2);
            _contacts.AddContact(contact3);
            List<Contact> contactList = _contacts.GetAll();
            Contact contactResult = contactList.Where(c => c.Id == contact1.Id).FirstOrDefault();

            //Verifica
            Assert.IsTrue(contactList.Count > 1);
            Assert.AreEqual(contactResult.Id, contact1.Id);
            Assert.AreEqual(contactResult.Nome, contact1.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contacts = null;
            _fixture = null;
        }
    }
}
