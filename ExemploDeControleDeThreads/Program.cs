using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploDeControleDeThreads
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var lista = new List<int>();
            for (int i = 0; i < 100; i++)
                lista.Add(i + 1);

            await ClasseDaOperacao.Iniciar(lista);
        }
    }
}
