using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.GenericRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories.ManufacturerRepository
{
    public interface IManufacturerRepository : IGenericRepository<Manufacturer>
    {
        Task<Manufacturer> GetByCountry(string country);
        Task<Dictionary<string, string>> GetAllManufacturersWithVehicles();
        
        Task<List<Manufacturer>> GetAllManufacturersWithLocation();

        Task<Dictionary<int, int>> GetAllManufacturersWithNOVehicles();


        Task<Manufacturer> GetByIdWithLocation(int id);

    }
}
