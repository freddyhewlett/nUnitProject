using System;
using System.Data.SqlClient;

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

        public void AddContact(string id, string name)
        {
            _connection.Open();
            string sql = string.Format("insert into Contato (Id, Nome) values ('{0}', '{1}');", id, name);

            SqlCommand cmd = new SqlCommand(sql, _connection);

            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public string GetContact(string id)
        {
            _connection.Open();
            string sql = string.Format("select Nome from Contato where Id = '{0}';", id);

            SqlCommand cmd = new SqlCommand(sql, _connection);

            string alias = cmd.ExecuteScalar().ToString();

            _connection.Close();

            return alias;
        }
    }
}
