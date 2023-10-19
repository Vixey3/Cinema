using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvpprojekat
{
    [Serializable()]
    class Sala
    {
        static int i = 1;
        private int sid = i++;
        private int brsl;
        private int ukupan;

        public Sala(int sid, int brsl, int ukupan)
        {
            this.Sid = sid;
            this.Brsl = brsl;
            this.Ukupan = ukupan;
        }

        public int Sid { get => sid; set => sid = value; }
        public int Brsl { get => brsl; set => brsl = value; }
        public int Ukupan { get => ukupan; set => ukupan = value; }

        public override string ToString()
        {
            return $"ID sale: {sid} broj sale: {brsl} ukupan broj sedista: {ukupan}";
        }
    }
}
