using System;

namespace SimuladorMicroondas
{
    public class CadastroPrograma
    {
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public char Caractere { get; set; }
        public string Instrucoes { get; set; }

        public CadastroPrograma() { }
        
        public CadastroPrograma(string nome, string alimento, int tempo, int potencia, char caractere, string instrucoes)
        {
            if (caractere == '.')
            {
                throw new ArgumentException("O caractere '.' é o padrão e não pode ser usado. Tente outro.");
            }

            Nome = nome;
            Alimento = alimento;
            Tempo = tempo;
            Potencia = potencia;
            Caractere = caractere;
            Instrucoes = instrucoes;
        }
    }
}