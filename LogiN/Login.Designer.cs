namespace LogiN
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox2 = new PictureBox();
            label1 = new Label();
            txtUsuarioL = new TextBox();
            label2 = new Label();
            txtSenhaL = new TextBox();
            label3 = new Label();
            btnEntrarL = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            btncadastraL = new Button();
            label9 = new Label();
            txtSenhaCadastroL = new TextBox();
            txtNomeCadastroL = new TextBox();
            btnSalvarCadastroL = new Button();
            label7 = new Label();
            label6 = new Label();
            PanelCadastroUsuarioL = new Panel();
            btnVoltarL = new Button();
            label12 = new Label();
            label5 = new Label();
            txtCpfCadastroL = new TextBox();
            pictureBox3 = new PictureBox();
            panelRedefinirSenhaL = new Panel();
            btnVoltarLogin = new Button();
            label8 = new Label();
            pictureBox4 = new PictureBox();
            label14 = new Label();
            label13 = new Label();
            l = new Label();
            txtSenhaRedefinirL = new TextBox();
            btnRedefinirSalvarL = new Button();
            txtCpfRedefinirL = new TextBox();
            lblEqueceuSenha = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelCadastroUsuarioL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panelRedefinirSenhaL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(649, 33);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(271, 183);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(621, 323);
            label1.Name = "label1";
            label1.Size = new Size(70, 21);
            label1.TabIndex = 2;
            label1.Text = "Usuario";
            // 
            // txtUsuarioL
            // 
            txtUsuarioL.Location = new Point(621, 347);
            txtUsuarioL.Multiline = true;
            txtUsuarioL.Name = "txtUsuarioL";
            txtUsuarioL.Size = new Size(331, 33);
            txtUsuarioL.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(731, 267);
            label2.Name = "label2";
            label2.Size = new Size(103, 21);
            label2.TabIndex = 4;
            label2.Text = "Bem vinda!";
            // 
            // txtSenhaL
            // 
            txtSenhaL.Location = new Point(621, 455);
            txtSenhaL.Multiline = true;
            txtSenhaL.Name = "txtSenhaL";
            txtSenhaL.Size = new Size(331, 33);
            txtSenhaL.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(621, 431);
            label3.Name = "label3";
            label3.Size = new Size(61, 21);
            label3.TabIndex = 5;
            label3.Text = "Senha";
            // 
            // btnEntrarL
            // 
            btnEntrarL.Location = new Point(621, 581);
            btnEntrarL.Name = "btnEntrarL";
            btnEntrarL.Size = new Size(144, 37);
            btnEntrarL.TabIndex = 5;
            btnEntrarL.Text = "Entrar";
            btnEntrarL.UseVisualStyleBackColor = true;
            btnEntrarL.Click += btnEntrarL_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 8F);
            label4.Location = new Point(937, 720);
            label4.Name = "label4";
            label4.Size = new Size(111, 19);
            label4.TabIndex = 8;
            label4.Text = "by  ASTER TECH";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-4, -8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(497, 768);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btncadastraL
            // 
            btncadastraL.Location = new Point(808, 581);
            btncadastraL.Name = "btncadastraL";
            btncadastraL.Size = new Size(144, 37);
            btncadastraL.TabIndex = 4;
            btncadastraL.Text = "Cadastrar";
            btncadastraL.UseVisualStyleBackColor = true;
            btncadastraL.Click += btncadastraL_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 9.75F);
            label9.Location = new Point(101, 493);
            label9.Name = "label9";
            label9.Size = new Size(66, 21);
            label9.TabIndex = 28;
            label9.Text = "Senha:";
            // 
            // txtSenhaCadastroL
            // 
            txtSenhaCadastroL.Location = new Point(100, 520);
            txtSenhaCadastroL.Margin = new Padding(3, 4, 3, 4);
            txtSenhaCadastroL.Name = "txtSenhaCadastroL";
            txtSenhaCadastroL.Size = new Size(353, 27);
            txtSenhaCadastroL.TabIndex = 3;
            // 
            // txtNomeCadastroL
            // 
            txtNomeCadastroL.Location = new Point(98, 354);
            txtNomeCadastroL.Margin = new Padding(3, 4, 3, 4);
            txtNomeCadastroL.Name = "txtNomeCadastroL";
            txtNomeCadastroL.Size = new Size(354, 27);
            txtNomeCadastroL.TabIndex = 1;
            // 
            // btnSalvarCadastroL
            // 
            btnSalvarCadastroL.BackColor = Color.White;
            btnSalvarCadastroL.Font = new Font("Century Gothic", 9F);
            btnSalvarCadastroL.Location = new Point(101, 611);
            btnSalvarCadastroL.Name = "btnSalvarCadastroL";
            btnSalvarCadastroL.Size = new Size(144, 35);
            btnSalvarCadastroL.TabIndex = 4;
            btnSalvarCadastroL.Text = "Salvar";
            btnSalvarCadastroL.UseVisualStyleBackColor = false;
            btnSalvarCadastroL.Click += btnSalvarCadastroL_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 15F, FontStyle.Bold);
            label7.Location = new Point(113, 237);
            label7.Name = "label7";
            label7.Size = new Size(325, 29);
            label7.TabIndex = 2;
            label7.Text = "Cadastre-se nove usuário";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9.75F);
            label6.Location = new Point(100, 325);
            label6.Name = "label6";
            label6.Size = new Size(65, 21);
            label6.TabIndex = 1;
            label6.Text = "Nome:";
            // 
            // PanelCadastroUsuarioL
            // 
            PanelCadastroUsuarioL.Controls.Add(panelRedefinirSenhaL);
            PanelCadastroUsuarioL.Controls.Add(btnVoltarL);
            PanelCadastroUsuarioL.Controls.Add(label12);
            PanelCadastroUsuarioL.Controls.Add(label9);
            PanelCadastroUsuarioL.Controls.Add(label7);
            PanelCadastroUsuarioL.Controls.Add(txtSenhaCadastroL);
            PanelCadastroUsuarioL.Controls.Add(txtNomeCadastroL);
            PanelCadastroUsuarioL.Controls.Add(label6);
            PanelCadastroUsuarioL.Controls.Add(btnSalvarCadastroL);
            PanelCadastroUsuarioL.Controls.Add(label5);
            PanelCadastroUsuarioL.Controls.Add(txtCpfCadastroL);
            PanelCadastroUsuarioL.Controls.Add(pictureBox3);
            PanelCadastroUsuarioL.Location = new Point(497, 2);
            PanelCadastroUsuarioL.Margin = new Padding(3, 4, 3, 4);
            PanelCadastroUsuarioL.Name = "PanelCadastroUsuarioL";
            PanelCadastroUsuarioL.Size = new Size(551, 746);
            PanelCadastroUsuarioL.TabIndex = 11;
            PanelCadastroUsuarioL.Visible = false;
            // 
            // btnVoltarL
            // 
            btnVoltarL.BackColor = Color.White;
            btnVoltarL.Font = new Font("Century Gothic", 9F);
            btnVoltarL.Location = new Point(308, 611);
            btnVoltarL.Name = "btnVoltarL";
            btnVoltarL.Size = new Size(144, 35);
            btnVoltarL.TabIndex = 31;
            btnVoltarL.Text = "Voltar";
            btnVoltarL.UseVisualStyleBackColor = false;
            btnVoltarL.Click += btnVoltarL_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 8F);
            label12.Location = new Point(426, 719);
            label12.Name = "label12";
            label12.Size = new Size(111, 19);
            label12.TabIndex = 30;
            label12.Text = "by  ASTER TECH";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9.75F);
            label5.Location = new Point(100, 401);
            label5.Name = "label5";
            label5.Size = new Size(47, 21);
            label5.TabIndex = 1;
            label5.Text = "CPF:";
            // 
            // txtCpfCadastroL
            // 
            txtCpfCadastroL.Location = new Point(100, 428);
            txtCpfCadastroL.Margin = new Padding(3, 4, 3, 4);
            txtCpfCadastroL.Name = "txtCpfCadastroL";
            txtCpfCadastroL.Size = new Size(353, 27);
            txtCpfCadastroL.TabIndex = 2;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(142, 32);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(271, 183);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // panelRedefinirSenhaL
            // 
            panelRedefinirSenhaL.Controls.Add(btnVoltarLogin);
            panelRedefinirSenhaL.Controls.Add(label8);
            panelRedefinirSenhaL.Controls.Add(pictureBox4);
            panelRedefinirSenhaL.Controls.Add(label14);
            panelRedefinirSenhaL.Controls.Add(label13);
            panelRedefinirSenhaL.Controls.Add(l);
            panelRedefinirSenhaL.Controls.Add(txtSenhaRedefinirL);
            panelRedefinirSenhaL.Controls.Add(btnRedefinirSalvarL);
            panelRedefinirSenhaL.Controls.Add(txtCpfRedefinirL);
            panelRedefinirSenhaL.Location = new Point(2, 0);
            panelRedefinirSenhaL.Margin = new Padding(3, 4, 3, 4);
            panelRedefinirSenhaL.Name = "panelRedefinirSenhaL";
            panelRedefinirSenhaL.Size = new Size(551, 746);
            panelRedefinirSenhaL.TabIndex = 12;
            panelRedefinirSenhaL.Visible = false;
            // 
            // btnVoltarLogin
            // 
            btnVoltarLogin.BackColor = Color.White;
            btnVoltarLogin.Font = new Font("Century Gothic", 9F);
            btnVoltarLogin.Location = new Point(299, 580);
            btnVoltarLogin.Margin = new Padding(3, 4, 3, 4);
            btnVoltarLogin.Name = "btnVoltarLogin";
            btnVoltarLogin.Size = new Size(144, 35);
            btnVoltarLogin.TabIndex = 33;
            btnVoltarLogin.Text = "Voltar";
            btnVoltarLogin.UseVisualStyleBackColor = false;
            btnVoltarLogin.Click += btnVoltarLogin_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 15F, FontStyle.Bold);
            label8.Location = new Point(145, 237);
            label8.Name = "label8";
            label8.Size = new Size(262, 29);
            label8.TabIndex = 32;
            label8.Text = "Redefina sua Senha ";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(142, 26);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(271, 183);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 31;
            pictureBox4.TabStop = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 8F);
            label14.Location = new Point(429, 719);
            label14.Name = "label14";
            label14.Size = new Size(111, 19);
            label14.TabIndex = 11;
            label14.Text = "by  ASTER TECH";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 9F);
            label13.Location = new Point(111, 461);
            label13.Name = "label13";
            label13.Size = new Size(99, 20);
            label13.TabIndex = 9;
            label13.Text = "Nova Senha";
            // 
            // l
            // 
            l.AutoSize = true;
            l.Font = new Font("Century Gothic", 9F);
            l.Location = new Point(113, 357);
            l.Name = "l";
            l.Size = new Size(37, 20);
            l.TabIndex = 8;
            l.Text = "CPF";
            // 
            // txtSenhaRedefinirL
            // 
            txtSenhaRedefinirL.Location = new Point(111, 492);
            txtSenhaRedefinirL.Margin = new Padding(3, 4, 3, 4);
            txtSenhaRedefinirL.Name = "txtSenhaRedefinirL";
            txtSenhaRedefinirL.Size = new Size(331, 27);
            txtSenhaRedefinirL.TabIndex = 2;
            // 
            // btnRedefinirSalvarL
            // 
            btnRedefinirSalvarL.BackColor = Color.White;
            btnRedefinirSalvarL.Font = new Font("Century Gothic", 9F);
            btnRedefinirSalvarL.Location = new Point(111, 580);
            btnRedefinirSalvarL.Margin = new Padding(3, 4, 3, 4);
            btnRedefinirSalvarL.Name = "btnRedefinirSalvarL";
            btnRedefinirSalvarL.Size = new Size(144, 35);
            btnRedefinirSalvarL.TabIndex = 3;
            btnRedefinirSalvarL.Text = "Redefinir";
            btnRedefinirSalvarL.UseVisualStyleBackColor = false;
            btnRedefinirSalvarL.Click += btnRedefinirSalvarL_Click;
            // 
            // txtCpfRedefinirL
            // 
            txtCpfRedefinirL.Location = new Point(113, 386);
            txtCpfRedefinirL.Margin = new Padding(3, 4, 3, 4);
            txtCpfRedefinirL.Name = "txtCpfRedefinirL";
            txtCpfRedefinirL.Size = new Size(330, 27);
            txtCpfRedefinirL.TabIndex = 1;
            // 
            // lblEqueceuSenha
            // 
            lblEqueceuSenha.AutoSize = true;
            lblEqueceuSenha.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEqueceuSenha.ForeColor = SystemColors.Desktop;
            lblEqueceuSenha.Location = new Point(779, 504);
            lblEqueceuSenha.Name = "lblEqueceuSenha";
            lblEqueceuSenha.Size = new Size(173, 21);
            lblEqueceuSenha.TabIndex = 3;
            lblEqueceuSenha.Text = "Esqueceu a senha?";
            lblEqueceuSenha.Click += EqueceuSenha_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1048, 748);
            Controls.Add(PanelCadastroUsuarioL);
            Controls.Add(btncadastraL);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(btnEntrarL);
            Controls.Add(txtSenhaL);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtUsuarioL);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(lblEqueceuSenha);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelCadastroUsuarioL.ResumeLayout(false);
            PanelCadastroUsuarioL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panelRedefinirSenhaL.ResumeLayout(false);
            panelRedefinirSenhaL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox2;
        private Label label1;
        private TextBox txtUsuarioL;
        private Label label2;
        private TextBox txtSenhaL;
        private Label label3;
        private Button btnEntrarL;
        private Label label4;
        private PictureBox pictureBox1;
        private Button btncadastraL;
        private Button btnVoltarS;
        private Button btnSalvarCadastroL;
        private Label label7;
        private Label label6;
        private TextBox txtNomeCadastroL;
        private TextBox txtSenhaCadastroL;
        private Label label9;
        private Panel PanelCadastroUsuarioL;
        private Label lblEqueceuSenha;
        private Panel panelRedefinirSenhaL;
        private PictureBox pictureBox3;
        private Label label13;
        private Label l;
        private TextBox txtSenhaRedefinirL;
        private Button btnRedefinirSalvarL;
        private TextBox txtCpfRedefinirL;
        private Label label5;
        private TextBox txtCpfCadastroL;
        private Label label12;
        private Label label14;
        private PictureBox pictureBox4;
        private Label label8;
        private Button btnVoltarL;
        private Button btnVoltarLogin;
    }
}
