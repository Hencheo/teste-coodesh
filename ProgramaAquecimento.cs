using System.Collections.Generic;

namespace SimuladorMicroondas
{
    public class ProgramaPreDefinido
    {
        private string _nome;
        private int _tempo;
        private int _potencia;
        private char _caractere;
        private string _instrucoes;

        public string Nome => _nome;
        public int Tempo => _tempo;
        public int Potencia => _potencia;
        public char Caractere => _caractere;
        public string Instrucoes => _instrucoes;

        public ProgramaPreDefinido(string nome, int tempo, int potencia, char caractere, string instrucoes)
        {
            _nome = nome;
            _tempo = tempo;
            _potencia = potencia;
            _caractere = caractere;
            _instrucoes = instrucoes;
        }

        public static List <ProgramaPreDefinido> ObterProgramas()
        {
            var lista = new List <ProgramaPreDefinido>();

            lista.Add(new ProgramaPreDefinido("Pipoca", 3 * 60, 7, '*', "Observar o barulho de estouros do milho. Se houver um intervalo de mais de 10 segundo entre um e outro, interrompa o aquecimento."));

            lista.Add(new ProgramaPreDefinido("Leite", 5 * 60, 5, 'o', "Cuidado com o aquecimento de líquidos! O choque térmico, aliado ao movimento do recipiente pode causar fervura imediata, causando risco de queimadura"));

            lista.Add(new ProgramaPreDefinido("Carne (pedaços/fatias)", 14 * 60, 4, 'X',"Interrompa o processo de aquecimento na metade. Vire o conteúdo com a parte debaixo agora voltada para cima, para um descongelamento uniforme."));

            lista.Add(new ProgramaPreDefinido("Frango (Qualquer corte)", 8 * 60, 7, '#', "Interrompa o processo de aquecimento na metade. Vire o conteúdo com a parte debaixo agora voltada para cima, para um descongelamento uniforme."));

            lista.Add(new ProgramaPreDefinido("Feijão congelado", 8 * 60, 9, 'O', "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente, pois o mesmo pode perder resistência em altas temperaturas"));

            return lista;
        }
    }
}