using AgendaDominio;
using AgendaInfra;
using AutoFixture;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaInfraTest
{
    [TestFixture]
    public class Contacts2Test : BaseTest
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
            Assert.AreEqual(3, contactList.Count);
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
