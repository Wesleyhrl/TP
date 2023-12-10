namespace TP
{
    using System;

    public class Fila
    {
        private Celula primeiro, ultimo;
        public Fila()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }
        public void Inserir(Candidato x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }
        public Candidato Remover()
        {
            if (primeiro == ultimo)
                throw new Exception("Pilha vazia");
            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            Candidato elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }
        public bool RemoverEspecifico(string nome)
        {
            Celula anterior = primeiro;
            Celula atual = primeiro.Prox;

            while (atual != null)
            {
                if (atual.Elemento.Nome.Equals(nome))
                {
                    anterior.Prox = atual.Prox;
                    atual.Prox = null;
                    return true;
                }

                anterior = atual;
                atual = atual.Prox;
            }

            return false;
        }
        public Candidato[] ObterElementos()
        {
            int tamanho = Tamanho();
            Candidato[] elementos = new Candidato[tamanho];
            int index = 0;

            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                elementos[index++] = i.Elemento;
            }

            return elementos;
        }

        private int Tamanho()
        {
            int tamanho = 0;
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                tamanho++;
            }
            return tamanho;
        }
    }

}
