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

        // ================= CARREGAR =================
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

        // ================= ESTILO =================
        private void EstiloGrid()
        {
            dgvEstoque.EnableHeadersVisualStyles = false;

            dgvEstoque.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvEstoque.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgvEstoque.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 165, 187);
            dgvEstoque.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvEstoque.RowHeadersVisible = false;
            dgvEstoque.BorderStyle = BorderStyle.None;
            dgvEstoque.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvEstoque.GridColor = Color.White;

            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstoque.MultiSelect = false;
            dgvEstoque.ReadOnly = true;
            dgvEstoque.AllowUserToAddRows = false;

            dgvEstoque.Columns["Id_estoque"].Visible = false;

            dgvEstoque.Columns["Nome_item"].HeaderText = "Nome";
            dgvEstoque.Columns["Quantidade"].HeaderText = "Quantidade";
            dgvEstoque.Columns["Categoria"].HeaderText = "Categoria";

            dgvEstoque.ClearSelection();
        }

        // ================= NOVO =================
        private void btnAbrirCadastroE_Click(object sender, EventArgs e)
        {
            modoEdicao = false;

            txtNomeItemE.Clear();
            QuantidadeE.Value = 0;
            cmbCategoriaE.SelectedIndex = -1;

            panelCadastroE.Visible = true;
            panelCadastroE.BringToFront();
        }

        // ================= EDITAR =================
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

        // ================= SALVAR =================
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

        // ================= EXCLUIR =================
        private void btnExcluirE_Click(object sender, EventArgs e)
        {
            if (dgvEstoque.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvEstoque.CurrentRow.Cells["Id_estoque"].Value);

                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    string sql = "DELETE FROM Estoque WHERE Id_estoque=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                CarregarEstoque();
            }
            else
            {
                MessageBox.Show("Selecione um item!");
            }
        }

        // ================= VOLTAR =================
        private void btnVoltarE_Click(object sender, EventArgs e)
        {
            panelCadastroE.Visible = false;
        }

        // ================= BUSCA =================
        private void txtBuscaE_TextChanged(object sender, EventArgs e)
        {
            (dgvEstoque.DataSource as DataTable).DefaultView.RowFilter =
                $"Nome_item LIKE '%{txtBuscaE.Text}%' OR Categoria LIKE '%{txtBuscaE.Text}%'";
        }

        // ================= NAVEGAÇÃO =================
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
    }
}