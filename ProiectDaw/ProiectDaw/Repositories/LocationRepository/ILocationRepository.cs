using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.GenericRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories.LocationRepository
{
    public interface ILocationRepository :IGenericRepository<Location>
    {
        Task<Location> GetLocationByZipCode(string zipCode);
        Task<List<Location>> GetAllLocations();
    }
}
