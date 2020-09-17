using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekser
{
    class Program
    {
        static void Main(string[] args)
        {
            string wyrazenie = "  2+(*34)";

            Lekser l = new Lekser();

            if(l.analizuj(wyrazenie))
            {
                Console.WriteLine("Rozpoznano wyrazenie");
                foreach(Token t in l.TablicaSymboli)
                {
                    Console.WriteLine("<{0},{1}>",t.nazwa,t.argument);
                }
            }
            else
            {
                int indeks;
                Console.WriteLine("Błąd analizy leksykalnej");
                Console.WriteLine("Nieznany token: {1},nr pozycji: {0}",
                    indeks = l.TablicaSymboli.Count() > 0 ? l.TablicaSymboli.Last().indeks+1 : 0,
                    wyrazenie.Substring(indeks,wyrazenie.Length-indeks>10 ? 10: wyrazenie.Length-indeks)
                    );

          }
            foreach (Token t in l.TablicaSymboli)
            {
                Console.WriteLine("<{0},{1}>", t.nazwa, t.argument);
            }
            Console.ReadLine();

        }
    }
}
