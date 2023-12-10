namespace TP
{
    public class Candidato

    {
        private string nome;
        private double notaRedacao;
        private double notaMatematica;
        private double notaLinguagens;
        private int codigoPrimeiraOpcao;
        private int codigoSegundaOpcao;

        public string Nome { get => nome; set => nome = value; }
        public double NotaRedacao { get => notaRedacao; set => notaRedacao = value; }
        public double NotaMatematica { get => notaMatematica; set => notaMatematica = value; }
        public double NotaLinguagens { get => notaLinguagens; set => notaLinguagens = value; }
        public int CodigoPrimeiraOpcao { get => codigoPrimeiraOpcao; set => codigoPrimeiraOpcao = value; }
        public int CodigoSegundaOpcao { get => codigoSegundaOpcao; set => codigoSegundaOpcao = value; }

        public Candidato(string nome, double notaRedacao, double notaMatematica, double notaLinguagens, int codigoPrimeiraOpcao, int codigoSegundaOpcao)
        {
            this.Nome = nome;
            this.NotaRedacao = notaRedacao;
            this.NotaMatematica = notaMatematica;
            this.NotaLinguagens = notaLinguagens;
            this.CodigoPrimeiraOpcao = codigoPrimeiraOpcao;
            this.CodigoSegundaOpcao = codigoSegundaOpcao;
        }

        // Calcula nota média das 3 provas
        public double CalcularMedia()
        {
            // Retorne a média formatada com duas casas decimais
            return Math.Round((NotaLinguagens + NotaMatematica + NotaRedacao) / 3, 2);
        }

    }
}
