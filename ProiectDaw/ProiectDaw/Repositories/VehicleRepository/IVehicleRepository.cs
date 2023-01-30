using ProiectDaw.Models.Entities;
using ProiectDaw.Repositories.GenericRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectDaw.Repositories.VehicleRepository
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Task<Vehicle> GetByName(string name);
        Task<List<Vehicle>> GetAllVehiclesWithManufacturers();

        Task<Vehicle> GetByIdWithManufacturer(int id);

    }
}
