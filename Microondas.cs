using System;

namespace SimuladorMicroondas
{
    public class Microondas
    {
        private int _tempo;
        private int _potencia = 10;
        private bool _estaLigado;
        private bool _estaPausado;
        private string _tela = "";
        private string _mensagemErro = "";
        private char _caractereAtual = '.';
        private bool _ehProgramaPreDefinido = false;

        public int Tempo => _tempo;
        public int Potencia => _potencia;
        public bool EstaLigado => _estaLigado;
        public bool EstaPausado => _estaPausado;
        public string Tela => _tela;
        public string MensagemErro => _mensagemErro;

        public bool PodeIniciar => !_estaLigado || _estaPausado;

        public bool Configurar(int segundos, int p, char caractere = '.', bool ehPrograma = false)
        {
            _mensagemErro = "";

            if (!ehPrograma && (segundos < 1 || segundos > 120))
            {
                _mensagemErro = "Erro: O tempo deve estar entre 1 e 120 segundos!";
                return false;
            }
            
            if (segundos < 1 || segundos > 600)
            {
                _mensagemErro = "Erro: Tempo inválido!";
                return false;
            }

            if (p < 1 || p > 10)
            {
                _mensagemErro = "Erro: A potência deve ser de 1 a 10!";
                return false;
            }

            _tempo = segundos;
            _potencia = p;
            _caractereAtual = caractere;
            _ehProgramaPreDefinido = ehPrograma;
            _tela = "";
            _estaPausado = false;
            _estaLigado = false;
            return true;
        }

        public void Iniciar()
        {
            _mensagemErro = "";
            if (!_estaLigado)
            {
                if (_tempo == 0)
                {
                    _tempo = 30;
                    _potencia = 10;
                    _caractereAtual = '.';
                    _ehProgramaPreDefinido = false;
                }
                _estaLigado = true;
                _estaPausado = false;
            }
            else
            {
                if (!_ehProgramaPreDefinido)
                {
                    _tempo += 30;
                    if (_tempo > 120) 
                    {
                        _tempo = 120;
                    }
                }
            }
        }

        public void Parar()
        {
            if (_estaLigado && !_estaPausado)
            {
                _estaPausado = true;
            }
            else
            {
                _estaLigado = false;
                _estaPausado = false;
                _tempo = 0;
                _tela = "";
                _mensagemErro = "";
                _ehProgramaPreDefinido = false;
            }
        }

        public void Atualizar()
        {
            if (_estaLigado && !_estaPausado && _tempo > 0)
            {
                for (int i = 0; i < _potencia; i++)
                {
                    _tela += _caractereAtual;
                }
                
                _tempo--;

                if (_tempo == 0)
                {
                    _estaLigado = false;
                    _tela += " Aquecimento concluído";
                }
            }
        }

        public void AdicionarDigito(int digito, ref int inputTempo)
        {
            string s = inputTempo.ToString();
            if (s == "0") s = "";
            s += digito.ToString();
            
            if (int.TryParse(s, out int result))
            {
                inputTempo = result;
            }
        }
    }
}
