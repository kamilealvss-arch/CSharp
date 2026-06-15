using System;
using System.Data;
using System.Globalization;

namespace CalculadoraInvestimentos
{

    class Investimento
    {
        private double entradaInicial;
        private double taxaJuros;
        private DateTime dataInicio;
        private DateTime dataFim;
        private double valorResgate;
        private DateTime dataResgate;

        public Investimento(double valor, double juros, DateTime idata, DateTime fdata, double vresgate, DateTime dresgate)
        {
            entradaInicial = valor;
            taxaJuros = juros;
            dataInicio = idata;
            dataFim = fdata;
            valorResgate = vresgate;
            dataResgate = dresgate;
        }

        public void Calculo()
        {

            Console.WriteLine($"Data de Início: {dataInicio:dd/MM/yyyy}");
            Console.WriteLine($"Data Final: {dataFim:dd/MM/yyyy}");
            Console.WriteLine($"Valor investido {entradaInicial}");

            int meses = ((dataFim.Year - dataInicio.Year) * 12) + dataFim.Month - dataInicio.Month;
            int dias = (dataFim - dataInicio).Days;

            int mesResgate = ((dataResgate.Year - dataInicio.Year) * 12) + (dataResgate.Month - dataInicio.Month);

            double presente = entradaInicial;
            double rendimentoMes;

            Console.WriteLine("\nPeríodo | Rendimento | Saldo Líquido");
            Console.WriteLine("Meses calculados: " + meses);
            Console.WriteLine("Dias totais: " + dias);
            Console.WriteLine("---------------------------------------------------------------------------------");


            for (int m = 1; m <= meses; m++)
            {
                rendimentoMes = presente * taxaJuros;
                presente = presente + rendimentoMes;

                if (m == mesResgate)
                {
                    presente = presente - valorResgate;
                    Console.WriteLine($"Mês {m} | {rendimentoMes:C2} | Saldo: {presente:C2} | Valor resgatado: {valorResgate:C2}");
                }
                else
                {
                    Console.WriteLine($"Mês {m} | {rendimentoMes:C2} | Saldo: {presente:C2} | Valor resgatado: {0:C2}");
                }
            }

            DateTime dataAposMeses = dataInicio.AddMonths(meses);


            int diasRestantes = (dataFim - dataAposMeses).Days;

            if (diasRestantes > 0)
            {
                double taxaDiaria = taxaJuros / 30.0;

                double rendimentoDias = presente * taxaDiaria * diasRestantes;
                presente = presente + rendimentoDias;

                Console.WriteLine($"Dias +{diasRestantes} | {rendimentoDias:C2} | Saldo: {presente:C2} | (Rendimento dos dias restantes)");
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

        Console.WriteLine("Digite o valor que deseja investir:");
        double entradaInicial = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite a taxa do juros (Ex: 2,0 para 2%):");
        double taxaJuros = Convert.ToDouble(Console.ReadLine()) / 100;

        Console.WriteLine("Digite a data de início (dd/mm/aaaa):");
        DateTime dataInicio = DateTime.ParseExact(Console.ReadLine() ?? "", "dd/MM/yyyy", null);

        Console.WriteLine("Digite a data final (dd/mm/aaaa):");
        DateTime dataFim = DateTime.ParseExact(Console.ReadLine() ?? "", "dd/MM/yyyy", null);

        Console.WriteLine("Deseja realizar um resgate? (sim/não)");
        string resgate = Console.ReadLine()?.ToLower() ?? "";

        double valorResgate = 0;
        DateTime dataResgate = DateTime.MinValue;

        if (resgate == "sim")
        {
            Console.WriteLine("Qual o valor que deseja resgatar?");
            valorResgate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Qual data deseja realizar o resgate?");
            dataResgate = DateTime.ParseExact(Console.ReadLine() ?? "", "dd/MM/yyyy", null);
        }

        Investimento meuInvestimento = new Investimento(entradaInicial, taxaJuros, dataInicio, dataFim, valorResgate, dataResgate);
        meuInvestimento.Calculo();
    }
}

