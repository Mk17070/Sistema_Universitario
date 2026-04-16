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

namespace Projeto_Sistema_Area_Restrita
{
    public partial class Form_Gerenciar_Usuarios : Form
    {
        private MySqlConnection Conexao;
        public Form_Gerenciar_Usuarios()
        {
            InitializeComponent();
            //var strConexao = "server=192.168.2.38; uid=p00297; pwd='s00297'; database=empresa";
            var strConexao = "server=localhost; uid=root; pwd=''; database=arearestrita";
            Conexao = new MySqlConnection(strConexao);
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string Nome_Usuario = Tb_Nome.Text;
            string User_Name = Tb_Usuario.Text;
            string Senha = Tb_Senha.Text;
            string Status = Cb_Status.Text;
            int Nivel = Convert.ToInt32(cb_Nivel.Text);


            var comando = new MySqlCommand("INSERT INTO arres_usuarios (Nome_Usuario, User_Name, Senha, Status, Nivel) VALUES (@nomeUsuario, @userName, @senha, @status, @nivel)", Conexao);

            comando.Parameters.AddWithValue("@nomeUsuario", Nome_Usuario);
            comando.Parameters.AddWithValue("@userName", User_Name);
            comando.Parameters.AddWithValue("@senha", Senha);
            comando.Parameters.AddWithValue("@status", Status);
            comando.Parameters.AddWithValue("@nivel", Nivel);

            try
            {
                Conexao.Open();
                comando.ExecuteNonQuery();
                Conexao.Close();

                MessageBox.Show("Usuario Inserido Com Sucesso");

                Tb_Nome.Clear();
                Tb_Usuario.Clear();
                Tb_Senha.Clear();
                Cb_Status.Text = "";
                cb_Nivel.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um Erro:" + ex.Message);
            }
        }
    }
}
