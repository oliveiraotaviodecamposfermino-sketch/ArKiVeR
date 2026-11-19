using System.Data;

namespace Projeto_Final
{
    public partial class Form1 : Form
    {
        int idAlterar;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MoverMarcador(btnBuscar);
            tabTelas.SelectedTab = tabBuscar;
            usBuscar1.lista_gridGames();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            MoverMarcador(btnCadastrar);
            tabTelas.SelectedTab = tabCadastrar;
        }

        public void AbrirAbaAlterar()
        {
            // Muda para a aba de alteração
            tabTelas.SelectedTab = tabAlterar;
        }

        // Método para mover o marcador para o botão clicado
        private void MoverMarcador(Button botao)
        {
            marcador.Width = botao.Width;
            marcador.Left = botao.Left;
            marcador.Top = botao.Bottom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaCBGeneros();
            listaCBPlataformas();
        }

        private void tabCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void cmbPlataforma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            if (cbmAlteraPlataforma.SelectedValue == null || cbmAlteraGenero.SelectedValue == null)
            {
                MessageBox.Show("Selecione uma plataforma e um gênero.");
                return;
            }

            ConectaBanco con = new ConectaBanco();
            Jogo jogoEditado = new Jogo();

            jogoEditado.Nome = txtAlteraNome.Text;
            jogoEditado.Fk_plataforma = Convert.ToInt32(cbmAlteraPlataforma.SelectedValue);
            jogoEditado.Fk_genero = Convert.ToInt32(cbmAlteraGenero.SelectedValue);
            jogoEditado.Desenvolvedora = txtAlteraDesenvolvedora.Text;
            jogoEditado.Ano_lancamento = Convert.ToInt32(nudAlteraAno.Value);
            jogoEditado.Nota = (float)nudAlteraNota.Value;
            jogoEditado.Observacao = txtAlteraObservacao.Text;

            bool retorno = con.alteraGame(jogoEditado, idAlterar);
            if (!retorno)
            {
                MessageBox.Show(con.mensagem);
            }
            else
            {
                MessageBox.Show("Jogo alterado com sucesso!");
                tabTelas.SelectedTab = tabBuscar;
                usBuscar1.lista_gridGames();
            }
        }

        private void btnAddGenero_Click(object sender, EventArgs e)
        {
            frmAdicionarGenero formGenero = new frmAdicionarGenero();
            this.Hide();
            formGenero.ShowDialog();
            this.Close();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        public void listaCBGeneros()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = con.listaGeneros();
            cmbGenero.DataSource = tabelaDados;
            cmbGenero.DisplayMember = "genero";
            cmbGenero.ValueMember = "idgenero";
            cmbGenero.SelectedIndex = -1;

            cbmAlteraGenero.DataSource = tabelaDados.Copy();
            cbmAlteraGenero.DisplayMember = "genero";
            cbmAlteraGenero.ValueMember = "idgenero";
            cbmAlteraGenero.SelectedIndex = -1;
        }

        public void listaCBPlataformas()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = con.listaPlataformas();
            cmbPlataforma.DataSource = tabelaDados;
            cmbPlataforma.DisplayMember = "plataforma";
            cmbPlataforma.ValueMember = "idplataforma";
            cmbPlataforma.SelectedIndex = -1;

            cbmAlteraPlataforma.DataSource = tabelaDados.Copy();
            cbmAlteraPlataforma.DisplayMember = "plataforma";
            cbmAlteraPlataforma.ValueMember = "idplataforma";
            cbmAlteraPlataforma.SelectedIndex = -1;
        }

        public void PreencherAbaAlterar(int id, string nome, string plataforma, string genero, string desenvolvedora, int ano, decimal nota, string observacao)
        {
            idAlterar = id;
            txtAlteraNome.Text = nome;
            cbmAlteraPlataforma.Text = plataforma;
            cbmAlteraGenero.Text = genero;
            txtAlteraDesenvolvedora.Text = desenvolvedora;
            nudAlteraAno.Value = ano;
            nudAlteraNota.Value = nota;
            txtAlteraObservacao.Text = observacao;

            tabTelas.SelectedTab = tabAlterar;
        }

        void limpaCampos()
        {
            txtNome.Clear();
            cmbPlataforma.SelectedIndex = -1;
            cmbGenero.SelectedIndex = -1;
            txtDesenvolvedora.Clear();
            nudAno.Value = 2026;
            nudNota.Value = 0;
            txtObservacao.Clear();
            txtNome.Focus();
        }

        private void btnSalvarJogo_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            Jogo novoJogo = new Jogo();

            novoJogo.Nome = txtNome.Text;
            novoJogo.Fk_plataforma = Convert.ToInt32(cmbPlataforma.SelectedValue);
            novoJogo.Fk_genero = Convert.ToInt32(cmbGenero.SelectedValue);
            novoJogo.Desenvolvedora = txtDesenvolvedora.Text;
            novoJogo.Ano_lancamento = Convert.ToInt32(nudAno.Value);
            novoJogo.Nota = (float)nudNota.Value;
            novoJogo.Observacao = txtObservacao.Text;

            bool retorno = con.insereGame(novoJogo);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else
            {
                MessageBox.Show("Jogo cadastrado com sucesso!");
                limpaCampos();
            }
        }
    }
}