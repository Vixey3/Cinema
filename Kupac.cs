using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvpprojekat
{
    [Serializable()]
    class Kupac : Korisnik
    {
        
        private int kid;
        private string ime;
        private string prezime;
        private DateTime datum;
        private string telefon;
        private string pol;

        public Kupac(int kid, string korime, string sifra, string ime, string prezime, DateTime datum, string telefon, string pol) : base(korime, sifra)
        {
            this.Korime = korime;
            this.Sifra = sifra;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Datum = datum;
            this.Telefon = telefon;
            this.Pol = pol;
            this.Kid = kid;
        }

        public int Kid { get => kid; set => kid = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Pol { get => pol; set => pol = value; }

        public override string ToString()
        {
            return $"ID kupca: {Kid} ime: {Ime} prezime: {Prezime} datum rodjenja: {Datum} broj telefona: {Telefon} pol: {Pol}";
        }
    }
}
