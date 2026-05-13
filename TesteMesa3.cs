using System;

namespace teste03
{
  class Program
  {
    static void Main(string[] args)
     {

    //a =7;
    //b = a - 6;
    //while (b<a) {
    //v[b]=b+a;
    //b=b+2

   int[] v = new int [8];
   int a = 7;
   int b = 0;
   b = a - 6;

   while (b < a)
            {
                v[a] = b + a;
                Console.WriteLine (v[a]);
                b = b + 2;
            }


    }
  }
}

    
    
  
