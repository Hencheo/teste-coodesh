using System;

namespace SimuladorMicroondas
{
    // classe para microondas
    public class Microondas
    {
        public int tempo; // tempo em segundos
        public int potencia = 10;
        public bool estaLigado; 
        public bool estaPausado;
        public string tela = "";

        // Lambda simples (Expression-bodied property)
        public bool PodeIniciar => !estaLigado || estaPausado;

        public void Configurar(int segundos, int p)
        {
            if (segundos < 1 || segundos > 120)
            {
                Console.WriteLine("Erro: Tempo tem que ser entre 1 e 120!!");
                return;
            }
            
            if (p < 1 || p > 10)
            {
                Console.WriteLine("Erro: Potencia entre 1 e 10!");
                return;
            }

            tempo = segundos;
            potencia = p;
            tela = "";
            estaPausado = false;
            estaLigado = false;
        }

        public void Iniciar()
        {
            if (!estaLigado)
            {
                if (tempo == 0)
                {
                    tempo = 30;
                    potencia = 10;
                }
                estaLigado = true;
                estaPausado = false;
            }
            else
            {
                tempo += 30;
                if (tempo > 120) tempo = 120;
            }
        }

        public void Parar()
        {
            if (estaLigado && !estaPausado)
            {
                estaPausado = true;
            }
            else
            {
                estaLigado = false;
                estaPausado = false;
                tempo = 0;
                tela = "";
            }
        }

        public void Atualizar()
        {
            if (estaLigado && !estaPausado && tempo > 0)
            {
                for (int i = 0; i < potencia; i++)
                {
                    tela += ".";
                }
                
                tempo--;

                if (tempo == 0)
                {
                    estaLigado = false;
                    tela += " Aquecimento concluído";
                }
            }
        }
    }
}
