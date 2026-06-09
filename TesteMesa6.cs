using System;

namespace CalculadoraInvestimentos
{

    class Datas
    {
        private double entradaInicial;
        private double taxaJuros;
        private DateTime dataFixa;

        public Datas (double valor, double juros, DateTime data)
        {
        entradaInicial = valor;
        taxaJuros = juros;
        dataFixa = data;
        }

        public double calcularInvestimento()
        {

        int meses = (( dataFixa.Year - DateTime.Now.Year) *12) + dataFixa.Month - DateTime.Now.Month;
        return entradaInicial * Math.Pow ((1 + taxaJuros), meses);
        }

        static void Main(string[] args)
        {
            DateTime dataInicio = DateTime.Now;
            DateTime dataBase = dataInicio.AddMonths(8).AddDays(10);

            Datas inv1 = new Datas (1000, 0.03, dataBase);
            Datas inv2 = new Datas (5500, 0.0248, dataBase);
            Datas inv3 = new Datas (12000, 0.02, dataBase);

            Console.WriteLine($"Investimento 1: {inv1.calcularInvestimento():C}");
            Console.WriteLine($"Investimento 2: {inv2.calcularInvestimento():C}");
            Console.WriteLine($"Investimento 3: {inv3.calcularInvestimento():C}");

        }
    } 
}    

