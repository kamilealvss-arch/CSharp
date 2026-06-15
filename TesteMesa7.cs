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
            int meses = 0;
            DateTime dataSimulada = dataInicio;
            while (dataSimulada.AddMonths(1) <= dataFim)
            {
                meses++;
                dataSimulada = dataSimulada.AddMonths(1);
            }
            
            int mesResgate = ((dataResgate.Year - dataInicio.Year) * 12) + (dataResgate.Month - dataInicio.Month) + 1;

            Console.WriteLine("\n==========================================================================================");
            Console.WriteLine($"Data de Início: {dataInicio:dd/MM/yyyy} | Data Final: {dataFim:dd/MM/yyyy}");
            Console.WriteLine($"Valor Investido: {entradaInicial:C2}");
            Console.WriteLine($"Meses calculados: {meses} | Dias totais: {(dataFim - dataInicio).Days}");
            Console.WriteLine("==========================================================================================");

            double presente = entradaInicial;
            double rendimentoMes;
            double rendaAcumulada = 0;

            Console.WriteLine(string.Format("{0,-12} | {1,-10} | {2,-15} | {3,-15} | {4,-13} | {5,-15}", 
                "Período", "Taxa Juros", "Rendimento", "Renda Acum.", "Resgate", "Saldo"));
            Console.WriteLine(new string('-', 95));

            for (int m = 1; m <= meses; m++)
            {
                rendimentoMes = presente * taxaJuros;
                presente = presente + rendimentoMes;
                rendaAcumulada += rendimentoMes;

                if (m == mesResgate && valorResgate > 0)
                {
                    presente = presente - valorResgate;
                    
                    Console.WriteLine(string.Format("{0,-12} | {1,-10:P2} | {2,-15:C2} | {3,-15:C2} | {4,-13:C2} | {5,-15:C2}",
                        $"Mês {m}", taxaJuros, rendimentoMes, rendaAcumulada, valorResgate, presente));
                }
                else
                {
                    Console.WriteLine(string.Format("{0,-12} | {1,-10:P2} | {2,-15:C2} | {3,-15:C2} | {4,-13:C2} | {5,-15:C2}",
                        $"Mês {m}", taxaJuros, rendimentoMes, rendaAcumulada, 0.0, presente));
                }
            }

            int diasRestantes = (dataFim - dataSimulada).Days;

            if (diasRestantes > 0)
            {
                double taxaDiaria = taxaJuros / 30.0;
                double rendimentoDias = presente * taxaDiaria * diasRestantes;
                presente = presente + rendimentoDias;
                rendaAcumulada += rendimentoDias;

                Console.WriteLine(string.Format("{0,-12} | {1,-10:P2} | {2,-15:C2} | {3,-15:C2} | {4,-13:C2} | {5,-15:C2}",
                    $"+{diasRestantes} Dias", taxaDiaria, rendimentoDias, rendaAcumulada, 0.0, presente));
            }
            Console.WriteLine(new string('-', 95));
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
}
