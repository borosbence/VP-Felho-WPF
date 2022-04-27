using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VP_Felho.Models;
using VP_Felho.Services;

namespace VP_Felho.Repositories
{
    public class FelhasznaloRepository
    {
        private felhoContext _context;
        public FelhasznaloRepository(felhoContext context)
        {
            _context = context;
        }

        public string Authenticate(string username, string password)
        {
            if (!_context.Database.CanConnect())
            {
                return Application.Current.Resources["dbFail"].ToString();
            }
            // Ezzel a felhasználónévvel létezik e rekord
            var dbUser = _context.Felhasznalok.AsNoTracking().SingleOrDefault(x => x.felhasznalonev .Equals(username));
            if (dbUser != null && !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                // Begépelt jelszó titkosítása, ezt el kell menteni az adatbázisba!
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                // Jelszó ellenőrzése
                bool verified = BCrypt.Net.BCrypt.Verify(password, dbUser.jelszo);
                if (verified)
                {
                    CurrentUser.Id = dbUser.id;
                    CurrentUser.UserName = dbUser.felhasznalonev;
                    return Application.Current.Resources["loginSuccess"].ToString();
                }
                else
                {
                    // Hibás login
                    return Application.Current.Resources["loginFail"].ToString();
                }
            }
            else
            {
                // Felhasználó nem létezik
                return Application.Current.Resources["loginNoUser"].ToString();
            }
        }
    }
}
