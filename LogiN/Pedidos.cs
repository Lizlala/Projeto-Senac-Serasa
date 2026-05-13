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

            Color lilas = Color.FromArgb(210, 227, 252);

            dgvPedidos.ColumnHeadersDefaultCellStyle.SelectionBackColor = lilas;
            dgvPedidos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            dgvPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            dgvPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvPedidos.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(250, 210, 207);

            dgvPedidos.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvPedidos.DefaultCellStyle.BackColor = Color.White;
            dgvPedidos.DefaultCellStyle.ForeColor = Color.Black;

            dgvPedidos.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvPedidos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvPedidos.RowHeadersVisible = false;

            dgvPedidos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPedidos.BorderStyle = BorderStyle.None;
            dgvPedidos.GridColor = Color.White;

            dgvPedidos.ReadOnly = true;

            // 🔥 remove linha branca vazia
            dgvPedidos.AllowUserToAddRows = false;

            dgvPedidos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPedidos.MultiSelect = false;

            dgvPedidos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // 🔥 CORREÇÃO DO TEXTO ESCONDIDO
            dgvPedidos.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvPedidos.RowTemplate.Height = 32;

            dgvPedidos.DefaultCellStyle.Padding =
                new Padding(4, 2, 4, 2);

            // 🔥 scroll funcionando
            dgvPedidos.ScrollBars = ScrollBars.Vertical;

            dgvPedidos.Columns["id_pedido_servico"].Visible = false;
            dgvPedidos.Columns["id_cliente"].Visible = false;
            dgvPedidos.Columns["id_servico"].Visible = false;

            dgvPedidos.Columns["Clientes"].HeaderText = "Cliente";
            dgvPedidos.Columns["cadastro_servico"].HeaderText = "Serviço";
            dgvPedidos.Columns["Valor"].HeaderText = "Valor";
            dgvPedidos.Columns["Status_pedido"].HeaderText = "Status";

            dgvPedidos.Columns["Valor"].DefaultCellStyle.Format = "C2";

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
            int clienteId = Convert.ToInt32(cmbClienteP.SelectedValue);
            int servicoId = Convert.ToInt32(cmbTipodeServicoP.SelectedValue);
            string status = cmbStatusP.Text;

            decimal valor;
            if (!decimal.TryParse(txtValorP.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out valor))
            {
                MessageBox.Show("Valor inválido!");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                if (!modoEdicao)
                {
                    string sql = "INSERT INTO Pedidos_servicos (id_cliente, id_servico, Valor, Status_pedido) VALUES (@c,@s,@v,@st)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@c", clienteId);
                    cmd.Parameters.AddWithValue("@s", servicoId);
                    cmd.Parameters.AddWithValue("@v", valor);
                    cmd.Parameters.AddWithValue("@st", status);

                    cmd.ExecuteNonQuery();
                }
                else
                {

                    string sql = "UPDATE Pedidos_servicos SET id_cliente=@c, id_servico=@s, Valor=@v, Status_pedido=@st WHERE id_pedido_servico=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@c", clienteId);
                    cmd.Parameters.AddWithValue("@s", servicoId);
                    cmd.Parameters.AddWithValue("@v", valor);
                    cmd.Parameters.AddWithValue("@st", status);
                    cmd.Parameters.AddWithValue("@id", idSelecionado);

                    cmd.ExecuteNonQuery();
                }
            }

            CarregarPedidos();
        }

        private void btnExcluirP_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["Id_pedido_servico"].Value);

                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    string sql = "DELETE FROM Pedidos_servicos WHERE Id_pedido_servico=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                CarregarPedidos();
            }
            else
            {
                MessageBox.Show("Selecione um pedido!");
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

        //====== Codigo para não permitir letras, apenas numeros =======
        private void txtValorP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        //====== Codigo para não permitir numeros, apenas letras =======
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

        //======================== EDITAR ==========================
        private void btnEditarP_Click(object sender, EventArgs e)
        {

            if (dgvPedidos.CurrentRow != null)
            {
                modoEdicao = true;

                idSelecionado = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["id_pedido_servico"].Value);

                cmbClienteP.SelectedValue = dgvPedidos.CurrentRow.Cells["id_cliente"].Value;

                cmbTipodeServicoP.SelectedValue = dgvPedidos.CurrentRow.Cells["id_servico"].Value;

                txtValorP.Text = dgvPedidos.CurrentRow.Cells["valor"].Value.ToString();

                cmbStatusP.Text = dgvPedidos.CurrentRow.Cells["status_pedido"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um pedido!");
            }
        }
    }
}