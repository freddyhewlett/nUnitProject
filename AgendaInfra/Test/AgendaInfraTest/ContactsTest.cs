﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaInfra;
using NUnit.Framework;
using AgendaDominio;

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
            Contact contact = new Contact() { Id = Guid.NewGuid(), Name = "Ghost" };

            //Executa
            _contacts.AddContact(contact);

            //Verifica
            Assert.True(true);
        }

        [Test]
        public void GetContactTest()
        {
            //Monta
            Contact contact = new Contact() { Id = Guid.NewGuid(), Name = "Zombie" };

            //Executa
            _contacts.AddContact(contact);
            Contact contactResult = _contacts.GetContact(contact.Id);

            //Verifica
            Assert.AreEqual(contact.Id, contactResult.Id);
            Assert.AreEqual(contact.Name, contactResult.Name);
        }

        [Test]
        public void GetAllTest()
        {
            //Monta
            Contact contact1 = new Contact() { Id = Guid.NewGuid(), Name = "Skeleton" };
            Contact contact2 = new Contact() { Id = Guid.NewGuid(), Name = "Wraith" };
            Contact contact3 = new Contact() { Id = Guid.NewGuid(), Name = "Will O Wisp" };

            //Executa
            _contacts.AddContact(contact1);
            _contacts.AddContact(contact2);
            _contacts.AddContact(contact3);
            List<Contact> contactList = _contacts.GetAll();
            Contact contactResult = contactList.Where(c => c.Id == contact1.Id).FirstOrDefault();

            //Verifica
            Assert.IsTrue(contactList.Count > 1);
            Assert.AreEqual(contactResult.Id, contact1.Id);
            Assert.AreEqual(contactResult.Name, contact1.Name);
        }

        [TearDown]
        public void TearDown()
        {
            _contacts = null;
        }
    }
}
