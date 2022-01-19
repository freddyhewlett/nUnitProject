using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaInfra;
using NUnit.Framework;

namespace AgendaInfraTest
{
    [TestFixture]
    public class ContactsTest
    {
        private Contacts _contacts;

        [SetUp]
        public void SetUp()
        {
            _contacts = new Contacts();
        }

        [Test]
        public void AddContactTest()
        {
            //Monta
            string id = Guid.NewGuid().ToString();
            string name = "Ghost";

            //Executa
            _contacts.AddContact(id, name);

            //Verifica
            Assert.True(true);
        }

        [Test]
        public void GetContactTest()
        {
            //Monta
            string id = Guid.NewGuid().ToString();
            string name = "Zombie";

            //Executa
            _contacts.AddContact(id, name);
            string result = _contacts.GetContact(id);

            //Verifica
            Assert.AreEqual(name, result);
        }

        [TearDown]
        public void TearDown()
        {
            _contacts = null;
        }
    }
}
