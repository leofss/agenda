using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace agenda
{
    class Conexao
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strQuery;


        public Conexao()
        {
            conexao = new MySqlConnection("Server=localhost;Database=db_agenda;Uid=root;Port=3306;Pwd=34686328;");
        }

        public void novo(string id, string nome, string sobrenome, string telefone, string celular)
        {
            strQuery = "INSERT INTO tb_agenda (id, nome, sobrenome, telefone, celular) VALUES (@id, @nome, @sobrenome, @telefone, @celular)";
            comando = new MySqlCommand(strQuery, conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@sobrenome", sobrenome);
            comando.Parameters.AddWithValue("@telefone", telefone);
            comando.Parameters.AddWithValue("@celular", celular);


            conexao.Open();

            comando.ExecuteNonQuery();
        }

        public void editar(string id, string nome, string sobrenome, string telefone, string celular)
        {
            strQuery = "UPDATE tb_agenda set nome = @nome, sobrenome = @sobrenome, telefone = @telefone, celular = @celular WHERE id = @id";
            comando = new MySqlCommand(strQuery, conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@sobrenome", sobrenome);
            comando.Parameters.AddWithValue("@telefone", telefone);
            comando.Parameters.AddWithValue("@celular", celular);

            conexao.Open();

            comando.ExecuteNonQuery();
        }

        public void excluir(string id)
        {
            strQuery = "DELETE from tb_agenda WHERE id = @id";

            comando = new MySqlCommand(strQuery, conexao);
            comando.Parameters.AddWithValue("@id", id);

            conexao.Open();

            comando.ExecuteNonQuery();
        }

        public MySqlDataReader consultar(string id)
        {
            strQuery = "SELECT * FROM tb_agenda WHERE id = @id";

            comando = new MySqlCommand(strQuery, conexao);
            comando.Parameters.AddWithValue("@id", id);

            conexao.Open();

            dr = comando.ExecuteReader();

            return dr;
        }

        public DataTable exibir()
        {
            strQuery = "SELECT * FROM tb_agenda";

            da = new MySqlDataAdapter(strQuery, conexao);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        public void close()
        {
            conexao.Close();
            conexao = null;
            comando = null;
        }
    }

}
