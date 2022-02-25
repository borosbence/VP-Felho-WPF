using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Felho.Services;

namespace VP_Felho.Models
{
    public partial class Fajl
    {
        public Fajl(string fajlnev, string kiterjesztes, byte[] adat)
        {
            this.fajlnev = fajlnev;
            this.kiterjesztes = kiterjesztes;
            this.adat = adat;
            this.datum = DateTime.Now;
            this.felhasznalo_id = CurrentUser.Id;
        }
    }
}
