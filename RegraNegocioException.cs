using System;

namespace SimuladorMicroondas{
    public class RegraNegocioException : Exception
    {
        public RegraNegocioException() : base() {}

        public RegraNegocioException(string mensagem) : base(mensagem){}

        public RegraNegocioException(string mensagem, Exception innerException) : base(mensagem, innerException) {}
        
    }
}