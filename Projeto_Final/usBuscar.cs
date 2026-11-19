using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_Final
{
    public partial class usBuscar : UserControl
    {
        public usBuscar()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "idjogos", DataPropertyName = "idjogos", Visible = false },
                new DataGridViewTextBoxColumn { Name = "colTitulo", HeaderText = "Título", DataPropertyName = "nome", FillWeight = 20 },
                new DataGridViewTextBoxColumn { Name = "colPlataforma", HeaderText = "Plataforma", DataPropertyName = "plataforma", FillWeight = 12 },
                new DataGridViewTextBoxColumn { Name = "colGenero", HeaderText = "Gênero", DataPropertyName = "genero", FillWeight = 13 },
                new DataGridViewTextBoxColumn { Name = "colDesenvolvedora", HeaderText = "Desenvolvedora", DataPropertyName = "desenvolvedora", FillWeight = 17 },
                new DataGridViewTextBoxColumn { Name = "colAnoLancamento", HeaderText = "Ano", DataPropertyName = "ano_lancamento", FillWeight = 8 },
                new DataGridViewTextBoxColumn { Name = "colNota", HeaderText = "Nota", DataPropertyName = "nota", FillWeight = 8 },
                new DataGridViewTextBoxColumn { Name = "colDescricao", HeaderText = "Observação", DataPropertyName = "observacao", FillWeight = 22 }
            );

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 42;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 228, 240);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(38, 18, 53);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(215, 205, 235);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(38, 18, 53);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 245, 250);
            dataGridView1.GridColor = Color.FromArgb(220, 220, 225);
        }

        public void lista_gridGames()
        {
            ConectaBanco con = new ConectaBanco();
            dataGridView1.DataSource = con.listaGames();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usBuscar_Load(object sender, EventArgs e)
        {
            lista_gridGames();
            dataGridView1.ReadOnly = true;
        }

        private void pictureBoxImagemTopo_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione um jogo na tabela para alterar.");
                return;
            }

            int linha = dataGridView1.CurrentRow.Index;
            int idAlterar = Convert.ToInt32(dataGridView1.Rows[linha].Cells["idjogos"].Value);
            string nome = dataGridView1.Rows[linha].Cells["colTitulo"].Value.ToString();
            string plataforma = dataGridView1.Rows[linha].Cells["colPlataforma"].Value.ToString();
            string genero = dataGridView1.Rows[linha].Cells["colGenero"].Value.ToString();
            string desenvolvedora = dataGridView1.Rows[linha].Cells["colDesenvolvedora"].Value.ToString();
            int ano = Convert.ToInt32(dataGridView1.Rows[linha].Cells["colAnoLancamento"].Value);
            decimal nota = Convert.ToDecimal(dataGridView1.Rows[linha].Cells["colNota"].Value);
            string observacao = dataGridView1.Rows[linha].Cells["colDescricao"].Value.ToString();

            Form1 formPrincipal = (Form1)this.FindForm();
            formPrincipal.PreencherAbaAlterar(idAlterar, nome, plataforma, genero, desenvolvedora, ano, nota, observacao);
        
        }

        private void btnBuscarNome_Click(object sender, EventArgs e)
        {
            txtBusca.Focus();
            FiltrarJogos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarJogos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione um jogo na tabela para excluir.");
                return;
            }

            int linha = dataGridView1.CurrentRow.Index;
            int idRemove = Convert.ToInt32(dataGridView1.Rows[linha].Cells["idjogos"].Value);
            string nomeJogo = dataGridView1.Rows[linha].Cells["colTitulo"].Value.ToString();

            DialogResult resp = MessageBox.Show($"Tem certeza que deseja excluir \"{nomeJogo}\"?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resp == DialogResult.Yes)
            {
                ConectaBanco con = new ConectaBanco();
                if (con.deletaGame(idRemove))
                {
                    MessageBox.Show("Jogo excluído com sucesso!");
                    lista_gridGames();
                }
                else
                {
                    MessageBox.Show(con.mensagem);
                }
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            FiltrarJogos();
        }

        private void FiltrarJogos()
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                string termo = txtBusca.Text.Replace("'", "''");
                dt.DefaultView.RowFilter = string.Format("nome LIKE '%{0}%'", termo);
            }
        }

    }
}
