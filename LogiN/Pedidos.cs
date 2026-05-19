using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LogiN
{
    public partial class TelaPedidos : Form
    {
        private int idSelecionado = 0;
        private bool modoEdicao = false;

        private string conexao = "server=localhost;database=fiodeouro;uid=root;pwd=;";

        private Label lblFinalizados = new Label();
        private Label lblAndamento = new Label();
        private Label lblPendentes = new Label();
        private Label lblTotalGeral = new Label();

        public TelaPedidos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += TelaPedidos_Load;
        }

        private void TelaPedidos_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosIniciais();

            CarregarClientes();
            CarregarServicos();

            CarregarPedidos();
        }

        private void ConfigurarEstilosIniciais()
        {
            cmbStatusP.Items.Clear();
            cmbStatusP.Items.Add("Pendente");
            cmbStatusP.Items.Add("Em andamento");
            cmbStatusP.Items.Add("Finalizado");

            if (!panelValores.Controls.Contains(lblFinalizados)) panelValores.Controls.Add(lblFinalizados);
            if (!panelValores.Controls.Contains(lblAndamento)) panelValores.Controls.Add(lblAndamento);
            if (!panelValores.Controls.Contains(lblPendentes)) panelValores.Controls.Add(lblPendentes);
            if (!panelValores.Controls.Contains(lblTotalGeral)) panelValores.Controls.Add(lblTotalGeral);

            lblFinalizados.ForeColor = Color.FromArgb(191, 165, 187);
            lblAndamento.ForeColor = Color.FromArgb(191, 165, 187);
            lblPendentes.ForeColor = Color.FromArgb(191, 165, 187);
            lblTotalGeral.ForeColor = Color.FromArgb(70, 50, 70);

            Font fonteCards = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblFinalizados.Font = fonteCards;
            lblAndamento.Font = fonteCards;
            lblPendentes.Font = fonteCards;
            lblTotalGeral.Font = new Font("Century Gothic", 14, FontStyle.Bold);

            lblFinalizados.AutoSize = true;
            lblAndamento.AutoSize = true;
            lblPendentes.AutoSize = true;
            lblTotalGeral.AutoSize = true;

            panelValores.BorderStyle = BorderStyle.None;
            panelValores.BackColor = Color.White;
            panelValores.Height = 110;
            panelValores.Padding = new Padding(20, 25, 20, 10);

            lblFinalizados.Location = new Point(138, 23);
            lblAndamento.Location = new Point(469, 23);
            lblPendentes.Location = new Point(800, 23);

            lblTotalGeral.Location = new Point(700, 85);

            lblFinalizados.Visible = true;
            lblAndamento.Visible = true;
            lblPendentes.Visible = true;
            lblTotalGeral.Visible = true;

            lblFinalizados.BringToFront();
            lblAndamento.BringToFront();
            lblPendentes.BringToFront();
            lblTotalGeral.BringToFront();

            dgvPedidos.Visible = true;
            panelCadastroPedidos.Visible = false;
        }


        private void CarregarPedidos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    string sql = @"SELECT p.id_pedido_servico,
                                          p.id_cliente,
                                          p.id_servico,
                                          c.nome AS Clientes,
                                          s.nome_servico AS cadastro_servico,
                                          p.valor,
                                          p.status_pedido
                                   FROM pedidos_servicos p
                                   JOIN clientes c ON p.id_cliente = c.id_cliente
                                   JOIN cadastro_servico s ON p.id_servico = s.id_cadastro_servico";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPedidos.DataSource = dt;
                    }

                    EstiloGrid();
                    CalcularStatusPedidos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar a lista de pedidos:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularStatusPedidos()
        {
            decimal totalFinalizados = 0;
            decimal totalAndamento = 0;
            decimal totalPendentes = 0;

            foreach (DataGridViewRow row in dgvPedidos.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["valor"].Value != DBNull.Value && row.Cells["status_pedido"].Value != null)
                {
                    decimal valor = Convert.ToDecimal(row.Cells["valor"].Value);
                    string status = row.Cells["status_pedido"].Value.ToString().Trim();

                    switch (status)
                    {
                        case "Finalizado":
                            totalFinalizados += valor;
                            break;

                        case "Em andamento":
                        case "Em Andamento":
                            totalAndamento += valor;
                            break;

                        case "Pendente":
                            totalPendentes += valor;
                            break;
                    }
                }
            }

            decimal totalGeral = totalFinalizados + totalAndamento + totalPendentes;

            lblFinalizados.Text = "Finalizados R$ " + totalFinalizados.ToString("N2");
            lblAndamento.Text = "Em Andamento R$ " + totalAndamento.ToString("N2");
            lblPendentes.Text = "Pendentes R$ " + totalPendentes.ToString("N2");
            lblTotalGeral.Text = "TOTAL GERAL: R$ " + totalGeral.ToString("N2");

            panelValores.Invalidate();
            panelValores.Update();
        }

        private void CarregarClientes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();
                    string sql = "SELECT Id_cliente, Nome FROM Clientes";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbClienteP.DataSource = dt;
                    }

                    cmbClienteP.DisplayMember = "Nome";
                    cmbClienteP.ValueMember = "Id_cliente";
                    cmbClienteP.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }

        private void CarregarServicos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();
                    string sql = "SELECT Id_cadastro_servico, nome_servico, Valor FROM cadastro_servico";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbTipodeServicoP.DataSource = dt;
                    }

                    cmbTipodeServicoP.DisplayMember = "nome_servico";
                    cmbTipodeServicoP.ValueMember = "Id_cadastro_servico";
                    cmbTipodeServicoP.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar serviços: " + ex.Message);
            }
        }

        private void EstiloGrid()
        {
            dgvPedidos.EnableHeadersVisualStyles = false;

            Font fontePadrao = new Font("Century Gothic", 10F, FontStyle.Regular);
            Font fonteCabecalho = new Font("Century Gothic", 10F, FontStyle.Bold);
            Color corSelecaoLinha = Color.FromArgb(191, 165, 187);

            dgvPedidos.BackgroundColor = Color.White;
            dgvPedidos.GridColor = Color.White;
            dgvPedidos.BorderStyle = BorderStyle.None;
            dgvPedidos.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dgvPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPedidos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvPedidos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = fonteCabecalho;
            dgvPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPedidos.ColumnHeadersHeight = 35;

            dgvPedidos.DefaultCellStyle.BackColor = Color.White;
            dgvPedidos.DefaultCellStyle.ForeColor = Color.Black;
            dgvPedidos.DefaultCellStyle.SelectionBackColor = corSelecaoLinha;
            dgvPedidos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPedidos.DefaultCellStyle.Font = fontePadrao;

            dgvPedidos.RowHeadersVisible = false;
            dgvPedidos.ReadOnly = true;
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.MultiSelect = false;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.RowTemplate.Height = 35;
            dgvPedidos.ScrollBars = ScrollBars.Vertical;

            if (dgvPedidos.Columns.Contains("id_pedido_servico")) dgvPedidos.Columns["id_pedido_servico"].Visible = false;
            if (dgvPedidos.Columns.Contains("id_cliente")) dgvPedidos.Columns["id_cliente"].Visible = false;
            if (dgvPedidos.Columns.Contains("id_servico")) dgvPedidos.Columns["id_servico"].Visible = false;

            if (dgvPedidos.Columns.Contains("Clientes")) dgvPedidos.Columns["Clientes"].HeaderText = "Cliente";
            if (dgvPedidos.Columns.Contains("cadastro_servico")) dgvPedidos.Columns["cadastro_servico"].HeaderText = "Serviço";

            if (dgvPedidos.Columns.Contains("valor"))
            {
                dgvPedidos.Columns["valor"].HeaderText = "Valor";
                dgvPedidos.Columns["valor"].DefaultCellStyle.Format = "C2";
            }

            if (dgvPedidos.Columns.Contains("status_pedido")) dgvPedidos.Columns["status_pedido"].HeaderText = "Status";

            dgvPedidos.ClearSelection();
        }

        private void cmbTipodeServicoP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipodeServicoP.Focused && cmbTipodeServicoP.SelectedItem is DataRowView row)
            {
                txtValorP.Text = Convert.ToDecimal(row["Valor"]).ToString("N2");
            }
        }

        private void btnSalvarP_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbClienteP.SelectedIndex == -1 || cmbTipodeServicoP.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbStatusP.Text))
                {
                    MessageBox.Show("Preencha todos os campos", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int clienteId = Convert.ToInt32(cmbClienteP.SelectedValue);
                int servicoId = Convert.ToInt32(cmbTipodeServicoP.SelectedValue);
                string status = cmbStatusP.Text;
                decimal valor;

                if (!decimal.TryParse(txtValorP.Text, out valor))
                {
                    MessageBox.Show("Insira um valor numérico válido para o serviço.");
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();
                    string sql = "";

                    if (!modoEdicao)
                    {
                        sql = "INSERT INTO pedidos_servicos (id_cliente, id_servico, valor, status_pedido) VALUES (@c,@s,@v,@st)";
                    }
                    else
                    {
                        sql = "UPDATE pedidos_servicos SET id_cliente=@c, id_servico=@s, valor=@v, status_pedido=@st WHERE id_pedido_servico=@id";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@c", clienteId);
                        cmd.Parameters.AddWithValue("@s", servicoId);
                        cmd.Parameters.AddWithValue("@v", valor);
                        cmd.Parameters.AddWithValue("@st", status);
                        if (modoEdicao) cmd.Parameters.AddWithValue("@id", idSelecionado);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(modoEdicao ? "Pedido atualizado" : "Pedido cadastrado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modoEdicao = false;
                }

                CarregarPedidos();
                btnVoltarP_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro interno ao processar a operação:\n\n" + ex.Message, "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirP_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow != null)
            {
                DialogResult confirmacao = MessageBox.Show(
                    "Tem certeza que deseja excluir este pedido?",
                    "Confirme a Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacao == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["id_pedido_servico"].Value);

                    using (MySqlConnection conn = new MySqlConnection(conexao))
                    {
                        conn.Open();
                        string sql = "DELETE FROM pedidos_servicos WHERE id_pedido_servico=@id";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Pedido excluído");
                    CarregarPedidos();
                }
            }
            else
            {
                MessageBox.Show("Para excluir selecione um pedido na tabela.");
            }
        }

        private void txtBuscaP_TextChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = $"Clientes LIKE '%{txtBuscaP.Text}%' OR cadastro_servico LIKE '%{txtBuscaP.Text}%'";
                CalcularStatusPedidos();
            }
        }

        private void txtValorP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnEditarP_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow != null)
            {
                modoEdicao = true;

                idSelecionado = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["id_pedido_servico"].Value);
                cmbClienteP.Text = dgvPedidos.CurrentRow.Cells["Clientes"].Value.ToString();
                cmbTipodeServicoP.Text = dgvPedidos.CurrentRow.Cells["cadastro_servico"].Value.ToString();
                txtValorP.Text = Convert.ToDecimal(dgvPedidos.CurrentRow.Cells["valor"].Value).ToString("N2");
                cmbStatusP.Text = dgvPedidos.CurrentRow.Cells["status_pedido"].Value.ToString();

                panelCadastroPedidos.Visible = true;
                panelCadastroPedidos.BringToFront();
                dgvPedidos.Visible = false;
            }
            else
            {
                MessageBox.Show("Para editar selecione um pedido na tabela");
            }
        }

        private void btnVoltarP_Click(object sender, EventArgs e)
        {
            panelCadastroPedidos.Visible = false;
            dgvPedidos.Visible = true;
            dgvPedidos.ClearSelection();
        }

        private void btnAbrirCadastroP_Click(object sender, EventArgs e)
        {
            modoEdicao = false;
            cmbClienteP.SelectedIndex = -1;
            cmbTipodeServicoP.SelectedIndex = -1;
            txtValorP.Clear();
            cmbStatusP.SelectedIndex = -1;

            panelCadastroPedidos.Visible = true;
            panelCadastroPedidos.BringToFront();
            dgvPedidos.Visible = false;
        }

        private void btnClientesP_Click(object sender, EventArgs e) { new TelaClientes().Show(); this.Hide(); }
        private void btnEstoqueP_Click(object sender, EventArgs e) { new TelaEstoque().Show(); this.Hide(); }
        private void btnServicosP_Click(object sender, EventArgs e) { new TelaServicos().Show(); this.Hide(); }
    }
}