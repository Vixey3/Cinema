using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvpprojekat
{
    [Serializable()]
    class Rezervacije
    {
        private int pid;
        private int kid;
        private int brmst;
        private double ukupno;

        public Rezervacije(int pid, int kid, int brmst, double ukupno)
        {
            this.Pid = pid;
            this.Kid = kid;
            this.Brmst = brmst;
            this.Ukupno = ukupno;
        }

        public int Pid { get => pid; set => pid = value; }
        public int Kid { get => kid; set => kid = value; }
        public int Brmst { get => brmst; set => brmst = value; }
        public double Ukupno { get => ukupno; set => ukupno = value; }

        public override string ToString()
        {
            return $"Vas ID projekcije je: {pid} id kupca: {kid} rezervisano {brmst} mesta ukupna cena rezervacije iznosi: {ukupno}";
        }
    }
}
