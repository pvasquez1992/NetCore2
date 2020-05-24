using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PeterApp.Data;
using PeterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace PeterApp.Services
{
    public class PaisRepository : IPaisRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PaisRepository(ApplicationDbContext dbcontex) {

            _dbContext = dbcontex;
        
        }


        public IList<Pais> GetPaises()
        {

            var result = _dbContext.Paises.ToList();
            return  result;
        }
    }
}
