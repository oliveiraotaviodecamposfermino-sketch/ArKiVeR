namespace Projeto_Final
{
    public partial class frmAdicionarGenero : Form
    {
        // Inicializa formulário gêneros
        public frmAdicionarGenero()
        {
            InitializeComponent();
            CarregarGeneros();
        }

        // Retorna tela principal
        private void btnFecharGenero_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formSistema = new Form1();
            formSistema.ShowDialog();
            this.Close();
        }

        // Cadastra novo gênero
        private void btnSalvarGenero_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            bool retorno = con.InserirGenero(txtNovoGenero.Text);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else
            {
                MessageBox.Show("Gênero cadastrado com sucesso!");
                txtNovoGenero.Clear();
                txtNovoGenero.Focus();
                CarregarGeneros();
            }
        }

        private void frmAdicionarGenero_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Popula ComboBox gêneros
        private void CarregarGeneros()
        {
            ConectaBanco con = new ConectaBanco();
            cmbExcluirGenero.DataSource = con.listaGeneros();
            cmbExcluirGenero.DisplayMember = "genero";
            cmbExcluirGenero.ValueMember = "idgenero";
            cmbExcluirGenero.SelectedIndex = -1;
        }

        // Exclui gênero selecionado
        private void btnExcluirGenero_Click(object sender, EventArgs e)
        {
            if (cmbExcluirGenero.SelectedValue == null)
            {
                MessageBox.Show("Selecione um gênero para excluir.");
                return;
            }

            int idGenero = Convert.ToInt32(cmbExcluirGenero.SelectedValue);
            string nomeGenero = cmbExcluirGenero.Text;

            DialogResult resp = MessageBox.Show(
                $"Tem certeza que deseja excluir o gênero \"{nomeGenero}\"?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resp == DialogResult.Yes)
            {
                ConectaBanco con = new ConectaBanco();
                if (con.RemoveGenero(idGenero))
                {
                    MessageBox.Show("Gênero excluído com sucesso!");
                    CarregarGeneros();
                }
                else
                {
                    MessageBox.Show(con.mensagem);
                }
            }
        }

        private void txtNovoGenero_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
