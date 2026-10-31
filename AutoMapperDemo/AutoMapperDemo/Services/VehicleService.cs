using AutoMapper;
using AutoMapperDemo.Models;
using AutoMapperDemo.Services.Contracts;
using AutoMapperDemo.Services.Data;

namespace AutoMapperDemo.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper mapper;

        private readonly IEnumerable<Vehicle> VehiclesDb = new List<Vehicle>()
        {
            new Vehicle()
            {
                Id = Guid.NewGuid(),
                Make = "Toyota",
                Model = "Camry",
                Year = 2020,
                Mileage = 14400,
                Seats = 5,
                ProductionDate = new DateTime(2020, 11, 19),
                VIN = "9823YU4234U8234203",
                FeaturesList = ["Seats", "20' screen"]
            },
            new Vehicle()
            {
                Id = Guid.NewGuid(),
                Make = "Aston Martin",
                Model = "Vanquish",
                Year = 2025,
                Mileage = 11430,
                Seats = 3,
                ProductionDate = new DateTime(2025, 2, 11),
                VIN = "34534563456345645",
                FeaturesList = ["Cooler seats", "10' screen", "Carbon"]
            }
        };

        public VehicleService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<IEnumerable<AllVehiclesDto>> GetAllVehiclesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AllVehiclesDto> GetVehicleByVINAsync(string vin)
        {
            Vehicle searchVehicle =
                VehiclesDb.SingleOrDefault(v => v.VIN.Equals(vin, StringComparison.OrdinalIgnoreCase));

            if (searchVehicle is null)
            {
                throw new ArgumentException($"Vehicle with VIN {vin} was not found");
            }

            // WITHOUT AutoMapper
            //AllVehiclesDto vehicleDto = new AllVehiclesDto()
            //{
            //    Id = searchVehicle.Id,
            //    Make = searchVehicle.Make,
            //    Model = searchVehicle.Model,
            //    Year = searchVehicle.Year,
            //    Mileage = searchVehicle.Mileage,
            //    Seats = searchVehicle.Seats,
            //    ProductionDate = searchVehicle.ProductionDate,
            //    VIN = searchVehicle.VIN
            //};

            // WITH AutoMapper
            AllVehiclesDto vehicleDto = mapper.Map<AllVehiclesDto>(searchVehicle);

            return vehicleDto;
        }
    }
}
