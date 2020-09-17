using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekser
{
    
    class Token
    {
        public string nazwa { get; set; }
        public string argument { get; set; }
        public int indeks { get; set; }

        public Token(string nazwa, string argument, int indeks)
        {
            this.nazwa = nazwa;
            this.argument = argument;
            this.indeks = indeks;

        }

    }
}
