using Microsoft.EntityFrameworkCore;
using ProiectDaw.Data;
using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.GenericRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories.VehicleRepository
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DBcon context) : base(context) { }

        public async Task<List<Vehicle>> GetAllVehiclesWithManufacturers()
        {
            return await _context.Vehicles.Include(v => v.Manufacturer).ToListAsync();
        }

        public async Task<Vehicle> GetByIdWithManufacturer(int id)
        {
            return await _context.Vehicles.Include(v =>v.Manufacturer).Where(v => v.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Vehicle> GetByName(string name)
        {
            return await _context.Vehicles.Where(v => v.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
