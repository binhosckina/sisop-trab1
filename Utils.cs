using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisop_trab1
{
    class Utils
    {
        public static void dump(Word w)
        {
            Console.Write("[ ");
            Console.Write(w.opc); Console.Write(", ");
            Console.Write(w.r1); Console.Write(", ");
            Console.Write(w.r2); Console.Write(", ");
            Console.Write(w.p); Console.WriteLine("  ] ");
        }

        static public void dump(Word[] m, int ini, int fim)
        {
            for (int i = ini; i < fim; i++)
            {
                Console.Write(i); Console.Write(":  "); dump(m[i]);
            }
        }

    }
}
