using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LogiN
{
    public partial class TelaEstoque : Form
    {
        int idSelecionado = 0;
        bool modoEdicao = false;

        string conexao = "server=localhost;database=fiodeouro;uid=root;pwd=;";

        public TelaEstoque()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += TelaEstoque_Load;
        }

        private void TelaEstoque_Load(object sender, EventArgs e)
        {
            panelCadastroE.Visible = false;
            dgvEstoque.Visible = true;

            CarregarEstoque();
        }

        private void CarregarEstoque()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    string sql = "SELECT * FROM Estoque";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvEstoque.DataSource = dt;

                    EstiloGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar:\n" + ex.ToString());
            }
        }

        private void EstiloGrid()
        {
            dgvEstoque.EnableHeadersVisualStyles = false;

            Font fontePadrao = new Font("Century Gothic", 10F, FontStyle.Regular);
            Font fonteCabecalho = new Font("Century Gothic", 10F, FontStyle.Bold);

            Color corSelecaoLinha = Color.FromArgb(191, 165, 187);

            dgvEstoque.BackgroundColor = Color.White;
            dgvEstoque.GridColor = Color.White;
            dgvEstoque.BorderStyle = BorderStyle.None;
            dgvEstoque.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dgvEstoque.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvEstoque.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvEstoque.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvEstoque.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEstoque.ColumnHeadersDefaultCellStyle.Font = fonteCabecalho;

            dgvEstoque.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEstoque.ColumnHeadersHeight = 35;

            dgvEstoque.DefaultCellStyle.BackColor = Color.White;
            dgvEstoque.DefaultCellStyle.ForeColor = Color.Black;
            dgvEstoque.DefaultCellStyle.SelectionBackColor = corSelecaoLinha;
            dgvEstoque.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEstoque.DefaultCellStyle.Font = fontePadrao;
            dgvEstoque.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvEstoque.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvEstoque.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvEstoque.AlternatingRowsDefaultCellStyle.SelectionBackColor = corSelecaoLinha;

            dgvEstoque.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvEstoque.AlternatingRowsDefaultCellStyle.Font = fontePadrao;

            dgvEstoque.RowHeadersVisible = false;
            dgvEstoque.ReadOnly = true;
            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvEstoque.MultiSelect = false;
            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstoque.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvEstoque.RowTemplate.Height = 35;
            dgvEstoque.ScrollBars = ScrollBars.Vertical;

            foreach (DataGridViewRow row in dgvEstoque.Rows)
            {
                row.DefaultCellStyle.Font = fontePadrao;
            }

            if (dgvEstoque.Columns.Contains("id_estoque"))
                dgvEstoque.Columns["id_estoque"].Visible = false;

            dgvEstoque.Columns["nome_item"].HeaderText = "Nome";
            dgvEstoque.Columns["quantidade"].HeaderText = "Quantidade";
            dgvEstoque.Columns["categoria"].HeaderText = "Categoria";

            dgvEstoque.ClearSelection();
        }

        private void btnAbrirCadastroE_Click(object sender, EventArgs e)
        {
            modoEdicao = false;

            txtNomeItemE.Clear();
            QuantidadeE.Value = 0;
            cmbCategoriaE.SelectedIndex = -1;

            panelCadastroE.Visible = true;
            panelCadastroE.BringToFront();
        }

        private void btnEditarE_Click(object sender, EventArgs e)
        {
            if (dgvEstoque.CurrentRow != null)
            {
                modoEdicao = true;

                idSelecionado = Convert.ToInt32(dgvEstoque.CurrentRow.Cells["Id_estoque"].Value);

                txtNomeItemE.Text = dgvEstoque.CurrentRow.Cells["Nome_item"].Value.ToString();
                QuantidadeE.Value = Convert.ToInt32(dgvEstoque.CurrentRow.Cells["Quantidade"].Value);
                cmbCategoriaE.Text = dgvEstoque.CurrentRow.Cells["Categoria"].Value.ToString();

                panelCadastroE.Visible = true;
                panelCadastroE.BringToFront();
            }
            else
            {
                MessageBox.Show("Selecione um item!");
            }
        }

        private void btnSalvarE_Click(object sender, EventArgs e)
        {
            string nome = txtNomeItemE.Text;
            int quantidade = (int)QuantidadeE.Value;
            string categoria = cmbCategoriaE.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Preencha tudo!");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                if (!modoEdicao)
                {
                    string sql = "INSERT INTO Estoque (Nome_item, Quantidade, Categoria) VALUES (@n,@q,@c)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@n", nome);
                    cmd.Parameters.AddWithValue("@q", quantidade);
                    cmd.Parameters.AddWithValue("@c", categoria);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string sql = "UPDATE Estoque SET Nome_item=@n, Quantidade=@q, Categoria=@c WHERE Id_estoque=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@n", nome);
                    cmd.Parameters.AddWithValue("@q", quantidade);
                    cmd.Parameters.AddWithValue("@c", categoria);
                    cmd.Parameters.AddWithValue("@id", idSelecionado);

                    cmd.ExecuteNonQuery();
                }
            }

            panelCadastroE.Visible = false;
            CarregarEstoque();
        }

        private void btnExcluirE_Click(object sender, EventArgs e)
        {
            if (dgvEstoque.CurrentRow != null)
            {
                DialogResult confirmacao = MessageBox.Show(
                    "Tem certeza que deseja excluir este item do estoque?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacao == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(
                        dgvEstoque.CurrentRow.Cells["Id_estoque"].Value);

                    using (MySqlConnection conn = new MySqlConnection(conexao))
                    {
                        conn.Open();

                        string sql = "DELETE FROM Estoque WHERE Id_estoque=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Item excluído com sucesso!");

                    CarregarEstoque();
                }
            }
            else
            {
                MessageBox.Show("Selecione um item!");
            }
        }

        private void btnVoltarE_Click(object sender, EventArgs e)
        {
            panelCadastroE.Visible = false;
        }

        private void txtBuscaE_TextChanged(object sender, EventArgs e)
        {
            (dgvEstoque.DataSource as DataTable).DefaultView.RowFilter =
                $"Nome_item LIKE '%{txtBuscaE.Text}%' OR Categoria LIKE '%{txtBuscaE.Text}%'";
        }

        private void btnClientesE_Click(object sender, EventArgs e)
        {
            new TelaClientes().Show();
            this.Hide();
        }

        private void btnServicosE_Click(object sender, EventArgs e)
        {
            new TelaServicos().Show();
            this.Hide();
        }

        private void btnPedidosE_Click(object sender, EventArgs e)
        {
            new TelaPedidos().Show();
            this.Hide();
        }

        private void txtNomeItemE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) &&
                e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void cmbCategoriaE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
            !char.IsWhiteSpace(e.KeyChar) &&
            e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}