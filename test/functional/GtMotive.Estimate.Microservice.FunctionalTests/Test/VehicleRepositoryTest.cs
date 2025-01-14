using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repository;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Test
{
    /// <summary>
    /// Vehicle repository test.
    /// </summary>
    public class VehicleRepositoryTest : IClassFixture<MongoDbFixture>
    {
        private readonly VehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleRepositoryTest"/> class.
        /// </summary>
        /// <param name="fixture">The fixture for MongoDB.</param>
        public VehicleRepositoryTest(MongoDbFixture fixture)
        {
            ArgumentNullException.ThrowIfNull(fixture);

            _vehicleRepository = new VehicleRepository(unitOfWork: fixture.UnitOfWorkFixture);
        }

        [Fact]
        public async Task FindByIdShouldBeReturnData()
        {
            // Arrange
            var id = "5f7b3b3b7f3b3b3b3b3b3b3b";
            await ArrangeDataForFindById(id);

            // Act
            var result = await _vehicleRepository.FindById(id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task FindByIdNotShouldBeReturnData()
        {
            // Arrange
            var id = "5f7b3b3b7f3b3b3b3b3b3b4b";

            // Act
            var result = await _vehicleRepository.FindById(id);

            // Assert
            Assert.Null(result);
        }

        private async Task ArrangeDataForFindById(string id)
        {
            // Arrange
            var vehicle = new Vehicle { Id = id, Make = "Ford", Model = "Focus", RentUserId = "5f7b3" };
            await _vehicleRepository.Add(vehicle);
        }
    }
}
