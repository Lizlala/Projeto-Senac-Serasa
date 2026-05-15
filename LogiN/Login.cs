using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LogiN
{
    public partial class Login : Form
    {
        string conexao = "server=localhost;uid=root;pwd=;database=fiodeouro;";

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnEntrarL;

            PanelCadastroUsuarioL.Visible = false;
            panelRedefinirSenhaL.Visible = false;
        }

        private void btnEntrarL_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conexao))
            {
                try
                {
                    con.Open();

                    string sql = "SELECT * FROM Login_usuario WHERE nome=@nome AND senha=@senha";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@nome", txtUsuarioL.Text);
                    cmd.Parameters.AddWithValue("@senha", txtSenhaL.Text);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        MessageBox.Show("Login realizado com sucesso!");

                        TelaEstoque tela = new TelaEstoque();
                        tela.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void btncadastraL_Click(object sender, EventArgs e)
        {
            PanelCadastroUsuarioL.Visible = true;
        }

        private void btnSalvarCadastroL_Click(object sender, EventArgs e)
        {
            if (txtNomeCadastroL.Text == "" || txtCpfCadastroL.Text == "" || txtSenhaCadastroL.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(conexao))
            {
                try
                {
                    con.Open();

                    string sql = "INSERT INTO Login_usuario (nome, cpf, senha) VALUES (@nome,@cpf,@senha)";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@nome", txtNomeCadastroL.Text);
                    cmd.Parameters.AddWithValue("@cpf", txtCpfCadastroL.Text);
                    cmd.Parameters.AddWithValue("@senha", txtSenhaCadastroL.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cadastro realizado com sucesso!");

                    txtNomeCadastroL.Clear();
                    txtCpfCadastroL.Clear();
                    txtSenhaCadastroL.Clear();

                    PanelCadastroUsuarioL.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void EqueceuSenha_Click(object sender, EventArgs e)
        {
            panelRedefinirSenhaL.Visible = true;
        }
        private void btnRedefinirSalvarL_Click(object sender, EventArgs e)
        {
            if (txtCpfRedefinirL.Text == "")
            {
                MessageBox.Show("Digite o CPF!");
                return;
            }

            string novaSenha = Guid.NewGuid().ToString("N").Substring(0, 8);

            using (MySqlConnection con = new MySqlConnection(conexao))
            {
                try
                {
                    con.Open();

                    string verifica = "SELECT COUNT(*) FROM Login_usuario WHERE cpf=@cpf";
                    MySqlCommand cmdVerifica = new MySqlCommand(verifica, con);
                    cmdVerifica.Parameters.AddWithValue("@cpf", txtCpfRedefinirL.Text);

                    int existe = Convert.ToInt32(cmdVerifica.ExecuteScalar());

                    if (existe == 0)
                    {
                        MessageBox.Show("CPF não encontrado!");
                        return;
                    }

                    string sql = "UPDATE Login_usuario SET senha=@senha WHERE cpf=@cpf";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@senha", novaSenha);
                    cmd.Parameters.AddWithValue("@cpf", txtCpfRedefinirL.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Nova senha: " + novaSenha);

                    panelRedefinirSenhaL.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void btnVoltarRedefinirL_Click(object sender, EventArgs e)
        {
            panelRedefinirSenhaL.Visible = false;
        }
    }
}