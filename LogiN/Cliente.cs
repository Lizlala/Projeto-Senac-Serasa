using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LogiN
{
    public partial class TelaClientes : Form
    {
        int idSelecionado = 0;
        bool modoEdicao = false;

        string conexaoString = "server=localhost;database=fiodeouro;uid=root;pwd=;";

        public TelaClientes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += TelaClientes_Load;
        }

        private void TelaClientes_Load(object sender, EventArgs e)
        {
            panelCadastroCliente.Visible = false;
            dgvClientes.Visible = true;

            CarregarClientes();
        }

        // ================= CARREGAR =================
        private void CarregarClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(conexaoString))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT Id_cliente, Nome, CPF, Telefone FROM Clientes";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvClientes.DataSource = dt;

                    EstilizarGrid();

                    dgvClientes.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar:\n" + ex.ToString());
                }
            }
        }

        // ================= ESTILO =================
        private void EstilizarGrid()
        {
            dgvClientes.EnableHeadersVisualStyles = false;

            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 165, 187);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClientes.GridColor = Color.White;

            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvClientes.Columns["Id_cliente"] != null)
                dgvClientes.Columns["Id_cliente"].Visible = false;
        }

        // ================= NOVO =================
        private void btnNovoClienteC_Click(object sender, EventArgs e)
        {
            modoEdicao = false;

            txtNomeC.Clear();
            txtCPF.Clear();
            txtTelefoneC.Clear();

            dgvClientes.Visible = false;
            panelCadastroCliente.Visible = true;
            panelCadastroCliente.BringToFront();
        }

        // ================= EDITAR =================
        private void btnEditarC_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                modoEdicao = true;

                idSelecionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells["Id_cliente"].Value);

                txtNomeC.Text = dgvClientes.CurrentRow.Cells["Nome"].Value.ToString();
                txtCPF.Text = dgvClientes.CurrentRow.Cells["CPF"].Value.ToString();
                txtTelefoneC.Text = dgvClientes.CurrentRow.Cells["Telefone"].Value.ToString();

                dgvClientes.Visible = false;
                panelCadastroCliente.Visible = true;
                panelCadastroCliente.BringToFront();
            }
            else
            {
                MessageBox.Show("Selecione um cliente!");
            }
        }

        // ================= SALVAR =================
        private void btnSalvarC_Click(object sender, EventArgs e)
        {
            string nome = txtNomeC.Text;
            string cpf = txtCPF.Text;
            string telefone = txtTelefoneC.Text;

            if (!string.IsNullOrWhiteSpace(nome) &&
                !string.IsNullOrWhiteSpace(cpf) &&
                !string.IsNullOrWhiteSpace(telefone))
            {
                using (MySqlConnection conn = new MySqlConnection(conexaoString))
                {
                    try
                    {
                        conn.Open();

                        if (!modoEdicao)
                        {
                            string sql = "INSERT INTO Clientes (Nome, CPF, Telefone) VALUES (@nome, @cpf, @tel)";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);

                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@cpf", cpf);
                            cmd.Parameters.AddWithValue("@tel", telefone);

                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            string sql = "UPDATE Clientes SET Nome=@nome, CPF=@cpf, Telefone=@tel WHERE Id_cliente=@id";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);

                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@cpf", cpf);
                            cmd.Parameters.AddWithValue("@tel", telefone);
                            cmd.Parameters.AddWithValue("@id", idSelecionado);

                            cmd.ExecuteNonQuery();
                        }

                        panelCadastroCliente.Visible = false;
                        dgvClientes.Visible = true;

                        CarregarClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar:\n" + ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        // ================= EXCLUIR =================
        private void btnExcluirC_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["Id_cliente"].Value);

                using (MySqlConnection conn = new MySqlConnection(conexaoString))
                {
                    try
                    {
                        conn.Open();

                        string sql = "DELETE FROM Clientes WHERE Id_cliente=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();

                        CarregarClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir:\n" + ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente!");
            }
        }

        // ================= VOLTAR =================
        private void btnVoltarC_Click(object sender, EventArgs e)
        {
            panelCadastroCliente.Visible = false;
            dgvClientes.Visible = true;
        }

        // ================= BUSCA =================
        private void txtBuscaC_TextChanged(object sender, EventArgs e)
        {
            string termo = txtBuscaC.Text.ToLower();

            CurrencyManager cm = (CurrencyManager)BindingContext[dgvClientes.DataSource];
            cm.SuspendBinding();

            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                if (row.IsNewRow) continue;

                string nome = row.Cells["Nome"].Value.ToString().ToLower();
                string cpf = row.Cells["CPF"].Value.ToString().ToLower();
                string tel = row.Cells["Telefone"].Value.ToString().ToLower();

                row.Visible = nome.Contains(termo) || cpf.Contains(termo) || tel.Contains(termo);
            }

            cm.ResumeBinding();
        }

        // ================= NAVEGAÇÃO =================
        private void btnEstoqueC_Click(object sender, EventArgs e)
        {
            new TelaEstoque().Show();
            this.Hide();
        }

        private void btnServicosC_Click(object sender, EventArgs e)
        {
            new TelaServicos().Show();
            this.Hide();
        }

        private void btnPedidosC_Click(object sender, EventArgs e)
        {
            new TelaPedidos().Show();
            this.Hide();
        }
    }
}