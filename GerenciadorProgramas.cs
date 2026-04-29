using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SimuladorMicroondas
{
    public class GerenciadorPrograma
    {
            private static List<CadastroPrograma> _programasCustomizados = new List<CadastroPrograma>();
            private List<ProgramaPreDefinido> _programasPreDefinidos = ProgramaPreDefinido.ObterProgramas();

            public GerenciadorPrograma()
            {
                CarregarPrograma();
            }

            public List<CadastroPrograma> ObterProgramasCustomizados()
            {
                return _programasCustomizados;
            }

            public void AdicionarPrograma(CadastroPrograma novoPrograma)
            {
                foreach (CadastroPrograma programa in _programasCustomizados)
                {
                    if (programa.Caractere == novoPrograma.Caractere)
                    {
                        throw new ArgumentException("Este caractere já está sendo usado por um programa customizado!");
                    }
                }

                foreach (ProgramaPreDefinido programa in _programasPreDefinidos)
                {
                    if (programa.Caractere == novoPrograma.Caractere)
                    {
                        throw new ArgumentException("Este caractere já está sendo usado por um programa pré-definido!");
                    }
                }
                
                _programasCustomizados.Add(novoPrograma);
                SalvarPrograma();
            }

        private void SalvarPrograma()
        {
            string textoToJson = JsonSerializer.Serialize(_programasCustomizados);
            File.WriteAllText("programas.json", textoToJson);
        }

        private void CarregarPrograma()
        {
            if (File.Exists("programas.json"))
            {
                string textoToMicroondas = File.ReadAllText("programas.json");
                _programasCustomizados = JsonSerializer.Deserialize<List<CadastroPrograma>>(textoToMicroondas);
            }
        }

    }

}