using System;
using System.Threading;

namespace SimuladorMicroondas
{
    class Program
    {
        static Microondas micro = new Microondas();

        static void Main(string[] args)
        {
            while (true)
            {
                ExibirStatus();
                
                if (micro.EstaLigado && !micro.EstaPausado)
                {
                    Console.WriteLine("Esquentando... (Aperte P para pausar)");
                    
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo tecla = Console.ReadKey(true);
                        if (tecla.Key == ConsoleKey.P) micro.Parar();
                        
                        if (tecla.Key == ConsoleKey.D2 || tecla.Key == ConsoleKey.NumPad2)
                        {
                            micro.Iniciar();
                        }
                    }
                    else
                    {
                        micro.Atualizar();
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("1 - Configurar");
                    Console.WriteLine("2 - Iniciar");
                    Console.WriteLine("3 - Pausar/Cancelar");
                    Console.WriteLine("0 - Sair");
                    Console.Write("Escolha: ");

                    string opcao = Console.ReadLine() ?? "";

                    if (opcao == "1")
                    {
                        Console.Write("Tempo: ");
                        if (int.TryParse(Console.ReadLine(), out int t))
                        {
                            Console.Write("Potencia (1-10): ");
                            string pStr = Console.ReadLine() ?? "";
                            int p = 10;
                            if (pStr != "") int.TryParse(pStr, out p);

                            if (!micro.Configurar(t, p))
                            {
                                Console.WriteLine(micro.MensagemErro);
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadKey();
                            }
                        }
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

        static void ExibirStatus()
        {
            Console.Clear();
            Console.WriteLine("=== MICROONDAS BENNER ===");
            
            int m = micro.Tempo / 60;
            int s = micro.Tempo % 60;
            
            Console.WriteLine($"Tempo: {m:D2}:{s:D2}");
            Console.WriteLine($"Potencia: {micro.Potencia}");
            Console.WriteLine($"Progresso: {micro.Tela}");
            if (!string.IsNullOrEmpty(micro.MensagemErro)) Console.WriteLine($"ERRO: {micro.MensagemErro}");
            Console.WriteLine("======================");
        }
    }
}
