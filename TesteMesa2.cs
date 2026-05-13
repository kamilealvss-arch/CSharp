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
    //a += 1;}
    
        int[] v = new int[6];
        int a = 2;

        while (a < 6)
        {
            v[a] = 10 * a;
            Console.WriteLine(v[a]);
            a += 1;
        }
    }
  }
}

    
    
  
