using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using AgendaDominio;
using Dapper;

namespace AgendaInfra
{
    public class Contacts
    {
        private string _stringConnection;

        public Contacts()
        {
            _stringConnection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        public void AddContact(Contact contact)
        {
            using(var con = new SqlConnection(_stringConnection))
            {
                con.Execute("insert into Contato (Id, Nome) values (@Id, @Nome)", contact);
            }
        }

        public Contact GetContact(Guid id)
        {
            Contact contact;
            using (var con = new SqlConnection(_stringConnection))
            {
                contact = con.QueryFirst<Contact>("select Id, Nome from Contato where Id = @Id", new { Id = id });                
            }
            return contact;
        }

        public List<Contact> GetAll()
        {
            List<Contact> contactList = new List<Contact>();
            using (var con = new SqlConnection(_stringConnection))
            {
                contactList = con.Query<Contact>("select Id, Nome from Contato").ToList();
            }
            return contactList;
        }
    }
}
