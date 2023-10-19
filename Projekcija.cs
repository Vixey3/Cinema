using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvpprojekat
{
    [Serializable()]
    class Projekcija
    {
        static int i = 1;
        private int pid = i++;
        private DateTime pdatum;
        private Sala sala;
        private double cena;
        private DateTime vreme;
        private Film film;
        private int slobodna;

        public Projekcija(int pid, DateTime pdatum, Sala sala, double cena, DateTime vreme, Film film)
        {
            slobodna = sala.Ukupan;
            this.Pid = pid;
            this.Pdatum = pdatum;
            this.Sala = sala;
            this.Cena = cena;
            this.Vreme = vreme;
            this.Film = film;
        }

        public int Pid { get => pid; set => pid = value; }
        public DateTime Pdatum { get => pdatum; set => pdatum = value; }
        public double Cena { get => cena; set => cena = value; }
        public DateTime Vreme { get => vreme; set => vreme = value; }
        public int Slobodna { get => slobodna; set => slobodna = value; }
        internal Sala Sala { get => sala; set => sala = value; }
        internal Film Film { get => film; set => film = value; }

        public override string ToString()
        {
            return $"ID projekcije: {pid} datum pocetka: {pdatum.Day} broj sale: {sala.Brsl} cena karata: {cena} vreme pocetka{vreme} prikazuje se film: {film.Naziv} dostupno mesta {slobodna}";
        }
    }
}
