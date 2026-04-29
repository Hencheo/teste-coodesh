using System;
using System.Security.Cryptography;
using System.Text;

namespace MicroondasWeb 
{
    public static class Criptografia
    {
        private static readonly byte [] ChaveAES = Encoding.UTF8.GetBytes("61436b628b007c5323b69014dd7d8518");

        private static readonly byte [] IvAES = Encoding.UTF8.GetBytes("61436b628b007c53");

        
        public static string GerarHash(string textoOriginal)
        {
            using var criptografar = SHA256.Create();

            byte [] textoOriginalEmByte = Encoding.UTF8.GetBytes(textoOriginal);

            byte [] hashAplicado = criptografar.ComputeHash(textoOriginalEmByte);  
            
            var hashAplicadoEmHexadecimal = new StringBuilder();

            foreach (byte i in hashAplicado)
            {
                hashAplicadoEmHexadecimal.Append(i.ToString("x2"));
            }

            return hashAplicadoEmHexadecimal.ToString();
        }


        public static string CriptografarComAES(string texto)
        {
            using var maquinaAes = Aes.Create();
            maquinaAes.Key = ChaveAES;
            maquinaAes.IV = IvAES;

            ICryptoTransform encriptador = maquinaAes.CreateEncryptor(maquinaAes.Key, maquinaAes.IV);

            using var memoria = new MemoryStream();
            using var cripto = new CryptoStream(memoria, encriptador, CryptoStreamMode.Write);
            using (var escritor = new StreamWriter(cripto))
            {
                escritor.Write(texto);
            }

            return Convert.ToBase64String(memoria.ToArray());
        }

        
        public static string DesCriptografarComAES(string textoCriptografado)
        {
            using var maquinaAes = Aes.Create();
            maquinaAes.Key = ChaveAES;
            maquinaAes.IV = IvAES;

            ICryptoTransform decriptador = maquinaAes.CreateDecryptor(maquinaAes.Key, maquinaAes.IV);

            using var memoria = new MemoryStream(Convert.FromBase64String(textoCriptografado));
            using var cripto = new CryptoStream(memoria, decriptador, CryptoStreamMode.Read);
            using (var leitor = new StreamReader(cripto))
            {
                return leitor.ReadToEnd();
            }
        }
    }
}