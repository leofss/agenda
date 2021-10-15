using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            {
                Conexao conexao = new Conexao();
                try
                {
                    conexao.novo(txtID.Text, txtnome.Text, txtsobrenome.Text, txttell.Text, txtcell.Text);
                    MessageBox.Show("Cadastro inserido!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.close();
                }
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            {
                Conexao conexao = new Conexao();
                try
                {
                    conexao.editar(txtID.Text, txtnome.Text, txtsobrenome.Text, txttell.Text, txtcell.Text);
                    MessageBox.Show("Cadastro alterado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.close();
                }
            }

        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            {
                Conexao conexao = new Conexao();

                try
                {
                    conexao.excluir(txtID.Text);
                    MessageBox.Show("Cadastro excluido!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.close();
                }
            }
        }

        private void btnconsultar_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();

            try
            {
                MySqlDataReader dr = conexao.consultar(txtID.Text);

                while (dr.Read())
                {
                    txtnome.Text = Convert.ToString(dr["nome"]);
                    txtsobrenome.Text = Convert.ToString(dr["sobrenome"]);
                    txttell.Text = Convert.ToString(dr["telefone"]);
                    txtcell.Text = Convert.ToString(dr["celular"]);

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.close();
            }

        }

        private void btnexibir_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            try
            {
                dgvDados.DataSource = conexao.exibir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.close();
            }
        }
    }
}
