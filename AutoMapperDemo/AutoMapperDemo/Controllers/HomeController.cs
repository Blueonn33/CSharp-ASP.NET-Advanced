using AutoMapper;
using AutoMapperDemo.Services.Contracts;
using AutoMapperDemo.Services.Data;
using AutoMapperDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoMapperDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public HomeController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            AllVehiclesDto vehicleWithVin = await _vehicleService.GetVehicleByVINAsync("34534563456345645");

            VehicleViewModel vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleWithVin);

            return Ok(vehicleViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
