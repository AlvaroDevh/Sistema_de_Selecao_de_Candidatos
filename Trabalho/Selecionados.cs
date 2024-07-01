using System;
using System.Collections.Generic;

namespace Trabalho {
    public class Selecionados {
        public List<Candidato> selecionados;
        public Fila filaEspera;
        public int qtdVagas;

        public Selecionados(int vagas) {
            selecionados = new List<Candidato>();
            filaEspera = new Fila();
            qtdVagas = vagas;
        }

        public void Inserir(Candidato candidato) {
            if (selecionados.Count < qtdVagas) {
                selecionados.Add(candidato);
            }
            else {
                filaEspera.Inserir(candidato);
            }
        }

        public bool FilaEsperaCheia() {
            return filaEspera.Cheia();
        }
        public double NotaUltimoCandidato() {
            if (selecionados.Count == 0) {
                return 0;
            }
            return selecionados[selecionados.Count - 1].Media; 
        }
     
    }
}
