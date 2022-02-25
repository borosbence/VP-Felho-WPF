using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Felho.Models;
using VP_Felho.Services;

namespace VP_Felho.Repositories
{
    public class FajlRepository : GenericRepository<Fajl, felhoContext>
    {
        public FajlRepository(felhoContext context) : base(context)
        {
        }

        public override List<Fajl> GetAll()
        {
            return _context.Fajlok
                .Where(x => x.felhasznalo_id == CurrentUser.Id)
                .OrderByDescending(x => x.datum)
                .ToList();
        }
    }
}
