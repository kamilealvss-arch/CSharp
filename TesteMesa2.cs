using System;

namespace teste02
{
  class Program
  {
    static void Main(string[] args)
    {

           //a= 2;
            //while (a<6)  {
            //v[a] = 10 * a;
            //a += 1; } 

            int[] v = new int[6];
            int a=2;

            while (a<6)
            {
                v[a] = 10 * a;
                a +=2;
            }

            for (int i = 0; i v.Length; i++)
            Console.WriteLine ($"v[{i}] = {v[i]}");
            
        }
    }
}