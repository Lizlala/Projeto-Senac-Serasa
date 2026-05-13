using K4os.Compression.LZ4.Internal;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Windows.Forms;

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

            cmbTipodeServicoS.Items.Add("Barra");
            cmbTipodeServicoS.Items.Add("Ajuste");
            cmbTipodeServicoS.Items.Add("Zíper");
            cmbTipodeServicoS.Items.Add("Customização");

            CarregarServicos();
        }

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

        private void EstiloGrid()
        {
            dgvServicos.EnableHeadersVisualStyles = false;

            // FONTES
            Font fontePadrao = new Font("Century Gothic", 10F, FontStyle.Regular);
            Font fonteCabecalho = new Font("Century Gothic", 10F, FontStyle.Bold);

            // COR PADRÃO DO SISTEMA
            Color corSelecaoLinha = Color.FromArgb(191, 165, 187);

            // FUNDO E BORDAS
            dgvServicos.BackgroundColor = Color.White;
            dgvServicos.GridColor = Color.White;
            dgvServicos.BorderStyle = BorderStyle.None;
            dgvServicos.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // CABEÇALHO
            dgvServicos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvServicos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvServicos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvServicos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvServicos.ColumnHeadersDefaultCellStyle.Font = fonteCabecalho;
            dgvServicos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvServicos.ColumnHeadersHeight = 35;

            // CÉLULAS
            dgvServicos.DefaultCellStyle.BackColor = Color.White;
            dgvServicos.DefaultCellStyle.ForeColor = Color.Black;
            dgvServicos.DefaultCellStyle.SelectionBackColor = corSelecaoLinha;
            dgvServicos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvServicos.DefaultCellStyle.Font = fontePadrao;
            dgvServicos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // LINHAS ALTERNADAS
            dgvServicos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvServicos.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvServicos.AlternatingRowsDefaultCellStyle.SelectionBackColor = corSelecaoLinha;
            dgvServicos.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvServicos.AlternatingRowsDefaultCellStyle.Font = fontePadrao;

            // COMPORTAMENTO
            dgvServicos.RowHeadersVisible = false;
            dgvServicos.ReadOnly = true;
            dgvServicos.AllowUserToAddRows = false;
            dgvServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicos.MultiSelect = false;

            dgvServicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvServicos.RowTemplate.Height = 35;
            dgvServicos.ScrollBars = ScrollBars.Vertical;

            // GARANTE PADRÃO NAS LINHAS
            foreach (DataGridViewRow row in dgvServicos.Rows)
            {
                row.DefaultCellStyle.Font = fontePadrao;
            }

            // 🔥 ESCONDE ID
            if (dgvServicos.Columns.Contains("Id_cadastro_servico"))
                dgvServicos.Columns["Id_cadastro_servico"].Visible = false;

            // 🔥 HEADERS PADRÃO
            if (dgvServicos.Columns.Contains("nome_servico"))
                dgvServicos.Columns["nome_servico"].HeaderText = "Tipo de Serviço";

            if (dgvServicos.Columns.Contains("Valor"))
            {
                dgvServicos.Columns["Valor"].HeaderText = "Preço";
                dgvServicos.Columns["Valor"].DefaultCellStyle.Format = "C2";
            }

            dgvServicos.ClearSelection();
        }

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

        private void btnAbrirCadastroS_Click(object sender, EventArgs e)
        {
            modoEdicao = false;

            cmbTipodeServicoS.SelectedIndex = -1;
            txtValorS.Clear();

            panelCadastroS.Visible = true;
            panelCadastroS.BringToFront();
        }

        private void btnEditarS_Click(object sender, EventArgs e)
        {
            if (dgvServicos.CurrentRow != null)
            {
                modoEdicao = true;

                idSelecionado = Convert.ToInt32(dgvServicos.CurrentRow.Cells["id_cadastro_servico"].Value);

                cmbTipodeServicoS.Text = dgvServicos.CurrentRow.Cells["nome_servico"].Value.ToString();
                txtValorS.Text = dgvServicos.CurrentRow.Cells["valor"].Value.ToString();

                panelCadastroS.Visible = true;
                panelCadastroS.BringToFront();
            }
            else
            {
                MessageBox.Show("Selecione um serviço!");
            }
        }

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
                        string sql = "INSERT INTO cadastro_servico(nome_servico, Valor) VALUES (@t,@v)";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@t", tipo);
                        cmd.Parameters.AddWithValue("@v", valor);

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string sql = "UPDATE cadastro_servico SET nome_servico=@t, Valor=@v WHERE Id_cadastro_servico=@id";
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

        private void btnExcluirS_Click(object sender, EventArgs e)
        {
            if (dgvServicos.CurrentRow != null)
            {
                DialogResult confirmacao = MessageBox.Show(
                    "Tem certeza que deseja excluir este serviço?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacao == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(
                            dgvServicos.CurrentRow.Cells["Id_cadastro_servico"].Value);

                        using (MySqlConnection conn = new MySqlConnection(conexao))
                        {
                            conn.Open();

                            string sql = "DELETE FROM cadastro_servico WHERE Id_cadastro_servico=@id";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@id", id);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Serviço excluído com sucesso!");

                        CarregarServicos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir:\n" + ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um serviço!");
            }
        }

        private void btnVoltarS_Click(object sender, EventArgs e)
        {
            panelCadastroS.Visible = false;
            dgvServicos.Visible = true;
        }

        private void txtBuscaS_TextChanged(object sender, EventArgs e)
        {
            if (dgvServicos.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter =
                    $"nome_servico LIKE '%{txtBuscaS.Text}%'";
            }
        }

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

        private void cmbTipodeServicoS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
            !char.IsWhiteSpace(e.KeyChar) &&
            e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtValorS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}