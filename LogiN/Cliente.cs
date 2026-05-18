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

            txtCPF.MaxLength = 11;
            txtTelefoneC.MaxLength = 11;

            CarregarClientes();
        }

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

        private void EstilizarGrid()
        {
            dgvClientes.EnableHeadersVisualStyles = false;

            Font fontePadrao = new Font("Century Gothic", 10F, FontStyle.Regular);
            Font fonteCabecalho = new Font("Century Gothic", 10F, FontStyle.Bold);

            Color corSelecaoLinha = Color.FromArgb(191, 165, 187);

            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.GridColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = fonteCabecalho;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvClientes.ColumnHeadersHeight = 35;

            dgvClientes.DefaultCellStyle.BackColor = Color.White;
            dgvClientes.DefaultCellStyle.ForeColor = Color.Black;
            dgvClientes.DefaultCellStyle.SelectionBackColor = corSelecaoLinha;
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvClientes.DefaultCellStyle.Font = fontePadrao;
            dgvClientes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvClientes.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvClientes.AlternatingRowsDefaultCellStyle.SelectionBackColor = corSelecaoLinha;
            dgvClientes.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvClientes.AlternatingRowsDefaultCellStyle.Font = fontePadrao;

            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.ReadOnly = true;

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvClientes.RowTemplate.Height = 35;
            dgvClientes.ScrollBars = ScrollBars.Vertical;

            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                row.DefaultCellStyle.Font = fontePadrao;
            }

            if (dgvClientes.Columns.Contains("Id_cliente"))
                dgvClientes.Columns["Id_cliente"].Visible = false;

            if (dgvClientes.Columns.Contains("Nome"))
                dgvClientes.Columns["Nome"].HeaderText = "Nome";

            if (dgvClientes.Columns.Contains("Telefone"))
                dgvClientes.Columns["Telefone"].HeaderText = "Telefone";

            if (dgvClientes.Columns.Contains("CPF"))
                dgvClientes.Columns["CPF"].HeaderText = "CPF";

            dgvClientes.ClearSelection();
            dgvClientes.CurrentCell = null;
        }

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

        private void btnEditarC_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                modoEdicao = true;

                idSelecionado = Convert.ToInt32(
                    dgvClientes.CurrentRow.Cells["Id_cliente"].Value);

                txtNomeC.Text =
                    dgvClientes.CurrentRow.Cells["Nome"].Value.ToString();

                txtCPF.Text =
                    dgvClientes.CurrentRow.Cells["CPF"].Value.ToString();

                txtTelefoneC.Text =
                    dgvClientes.CurrentRow.Cells["Telefone"].Value.ToString();

                dgvClientes.Visible = false;
                panelCadastroCliente.Visible = true;
                panelCadastroCliente.BringToFront();
            }
            else
            {
                MessageBox.Show("Selecione um cliente!");
            }
        }

        private void btnSalvarC_Click(object sender, EventArgs e)
        {
            string nome = txtNomeC.Text.Trim();
            string cpf = txtCPF.Text.Trim();
            string telefone = txtTelefoneC.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrWhiteSpace(cpf) ||
                string.IsNullOrWhiteSpace(telefone))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            if (cpf.Length != 11)
            {
                MessageBox.Show("CPF deve conter 11 dígitos!");
                return;
            }

            if (telefone.Length != 11)
            {
                MessageBox.Show("Telefone deve conter 11 dígitos!");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexaoString))
            {
                try
                {
                    conn.Open();

                    if (!modoEdicao)
                    {
                        string verificaCpf =
                            "SELECT COUNT(*) FROM Clientes WHERE CPF=@cpf";

                        MySqlCommand verifica =
                            new MySqlCommand(verificaCpf, conn);

                        verifica.Parameters.AddWithValue("@cpf", cpf);

                        int existe =
                            Convert.ToInt32(verifica.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show("CPF já cadastrado!");
                            return;
                        }

                        string sql =
                            "INSERT INTO Clientes (Nome, CPF, Telefone) " +
                            "VALUES (@nome, @cpf, @tel)";

                        MySqlCommand cmd =
                            new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.Parameters.AddWithValue("@tel", telefone);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cliente cadastrado!");
                    }
                    else
                    {
                        string sql =
                            "UPDATE Clientes " +
                            "SET Nome=@nome, CPF=@cpf, Telefone=@tel " +
                            "WHERE Id_cliente=@id";

                        MySqlCommand cmd =
                            new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.Parameters.AddWithValue("@tel", telefone);
                        cmd.Parameters.AddWithValue("@id", idSelecionado);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cliente atualizado!");

                        modoEdicao = false;
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

        private void btnExcluirC_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                DialogResult confirmacao = MessageBox.Show(
                    "Tem certeza que deseja excluir este cliente?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacao == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(
                        dgvClientes.CurrentRow.Cells["Id_cliente"].Value);

                    using (MySqlConnection conn =
                        new MySqlConnection(conexaoString))
                    {
                        try
                        {
                            conn.Open();

                            string sql =
                                "DELETE FROM Clientes WHERE Id_cliente=@id";

                            MySqlCommand cmd =
                                new MySqlCommand(sql, conn);

                            cmd.Parameters.AddWithValue("@id", id);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show(
                                "Cliente excluído com sucesso!");

                            CarregarClientes();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "Erro ao excluir:\n" + ex.ToString());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente!");
            }
        }

        private void btnVoltarC_Click(object sender, EventArgs e)
        {
            panelCadastroCliente.Visible = false;
            dgvClientes.Visible = true;
        }

        private void txtBuscaC_TextChanged(object sender, EventArgs e)
        {
            string termo = txtBuscaC.Text.ToLower();

            CurrencyManager cm =
                (CurrencyManager)BindingContext[dgvClientes.DataSource];

            cm.SuspendBinding();

            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string nome =
                    row.Cells["Nome"].Value.ToString().ToLower();

                string cpf =
                    row.Cells["CPF"].Value.ToString().ToLower();

                string tel =
                    row.Cells["Telefone"].Value.ToString().ToLower();

                row.Visible =
                    nome.Contains(termo) ||
                    cpf.Contains(termo) ||
                    tel.Contains(termo);
            }

            cm.ResumeBinding();
        }

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

        private void txtNomeC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) &&
                e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            if (txtCPF.Text.Length >= 11 &&
                e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtTelefoneC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            if (txtTelefoneC.Text.Length >= 11 &&
                e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}