using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LogiN
{
    public partial class TelaPedidos : Form
    {
        int idSelecionado = 0;
        bool modoEdicao = false;

        string conexao = "server=localhost;database=fiodeouro;uid=root;pwd=;";

        public TelaPedidos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += TelaPedidos_Load;
        }

        private void TelaPedidos_Load(object sender, EventArgs e)
        {
            CarregarPedidos();
            CarregarClientes();
            CarregarServicos();

            cmbStatusP.Items.Add("Pendente");
            cmbStatusP.Items.Add("Em andamento");
            cmbStatusP.Items.Add("Finalizado");
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

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPedidos.DataSource = dt;

                    EstiloGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar:\n" + ex.ToString());
            }
        }

        private void CarregarClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                string sql = "SELECT Id_cliente, Nome FROM Clientes";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbClienteP.DataSource = dt;
                cmbClienteP.DisplayMember = "Nome";
                cmbClienteP.ValueMember = "Id_cliente";
            }
        }

        private void CarregarServicos()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                string sql = "SELECT Id_cadastro_servico, nome_servico, Valor FROM cadastro_Servico";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbTipodeServicoP.DataSource = dt;
                cmbTipodeServicoP.DisplayMember = "nome_servico";
                cmbTipodeServicoP.ValueMember = "Id_cadastro_servico";
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

            // CABEÇALHO
            dgvPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPedidos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvPedidos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = fonteCabecalho;
            dgvPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPedidos.ColumnHeadersHeight = 35;

            // LINHAS
            dgvPedidos.DefaultCellStyle.BackColor = Color.White;
            dgvPedidos.DefaultCellStyle.ForeColor = Color.Black;
            dgvPedidos.DefaultCellStyle.SelectionBackColor = corSelecaoLinha;
            dgvPedidos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPedidos.DefaultCellStyle.Font = fontePadrao;
            dgvPedidos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // LINHAS ALTERNADAS
            dgvPedidos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvPedidos.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvPedidos.AlternatingRowsDefaultCellStyle.SelectionBackColor = corSelecaoLinha;
            dgvPedidos.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPedidos.AlternatingRowsDefaultCellStyle.Font = fontePadrao;

            dgvPedidos.RowHeadersVisible = false;
            dgvPedidos.ReadOnly = true;
            dgvPedidos.AllowUserToAddRows = false;

            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.MultiSelect = false;

            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvPedidos.RowTemplate.Height = 35;
            dgvPedidos.ScrollBars = ScrollBars.Vertical;


            dgvPedidos.Columns["id_pedido_servico"].Visible = false;
            dgvPedidos.Columns["id_cliente"].Visible = false;
            dgvPedidos.Columns["id_servico"].Visible = false;

            // ✅ 🔥 ESSA PARTE FAZ FICAR IGUAL AO ESTOQUE
            foreach (DataGridViewRow row in dgvPedidos.Rows)
            {
                row.DefaultCellStyle.Font = fontePadrao;
            }

            // ESCONDE IDS
            if (dgvPedidos.Columns.Contains("id_pedido_servico"))
                dgvPedidos.Columns["id_pedido_servico"].Visible = false;

            if (dgvPedidos.Columns.Contains("id_cliente"))
                dgvPedidos.Columns["id_cliente"].Visible = false;

            if (dgvPedidos.Columns.Contains("id_servico"))
                dgvPedidos.Columns["id_servico"].Visible = false;

            // COLUNAS
            if (dgvPedidos.Columns.Contains("Clientes"))
                dgvPedidos.Columns["Clientes"].HeaderText = "Cliente";

            if (dgvPedidos.Columns.Contains("cadastro_servico"))
                dgvPedidos.Columns["cadastro_servico"].HeaderText = "Serviço";

            if (dgvPedidos.Columns.Contains("Valor"))
            {
                dgvPedidos.Columns["Valor"].HeaderText = "Valor";
                dgvPedidos.Columns["Valor"].DefaultCellStyle.Format = "C2";
            }

            if (dgvPedidos.Columns.Contains("Status_pedido"))
                dgvPedidos.Columns["Status_pedido"].HeaderText = "Status";

            dgvPedidos.ClearSelection();
        }



        private void cmbTipodeServicoP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipodeServicoP.SelectedItem is DataRowView row)
            {
                txtValorP.Text = row["Valor"].ToString();
            }
        }

        private void btnSalvarP_Click(object sender, EventArgs e)
        {
            try
            {
                int clienteId = Convert.ToInt32(cmbClienteP.SelectedValue);
                int servicoId = Convert.ToInt32(cmbTipodeServicoP.SelectedValue);
                string status = cmbStatusP.Text;

                decimal valor;

                if (!decimal.TryParse(
                    txtValorP.Text.Replace(",", "."),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out valor))
                {
                    return;
                }

                using (MySqlConnection conn =
                    new MySqlConnection(conexao))
                {
                    conn.Open();

                    // INSERT
                    if (!modoEdicao)
                    {
                        string sql =
                            "INSERT INTO Pedidos_servicos " +
                            "(id_cliente, id_servico, Valor, Status_pedido) " +
                            "VALUES (@c,@s,@v,@st)";

                        MySqlCommand cmd =
                            new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@c", clienteId);
                        cmd.Parameters.AddWithValue("@s", servicoId);
                        cmd.Parameters.AddWithValue("@v", valor);
                        cmd.Parameters.AddWithValue("@st", status);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Pedido cadastrado!");
                    }

                    else
                    {
                        string sql =
                            "UPDATE Pedidos_servicos " +
                            "SET id_cliente=@c, " +
                            "id_servico=@s, " +
                            "Valor=@v, " +
                            "Status_pedido=@st " +
                            "WHERE Id_pedido_servico=@id";

                        MySqlCommand cmd =
                            new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@c", clienteId);
                        cmd.Parameters.AddWithValue("@s", servicoId);
                        cmd.Parameters.AddWithValue("@v", valor);
                        cmd.Parameters.AddWithValue("@st", status);
                        cmd.Parameters.AddWithValue("@id", idSelecionado);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Pedido atualizado!");

                        modoEdicao = false;
                    }
                }

                CarregarPedidos();

                dgvPedidos.ClearSelection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "Erro ao salvar:\n\n" + ex.ToString());
            }
        }

        private void btnExcluirP_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow != null)
            {
                DialogResult confirmacao = MessageBox.Show(
                    "Tem certeza que deseja excluir este pedido?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacao == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(
                        dgvPedidos.CurrentRow.Cells["Id_pedido_servico"].Value);

                    using (MySqlConnection conn = new MySqlConnection(conexao))
                    {
                        conn.Open();

                        string sql = "DELETE FROM Pedidos_servicos WHERE Id_pedido_servico=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Pedido excluído com sucesso!");

                    CarregarPedidos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um pedido para excluir.");
            }
        }

        private void txtBuscaP_TextChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter =
                    $"Clientes LIKE '%{txtBuscaP.Text}%' OR cadastro_Servico LIKE '%{txtBuscaP.Text}%'";
            }
        }

        private void btnClientesP_Click(object sender, EventArgs e)
        {
            new TelaClientes().Show();
            this.Hide();
        }

        private void btnEstoqueP_Click(object sender, EventArgs e)
        {
            new TelaEstoque().Show();
            this.Hide();
        }

        private void btnServicosP_Click(object sender, EventArgs e)
        {
            new TelaServicos().Show();
            this.Hide();
        }

        private void txtValorP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void cmbClienteP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
            !char.IsWhiteSpace(e.KeyChar) &&
            e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void cmbTipodeServicoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
            !char.IsWhiteSpace(e.KeyChar) &&
            e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void cmbStatusP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
            !char.IsWhiteSpace(e.KeyChar) &&
            e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }


        private void btnEditarP_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow != null)
            {
                modoEdicao = true;


                idSelecionado = Convert.ToInt32(
                    dgvPedidos.CurrentRow.Cells["Id_pedido_servico"].Value);

                cmbClienteP.Text =
                    dgvPedidos.CurrentRow.Cells["Clientes"].Value.ToString();

                cmbTipodeServicoP.Text =
                    dgvPedidos.CurrentRow.Cells["cadastro_servico"].Value.ToString();

                txtValorP.Text =
                    dgvPedidos.CurrentRow.Cells["Valor"].Value.ToString();

                cmbStatusP.Text =
                    dgvPedidos.CurrentRow.Cells["Status_pedido"].Value.ToString();

                panelCadastroPedidos.Visible = true;
                panelCadastroPedidos.BringToFront();

                dgvPedidos.Visible = false;

            }
            else
            {
                MessageBox.Show("Selecione um pedido!");
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
    }
}