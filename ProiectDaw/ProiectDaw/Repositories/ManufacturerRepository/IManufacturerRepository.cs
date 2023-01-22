using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.GenericRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories.ManufacturerRepository
{
    public interface IManufacturerRepository : IGenericRepository<Manufacturer>
    {
        Task<Manufacturer> GetByCountry(string country);
        Task<List<Manufacturer>> GetAllManufacturersWithLocation();
        Task<Manufacturer> GetByIdWithLocation(int id);

    }
}
