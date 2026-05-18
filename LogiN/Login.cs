using MySql.Data.MySqlClient;
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

            lblEqueceuSenha.Click += EqueceuSenha_Click;

            txtCpfCadastroL.MaxLength = 11;
            txtSenhaCadastroL.MaxLength = 6;

            txtCpfRedefinirL.MaxLength = 11;
            txtSenhaRedefinirL.MaxLength = 6;

            txtCpfCadastroL.KeyPress += ApenasNumeros_KeyPress;
            txtSenhaCadastroL.KeyPress += ApenasNumeros_KeyPress;
            txtCpfRedefinirL.KeyPress += ApenasNumeros_KeyPress;
            txtSenhaRedefinirL.KeyPress += ApenasNumeros_KeyPress;

            //btnVoltarRedefinirL.Click += btnVoltarRedefinirL_Click;
        }

        private void ApenasNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true; 
            }
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
            PanelCadastroUsuarioL.BringToFront();
        }

        private void btnSalvarCadastroL_Click(object sender, EventArgs e)
        {
            if (txtCpfCadastroL.Text.Length != 11)
            {
                MessageBox.Show("O CPF deve conter exatamente 11 números!");
                return;
            }
            if (txtSenhaCadastroL.Text.Length != 6)
            {
                MessageBox.Show("A senha deve conter exatamente 6 números!");
                return;
            }

            if (txtNomeCadastroL.Text == "")
            {
                MessageBox.Show("Preencha o campo Nome!");
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
                    LimparCamposCadastro();
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
            panelRedefinirSenhaL.BringToFront();
        }

        private void btnRedefinirSalvarL_Click(object sender, EventArgs e)
        {
            if (txtCpfRedefinirL.Text.Length != 11)
            {
                MessageBox.Show("O CPF deve conter exatamente 11 números!");
                return;
            }
            if (txtSenhaRedefinirL.Text.Length != 6)
            {
                MessageBox.Show("A nova senha deve conter exatamente 6 números!");
                return;
            }

            string novaSenha = txtSenhaRedefinirL.Text;

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

                    MessageBox.Show("Senha redefinida com sucesso!");
                    LimparCamposRedefinir();
                    panelRedefinirSenhaL.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void btnVoltarLogin_Click(object sender, EventArgs e)
        {
            LimparCamposCadastro();
            PanelCadastroUsuarioL.Visible = false;
        }

        private void btnVoltarL_Click(object sender, EventArgs e)
        {
            LimparCamposCadastro();
            PanelCadastroUsuarioL.Visible = false;
        }

        private void LimparCamposCadastro()
        {
            txtNomeCadastroL.Clear();
            txtCpfCadastroL.Clear();
            txtSenhaCadastroL.Clear();
        }

        private void LimparCamposRedefinir()
        {
            txtCpfRedefinirL.Clear();
            txtSenhaRedefinirL.Clear();
        }
    }
}