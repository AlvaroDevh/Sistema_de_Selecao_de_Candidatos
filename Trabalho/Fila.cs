using System;

namespace Trabalho {
    public class Fila {
        private Candidato[] array;
        private int primeiro;
        private int ultimo;

        public Fila() {
            array = new Candidato[11];
            primeiro = ultimo = 0;
        }

        public void Inserir(Candidato x) {
            if (Cheia()) {
                return;
            }
            array[ultimo] = x;
            ultimo = (ultimo + 1) % array.Length;
        }

        public bool Cheia() {
            return ((ultimo + 1) % array.Length) == primeiro;
        }
   

        public void Print(StreamWriter arqSaida) {
            int i = primeiro;
            while (i != ultimo) {
                arqSaida.WriteLine($"{array[i].NomeCanditato} {array[i].Media:F2} {array[i].Redacao} {array[i].Matematica} {array[i].Portugues}");
                i = (i + 1) % array.Length;
            }
        }
    }
}