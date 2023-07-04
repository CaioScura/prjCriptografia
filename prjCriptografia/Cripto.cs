using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace prjCriptografia
{
    public class Cripto
    {
        const string chave = "12345";

        public static string criptografar(string texto)
        {
            byte[] Results;

            // gerar o HASH
            UTF8Encoding UTF8 = new UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(chave));

            // criptografar o texto ....
            TripleDESCryptoServiceProvider algoritmo = new TripleDESCryptoServiceProvider();
            algoritmo.Key = TDESKey;
            algoritmo.Mode = CipherMode.ECB;
            algoritmo.Padding = PaddingMode.PKCS7;

            byte[] DataToEncrpty = UTF8.GetBytes(texto);

            try
            {
                ICryptoTransform encriptador = algoritmo.CreateEncryptor();
                Results = encriptador.TransformFinalBlock(DataToEncrpty, 0,
                    DataToEncrpty.Length);
                return Convert.ToBase64String(Results);
            }

            catch (Exception Erro)
            {
                algoritmo.Clear();
                HashProvider.Clear();
                Console.WriteLine("Erro: {0}", Erro.Message);
            }

            return "";
        }


        public static string descriptografar(string texto)
        {
            byte[] Results;

            // gerar o HASH
            UTF8Encoding UTF8 = new UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(chave));
            TripleDESCryptoServiceProvider algoritmo = new TripleDESCryptoServiceProvider();

            algoritmo.Key = TDESKey;
            algoritmo.Mode = CipherMode.ECB;
            algoritmo.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrpty = Convert.FromBase64String(texto);

            try
            {
                ICryptoTransform decriptador = algoritmo.CreateDecryptor();
                Results = decriptador.TransformFinalBlock(DataToDecrpty, 0,
                    DataToDecrpty.Length);

                return UTF8.GetString(Results);
            }

            catch (Exception Erro)
            {
                algoritmo.Clear();
                HashProvider.Clear();
                Console.WriteLine("Erro: {0}", Erro.Message);
            }

            return "";
        }
    }
}
