using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace PeterApp.Services
{
    public class PaisRepository : IPaisRepository
    {
        public IList<string> GetPaises()
        {
            return new List<string>()
            {
                "El Salvador", "Peru", "Canada", "Estados Unidos", "Mexico", "Guatemala"
            };
        }
    }
}
