using System;

namespace SimuladorMicroondas
{
    // classe para microondas
    public class Microondas
    {
        public int tempo; // tempo em segundos
        public int pot = 10;
        public bool taLigado; 
        public bool pausado;
        public string tela = ""; // Isso é pra guardar os pontinhos que aparecem na tela

        // Faz a validação aqui mesmo pra não deixar colocar tempo errado
        public void Configurar(int seg, int p)
        {
            if (seg < 1 || seg > 120)
            {
                Console.WriteLine("Erro: Tempo tem que ser entre 1 e 120!!");
                return;
            }
            
            if (p < 1 || p > 10)
            {
                Console.WriteLine("Erro: Potencia entre 1 e 10!");
                return;
            }

            tempo = seg;
            pot = p;
            tela = "";
            pausado = false;
            taLigado = false;
        }

        // Iniciar fica assim porque ele serve tanto para começar quanto para somar 30 segundos
        public void Iniciar()
        {
            if (taLigado == false)
            {
                if (tempo == 0)
                {
                    tempo = 30;
                    pot = 10;
                }
                taLigado = true;
                pausado = false;
            }
            else
            {
                // soma 30 seg
                tempo = tempo + 30;
                if (tempo > 120) tempo = 120;
            }
        }

        // esse método é para os dois casos (pausa e cancela), para não complicar
        public void Parar()
        {
            if (taLigado == true && pausado == false)
            {
                pausado = true;
            }
            else
            {
                taLigado = false;
                pausado = false;
                tempo = 0;
                tela = "";
            }
        }

        // Aqui é a mágica de diminuir o tempo e colocar os pontos
        public void Atualizar()
        {
            if (taLigado && !pausado && tempo > 0)
            {
                for (int i = 0; i < pot; i++)
                {
                    tela = tela + ".";
                }
                
                tempo = tempo - 1;

                if (tempo == 0)
                {
                    taLigado = false;
                    tela = tela + " Aquecimento concluído";
                }
            }
        }
    }
}
