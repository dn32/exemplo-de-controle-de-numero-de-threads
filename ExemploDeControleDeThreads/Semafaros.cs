using System.Threading;

namespace ExemploDeControleDeThreads
{
    public static class Semafaros
    {
        const int NUMERO_DE_CADASTROS_SIMULTANEOS_PERMITIDOS = 3;

        public static SemaphoreSlim FluxoDeCadastrosSimultaneos { get; set; } = new SemaphoreSlim(NUMERO_DE_CADASTROS_SIMULTANEOS_PERMITIDOS);
    }
}
