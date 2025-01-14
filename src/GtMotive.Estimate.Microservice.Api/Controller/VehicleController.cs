using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindAvailable;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindById;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleController(
        IUseCase<AddVehicleUseCaseInput, AddVehicleUseCaseOutput> addVehicle,
        IUseCase<RentVehicleUseCaseInput, RentVehicleUseCaseOutput> rentVehicles,
        IUseCase<ReturnVehicleUseCaseInput, ReturnVehicleUseCaseOutput> returnVehicles,
        IUseCaseList<FindAllAvailableVehiclesUseCaseInput, FindAllAvailableVehiclesUseCaseOutput> findAllAvailableVehiclesUseCase,
        IUseCase<FindVehicleUseCaseInput, FindVehicleUseCaseOutput> findVehicleUseCase) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddVehicleUseCaseInput input)
            => Ok(await addVehicle.Execute(input));

        [HttpPut]
        public async Task<IActionResult> Rent([FromBody] RentVehicleUseCaseInput input)
            => Ok(await rentVehicles.Execute(input));

        [HttpPut]
        public async Task<IActionResult> Return([FromBody] ReturnVehicleUseCaseInput input)
            => Ok(await returnVehicles.Execute(input));

        [HttpGet]
        public async Task<IActionResult> FindAllAvailable([FromQuery] FindAllAvailableVehiclesUseCaseInput input)
            => Ok(await findAllAvailableVehiclesUseCase.Execute(input));

        [HttpGet]
        public async Task<IActionResult> FindById([FromQuery] FindVehicleUseCaseInput input)
            => Ok(await findVehicleUseCase.Execute(input));
    }
}
