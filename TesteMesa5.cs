using System;


namespace TesteMesa5
{
    class Program
    {
        static void Main(string[] args)
        {
            double p;
            double i;
            double n;
            double r;
            double rl;
            double ra;
            double mr = 0;
            double vre = 0;
            string resg;
            string tipoTempo;


            Console.WriteLine("Digite o valor que deseja investir:");
            p = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Digite o valor do juros:");
            i = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Quer Calcular o tempo em meses ou anos? (meses/anos)");
            tipoTempo = Console.ReadLine()?.ToLower() ?? "";


            Console.WriteLine("Digite quanto tempo deseja investir:");
            n = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Deseja realizar um resgate? (sim/não)");
            resg = Console.ReadLine()?.ToLower() ?? "";


            if (resg == "sim")
            {
                Console.WriteLine("Qual mês você deseja realizar o resgate");
                mr = Convert.ToDouble(Console.ReadLine());


                Console.WriteLine("Quanto você deseja retirar?");
                vre = Convert.ToDouble(Console.ReadLine());


            }


            if (tipoTempo == "anos")
            {
                n = n * 12;
            }


            i = i / 100;
            r = p;
            ra = p;


            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("Mês | Taxa   | Rendimento   | Rendi. Líquido | Renda Acumulada | Resgate    | Saldo");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");


            r = p;


            for (int m = 1; m <= n; m++)
            {
                r = r * (1 + i);
                ra = r;
                rl = ra - p;


                double valorResgatadoNoMes = 0;
                if (resg == "sim" && m == mr)
                {
                    valorResgatadoNoMes = vre;
                    r = r - valorResgatadoNoMes;


                    p = r;
                }


 
                Console.WriteLine(
                    $"{m:00}  | " +
                    $"{i,-6:P2} | " +
                    $"{ra,-12:C2} | " +
                    $"{rl,-14:C2} | " +
                    $"{ra,-15:C2} | " +
                    $"{valorResgatadoNoMes,-10:C2} | " +
                    $"{r:C2}"
                );


            }


        }
    }
}
