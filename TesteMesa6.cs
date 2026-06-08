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
            double mr;
            double vre;
            string resg;
            string tipoTempo;


            Console.WriteLine("Digite o valor que deseja investir:");
            p = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Digite o valor do juros:");
            i = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Quer Calcular o tempo em meses ou anos? (meses/anos)");
            tipoTempo = Console.ReadLine()?.ToLower() ?? "";


            Console.WriteLine("Digite o valor do tempo (período):");
            n = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Deseja realizar um resgate? (sim/não)");
            resg = Console.ReadLine()?.ToLower() ?? "";


            if (resg == "sim")
            {
            Console.WriteLine("Qual mês você deseja realizar o resgate");
            mr = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Quando você deseja retirar?");
            vre = Convert.ToDouble(Console.ReadLine());


            }


            if (tipoTempo == "anos")
            {
                n = n * 12;
            }


            i = i / 100;
            r = p;
            ra = p;


            Console.WriteLine("===========================================================================");
            Console.WriteLine("Mês | Taxa Juros | Rendimento  | Rendi. Liquido | Renda Acumulada |");
            Console.WriteLine("---------------------------------------------------------------------------");




            for (int m = 1; m <= n; m++)
            {
                r = r * (1 + i);


                rl = r - p;


                if (m == 1)
                {
           
                    ra = r;
                }
                else
                {
           
                    ra = ra + rl;
                }


           
                Console.WriteLine($"{m:00}  | {i:P2}      | {r:C2} | {rl:C2}       |   {ra:C2}     |");
            }


            Console.WriteLine("===========================================================================");
        }
    }
}

