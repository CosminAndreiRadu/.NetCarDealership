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

        public async Task<Dictionary<string, string>> GetAllManufacturersWithVehicles()
        {
            List<Manufacturer> ManufacturersList = await _context.Manufacturers.ToListAsync();
            List<Vehicle> VehiclesList = await _context.Vehicles.ToListAsync();

            var ls = from manufacturer in ManufacturersList
                        join vehicle in VehiclesList
                        on manufacturer.Id equals vehicle.ManufacturerId
                        select new
                          {
                              VehicleName = vehicle.Name,
                              ManufacturerName = manufacturer.Name
                          };

            Dictionary<string, string> dict =
            new Dictionary<string, string>();

            foreach(var el in ls)
            {
                dict.Add(el.ManufacturerName, el.VehicleName);
            }

            return dict;
        }

        public async Task<Manufacturer> GetByIdWithLocation(int id)
        {
            return await _context.Manufacturers.Include(m => m.Location).Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Manufacturer>> GetAllManufacturersWithLocation()
        {
            return await _context.Manufacturers.Include(m => m.Location).ToListAsync();
        }

        public async Task<Dictionary<int, int>> GetAllManufacturersWithNOVehicles()
        {
            List<Manufacturer> ManufacturersList = await _context.Manufacturers.ToListAsync();
            List<Vehicle> VehiclesList = await _context.Vehicles.ToListAsync();

            var ls = from manufacturer in ManufacturersList
                     join vehicle in VehiclesList
                     on manufacturer.Id equals vehicle.ManufacturerId
                     group manufacturer by manufacturer.Id into man
                     select new
                     {
                         ManufacturerName = man.Key,
                         NrOfVehicles = man.Count()
                     };

            Dictionary<int, int> dict =
            new Dictionary<int, int>();

            foreach (var el in ls)
            {
                dict.Add(el.ManufacturerName, el.NrOfVehicles);
            }

            return dict;
        }
    }
}
