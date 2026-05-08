using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LogiN
{
    public partial class TelaServicos : Form
    {
        int idSelecionado = 0;
        bool modoEdicao = false;

        string conexao = "server=localhost;database=fiodeouro;uid=root;pwd=;";

        public TelaServicos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += TelaServicos_Load;
        }

        private void TelaServicos_Load(object sender, EventArgs e)
        {
            panelCadastroS.Visible = false;
            dgvServicos.Visible = true;

            // TIPOS DE SERVIÇO
            cmbTipodeServicoS.Items.Add("Barra");
            cmbTipodeServicoS.Items.Add("Ajuste");
            cmbTipodeServicoS.Items.Add("Zíper");
            cmbTipodeServicoS.Items.Add("Customização");

            CarregarServicos();
        }

        // ================= CARREGAR =================
        private void CarregarServicos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    string sql = "SELECT * FROM cadastro_servico";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvServicos.DataSource = dt;

                    EstiloGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro REAL ao carregar:\n" + ex.ToString());
            }
        }

        // ================= ESTILO =================
        private void EstiloGrid()
        {
            dgvServicos.EnableHeadersVisualStyles = false;

            dgvServicos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvServicos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgvServicos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 165, 187);
            dgvServicos.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvServicos.RowHeadersVisible = false;
            dgvServicos.BorderStyle = BorderStyle.None;
            dgvServicos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvServicos.GridColor = Color.White;

            dgvServicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicos.MultiSelect = false;
            dgvServicos.ReadOnly = true;
            dgvServicos.AllowUserToAddRows = false;

            dgvServicos.Columns["Id_cadastro_servico"].Visible = false;

            dgvServicos.Columns["nome_servico"].HeaderText = "Tipo de Serviço";
            dgvServicos.Columns["Valor"].HeaderText = "Preço";

            dgvServicos.Columns["Valor"].DefaultCellStyle.Format = "C2";

            dgvServicos.ClearSelection();
        }

        // ================= TIPO → PREÇO =================
        private void cmbTipodeServicoS_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTipodeServicoS.Text)
            {
                case "Barra":
                    txtValorS.Text = "15";
                    break;

                case "Ajuste":
                    txtValorS.Text = "25";
                    break;

                case "Zíper":
                    txtValorS.Text = "30";
                    break;

                case "Customização":
                    txtValorS.Text = "50";
                    break;
            }
        }

        // ================= NOVO =================
        private void btnAbrirCadastroS_Click(object sender, EventArgs e)
        {
            modoEdicao = false;

            cmbTipodeServicoS.SelectedIndex = -1;
            txtValorS.Clear();

            panelCadastroS.Visible = true;
            panelCadastroS.BringToFront();
        }

        // ================= EDITAR =================
        private void btnEditarS_Click(object sender, EventArgs e)
        {
            if (dgvServicos.CurrentRow != null)
            {
                modoEdicao = true;

                idSelecionado = Convert.ToInt32(dgvServicos.CurrentRow.Cells["id_cadastro_servico"].Value);

                cmbTipodeServicoS.Text = dgvServicos.CurrentRow.Cells["nome_servico"].Value.ToString();
                txtValorS.Text = dgvServicos.CurrentRow.Cells["Valor"].Value.ToString();

                panelCadastroS.Visible = true;
                panelCadastroS.BringToFront();
            }
            else
            {
                MessageBox.Show("Selecione um serviço!");
            }
        }

        // ================= SALVAR =================
        private void btnSalvarS_Click(object sender, EventArgs e)
        {
            string tipo = cmbTipodeServicoS.Text;

            decimal valor;
            if (!decimal.TryParse(txtValorS.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out valor))
            {
                MessageBox.Show("Preço inválido!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tipo))
            {
                MessageBox.Show("Selecione um tipo!");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    if (!modoEdicao)
                    {
                        string sql = "INSERT INTO cadastro_servico (nome_servico, Valor) VALUES (@t,@v)";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@t", tipo);
                        cmd.Parameters.AddWithValue("@v", valor);

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string sql = "UPDATE cadastro_servicos SET nome_servico=@t, Valor=@v WHERE Id_cadastro_servico=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@t", tipo);
                        cmd.Parameters.AddWithValue("@v", valor);
                        cmd.Parameters.AddWithValue("@id", idSelecionado);

                        cmd.ExecuteNonQuery();
                    }
                }

                panelCadastroS.Visible = false;
                dgvServicos.Visible = true;

                CarregarServicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro REAL ao salvar:\n" + ex.ToString());
            }
        }

        // ================= EXCLUIR =================
        private void btnExcluirS_Click(object sender, EventArgs e)
        {
            if (dgvServicos.CurrentRow != null)
            {
                try
                {
                    int id = Convert.ToInt32(dgvServicos.CurrentRow.Cells["Id_cadastro_servico"].Value);

                    using (MySqlConnection conn = new MySqlConnection(conexao))
                    {
                        conn.Open();

                        string sql = "DELETE FROM cadastro_servico WHERE Id_cadastro_servico=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }

                    CarregarServicos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro REAL ao excluir:\n" + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Selecione um serviço!");
            }
        }

        // ================= VOLTAR =================
        private void btnVoltarS_Click(object sender, EventArgs e)
        {
            panelCadastroS.Visible = false;
            dgvServicos.Visible = true;
        }

        // ================= BUSCA =================
        private void txtBuscaS_TextChanged(object sender, EventArgs e)
        {
            if (dgvServicos.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter =
                    $"nome_servico LIKE '%{txtBuscaS.Text}%'";
            }
        }

        // ================= NAVEGAÇÃO =================
        private void btnClientesS_Click(object sender, EventArgs e)
        {
            new TelaClientes().Show();
            this.Hide();
        }

        private void btnEstoqueS_Click(object sender, EventArgs e)
        {
            new TelaEstoque().Show();
            this.Hide();
        }

        private void btnPedidosS_Click(object sender, EventArgs e)
        {
            new TelaPedidos().Show();
            this.Hide();
        }

        private void btnVoltarS_Click_1(object sender, EventArgs e)
        {
            panelCadastroS.Visible = false;
            dgvServicos.Visible = true;
        }
    }
}