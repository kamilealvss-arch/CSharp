using System;

namespace Rendimento
{
  class Program
  {
    static void Main(string[] args)
    {
        double p;
        double i;
        double f;
        double n;
        string tipoTempo;

        Console.WriteLine("Digite o valor que deseja invetir:");
        p = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite o valor do juros:");
        i = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Quer Calcular o tempo em meses ou anos? (meses/anos)");
        tipoTempo = Console.ReadLine()?.ToLower() ?? "";

        Console.WriteLine("Digite o valor do tempo (período):");
        n = Convert.ToDouble(Console.ReadLine());

         if (tipoTempo == "anos")
            {
                n = n * 12;
            }

            f = p * Math.Pow(1 + (i/100), n);

             Console.WriteLine($"O valor final é de: {f:C}");

    }
  }
}