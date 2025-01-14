using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    /// <summary>
    /// Fixture for MongoDB.
    /// </summary>
    public class MongoDbFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbFixture"/> class.
        /// </summary>
        public MongoDbFixture()
        {
            UnitOfWorkFixture = new UnitOfWork(new OptionsWrapper<MongoDbSettings>(new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                MongoDbDatabaseName = "IntegrationTestDb"
            }));
        }

        public IUnitOfWork UnitOfWorkFixture { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    UnitOfWorkFixture.Db.Client.DropDatabase("IntegrationTestDb");
                }

                // Dispose unmanaged resources (if any).
                _disposed = true;
            }
        }
    }
}
