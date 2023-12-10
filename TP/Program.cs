using System.Text;
using TP;

public class Program
{
    static void Main(string[] args)
    {

        Dictionary<int, Curso> cursos; // Dicionario para armazenar os cursos existentes 
        Lista candidatos;
        LeituraArquivo(out cursos, out candidatos);
        // Ordena a lista em ordem decrescente por nota da media dos candidatos
        candidatos.OrdenarPorMedia();
        // Exibe informações dos cursos
        Console.WriteLine("Informações dos Cursos:");
        foreach (Curso curso in cursos.Values)
        {
            Console.WriteLine($"Código: {curso.CodigoDoCurso}, Nome: {curso.NomeDoCurso}, Vagas Disponíveis: {curso.QuantidadeDeVagas}");
        }

        // Exibe informações dos candidatos
        Console.WriteLine("\nInformações dos Candidatos:");
        foreach (Candidato candidato in candidatos.ObterElementos())
        {
            Console.WriteLine($"Nome: {candidato.Nome}, Nota Redação: {candidato.NotaRedacao}, Nota Matemática: {candidato.NotaMatematica}, Nota Linguagens: {candidato.NotaLinguagens}, Opção 1: {candidato.CodigoPrimeiraOpcao}, Opção 2: {candidato.CodigoSegundaOpcao}");
            Console.WriteLine($"Média: {candidato.CalcularMedia()}");
        }


        //Logica de seleção dos Candidatos
        foreach (Candidato candidato in candidatos.ObterElementos())
        {
            Curso curso1 = cursos[candidato.CodigoPrimeiraOpcao];
            Curso curso2 = cursos[candidato.CodigoSegundaOpcao];



            if (curso1.NumSelecionados() < curso1.QuantidadeDeVagas)
            {
                curso1.AdicionarSelecionado(candidato);
                if (curso2.NumSelecionados() > 0)
                {
                    curso2.RemoverSelecionado(candidato);
                }
            }
            else
            {
                if (curso2.NumSelecionados() < curso2.QuantidadeDeVagas)
                {
                    curso2.AdicionarSelecionado(candidato);
                    curso1.AdicionarFilaEspera(candidato);
                }
                else
                {
                    curso1.AdicionarFilaEspera(candidato);
                    curso2.AdicionarFilaEspera(candidato);
                }
            }
        }


        Console.WriteLine("-----------------------------");
        Console.WriteLine("Informações dos Cursos Depois da Seleção dos Candidatos:");
        foreach (Curso curso in cursos.Values)
        {
            Console.WriteLine("\n Curso:");
            Console.WriteLine($"Código: {curso.CodigoDoCurso}, Nome: {curso.NomeDoCurso},Nota de Corte: {curso.CalcularNotaCorte()} , Vagas Disponíveis: {curso.QuantidadeDeVagas}");
            Console.WriteLine("Candidatos Selecionados:");


            Console.WriteLine("Candidatos Selecionados:");
            Candidato[] candidatosSelecionados = curso.ArrayCandidatos();
            for (int i = 0; i < candidatosSelecionados.Length; i++)
            {
                if (candidatosSelecionados[i] != null)
                {
                    Console.WriteLine($"{candidatosSelecionados[i].Nome} - {candidatosSelecionados[i].CalcularMedia()}");
                }
            }

            Console.WriteLine("Fila de Espera:");
            Candidato[] filaEspera = curso.ArrayFilaEspera();
            for (int i = 0; i < filaEspera.Length; i++)
            {
                if (filaEspera[i] != null)
                {
                    Console.WriteLine($"{filaEspera[i].Nome} - {filaEspera[i].CalcularMedia()}");
                }
            }
        }
        Console.ReadKey();
    }


    static void LeituraArquivo(out Dictionary<int, Curso> cursos, out Lista candidatos) // Método que irá ler o arquivo .txt e criar os objetos Candidatos/Cursos referentes
    {


        String[] linhas = File.ReadAllLines("arquivo.txt", Encoding.UTF8); // Leitura do Arquivo

        String[] dadosNM = linhas[0].Split(';'); // Lendo o número de cursos (N) e de candidatos (M)
        int N = int.Parse(dadosNM[0]); // Número de Cursos
        int M = int.Parse(dadosNM[1]); // Número de Candidatos 

        cursos = new Dictionary<int, Curso>();
        candidatos = new Lista(M);

        for (int i = 1; i <= N; i++) // Lendo as informações dos cursos ; O loop roda com limite do número de cursos (N) que estão no arquivo .txt 
        {
            String[] dadosCurso = linhas[i].Split(';');

            int CodigoCurso = int.Parse(dadosCurso[0]);
            String NomeCurso = dadosCurso[1];
            int QuantidadeDeVagas = int.Parse(dadosCurso[2]);

            Curso curso = new Curso(CodigoCurso, NomeCurso, QuantidadeDeVagas);
            cursos.Add(CodigoCurso, curso);
        }

        for (int i = N + 1; i <= N + M; i++) // Lendo as informações dos candidatos ; O loop roda com limite do número de candidatos (M) que estão no arquivo .txt 
        {
            String[] dadosCandidato = linhas[i].Split(';');
            String Nome = dadosCandidato[0];
            double NotaRedacao = double.Parse(dadosCandidato[1]);
            double NotaMatematica = double.Parse(dadosCandidato[2]);
            double NotaLinguagens = double.Parse(dadosCandidato[3]);
            int CodigoPrimeiraOpcaoCurso = int.Parse(dadosCandidato[4]);
            int CodigoSegundaOpcaoCurso = int.Parse(dadosCandidato[5]);

            Candidato candidato = new Candidato(Nome, NotaRedacao, NotaMatematica, NotaLinguagens, CodigoPrimeiraOpcaoCurso, CodigoSegundaOpcaoCurso);
            candidatos.InserirFim(candidato);

        }
    }

}

