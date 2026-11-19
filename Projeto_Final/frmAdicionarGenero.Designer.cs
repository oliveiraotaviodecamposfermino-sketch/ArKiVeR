namespace Projeto_Final
{
    partial class frmAdicionarGenero
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
            pnlTopoGenero = new Panel();
            btnFecharGenero = new Button();
            label1 = new Label();
            label2 = new Label();
            txtNovoGenero = new TextBox();
            btnSalvarGenero = new Button();
            panel1 = new Panel();
            label3 = new Label();
            cmbExcluirGenero = new ComboBox();
            btnExcluirGenero = new Button();
            pnlTopoGenero.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopoGenero
            // 
            pnlTopoGenero.BackColor = Color.FromArgb(38, 18, 53);
            pnlTopoGenero.Controls.Add(btnFecharGenero);
            pnlTopoGenero.Controls.Add(label1);
            pnlTopoGenero.Dock = DockStyle.Top;
            pnlTopoGenero.Location = new Point(0, 0);
            pnlTopoGenero.Name = "pnlTopoGenero";
            pnlTopoGenero.Size = new Size(500, 50);
            pnlTopoGenero.TabIndex = 0;
            // 
            // btnFecharGenero
            // 
            btnFecharGenero.Cursor = Cursors.Hand;
            btnFecharGenero.FlatAppearance.BorderSize = 0;
            btnFecharGenero.FlatStyle = FlatStyle.Flat;
            btnFecharGenero.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFecharGenero.Image = Properties.Resources.close;
            btnFecharGenero.Location = new Point(453, 6);
            btnFecharGenero.Name = "btnFecharGenero";
            btnFecharGenero.Size = new Size(35, 35);
            btnFecharGenero.TabIndex = 3;
            btnFecharGenero.UseVisualStyleBackColor = true;
            btnFecharGenero.Click += btnFecharGenero_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(229, 229, 229);
            label1.Location = new Point(18, 14);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 0;
            label1.Text = "Gerenciar Gêneros";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = Color.FromArgb(229, 229, 229);
            label2.Location = new Point(71, 73);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 1;
            label2.Text = "Nome do Gênero:";
            // 
            // txtNovoGenero
            // 
            txtNovoGenero.Font = new Font("Microsoft Sans Serif", 11F);
            txtNovoGenero.Location = new Point(71, 109);
            txtNovoGenero.Name = "txtNovoGenero";
            txtNovoGenero.Size = new Size(350, 24);
            txtNovoGenero.TabIndex = 2;
            // 
            // btnSalvarGenero
            // 
            btnSalvarGenero.BackColor = Color.MediumSlateBlue;
            btnSalvarGenero.Cursor = Cursors.Hand;
            btnSalvarGenero.FlatAppearance.BorderSize = 0;
            btnSalvarGenero.FlatStyle = FlatStyle.Flat;
            btnSalvarGenero.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvarGenero.ForeColor = Color.FromArgb(229, 229, 229);
            btnSalvarGenero.Location = new Point(71, 151);
            btnSalvarGenero.Name = "btnSalvarGenero";
            btnSalvarGenero.Size = new Size(350, 42);
            btnSalvarGenero.TabIndex = 3;
            btnSalvarGenero.Text = "Adicionar Gênero";
            btnSalvarGenero.UseVisualStyleBackColor = false;
            btnSalvarGenero.Click += btnSalvarGenero_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateBlue;
            panel1.Location = new Point(0, 221);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 1);
            panel1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.ForeColor = Color.FromArgb(229, 229, 229);
            label3.Location = new Point(71, 241);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 5;
            label3.Text = "Excluir Gênero:";
            label3.Click += label3_Click;
            // 
            // cmbExcluirGenero
            // 
            cmbExcluirGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExcluirGenero.Font = new Font("Segoe UI", 11F);
            cmbExcluirGenero.FormattingEnabled = true;
            cmbExcluirGenero.Location = new Point(71, 273);
            cmbExcluirGenero.MaxDropDownItems = 5;
            cmbExcluirGenero.Name = "cmbExcluirGenero";
            cmbExcluirGenero.Size = new Size(350, 28);
            cmbExcluirGenero.TabIndex = 6;
            // 
            // btnExcluirGenero
            // 
            btnExcluirGenero.BackColor = Color.FromArgb(64, 0, 0);
            btnExcluirGenero.FlatAppearance.BorderSize = 0;
            btnExcluirGenero.FlatStyle = FlatStyle.Flat;
            btnExcluirGenero.Font = new Font("Segoe UI", 11F);
            btnExcluirGenero.ForeColor = Color.FromArgb(229, 229, 229);
            btnExcluirGenero.ImageAlign = ContentAlignment.MiddleLeft;
            btnExcluirGenero.Location = new Point(71, 403);
            btnExcluirGenero.Name = "btnExcluirGenero";
            btnExcluirGenero.Size = new Size(350, 42);
            btnExcluirGenero.TabIndex = 7;
            btnExcluirGenero.Text = "Excluir Gênero";
            btnExcluirGenero.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExcluirGenero.UseVisualStyleBackColor = false;
            btnExcluirGenero.Click += btnExcluirGenero_Click;
            // 
            // frmAdicionarGenero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(500, 490);
            Controls.Add(btnExcluirGenero);
            Controls.Add(cmbExcluirGenero);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(btnSalvarGenero);
            Controls.Add(txtNovoGenero);
            Controls.Add(label2);
            Controls.Add(pnlTopoGenero);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAdicionarGenero";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAdicionarGenero";
            Load += frmAdicionarGenero_Load;
            pnlTopoGenero.ResumeLayout(false);
            pnlTopoGenero.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTopoGenero;
        private Label label1;
        private Button btnFecharGenero;
        private Label label2;
        private TextBox txtNovoGenero;
        private Button btnSalvarGenero;
        private Panel panel1;
        private Label label3;
        private ComboBox cmbExcluirGenero;
        private Button btnExcluirGenero;
    }
}