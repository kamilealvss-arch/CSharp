//Console.WriteLine("Hello, World!");
/* Tarefa 1: Em c#
Calculadora de valor de venda e aluguel de um imóvel, entradas:
-Área metro:
-Valor metro região:
-Total de quartos > 4
-Aluguel valor 1%
-Quanto o andar mais alto no predio mais caro
-saída: Valor de venda e valor de aluguel
*/

using System;

class Program
{
    static void Main()
    {
    
        string tipoImovel;
        double valorMetro;
        double valorPorAndar;
        double area;
        int quartos;
        int andar = 0;

        double valorVenda;
        double valorAluguel;
        double valorExtraAndar;

        Console.WriteLine("O imóvel é um apartamento? (sim/não)");
        tipoImovel = Console.ReadLine()?.ToLower() ?? "";

        Console.WriteLine("Digite o valor do metro quadrado:");
        valorMetro = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite a área do imóvel:");
        area = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite a quantidade de quartos:");
        quartos = Convert.ToInt32(Console.ReadLine());

        if (tipoImovel == "sim")
        {
            Console.WriteLine("Digite o andar do imóvel:");
            andar = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Digite o valor adicional por andar:");
            valorPorAndar = Convert.ToDouble(Console.ReadLine());
            valorExtraAndar = andar * valorPorAndar;
        }
        else
        {
            valorExtraAndar = 0;
        }
        
        valorVenda = (area * valorMetro) + valorExtraAndar;
        
        if (quartos > 4)
        {
            valorVenda = valorVenda * 1.10;
        }

        valorAluguel = valorVenda * 0.01;

        Console.WriteLine($"O valor do aluguel é de: {valorAluguel:C}");
        Console.WriteLine($"O valor de Venda é de: {valorVenda:C}");
    }
}