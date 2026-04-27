using Xunit;
using SimuladorMicroondas;

namespace microodas.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TesteConfiguracaoValida()
        {
            var micro = new Microondas();
            bool result = micro.Configurar(60, 5);
            
            Assert.True(result);
            Assert.Equal(60, micro.Tempo);
            Assert.Equal(5, micro.Potencia);
        }

        [Fact]
        public void TesteConfiguracaoInvalidaTempo()
        {
            var micro = new Microondas();
            bool result = micro.Configurar(150, 5);
            
            Assert.False(result);
            Assert.NotEmpty(micro.MensagemErro);
        }

        [Fact]
        public void TesteInicioRapido()
        {
            var micro = new Microondas();
            micro.Iniciar(); // Sem configurar nada
            
            Assert.Equal(30, micro.Tempo);
            Assert.Equal(10, micro.Potencia);
            Assert.True(micro.EstaLigado);
        }

        [Fact]
        public void TestePausaECancela()
        {
            var micro = new Microondas();
            micro.Configurar(30, 10);
            micro.Iniciar();
            
            micro.Parar(); // Pausa
            Assert.True(micro.EstaPausado);
            
            micro.Parar(); // Cancela
            Assert.False(micro.EstaLigado);
            Assert.Equal(0, micro.Tempo);
        }
    }
}
