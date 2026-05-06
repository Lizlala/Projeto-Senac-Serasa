namespace LogiN
{
    partial class TelaClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaClientes));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnNovoClienteC = new Button();
            panel2 = new Panel();
            txtBuscaC = new TextBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            dgvClientes = new DataGridView();
            panel1 = new Panel();
            btnPedidosC = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnServicosC = new Button();
            btnClientesC = new Button();
            btnEstoqueC = new Button();
            btnExcluirC = new Button();
            btnEditarC = new Button();
            groupBox1 = new GroupBox();
            panelCadastroCliente = new Panel();
            label8 = new Label();
            CadastrarNovoCliente = new GroupBox();
            label10 = new Label();
            btnVoltarC = new Button();
            btnSalvarC = new Button();
            txtTelefoneC = new TextBox();
            txtCPF = new TextBox();
            txtNomeC = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label7 = new Label();
            label6 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            panelCadastroCliente.SuspendLayout();
            CadastrarNovoCliente.SuspendLayout();
            SuspendLayout();
            // 
            // btnNovoClienteC
            // 
            btnNovoClienteC.BackColor = Color.FromArgb(191, 165, 187);
            btnNovoClienteC.FlatAppearance.BorderSize = 0;
            btnNovoClienteC.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnNovoClienteC.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnNovoClienteC.FlatStyle = FlatStyle.Flat;
            btnNovoClienteC.Font = new Font("Century Gothic", 12F);
            btnNovoClienteC.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovoClienteC.Location = new Point(810, 45);
            btnNovoClienteC.Name = "btnNovoClienteC";
            btnNovoClienteC.Size = new Size(215, 49);
            btnNovoClienteC.TabIndex = 4;
            btnNovoClienteC.Text = "+ Novo Cliente";
            btnNovoClienteC.UseVisualStyleBackColor = false;
            btnNovoClienteC.Click += btnNovoClienteC_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(txtBuscaC);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(6, 142);
            panel2.Name = "panel2";
            panel2.Size = new Size(1042, 63);
            panel2.TabIndex = 23;
            // 
            // txtBuscaC
            // 
            txtBuscaC.Location = new Point(75, 18);
            txtBuscaC.Margin = new Padding(3, 4, 3, 4);
            txtBuscaC.Name = "txtBuscaC";
            txtBuscaC.Size = new Size(943, 29);
            txtBuscaC.TabIndex = 5;
            txtBuscaC.TextChanged += txtBuscaC_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(9, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 39);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 16F, FontStyle.Bold);
            label2.Location = new Point(15, 45);
            label2.Name = "label2";
            label2.Size = new Size(312, 32);
            label2.TabIndex = 21;
            label2.Text = "Gerencie seus Clientes";
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvClientes.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.MediumAquamarine;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.Location = new Point(383, 425);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowHeadersWidth = 45;
            dgvClientes.RowTemplate.Height = 40;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(1055, 372);
            dgvClientes.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnPedidosC);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnServicosC);
            panel1.Controls.Add(btnClientesC);
            panel1.Controls.Add(btnEstoqueC);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 827);
            panel1.TabIndex = 28;
            // 
            // btnPedidosC
            // 
            btnPedidosC.BackColor = Color.White;
            btnPedidosC.FlatAppearance.BorderSize = 0;
            btnPedidosC.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnPedidosC.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnPedidosC.FlatStyle = FlatStyle.Flat;
            btnPedidosC.Font = new Font("Century Gothic", 12F);
            btnPedidosC.Image = (Image)resources.GetObject("btnPedidosC.Image");
            btnPedidosC.ImageAlign = ContentAlignment.MiddleLeft;
            btnPedidosC.Location = new Point(26, 671);
            btnPedidosC.Name = "btnPedidosC";
            btnPedidosC.Size = new Size(291, 64);
            btnPedidosC.TabIndex = 3;
            btnPedidosC.Text = "Pedidos";
            btnPedidosC.UseVisualStyleBackColor = false;
            btnPedidosC.Click += btnPedidosC_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13F, FontStyle.Bold);
            label1.Location = new Point(47, 165);
            label1.Name = "label1";
            label1.Size = new Size(253, 26);
            label1.TabIndex = 5;
            label1.Text = "Bem-vinda ao Sistema";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(26, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(291, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnServicosC
            // 
            btnServicosC.BackColor = Color.White;
            btnServicosC.FlatAppearance.BorderSize = 0;
            btnServicosC.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnServicosC.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnServicosC.FlatStyle = FlatStyle.Flat;
            btnServicosC.Font = new Font("Century Gothic", 12F);
            btnServicosC.Image = (Image)resources.GetObject("btnServicosC.Image");
            btnServicosC.ImageAlign = ContentAlignment.MiddleLeft;
            btnServicosC.Location = new Point(26, 557);
            btnServicosC.Name = "btnServicosC";
            btnServicosC.Size = new Size(291, 64);
            btnServicosC.TabIndex = 2;
            btnServicosC.Text = "Serviços";
            btnServicosC.UseVisualStyleBackColor = false;
            btnServicosC.Click += btnServicosC_Click;
            // 
            // btnClientesC
            // 
            btnClientesC.BackColor = Color.FromArgb(191, 165, 187);
            btnClientesC.FlatAppearance.BorderSize = 0;
            btnClientesC.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnClientesC.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnClientesC.FlatStyle = FlatStyle.Flat;
            btnClientesC.Font = new Font("Century Gothic", 12F);
            btnClientesC.Image = (Image)resources.GetObject("btnClientesC.Image");
            btnClientesC.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientesC.Location = new Point(26, 444);
            btnClientesC.Name = "btnClientesC";
            btnClientesC.Size = new Size(291, 64);
            btnClientesC.TabIndex = 1;
            btnClientesC.Text = "Clientes";
            btnClientesC.UseVisualStyleBackColor = false;
            // 
            // btnEstoqueC
            // 
            btnEstoqueC.BackColor = Color.White;
            btnEstoqueC.FlatAppearance.BorderSize = 0;
            btnEstoqueC.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnEstoqueC.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnEstoqueC.FlatStyle = FlatStyle.Flat;
            btnEstoqueC.Font = new Font("Century Gothic", 12F);
            btnEstoqueC.ForeColor = Color.Black;
            btnEstoqueC.Image = (Image)resources.GetObject("btnEstoqueC.Image");
            btnEstoqueC.ImageAlign = ContentAlignment.MiddleLeft;
            btnEstoqueC.Location = new Point(26, 331);
            btnEstoqueC.Name = "btnEstoqueC";
            btnEstoqueC.Size = new Size(291, 64);
            btnEstoqueC.TabIndex = 0;
            btnEstoqueC.Text = "Estoque";
            btnEstoqueC.UseVisualStyleBackColor = false;
            btnEstoqueC.Click += btnEstoqueC_Click;
            // 
            // btnExcluirC
            // 
            btnExcluirC.BackColor = Color.FromArgb(191, 165, 187);
            btnExcluirC.FlatAppearance.BorderSize = 0;
            btnExcluirC.FlatStyle = FlatStyle.Flat;
            btnExcluirC.Font = new Font("Century Gothic", 10F);
            btnExcluirC.Location = new Point(918, 262);
            btnExcluirC.Name = "btnExcluirC";
            btnExcluirC.Size = new Size(107, 35);
            btnExcluirC.TabIndex = 6;
            btnExcluirC.Text = "Excluir ";
            btnExcluirC.UseVisualStyleBackColor = false;
            btnExcluirC.Click += btnExcluirC_Click;
            // 
            // btnEditarC
            // 
            btnEditarC.BackColor = Color.White;
            btnEditarC.FlatAppearance.BorderSize = 0;
            btnEditarC.FlatStyle = FlatStyle.Flat;
            btnEditarC.Font = new Font("Century Gothic", 10F);
            btnEditarC.Location = new Point(785, 262);
            btnEditarC.Name = "btnEditarC";
            btnEditarC.Size = new Size(107, 35);
            btnEditarC.TabIndex = 7;
            btnEditarC.Text = "Editar";
            btnEditarC.UseVisualStyleBackColor = false;
            btnEditarC.Click += btnEditarC_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEditarC);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnNovoClienteC);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(btnExcluirC);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(383, 23);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1055, 324);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            // 
            // panelCadastroCliente
            // 
            panelCadastroCliente.Controls.Add(label8);
            panelCadastroCliente.Controls.Add(CadastrarNovoCliente);
            panelCadastroCliente.Location = new Point(342, 3);
            panelCadastroCliente.Name = "panelCadastroCliente";
            panelCadastroCliente.Size = new Size(1128, 824);
            panelCadastroCliente.TabIndex = 32;
            panelCadastroCliente.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(484, 450);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 5;
            // 
            // CadastrarNovoCliente
            // 
            CadastrarNovoCliente.Controls.Add(label10);
            CadastrarNovoCliente.Controls.Add(btnVoltarC);
            CadastrarNovoCliente.Controls.Add(btnSalvarC);
            CadastrarNovoCliente.Controls.Add(txtTelefoneC);
            CadastrarNovoCliente.Controls.Add(txtCPF);
            CadastrarNovoCliente.Controls.Add(txtNomeC);
            CadastrarNovoCliente.Controls.Add(label5);
            CadastrarNovoCliente.Controls.Add(label4);
            CadastrarNovoCliente.Controls.Add(label7);
            CadastrarNovoCliente.Controls.Add(label6);
            CadastrarNovoCliente.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CadastrarNovoCliente.Location = new Point(65, 50);
            CadastrarNovoCliente.Margin = new Padding(3, 4, 3, 4);
            CadastrarNovoCliente.Name = "CadastrarNovoCliente";
            CadastrarNovoCliente.Padding = new Padding(3, 4, 3, 4);
            CadastrarNovoCliente.Size = new Size(995, 460);
            CadastrarNovoCliente.TabIndex = 4;
            CadastrarNovoCliente.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 10F);
            label10.Location = new Point(23, 58);
            label10.Name = "label10";
            label10.Size = new Size(195, 21);
            label10.TabIndex = 23;
            label10.Text = "Gerencie seus clientes";
            // 
            // btnVoltarC
            // 
            btnVoltarC.BackColor = Color.White;
            btnVoltarC.FlatAppearance.BorderSize = 0;
            btnVoltarC.FlatStyle = FlatStyle.Flat;
            btnVoltarC.Font = new Font("Century Gothic", 10F);
            btnVoltarC.Location = new Point(841, 406);
            btnVoltarC.Name = "btnVoltarC";
            btnVoltarC.Size = new Size(107, 35);
            btnVoltarC.TabIndex = 3;
            btnVoltarC.Text = "Voltar";
            btnVoltarC.UseVisualStyleBackColor = false;
            btnVoltarC.Click += btnVoltarC_Click;
            // 
            // btnSalvarC
            // 
            btnSalvarC.BackColor = Color.FromArgb(191, 165, 187);
            btnSalvarC.FlatAppearance.BorderSize = 0;
            btnSalvarC.FlatStyle = FlatStyle.Flat;
            btnSalvarC.Font = new Font("Century Gothic", 10F);
            btnSalvarC.Location = new Point(704, 406);
            btnSalvarC.Name = "btnSalvarC";
            btnSalvarC.Size = new Size(107, 35);
            btnSalvarC.TabIndex = 4;
            btnSalvarC.Text = "Salvar";
            btnSalvarC.UseVisualStyleBackColor = false;
            btnSalvarC.Click += btnSalvarC_Click;
            // 
            // txtTelefoneC
            // 
            txtTelefoneC.Location = new Point(53, 318);
            txtTelefoneC.Margin = new Padding(3, 4, 3, 4);
            txtTelefoneC.Name = "txtTelefoneC";
            txtTelefoneC.Size = new Size(895, 29);
            txtTelefoneC.TabIndex = 2;
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(53, 235);
            txtCPF.Margin = new Padding(3, 4, 3, 4);
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(895, 29);
            txtCPF.TabIndex = 1;
            // 
            // txtNomeC
            // 
            txtNomeC.Location = new Point(53, 141);
            txtNomeC.Margin = new Padding(3, 4, 3, 4);
            txtNomeC.Name = "txtNomeC";
            txtNomeC.Size = new Size(895, 29);
            txtNomeC.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9.75F);
            label5.Location = new Point(53, 292);
            label5.Name = "label5";
            label5.Size = new Size(80, 21);
            label5.TabIndex = 1;
            label5.Text = "Telefone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9.75F);
            label4.Location = new Point(53, 116);
            label4.Name = "label4";
            label4.Size = new Size(149, 21);
            label4.TabIndex = 0;
            label4.Text = "Nome Completo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 15F, FontStyle.Bold);
            label7.Location = new Point(23, 29);
            label7.Name = "label7";
            label7.Size = new Size(297, 29);
            label7.TabIndex = 2;
            label7.Text = "Cadastrar Novo Cliente";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9.75F);
            label6.Location = new Point(53, 209);
            label6.Name = "label6";
            label6.Size = new Size(42, 21);
            label6.TabIndex = 1;
            label6.Text = "CPF";
            // 
            // TelaClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1475, 827);
            Controls.Add(panelCadastroCliente);
            Controls.Add(panel1);
            Controls.Add(dgvClientes);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "TelaClientes";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelCadastroCliente.ResumeLayout(false);
            panelCadastroCliente.PerformLayout();
            CadastrarNovoCliente.ResumeLayout(false);
            CadastrarNovoCliente.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNovoClienteC;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView dgvClientes;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnServicosC;
        private Button btnClientesC;
        private Button btnEstoqueC;
        private Button btnPedidosC;
        private Button btnExcluirC;
        private TextBox txtBuscaC;
        private Button btnEditarC;
        private GroupBox groupBox1;
        private Panel panelCadastroCliente;
        private Label label8;
        private GroupBox CadastrarNovoCliente;
        private Label label10;
        private Button btnVoltarC;
        private Button btnSalvarC;
        private TextBox txtTelefoneC;
        private TextBox txtCPF;
        private TextBox txtNomeC;
        private Label label5;
        private Label label4;
        private Label label7;
        private Label label6;
    }
}