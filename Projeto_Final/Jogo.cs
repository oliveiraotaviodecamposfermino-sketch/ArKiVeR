namespace Projeto_Final
{
    internal class Jogo
    {
        string nome;
        int fk_plataforma;
        int fk_genero;
        string desenvolvedora;
        int ano_lancamento;
        float nota;
        string observacao;

        public string Nome { get => nome; set => nome = value; }
        public int Fk_plataforma { get => fk_plataforma; set => fk_plataforma = value; }
        public int Fk_genero { get => fk_genero; set => fk_genero = value; }
        public string Desenvolvedora { get => desenvolvedora; set => desenvolvedora = value; }
        public int Ano_lancamento { get => ano_lancamento; set => ano_lancamento = value; }
        public float Nota { get => nota; set => nota = value; }
        public string Observacao { get => observacao; set => observacao = value; }
    }
}