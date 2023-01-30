using Microsoft.EntityFrameworkCore;
using ProiectDaw.Data;
using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.GenericRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories.LocationRepository
{
    public class LocationRepository : GenericRepository<Location> , ILocationRepository
    {
        public LocationRepository(DBcon context) : base(context) { }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetLocationByZipCode(string zipCode)
        {
            return await _context.Locations.Where(l => l.ZipCode.Equals(zipCode)).FirstOrDefaultAsync();
        }
    }
}
