using System;
using System.IO;
using System.Text;
using Trabalho;

namespace Program {

    public class Trabalho {

        public static void Main(string[] args) {


            List<Candidato> list = new List<Candidato>();
            Dictionary<int, string> dicionarioCursos = new Dictionary<int, string>();
            Ordenar ordenar = new Ordenar();
            Candidato[] candidato;
            Dictionary<int, Selecionados> dicionarioSelecionados = new Dictionary<int, Selecionados>();


            string[] dados;
            string linhas, nomeCurso, nomeCandidato;
            int qtdCursos, qtdCandidatos, codigoCurso, qtdVagas, opcaoCurso01, opcaoCurso02;
            double redacao, matematica, portugues, media;

            try {
                StreamReader arq = new StreamReader(@"C:\Users\joaoa\OneDrive\Documentos\AED\TrabalhoAED\teste.txt", Encoding.UTF8);
                {
                    linhas = arq.ReadLine();
                    dados = linhas.Split(';'); 

                    qtdCursos = int.Parse(dados[0]);
                    qtdCandidatos = int.Parse(dados[1]);

                    candidato = new Candidato[qtdCandidatos];

                    for (int i = 0; i < qtdCursos; i++) {
                        linhas = arq.ReadLine();
                        dados = linhas.Split(';');

                        codigoCurso = int.Parse(dados[0]);
                        nomeCurso = dados[1];
                        qtdVagas = int.Parse(dados[2]);

                        dicionarioCursos.Add(codigoCurso, nomeCurso);
                        dicionarioSelecionados.Add(codigoCurso, new Selecionados(qtdVagas));


                    }

                    for (int i = 0; i < qtdCandidatos; i++) {
                        linhas = arq.ReadLine();
                        dados = linhas.Split(';');

                        nomeCandidato = dados[0];
                        redacao = double.Parse(dados[1]);
                        matematica = double.Parse(dados[2]);
                        portugues = double.Parse(dados[3]);
                        opcaoCurso01 = int.Parse(dados[4]);
                        opcaoCurso02 = int.Parse(dados[5]);

                        candidato[i] = new Candidato(nomeCandidato, redacao, matematica, portugues, opcaoCurso01, opcaoCurso02);
                        list.Add(candidato[i]);

                        media = candidato[i].CalcularMedia(redacao, matematica, portugues);

                    }
                    arq.Close();
                }
                ordenar.Quicksort(candidato, 0, candidato.Length - 1);


                foreach (var aluno in candidato) {
                    var opcacaoCurso01 = dicionarioSelecionados[aluno.Opcaao01];
                    var opcacaoCurso02 = dicionarioSelecionados[aluno.Opcaao02];


                    if (opcacaoCurso01.selecionados.Count < opcacaoCurso01.qtdVagas) {
                        opcacaoCurso01.Inserir(aluno);
                    }
                    else if (opcacaoCurso02.selecionados.Count < opcacaoCurso02.qtdVagas) {
                        opcacaoCurso02.Inserir(aluno); 
                        if (!opcacaoCurso01.FilaEsperaCheia()) {
                            opcacaoCurso01.filaEspera.Inserir(aluno);
                        }
                    }
                    else {
                        if (!opcacaoCurso01.FilaEsperaCheia()) {
                            opcacaoCurso01.filaEspera.Inserir(aluno);
                        }
                        if (!opcacaoCurso02.FilaEsperaCheia()) {
                            opcacaoCurso02.filaEspera.Inserir(aluno);
                        }
                    }
                }
              
               
                try {

                    using (StreamWriter arqSaida = new StreamWriter(@"C:\Users\joaoa\OneDrive\Documentos\AED\TrabalhoAED\saida.txt", false, Encoding.UTF8)) {
                        foreach (var curso in dicionarioCursos) {
                            arqSaida.WriteLine($"{curso.Value} {dicionarioSelecionados[curso.Key].NotaUltimoCandidato():F2}");
                            arqSaida.WriteLine("Selecionados:");

                            foreach (var cand in dicionarioSelecionados[curso.Key].selecionados) {
                                arqSaida.WriteLine($"{cand.NomeCanditato} {cand.Media:F5} {cand.Redacao} {cand.Matematica} {cand.Portugues}");
                            }

                            arqSaida.WriteLine("Fila de Espera:");
                            dicionarioSelecionados[curso.Key].filaEspera.Print(arqSaida);
                            arqSaida.WriteLine();
                        }
                    }


                }
                catch (Exception e) {
                    Console.WriteLine("Erro: " + e.Message);
                }
            }
            catch (Exception e) {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}

