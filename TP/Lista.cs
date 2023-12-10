namespace TP
{
    using System;
    public class Lista
    {
        private Candidato[] array;
        private int n;


        public Lista(int tamanho)
        {
            array = new Candidato[tamanho];
            n = 0;
        }

        public int Quantidade()
        {
            return n;
        }

        public void InserirInicio(Candidato x)
        {
            if (n >= array.Length)
            {
                throw new Exception("Erro ao inserir!");
            }
            for (int i = n; i > 0; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = x;
            n++;
        }

        public void InserirFim(Candidato x)
        {
            if (n >= array.Length)
            {
                throw new Exception("Erro ao inserir!");
            }
            array[n] = x;
            n++;
        }

        public void Inserir(Candidato x, int pos)
        {
            if (n >= array.Length || pos < 0 || pos > n)
            {
                throw new Exception("Erro ao inserir!");
            }
            for (int i = n; i > pos; i--)
            {
                array[i] = array[i - 1];
            }
            array[pos] = x;
            n++;
        }

        public Candidato RemoverInicio()
        {
            if (n == 0)
            {
                throw new Exception("Erro ao remover!");
            }
            Candidato resp = array[0];
            n--;
            for (int i = 0; i < n; i++)
            {
                array[i] = array[i + 1];
            }
            return resp;
        }

        public Candidato RemoverFim()
        {
            if (n == 0)
            {
                throw new Exception("Erro ao remover!");
            }
            n--;
            return array[n];
        }

        public bool RemoverItem(string nome)
        {
            if (n == 0)
                throw new Exception("Erro!");

            for (int i = 0; i < n; i++)
            {
                if (array[i].Nome == nome)
                {
                    Remover(i);
                    return true;
                }
            }
            return false;
        }

        public Candidato Remover(int pos)
        {
            if (n == 0 || pos < 0 || pos >= n)
            {
                throw new Exception("Erro ao remover!");
            }
            Candidato resp = array[pos];
            n--;
            for (int i = pos; i < n; i++)
            {
                array[i] = array[i + 1];
            }
            return resp;
        }

        public Candidato[] ObterElementos()
        {
            return array;
        }

        public void OrdenarPorMedia()
        {
            OrdenarDecrescente(array, 0, n - 1);
        }

        private void OrdenarDecrescente(Candidato[] array, int esq, int dir)
        {
            void Trocar(int i, int j)
            {
                Candidato temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            int i = esq, j = dir;
            double pivoMedia = array[(esq + dir) / 2].CalcularMedia();
            double pivoRedacao = array[(esq + dir) / 2].NotaRedacao;

            while (i <= j)
            {
                while (array[i].CalcularMedia() > pivoMedia || (array[i].CalcularMedia() == pivoMedia && array[i].NotaRedacao > pivoRedacao))
                    i++;

                while (array[j].CalcularMedia() < pivoMedia || (array[j].CalcularMedia() == pivoMedia && array[j].NotaRedacao < pivoRedacao))
                    j--;


                if (i <= j)
                {
                    Trocar(i, j);
                    i++;
                    j--;
                }
            }

            if (esq < j)
                OrdenarDecrescente(array, esq, j);

            if (i < dir)
                OrdenarDecrescente(array, i, dir);
        }

    }

}
