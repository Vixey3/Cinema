using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvpprojekat
{
    [Serializable()]
    class Administrator : Korisnik
    {
        public Administrator() : base("admin","admin")
        {
            
        }

    }
}
