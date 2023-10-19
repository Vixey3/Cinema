using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvpprojekat
{
    [Serializable()]
    class Film
    {
        static int i = 1;
        private int fid = i++;
        private string naziv;
        private string zanr;
        private int duzina;
        private int granica;

        public Film(int fid, string naziv, string zanr, int duzina, int granica)
        {
            this.Fid = fid;
            this.Naziv = naziv;
            this.Zanr = zanr;
            this.Duzina = duzina;
            this.Granica = granica;
        }

        public int Fid { get => fid; set => fid = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Zanr { get => zanr; set => zanr = value; }
        public int Duzina { get => duzina; set => duzina = value; }
        public int Granica { get => granica; set => granica = value; }

        public override string ToString()
        {
            return $"ID filma: {fid} naziv: {naziv} zanr: {zanr} duzina trajanja (u minutima): {duzina} nije preporuceno za mladje od: {granica}";
        }
    }
}
