using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AgendaUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNovoContato.Text;
            //txtContatoSalvo.Text = nome;

            string id = Guid.NewGuid().ToString();
            string stringConnection = @"Data Source=(local)\sqlexpress;Initial Catalog=Agenda;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(stringConnection);
            connection.Open();

            string sql = string.Format("insert into Contato (Id, Nome) values ('{0}', '{1}');", id, nome);

            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.ExecuteNonQuery();

            sql = string.Format("select Nome from Contato where Id = '{0}';", id);

            cmd = new SqlCommand(sql, connection);

            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            connection.Close();
        }
    }
}
