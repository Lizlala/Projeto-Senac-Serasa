namespace LogiN
{
    partial class TelaEstoque
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaEstoque));
            btnAbrirCadastroE = new Button();
            dgvEstoque = new DataGridView();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            txtBuscaE = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            label14 = new Label();
            btnServicosE = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnPedidosE = new Button();
            btnClientesE = new Button();
            btnEstoqueE = new Button();
            btnEditarE = new Button();
            btnExcluirE = new Button();
            groupBox2 = new GroupBox();
            panelCadastroE = new Panel();
            groupBox1 = new GroupBox();
            btnVoltarE = new Button();
            label4 = new Label();
            btnSalvarE = new Button();
            label6 = new Label();
            label8 = new Label();
            cmbCategoriaE = new ComboBox();
            txtNomeItemE = new TextBox();
            label7 = new Label();
            QuantidadeE = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            panelCadastroE.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuantidadeE).BeginInit();
            SuspendLayout();
            // 
            // btnAbrirCadastroE
            // 
            btnAbrirCadastroE.BackColor = Color.FromArgb(191, 165, 187);
            btnAbrirCadastroE.FlatAppearance.BorderSize = 0;
            btnAbrirCadastroE.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnAbrirCadastroE.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnAbrirCadastroE.FlatStyle = FlatStyle.Flat;
            btnAbrirCadastroE.Font = new Font("Century Gothic", 12F);
            btnAbrirCadastroE.ImageAlign = ContentAlignment.MiddleLeft;
            btnAbrirCadastroE.Location = new Point(823, 43);
            btnAbrirCadastroE.Name = "btnAbrirCadastroE";
            btnAbrirCadastroE.Size = new Size(215, 49);
            btnAbrirCadastroE.TabIndex = 4;
            btnAbrirCadastroE.Text = "+ Adicionar Item";
            btnAbrirCadastroE.UseVisualStyleBackColor = false;
            btnAbrirCadastroE.Click += btnAbrirCadastroE_Click;
            // 
            // dgvEstoque
            // 
            dgvEstoque.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEstoque.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstoque.BackgroundColor = Color.White;
            dgvEstoque.BorderStyle = BorderStyle.None;
            dgvEstoque.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEstoque.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEstoque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEstoque.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.MediumAquamarine;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvEstoque.DefaultCellStyle = dataGridViewCellStyle3;
            dgvEstoque.EnableHeadersVisualStyles = false;
            dgvEstoque.Location = new Point(381, 405);
            dgvEstoque.Name = "dgvEstoque";
            dgvEstoque.RowHeadersVisible = false;
            dgvEstoque.RowHeadersWidth = 51;
            dgvEstoque.RowTemplate.Height = 40;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstoque.Size = new Size(1055, 389);
            dgvEstoque.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(txtBuscaE);
            panel2.Location = new Point(398, 153);
            panel2.Name = "panel2";
            panel2.Size = new Size(1029, 63);
            panel2.TabIndex = 17;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(11, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 39);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // txtBuscaE
            // 
            txtBuscaE.BackColor = Color.White;
            txtBuscaE.Location = new Point(62, 12);
            txtBuscaE.Multiline = true;
            txtBuscaE.Name = "txtBuscaE";
            txtBuscaE.Size = new Size(946, 39);
            txtBuscaE.TabIndex = 5;
            txtBuscaE.TextChanged += txtBuscaE_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10F);
            label3.Location = new Point(17, 69);
            label3.Name = "label3";
            label3.Size = new Size(327, 21);
            label3.TabIndex = 16;
            label3.Text = "Gerencie seus materiais e aviamentos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 16F, FontStyle.Bold);
            label2.Location = new Point(17, 23);
            label2.Name = "label2";
            label2.Size = new Size(278, 32);
            label2.TabIndex = 15;
            label2.Text = "Controle de Estoque";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label14);
            panel1.Controls.Add(btnServicosE);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnPedidosE);
            panel1.Controls.Add(btnClientesE);
            panel1.Controls.Add(btnEstoqueE);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 827);
            panel1.TabIndex = 21;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 8F);
            label14.Location = new Point(98, 799);
            label14.Name = "label14";
            label14.Size = new Size(111, 19);
            label14.TabIndex = 12;
            label14.Text = "by  ASTER TECH";
            // 
            // btnServicosE
            // 
            btnServicosE.BackColor = Color.White;
            btnServicosE.FlatAppearance.BorderSize = 0;
            btnServicosE.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnServicosE.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnServicosE.FlatStyle = FlatStyle.Flat;
            btnServicosE.Font = new Font("Century Gothic", 12F);
            btnServicosE.Image = (Image)resources.GetObject("btnServicosE.Image");
            btnServicosE.ImageAlign = ContentAlignment.MiddleLeft;
            btnServicosE.Location = new Point(26, 552);
            btnServicosE.Name = "btnServicosE";
            btnServicosE.Size = new Size(291, 64);
            btnServicosE.TabIndex = 2;
            btnServicosE.Text = "Serviços";
            btnServicosE.UseVisualStyleBackColor = false;
            btnServicosE.Click += btnServicosE_Click;
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
            // btnPedidosE
            // 
            btnPedidosE.BackColor = Color.White;
            btnPedidosE.FlatAppearance.BorderSize = 0;
            btnPedidosE.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnPedidosE.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnPedidosE.FlatStyle = FlatStyle.Flat;
            btnPedidosE.Font = new Font("Century Gothic", 12F);
            btnPedidosE.Image = (Image)resources.GetObject("btnPedidosE.Image");
            btnPedidosE.ImageAlign = ContentAlignment.MiddleLeft;
            btnPedidosE.Location = new Point(26, 663);
            btnPedidosE.Name = "btnPedidosE";
            btnPedidosE.Size = new Size(291, 64);
            btnPedidosE.TabIndex = 3;
            btnPedidosE.Text = "Pedidos";
            btnPedidosE.UseVisualStyleBackColor = false;
            btnPedidosE.Click += btnPedidosE_Click;
            // 
            // btnClientesE
            // 
            btnClientesE.BackColor = Color.White;
            btnClientesE.FlatAppearance.BorderSize = 0;
            btnClientesE.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnClientesE.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnClientesE.FlatStyle = FlatStyle.Flat;
            btnClientesE.Font = new Font("Century Gothic", 12F);
            btnClientesE.Image = (Image)resources.GetObject("btnClientesE.Image");
            btnClientesE.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientesE.Location = new Point(26, 441);
            btnClientesE.Name = "btnClientesE";
            btnClientesE.Size = new Size(291, 64);
            btnClientesE.TabIndex = 1;
            btnClientesE.Text = "Clientes";
            btnClientesE.UseVisualStyleBackColor = false;
            btnClientesE.Click += btnClientesE_Click;
            // 
            // btnEstoqueE
            // 
            btnEstoqueE.BackColor = Color.FromArgb(191, 165, 187);
            btnEstoqueE.FlatAppearance.BorderSize = 0;
            btnEstoqueE.FlatAppearance.MouseDownBackColor = Color.FromArgb(191, 165, 187);
            btnEstoqueE.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 165, 187);
            btnEstoqueE.FlatStyle = FlatStyle.Flat;
            btnEstoqueE.Font = new Font("Century Gothic", 12F);
            btnEstoqueE.ForeColor = Color.Black;
            btnEstoqueE.Image = (Image)resources.GetObject("btnEstoqueE.Image");
            btnEstoqueE.ImageAlign = ContentAlignment.MiddleLeft;
            btnEstoqueE.Location = new Point(26, 331);
            btnEstoqueE.Name = "btnEstoqueE";
            btnEstoqueE.Size = new Size(291, 64);
            btnEstoqueE.TabIndex = 0;
            btnEstoqueE.Text = "Estoque";
            btnEstoqueE.UseVisualStyleBackColor = false;
            // 
            // btnEditarE
            // 
            btnEditarE.BackColor = Color.White;
            btnEditarE.FlatAppearance.BorderSize = 0;
            btnEditarE.FlatStyle = FlatStyle.Flat;
            btnEditarE.Font = new Font("Century Gothic", 10F);
            btnEditarE.Location = new Point(785, 237);
            btnEditarE.Name = "btnEditarE";
            btnEditarE.Size = new Size(107, 35);
            btnEditarE.TabIndex = 6;
            btnEditarE.Text = "Editar";
            btnEditarE.UseVisualStyleBackColor = false;
            btnEditarE.Click += btnEditarE_Click;
            // 
            // btnExcluirE
            // 
            btnExcluirE.BackColor = Color.FromArgb(191, 165, 187);
            btnExcluirE.FlatAppearance.BorderSize = 0;
            btnExcluirE.FlatStyle = FlatStyle.Flat;
            btnExcluirE.Font = new Font("Century Gothic", 10F);
            btnExcluirE.Location = new Point(918, 237);
            btnExcluirE.Name = "btnExcluirE";
            btnExcluirE.Size = new Size(107, 35);
            btnExcluirE.TabIndex = 7;
            btnExcluirE.Text = "Excluir ";
            btnExcluirE.UseVisualStyleBackColor = false;
            btnExcluirE.Click += btnExcluirE_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnEditarE);
            groupBox2.Controls.Add(btnAbrirCadastroE);
            groupBox2.Controls.Add(btnExcluirE);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(381, 21);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1055, 303);
            groupBox2.TabIndex = 33;
            groupBox2.TabStop = false;
            // 
            // panelCadastroE
            // 
            panelCadastroE.Controls.Add(groupBox1);
            panelCadastroE.Location = new Point(342, 0);
            panelCadastroE.Name = "panelCadastroE";
            panelCadastroE.Size = new Size(1136, 821);
            panelCadastroE.TabIndex = 33;
            panelCadastroE.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnVoltarE);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnSalvarE);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(cmbCategoriaE);
            groupBox1.Controls.Add(txtNomeItemE);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(QuantidadeE);
            groupBox1.Location = new Point(42, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1055, 396);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            // 
            // btnVoltarE
            // 
            btnVoltarE.BackColor = Color.White;
            btnVoltarE.FlatAppearance.BorderSize = 0;
            btnVoltarE.FlatStyle = FlatStyle.Flat;
            btnVoltarE.Font = new Font("Century Gothic", 10F);
            btnVoltarE.Location = new Point(902, 333);
            btnVoltarE.Name = "btnVoltarE";
            btnVoltarE.Size = new Size(107, 35);
            btnVoltarE.TabIndex = 3;
            btnVoltarE.Text = "Voltar";
            btnVoltarE.UseVisualStyleBackColor = false;
            btnVoltarE.Click += btnVoltarE_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 23);
            label4.Name = "label4";
            label4.Size = new Size(477, 29);
            label4.TabIndex = 20;
            label4.Text = "Gerencie seus materiais e aviamentos";
            // 
            // btnSalvarE
            // 
            btnSalvarE.BackColor = Color.FromArgb(191, 165, 187);
            btnSalvarE.FlatAppearance.BorderSize = 0;
            btnSalvarE.FlatStyle = FlatStyle.Flat;
            btnSalvarE.Font = new Font("Century Gothic", 10F);
            btnSalvarE.Location = new Point(729, 333);
            btnSalvarE.Name = "btnSalvarE";
            btnSalvarE.Size = new Size(107, 35);
            btnSalvarE.TabIndex = 4;
            btnSalvarE.Text = "Salvar";
            btnSalvarE.UseVisualStyleBackColor = false;
            btnSalvarE.Click += btnSalvarE_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 10F);
            label6.Location = new Point(53, 172);
            label6.Name = "label6";
            label6.Size = new Size(103, 21);
            label6.TabIndex = 3;
            label6.Text = "Nome Item";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 10F);
            label8.Location = new Point(744, 173);
            label8.Name = "label8";
            label8.Size = new Size(96, 21);
            label8.TabIndex = 5;
            label8.Text = "Categoria";
            // 
            // cmbCategoriaE
            // 
            cmbCategoriaE.FormattingEnabled = true;
            cmbCategoriaE.Items.AddRange(new object[] { "Tecido", "Linha", "Aviamentos" });
            cmbCategoriaE.Location = new Point(744, 203);
            cmbCategoriaE.Name = "cmbCategoriaE";
            cmbCategoriaE.Size = new Size(238, 28);
            cmbCategoriaE.TabIndex = 2;
            cmbCategoriaE.KeyPress += cmbCategoriaE_KeyPress;
            // 
            // txtNomeItemE
            // 
            txtNomeItemE.Location = new Point(49, 200);
            txtNomeItemE.Name = "txtNomeItemE";
            txtNomeItemE.Size = new Size(238, 27);
            txtNomeItemE.TabIndex = 0;
            txtNomeItemE.KeyPress += txtNomeItemE_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 10F);
            label7.Location = new Point(386, 173);
            label7.Name = "label7";
            label7.Size = new Size(114, 21);
            label7.TabIndex = 4;
            label7.Text = "Quantidade";
            // 
            // QuantidadeE
            // 
            QuantidadeE.Location = new Point(386, 203);
            QuantidadeE.Name = "QuantidadeE";
            QuantidadeE.Size = new Size(235, 27);
            QuantidadeE.TabIndex = 1;
            // 
            // TelaEstoque
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1475, 827);
            Controls.Add(panelCadastroE);
            Controls.Add(panel1);
            Controls.Add(dgvEstoque);
            Controls.Add(panel2);
            Controls.Add(groupBox2);
            MaximizeBox = false;
            Name = "TelaEstoque";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelaEstoque";
            ((System.ComponentModel.ISupportInitialize)dgvEstoque).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panelCadastroE.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)QuantidadeE).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAbrirCadastroE;
        private DataGridView dgvEstoque;
        private Panel panel2;
        private PictureBox pictureBox2;
        private TextBox txtBuscaE;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Button btnServicosE;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnPedidosE;
        private Button btnClientesE;
        private Button btnEstoqueE;
        private Button btnEditarC;
        private Button btnExcluirC;
        private GroupBox groupBox2;
        private Button btnEditarE;
        private Button btnExcluirE;
        private Panel panelCadastroE;
        private GroupBox groupBox1;
        private Button btnVoltarE;
        private Label label4;
        private Button btnSalvarE;
        private Label label6;
        private Label label8;
        private ComboBox cmbCategoriaE;
        private TextBox txtNomeItemE;
        private Label label7;
        private NumericUpDown QuantidadeE;
        private Label label14;
    }
}