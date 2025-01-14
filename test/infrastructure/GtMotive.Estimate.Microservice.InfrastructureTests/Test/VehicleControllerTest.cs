using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.Controller;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindAvailable;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindById;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Test
{
    public class VehicleControllerTest
    {
        private readonly VehicleController _vehicleController;
        private readonly Mock<IUseCase<AddVehicleUseCaseInput, AddVehicleUseCaseOutput>> _addVehicle;
        private readonly Mock<IUseCase<RentVehicleUseCaseInput, RentVehicleUseCaseOutput>> _rentVehicles;
        private readonly Mock<IUseCase<ReturnVehicleUseCaseInput, ReturnVehicleUseCaseOutput>> _returnVehicles;
        private readonly Mock<IUseCaseList<FindAllAvailableVehiclesUseCaseInput, FindAllAvailableVehiclesUseCaseOutput>> _findAllAvailableVehiclesUseCase;
        private readonly Mock<IUseCase<FindVehicleUseCaseInput, FindVehicleUseCaseOutput>> _findVehicleUseCase;

        public VehicleControllerTest()
        {
            _addVehicle = new Mock<IUseCase<AddVehicleUseCaseInput, AddVehicleUseCaseOutput>>();
            _rentVehicles = new Mock<IUseCase<RentVehicleUseCaseInput, RentVehicleUseCaseOutput>>();
            _returnVehicles = new Mock<IUseCase<ReturnVehicleUseCaseInput, ReturnVehicleUseCaseOutput>>();
            _findAllAvailableVehiclesUseCase = new Mock<IUseCaseList<FindAllAvailableVehiclesUseCaseInput, FindAllAvailableVehiclesUseCaseOutput>>();
            _findVehicleUseCase = new Mock<IUseCase<FindVehicleUseCaseInput, FindVehicleUseCaseOutput>>();

            _vehicleController = new VehicleController(
                _addVehicle.Object,
                _rentVehicles.Object,
                _returnVehicles.Object,
                _findAllAvailableVehiclesUseCase.Object,
                _findVehicleUseCase.Object);
        }

        [Fact]
        public async Task FindByIdWithValidDataReturnsOk()
        {
            // Arrange
            FindVehicleUseCaseInput input = new() { Id = "1" };
            FindVehicleUseCaseOutput output = new() { Id = "1" };

            var expectedResult = new OkObjectResult(output);

            _findVehicleUseCase.Setup(s => s.Execute(input)).ReturnsAsync(output);

            // Act
            var result = await _vehicleController.FindById(input) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result!.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
