using Microsoft.EntityFrameworkCore;
using ProiectDaw.Data;
using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.GenericRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories.ManufacturerRepository
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(DBcon context) : base(context) { }
        public async Task<Manufacturer> GetByCountry(string country)
        {
            return await _context.Manufacturers.Where(m => m.Country.Equals(country)).FirstOrDefaultAsync();
        }

        public async Task<List<Manufacturer>> GetAllManufacturersWithLocation()
        {
            return await _context.Manufacturers.Include(m => m.Location).ToListAsync();
        }

        public async Task<Manufacturer> GetByIdWithLocation(int id)
        {
            return await _context.Manufacturers.Include(m => m.Location).Where(m => m.Id == id).FirstOrDefaultAsync();
        }

    }
}
