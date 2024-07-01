using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho {
    public class Candidato {

        private string nomeCanditato;

        public string NomeCanditato {
            get { return nomeCanditato; }
            set { nomeCanditato = value; }
        }

        private double redacao;

        public double Redacao {
            get { return redacao; }
            set { redacao = value; }
        }

        private double matematica;

        public double Matematica {
            get { return matematica; }
            set { matematica = value; }
        }

        private double portugues;

        public double Portugues {
            get { return portugues; }
            set { portugues = value; }
        }


        private int opcaao01;

        public int Opcaao01 {
            get { return opcaao01; }
            set { opcaao01 = value; }
        }

        private int opcaao02;

        public int Opcaao02 {
            get { return opcaao02; }
            set { opcaao02 = value; }
        }


        private double media;

        public double Media {
            get { return media; }
            set { media = value; }
        }



        public Candidato() { }

        public Candidato(string nomeCanditato, double redacao, double matematica, double portugues, int opcaao01, int opcaao02) {
            NomeCanditato = nomeCanditato;
            Redacao = redacao;
            Matematica = matematica;
            Portugues = portugues;
            Opcaao01 = opcaao01;
            Opcaao02 = opcaao02;
            Media = CalcularMedia(redacao, portugues, matematica);
        }

        public double CalcularMedia(double n1, double n2, double n3) {
            return (Redacao + Matematica + Portugues) / 3;
        }
        public override string ToString() {
            return $"{NomeCanditato} , {Redacao} , {Matematica} , {Portugues}, {Opcaao01}, {Opcaao02}";
        }
    }
    
}
