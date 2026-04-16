using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Projeto_Sistema_Area_Restrita
{
    public partial class Form_Login : Form
    {
        private Form_Area_Admin form_Area_Admin = new Form_Area_Admin();
        private Form_Aluno form_Aluno = new Form_Aluno();
        private Form_Professor form_Professor = new Form_Professor();
        public Form_Login()
        {
            InitializeComponent();
        }
        private void btn_Logar_Click(object sender, EventArgs e)
        {
            string username = txt_usuario.Text;
            string senha = txt_senha.Text;

            if (username == "" || senha == "")
            {
                MessageBox.Show("Usuário e ou Senha em Branco", "ALERTA");
                txt_usuario.Focus();
                return;
            }

            bool usuarioCadastrado = false;

            try
            {
                //var strConexao = "server=192.168.2.38; uid=p00297; pwd='s00297'; database=empresa";
                var strConexao = "server=localhost; uid=root; pwd=''; database=arearestrita";
                var conexao = new MySqlConnection(strConexao);
                conexao.Open();

                var comando = new MySqlCommand("SELECT * FROM arres_usuarios WHERE User_Name = @usuario AND Senha = @senha", conexao);
                comando.Parameters.AddWithValue("@usuario", username);
                comando.Parameters.AddWithValue("@senha", senha);

                var reader = comando.ExecuteReader();

                if (reader.HasRows)
                {   
                    usuarioCadastrado = true;
                    form_Area_Admin.reader = reader;
                    form_Aluno.reader = reader;
                    form_Professor.reader = reader;

                    int Valor_Nivel = 0;

                    if (reader.Read())
                    {
                        Valor_Nivel = Convert.ToInt32(reader["Nivel"]);
                    }

                    if(Valor_Nivel == 3)
                    {
                        Close();
                        MessageBox.Show("BEM VINDO ADMIN", ":)");
                        form_Area_Admin.Show();
                    }
                    if(Valor_Nivel == 2)
                    {
                        Close();
                        MessageBox.Show("BEM VINDO PROFESSOR", ":)");
                        form_Professor.Show();
                    }
                    else if(Valor_Nivel == 1)
                    {
                        Close();
                        MessageBox.Show("BEM VINDO ALUNO", ":)");
                        form_Aluno.Show();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu Um Erro: " + ex.Message);
            }

            if (usuarioCadastrado == false)
            {
                MessageBox.Show("Usuário ou Senha Incorretos.", "ALERTA");
                txt_usuario.Clear();
                txt_senha.Clear();
                txt_usuario.Focus();
            }
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            txt_usuario.Focus();
        }
    }
}
