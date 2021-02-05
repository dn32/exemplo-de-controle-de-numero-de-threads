using System;
using System.Collections.Generic;
using System.Threading;
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
    public static class Semafaros
    {
        const int NUMERO_DE_CADASTROS_SIMULTANEOS_PERMITIDOS = 3;

        public static SemaphoreSlim FluxoDeCadastrosSimultaneos { get; set; } = new SemaphoreSlim(NUMERO_DE_CADASTROS_SIMULTANEOS_PERMITIDOS);
    }

    public static class ClasseDaOperacao
    {
        public static async Task Iniciar(List<int> Valores)
        {
            var tasks = new List<Task>();
            foreach (var valor in Valores)
            {
                await Semafaros.FluxoDeCadastrosSimultaneos.WaitAsync();
                var task = OperacaoAsync(valor);
                tasks.Add(task);
            }

            await Task.WhenAny(tasks);
        }

        private static async Task OperacaoAsync(int operacao)
        {
            try
            {
                Console.WriteLine($"Iniciando operação: {operacao}");
                await Task.Delay(1000);
                Console.WriteLine($"Finalizando operação: {operacao}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Semafaros.FluxoDeCadastrosSimultaneos.Release();
            }
        }
    }
}
