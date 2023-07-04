using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCriptografia
{
    class Program
    {
        public static void Main(string[] args)
        {
            string Texto = "";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("----- TESTE DE CRIPTOGRAFIA DE DADOS DA API --------");
            Console.Write("DIGITE O TEXTO A SER CRIPTOGRAFADO: ");

            Texto = Console.ReadLine();

            string Saida = Cripto.criptografar(Texto);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nTEXTO CRIPTOGRAFADO:{0}", Saida);
            Console.WriteLine("\n----- TESTE DE DESCRIPTOGRAFIA DE DADOS DA API --------");

            string Saida2 = Cripto.descriptografar(Saida);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("TEXTO DECRIPTOGRAFADO:{0}", Saida2);
            Console.ReadKey();
        }
    }
}
