using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploDeControleDeThreads
{
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

            await Task.WhenAll(tasks);
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
