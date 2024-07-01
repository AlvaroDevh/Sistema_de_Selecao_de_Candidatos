using System;

namespace Trabalho {
    public class Ordenar {
        public void Quicksort(Candidato[] array, int esq, int dir) {
            int i = esq, j = dir;
            Candidato pivo = array[(esq + dir) / 2];
            while (i <= j) {
                while (Desempate(array[i], pivo) > 0) {
                    i++;
                }
                while (Desempate(array[j], pivo) < 0) {
                    j--;
                }
                if (i <= j) {
                    Trocar(array, i, j);
                    i++;
                    j--;
                }
            }
            if (esq < j) {
                Quicksort(array, esq, j);
            }
            if (i < dir) {
                Quicksort(array, i, dir);
            }
        }

        private void Trocar(Candidato[] array, int i, int j) {
            Candidato temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
       
        private int Desempate(Candidato a, Candidato b) {
            if (a.Media != b.Media) {
                return a.Media.CompareTo(b.Media);
            }
            if (a.Redacao != b.Redacao) {
                return a.Redacao.CompareTo(b.Redacao);
            }
            if (a.Matematica != b.Matematica) {
                return a.Matematica.CompareTo(b.Matematica);
            }
            return a.Portugues.CompareTo(b.Portugues);
        }
    }
}
