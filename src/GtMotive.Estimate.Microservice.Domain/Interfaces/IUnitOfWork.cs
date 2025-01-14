using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Unit Of Work. Should only be used by Use Cases.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the database.
        /// </summary>
        IMongoDatabase Db { get; }
    }
}
