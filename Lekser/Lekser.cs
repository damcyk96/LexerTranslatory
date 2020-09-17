using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekser
{
    
    class Lekser
    {
        public List<Token> TablicaSymboli;
             public bool analizuj(string wyrazenie)
        {
            this.TablicaSymboli = new List<Token>();
            int indeks = 0;
            WynikAnalizyLeksykalnej wynik = new WynikAnalizyLeksykalnej();
            wynik.wynik = false;
            while (indeks<wyrazenie.Length &&(wynik = S(wyrazenie, indeks)).wynik) 
            {
              
                this.TablicaSymboli.Add(wynik.token);
                indeks = indeks + wynik.token.argument.Length;
                
            }
            return wynik.wynik;
        }
        public WynikAnalizyLeksykalnej S(string wyrazenie,int i)
        {
            WynikAnalizyLeksykalnej wynik;
            if ((wynik = N(wyrazenie, i)).wynik) return wynik;
            if((wynik = B(wyrazenie, i)).wynik) return wynik;
            if ((wynik = L(wyrazenie, i)).wynik) return wynik;
            wynik = O(wyrazenie, i);
            return wynik;

         
        }
        public WynikAnalizyLeksykalnej N(string wyrazenie, int i)
        {
            WynikAnalizyLeksykalnej wynik = new WynikAnalizyLeksykalnej();
            if(wyrazenie[i]=='(' || wyrazenie[i] == ')')
            {
                wynik.wynik = true;
                wynik.token = new Token(TypTokenu.Nawias, wyrazenie[i].ToString(), i);
                return wynik;

            }

            wynik.wynik = false;
            return wynik;

        }
        public WynikAnalizyLeksykalnej O(string wyrazenie, int i)
        {
            WynikAnalizyLeksykalnej wynik = new WynikAnalizyLeksykalnej();
            if (wyrazenie[i] == '+' || wyrazenie[i] == '-' || wyrazenie[i] == '-' || wyrazenie[i] == '*' || wyrazenie[i] == '/')
            {
                wynik.wynik = true;
                wynik.token = new Token(TypTokenu.Operator, wyrazenie[i].ToString(), i);
                return wynik;

            }

            wynik.wynik = false;
            return wynik;

        }

        public WynikAnalizyLeksykalnej B(string wyrazenie, int i)
        {
            WynikAnalizyLeksykalnej bufor, wynik = new WynikAnalizyLeksykalnej();
            if (wyrazenie.Length >i+1 &&  wyrazenie[i] == ' ' && (bufor= B(wyrazenie,i+1)).wynik)
            {
                wynik.wynik = true;
                wynik.token = new Token(TypTokenu.BialeZnaki, wyrazenie[i].ToString()+bufor.token.argument, i);
                return wynik;

            }
            else if (wyrazenie[i] == ' ')
            {
                wynik.wynik = true;
                wynik.token = new Token(TypTokenu.BialeZnaki, wyrazenie[i].ToString(), i);
                return wynik;

            }

            wynik.wynik = false;
            return wynik;

        }
        public WynikAnalizyLeksykalnej L(string wyrazenie, int i)
        {
            WynikAnalizyLeksykalnej bufor, wynik = new WynikAnalizyLeksykalnej();
            if (wyrazenie.Length > i + 1 && wyrazenie[i] == ' ' && (bufor = L(wyrazenie, i + 1)).wynik)
            {
                wynik.wynik = true;
                wynik.token = new Token(TypTokenu.Liczba, wyrazenie[i].ToString() + bufor.token.argument, i);
                return wynik;

            }
            else if (wyrazenie[i] == '0')
            {
                wynik.wynik = true;
                wynik.token = new Token(TypTokenu.Liczba, wyrazenie[i].ToString(), i);
                return wynik;

            }
            else if ("123456789".Contains(wyrazenie[i]))
            {
                wynik.wynik = true;
                wynik.token = new Token(TypTokenu.Liczba, wyrazenie[i].ToString(), i);
                return wynik;

            }


            wynik.wynik = false;
            return wynik;

        }




    }
}
