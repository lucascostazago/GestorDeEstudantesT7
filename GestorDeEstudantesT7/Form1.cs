using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeEstudantesT7
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            MeuBancoDeDados meuBancoDeDados = new MeuBancoDeDados();
            MySqlDataAdapter meuAdaptorSql = new MySqlDataAdapter();
            DataTable tabelaDeDados = new DataTable();
            MySqlCommand comandoSql = new MySqlCommand("SELECT * FROM `usuarios` WHERE `nome_de_usuario` = @usuario AND `senha` = @senha", meuBancoDeDados.getConexao);

            comandoSql.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = textBoxUsuario.Text;
            comandoSql.Parameters.Add("@senha", MySqlDbType.VarChar).Value = textBoxSenha.Text;

            meuAdaptorSql.SelectCommand = comandoSql;
            meuAdaptorSql.Fill(tabelaDeDados);

            if (tabelaDeDados.Rows.Count > 0)
            {
                MessageBox.Show("SIM");
            }
            else
            {
                MessageBox.Show("NAO");
            }
        }

        private void pictureBoxUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
