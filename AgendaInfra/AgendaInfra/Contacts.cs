using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgendaDominio;

namespace AgendaInfra
{
    public class Contacts
    {
        private string _stringConnection;
        private SqlConnection _connection;

        public Contacts()
        {
            _stringConnection = @"Data Source=(local)\sqlexpress;Initial Catalog=Agenda;Integrated Security=True;";
            _connection = new SqlConnection(_stringConnection);
        }

        public void AddContact(Contact contact)
        {
            _connection.Open();
            string sql = string.Format("insert into Contato (Id, Nome) values ('{0}', '{1}');", contact.Id, contact.Name);

            SqlCommand cmd = new SqlCommand(sql, _connection);

            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public Contact GetContact(Guid id)
        {
            _connection.Open();
            string sql = string.Format("select Id, Nome from Contato where Id = '{0}';", id);

            SqlCommand cmd = new SqlCommand(sql, _connection);

            var sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();

            Contact contact = new Contact() { Id = Guid.Parse(sqlDataReader["Id"].ToString()), Name = sqlDataReader["Nome"].ToString() };

            _connection.Close();

            return contact;
        }

        public List<Contact> GetAll()
        {
            List<Contact> contactList = new List<Contact>();

            _connection.Open();
            string sql = string.Format("select Id, Nome from Contato;");

            SqlCommand cmd = new SqlCommand(sql, _connection);

            var sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Contact contact = new Contact() { Id = Guid.Parse(sqlDataReader["Id"].ToString()), Name = sqlDataReader["Nome"].ToString() };
                contactList.Add(contact);
            }

            _connection.Close();

            return contactList;
        }
    }
}
