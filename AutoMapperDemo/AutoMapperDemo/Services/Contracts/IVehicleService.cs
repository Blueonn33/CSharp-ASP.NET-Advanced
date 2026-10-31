using AutoMapperDemo.Services.Data;

namespace AutoMapperDemo.Services.Contracts
{
    public interface IVehicleService
    {
        Task<AllVehiclesDto> GetVehicleByVINAsync(string vin);
        Task<IEnumerable<AllVehiclesDto>> GetAllVehiclesAsync();
    }
}
