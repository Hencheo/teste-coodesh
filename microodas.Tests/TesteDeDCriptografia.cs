using Xunit;
using MicroondasWeb;

namespace Microodas.Tests
{
    public class TesteCriptografia
    {
        [Fact]
        public void TesteCriptografiaIdaeVolda()
        {
            string textoOriginal = "minhaSenhaSecreta123@";
            
            string textoCriptografado = Criptografia.CriptografarComAES(textoOriginal);

            string textoFinalDescriptografado = Criptografia.DesCriptografarComAES(textoCriptografado);

            Assert.NotEqual(textoOriginal, textoCriptografado);
            Assert.Equal(textoOriginal, textoFinalDescriptografado);
        }
    }

}