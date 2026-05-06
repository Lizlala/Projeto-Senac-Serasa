namespace LogiN
{
    public partial class Login : System.Windows.Forms.Form
    {
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnEntrar;

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

        }





        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;


            if (usuario == "usuario" && senha == "123456")
            {
                TelaEstoque principal = new TelaEstoque();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = '*';
        }
    }
}
