using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.FindById;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repository;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    /// <summary>
    /// Represents the test class for the FindVehicleUseCase.
    /// </summary>
    public class FindVehicleUseCaseTest
    {
        private readonly FindVehicleUseCase _useCase;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IVehicleRepository> _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindVehicleUseCaseTest"/> class.
        /// </summary>
        public FindVehicleUseCaseTest()
        {
            _mapper = new Mock<IMapper>();
            _vehicleRepository = new Mock<IVehicleRepository>();
            _useCase = new(_vehicleRepository.Object, _mapper.Object);
        }

        /// <summary>
        /// Test to find a vehicle.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. </returns>
        [Fact]
        public async Task FindVehicleUseCaseShouldReturnEntity()
        {
            // Arrange
            var input = new FindVehicleUseCaseInput
            {
                Id = "1"
            };

            var bson = new Vehicle()
            {
                Id = "1"
            };

            var output = new FindVehicleUseCaseOutput();

            _vehicleRepository.Setup(s => s.FindById(input.Id)).ReturnsAsync(bson);
            _mapper.Setup(s => s.Map<FindVehicleUseCaseOutput>(bson)).Returns(output);

            // Act
            var result = await _useCase.Execute(input);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(output);
        }
    }
}
