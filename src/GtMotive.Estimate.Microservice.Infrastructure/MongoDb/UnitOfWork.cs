using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    /// <summary>
    /// Unit Of Work. Should only be used by Use Cases.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IClientSessionHandle _session;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        /// <exception cref="ArgumentNullException">Thrown when options or mongoService is null.</exception>
        public UnitOfWork(IOptions<MongoDbSettings> options)
        {
            ArgumentNullException.ThrowIfNull(options);

            RegisterBsonClasses();

            var mongoClient = new MongoClient(options.Value.ConnectionString);
            Db = mongoClient.GetDatabase(options.Value.MongoDbDatabaseName);
            _session = Db.Client.StartSession();
        }

        public IMongoDatabase Db { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _session?.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// Register Bson classes.
        /// </summary>
        private static void RegisterBsonClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Vehicle)))
            {
                BsonClassMap.RegisterClassMap<Vehicle>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
