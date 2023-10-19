using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvpprojekat
{
    [Serializable()]
    class Korisnik
    {
        private string korime;
        private string sifra;

        public string Korime { get => korime; set => korime = value; }
        public string Sifra { get => sifra; set => sifra = value; }

        public Korisnik(string korime, string sifra)
        {
            this.Korime = korime;
            this.Sifra = sifra;
        }

        public override string ToString()
        {
            return $"Korisnicko ime: {korime} lozinka: {sifra}";
        }
    }
}
