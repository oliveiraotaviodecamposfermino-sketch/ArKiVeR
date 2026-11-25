namespace Projeto_Final
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // Fecha tela login
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        // Autentica acesso usuário
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ConectaBanco conecta = new ConectaBanco();
            if (conecta.verifica(txtUserLogin.Text, txtSenhaLogin.Text) == true)
            {
                Form1 formSistema = new Form1();
                this.Hide();
                formSistema.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!" + conecta.mensagem);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

