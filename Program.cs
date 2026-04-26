using System;
using System.Threading;

namespace SimuladorMicroondas
{
    class Program
    {
        static Microondas micro = new Microondas();

        static void Main(string[] args)
        {
            // Inicio d loop pra ficar rodando até eu mandar sair
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MICROONDAS BENNER ===");
                
                // formatar o tempo de forma simples
                int m = micro.tempo / 60;
                int s = micro.tempo % 60;
                string tempoFormatado = m + ":" + (s < 10 ? "0" + s : s.ToString());
                
                Console.WriteLine("Tempo: " + tempoFormatado);
                Console.WriteLine("Potencia: " + micro.pot);
                Console.WriteLine("Progresso: " + micro.tela);
                Console.WriteLine("======================");
                
                // Se o microondas estiver ligado, ele entra nesse modo de esperar a tecla
                if (micro.taLigado == true && micro.pausado == false)
                {
                    Console.WriteLine("Esquentando... (Aperte P para pausar)");
                    
                    // Eu preferi usar o KeyAvailable pr o programa não ficar travado esperando o ReadLine
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo tecla = Console.ReadKey(true);
                        if (tecla.Key == ConsoleKey.P) micro.Parar(); // Tudo na mesma linha pra ficar mais "curto"
                        
                        if (tecla.Key == ConsoleKey.D2 || tecla.Key == ConsoleKey.NumPad2)
                        {
                            micro.Iniciar();
                        }
                    }
                    else
                    {
                        micro.Atualizar();
                        Thread.Sleep(1000);
                        // Console.WriteLine("debug: tempo agora e " + micro.tempo); // esqueci de tirar
                    }
                }
                else
                {
                    // Aqui é o menu que eu decidi montar para o usuário escolher o que fazer
                    Console.WriteLine("1 - Configurar");
                    Console.WriteLine("2 - Iniciar");
                    Console.WriteLine("3 - Pausar/Cancelar");
                    Console.WriteLine("0 - Sair");
                    Console.Write("Escolha: ");

                    string opcao = Console.ReadLine();

                    if (opcao == "1")
                    {
                        // ler os dados assim um por um pra ficar mais fácil
                        Console.Write("Tempo: ");
                        int t = int.Parse(Console.ReadLine());
                        Console.Write("Potencia (1-10): ");
                        string pStr = Console.ReadLine();
                        int p = 10;
                        if (pStr != "") p = int.Parse(pStr); // se for vazio, vira 10

                        micro.Configurar(t, p);
                    }
                    else if (opcao == "2")
                    {
                        micro.Iniciar();
                    }
                    else if (opcao == "3")
                    {
                        micro.Parar();
                    }
                    else if (opcao == "0")
                    {
                        break;
                    }
                }
            }
        }
    }
}
