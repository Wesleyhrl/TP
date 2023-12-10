namespace TP
{
    public class Curso
    {

        private int codigoDoCurso;
        private string nomeDoCurso;
        private int quantidadeDeVagas;
        private Lista CandidatosSelecionados;
        private Fila FilaEspera;

        public int CodigoDoCurso { get => codigoDoCurso; set => codigoDoCurso = value; }
        public string NomeDoCurso { get => nomeDoCurso; set => nomeDoCurso = value; }
        public int QuantidadeDeVagas { get => quantidadeDeVagas; set => quantidadeDeVagas = value; }

        public Curso(int codigo, string nome, int vagas)
        {
            CodigoDoCurso = codigo;
            NomeDoCurso = nome;
            QuantidadeDeVagas = vagas;
            CandidatosSelecionados = new Lista(vagas);
            FilaEspera = new Fila();
        }

        public Candidato[] ArrayCandidatos()
        {
            return CandidatosSelecionados.ObterElementos();
        }

        public Candidato[] ArrayFilaEspera()
        {
            return FilaEspera.ObterElementos();
        }

        public int NumSelecionados()
        {
            return CandidatosSelecionados.Quantidade();
        }
        public double CalcularNotaCorte()
        {
            if (CandidatosSelecionados != null && NumSelecionados() > 0)
            {
                double menorMedia = double.MaxValue;
                foreach (Candidato candidato in CandidatosSelecionados.ObterElementos())
                {
                    if (candidato != null && candidato.CalcularMedia() < menorMedia)
                    {
                        menorMedia = candidato.CalcularMedia();
                    }
                }
                return menorMedia;
            }
            else
            {
                return 0;
            }
        }

        public void AdicionarSelecionado(Candidato candidato)
        {

            CandidatosSelecionados.InserirFim(candidato);

        }
        public bool RemoverSelecionado(Candidato candidato)
        {
            return CandidatosSelecionados.RemoverItem(candidato.Nome);
        }

        public void AdicionarFilaEspera(Candidato candidato)
        {
            FilaEspera.Inserir(candidato);
        }
        public bool RemoverEspecificoFilaEspera(Candidato candidato)
        {
            return FilaEspera.RemoverEspecifico(candidato.Nome);
        }
    }
}
