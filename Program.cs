using System.Diagnostics;

namespace ProgramacaoDinamica;

public class Program
{
    private static bool isDebugging;
    private static ulong iteracoes;

    public static void Main(string[] args)
    {
        isDebugging = "--debug".Equals(args[0], StringComparison.OrdinalIgnoreCase);
        int parametro = int.Parse(args.Length > 1 ? args[1] : args[0]);
        
        // Testando o Recursivo
        iteracoes = 0;
        var temporizador = Stopwatch.StartNew();
        int resultado = FiboRec(parametro);
        temporizador.Stop();
        Console.WriteLine($"Recursivo - Resultado: {resultado}\nIterações: {iteracoes}, Tempo: {temporizador.Elapsed.TotalSeconds:F5}s\n");

        // Testando o Iterativo
        iteracoes = 0;
        temporizador.Restart();
        resultado = Fibo(parametro);
        temporizador.Stop();
        Console.WriteLine($"Iterativo - Resultado: {resultado}\nIterações: {iteracoes}, Tempo: {temporizador.Elapsed.TotalSeconds:F5}s");

        // Testando o MEMOIZED-FIBO & LOOKUP-FIBO
        iteracoes = 0;
        temporizador.Restart();
        resultado = MemorizedFibo(parametro);
        temporizador.Stop();
        Console.WriteLine($"MEMOIZED-FIBO & LOOKUP-FIBO - Resultado: {resultado}\nIterações: {iteracoes}, Tempo: {temporizador.Elapsed.TotalSeconds:F5}s");

    }


    private static int FiboRec(int num)
    {
        iteracoes++;
        
        if(num <= 1)
            return num;
        

        return FiboRec(num - 1) + FiboRec(num - 2);
    }

    private static int Fibo(int num)
    {
        if(num < 1)
            return 0;

        if(num == 1)
            return 1;

        int[] array = new int[num];

        array[0] = array[1] = 1;

        for(int i = 2; i < array.Length; i++)
        {
            iteracoes++;
            array[i] = array[i - 1] + array[i - 2];
        }

        if (isDebugging)
        {
            Console.WriteLine(string.Join(',',array));
        }

        return array[num - 1];
    }
    
    private static int MemorizedFibo(int[] array, int num)
    {
        
    }
    
}